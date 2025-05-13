using System;
using System.Windows.Forms;
using System.Drawing;
using System.Reflection.Emit;

namespace InvestApp
{
    /// <summary>
    /// The main application form showing the user's investment portfolio
    /// </summary>
    public partial class MainForm : Form
    {
        private readonly User _currentUser;
        private Asset _selectedAsset;

        /// <summary>
        /// Handles selection changes in the assets DataGridView
        /// </summary>
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

        /// <summary>
        /// Creates a new MainForm for the specified user
        /// </summary>
        /// <param name="currentUser">The logged in user</param>
        public MainForm(User currentUser)
        {
            _currentUser = currentUser;

            InitializeComponent();
            InitializeDataGridView();
            LoadPortfolioData();
        }

        /// <summary>
        /// Loads the user's portfolio data from file
        /// </summary>
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

        /// <summary>
        /// Refreshes the portfolio display with current data
        /// </summary>
        private void RefreshPortfolio()
        {
            dgvAssets.DataSource = null;
            dgvAssets.DataSource = _currentUser.UserPortfolio.Assets;

            decimal totalValue = _currentUser.UserPortfolio.TotalValue;
            decimal totalZakat = _currentUser.UserPortfolio.TotalZakat;

            lblTotalValue.Text = $"Total Value: {totalValue:C}\nZakat Due: {totalZakat:C}";
        }

        /// <summary>
        /// Initializes the DataGridView settings
        /// </summary>
        private void InitializeDataGridView()
        {
            dgvAssets.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAssets.MultiSelect = false;
            dgvAssets.ReadOnly = true;

            dgvAssets.SelectionChanged += DgvAssets_SelectionChanged;
        }

        /// <summary>
        /// Handles the remove asset button click
        /// </summary>
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

        /// <summary>
        /// Handles the edit asset button click
        /// </summary>
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

        /// <summary>
        /// Handles the add asset button click
        /// </summary>
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

        /// <summary>
        /// Handles the connect to bank system button click
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            if (!chb_isconnected.Checked)
            {
                var Connect = new ConnectToBankSystem();
                Connect.ShowDialog();
                chb_isconnected.Checked = true;
            }
        }
    }
}