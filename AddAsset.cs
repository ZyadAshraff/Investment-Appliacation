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
        // Property to hold the asset created by the form
        public Asset CreatedAsset { get; private set; }

        // Constructor to initialize the form
        public AddAsset()
        {
            InitializeComponent();
        }

        // Method to validate user inputs in the form fields
        private bool ValidateInputs()
        {
            // Check if asset name is not empty or whitespace
            if (string.IsNullOrWhiteSpace(tb_AssetName.Text))
            {
                MessageBox.Show("Please enter an asset name.");
                return false;
            }

            // Check if value is a valid positive decimal number
            if (!decimal.TryParse(tb_value.Text, out decimal value) || value <= 0)
            {
                MessageBox.Show("Please enter a valid positive number for value.");
                return false;
            }

            // Duplicate check for asset name (can be removed or replaced)
            if (string.IsNullOrWhiteSpace(tb_AssetName.Text))
            {
                MessageBox.Show("Please enter an asset name.");
                return false;
            }

            return true;
        }

        // Event handler for the Save button click
        private void bt_save_Click(object sender, EventArgs e)
        {
            // Validate inputs before proceeding
            if (!ValidateInputs()) return;

            try
            {
                // Create a new Asset object with user inputs
                CreatedAsset = new Asset(
                    tb_AssetName.Text,
                    decimal.Parse(tb_value.Text),
                    new AssetType(
                        "Name", // Placeholder name for the asset type
                        true    // Example boolean flag
                    )
                );

                // Set dialog result to OK and close the form
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                // Show any exception message that occurs during asset creation
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        // Event handler for the Cancel button click
        private void bt_cancel_Click(object sender, EventArgs e)
        {
            // Set dialog result to Cancel and close the form
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        // Event handler for form load (currently not used)
        private void AddAsset_Load_1(object sender, EventArgs e)
        {

        }

        // Event handler for text change in a TextBox (currently not used)
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
