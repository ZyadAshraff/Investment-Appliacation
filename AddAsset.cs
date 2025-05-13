using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InvestApp
{
    public partial class AddAsset : Form
    {
        public Asset CreatedAsset { get; private set; }
        public AddAsset()
        {
            InitializeComponent();
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(tb_AssetName.Text))
            {
                MessageBox.Show("Please enter an asset name.");
                return false;
            }

            if (!decimal.TryParse(tb_value.Text, out decimal value) || value <= 0)
            {
                MessageBox.Show("Please enter a valid positive number for value.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(tb_AssetName.Text))
            {
                MessageBox.Show("Please enter an asset name.");
                return false;
            }

            return true;
        }

        private void bt_save_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            try
            {
                CreatedAsset = new Asset(
                    tb_AssetName.Text,
                    decimal.Parse(tb_value.Text),
                    new AssetType(
                        "Name",
                        true
                        
                    )
                );

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void bt_cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void AddAsset_Load_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
