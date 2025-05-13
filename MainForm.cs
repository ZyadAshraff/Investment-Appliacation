using System;
using System.Windows.Forms;
using System.Drawing;
using System.Reflection.Emit;

namespace InvestApp
{
    public partial class MainForm : Form
    {
        private readonly User _currentUser;
        private Asset _selectedAsset;
        private void DgvAssets_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvAssets.SelectedRows.Count > 0)
            {
                _selectedAsset = (Asset)dgvAssets.SelectedRows[0].DataBoundItem;

                bt_removeasset.Enabled = true;
                bt_editasset.Enabled = true;
            }
            else
            {
                _selectedAsset = null;
                bt_removeasset.Enabled = false;
                bt_editasset.Enabled = false;
            }
        }

        public MainForm(User currentUser)
        {
            _currentUser = currentUser;

            InitializeComponent();
            InitializeDataGridView();
            LoadPortfolioData();
        }


        private void LoadPortfolioData()
        {
            try
            {
                _currentUser.UserPortfolio.LoadFromFile();
                RefreshPortfolio();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading portfolio: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshPortfolio()
        {
            dgvAssets.DataSource = null;
            dgvAssets.DataSource = _currentUser.UserPortfolio.Assets;

            decimal totalValue = _currentUser.UserPortfolio.TotalValue;
            decimal totalZakat = _currentUser.UserPortfolio.TotalZakat;

            lblTotalValue.Text = $"Total Value: {totalValue:C}\nZakat Due: {totalZakat:C}";
        }

        private void InitializeDataGridView()
        {
            dgvAssets.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAssets.MultiSelect = false;
            dgvAssets.ReadOnly = true;

            dgvAssets.SelectionChanged += DgvAssets_SelectionChanged;
        }

        private void bt_removeasset_Click(object sender, EventArgs e)
        {
            if (_selectedAsset == null) return;

            var confirm = MessageBox.Show($"Delete {_selectedAsset.Name}?",
                                         "Confirm Delete",
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                _currentUser.UserPortfolio.RemoveAsset(_selectedAsset.Id);
                RefreshPortfolio();
                MessageBox.Show("Asset deleted successfully!", "Success",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void bt_editasset_Click(object sender, EventArgs e)
        {
            if (_selectedAsset == null) return;

            using (var editForm = new EditAsset(_selectedAsset))
            {
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    _currentUser.UserPortfolio.SaveToFile();
                    RefreshPortfolio();
                    MessageBox.Show("Asset updated successfully!", "Success",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void bt_addasset_Click(object sender, EventArgs e)
        {
            using (var addForm = new AddAsset())
            {
                if (addForm.ShowDialog() == DialogResult.OK && addForm.CreatedAsset != null)
                {
                    _currentUser.UserPortfolio.AddAsset(addForm.CreatedAsset);
                    RefreshPortfolio();
                    MessageBox.Show("Asset added successfully!", "Success",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(!chb_isconnected.Checked)
            {
                var Connect = new ConnectToBankSystem();
                Connect.ShowDialog();
                chb_isconnected.Checked = true;
            }
        }
    }
}