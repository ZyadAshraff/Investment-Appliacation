using System;
using System.Windows.Forms;
using System.Drawing;

namespace InvestApp
{
    /// <summary>
    /// Form for editing an existing asset
    /// </summary>
    public partial class EditAsset : Form
    {
        /// <summary>
        /// Gets the edited asset
        /// </summary>
        public Asset EditedAsset { get; }

        /// <summary>
        /// Creates a new EditAsset form for the specified asset
        /// </summary>
        /// <param name="assetToEdit">The asset to edit</param>
        public EditAsset(Asset assetToEdit)
        {
            InitializeComponent();
            EditedAsset = assetToEdit;
            SetupForm();
        }

        /// <summary>
        /// Sets up the form controls and layout
        /// </summary>
        private void SetupForm()
        {
            this.Text = "Edit Asset";
            this.Size = new Size(400, 350);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;
            this.MinimizeBox = false;
            this.MaximizeBox = false;

            var lblName = new Label { Text = "Asset Name:", Top = 20, Left = 20, Width = 100 };
            var txtName = new TextBox { Top = 20, Left = 130, Width = 200, Text = EditedAsset.Name };

            var lblPurchasePrice = new Label { Text = "Purchase Price:", Top = 60, Left = 20, Width = 100 };
            var lblPurchasePriceValue = new Label
            {
                Text = EditedAsset.PurchasePrice.ToString("N2"),
                Top = 60,
                Left = 130,
                Width = 200
            };

            var lblCurrentValue = new Label { Text = "Current Value:", Top = 100, Left = 20, Width = 100 };
            var numCurrentValue = new NumericUpDown
            {
                Top = 100,
                Left = 130,
                Width = 200,
                DecimalPlaces = 2,
                Minimum = 0,
                Maximum = decimal.MaxValue,
                Value = EditedAsset.CurrentValue
            };

            var lblDate = new Label { Text = "Acquisition Date:", Top = 140, Left = 20, Width = 100 };
            var lblDateValue = new Label
            {
                Text = EditedAsset.AcquisitionDate.ToShortDateString(),
                Top = 140,
                Left = 130,
                Width = 200
            };

            var lblType = new Label { Text = "Asset Type:", Top = 180, Left = 20, Width = 100 };
            var lblTypeValue = new Label
            {
                Text = EditedAsset.Type.ToString(),
                Top = 180,
                Left = 130,
                Width = 200
            };

            var lblZakatStatus = new Label
            {
                Text = "Zakat Status:",
                Top = 220,
                Left = 20,
                Width = 100
            };

            var lblZakatValue = new Label
            {
                Text = EditedAsset.CurrentValue >= 450000 ? "Applicable (≥ 450,000)" : "Not Applicable (< 450,000)",
                Top = 220,
                Left = 130,
                Width = 200,
                ForeColor = EditedAsset.CurrentValue >= 450000 ? Color.Green : Color.Red
            };

            var btnSave = new Button
            {
                Text = "Save Changes",
                DialogResult = DialogResult.OK,
                Top = 260,
                Left = 130,
                Width = 120
            };
            var btnCancel = new Button
            {
                Text = "Cancel",
                DialogResult = DialogResult.Cancel,
                Top = 260,
                Left = 260,
                Width = 100
            };

            numCurrentValue.ValueChanged += (sender, e) =>
            {
                bool isApplicable = numCurrentValue.Value >= 450000;
                lblZakatValue.Text = isApplicable ? "Applicable (≥ 450,000)" : "Not Applicable (< 450,000)";
                lblZakatValue.ForeColor = isApplicable ? Color.Green : Color.Red;
            };

            this.Controls.AddRange(new Control[] {
                lblName, txtName,
                lblPurchasePrice, lblPurchasePriceValue,
                lblCurrentValue, numCurrentValue,
                lblDate, lblDateValue,
                lblType, lblTypeValue,
                lblZakatStatus, lblZakatValue,
                btnSave, btnCancel
            });

            this.AcceptButton = btnSave;
            this.CancelButton = btnCancel;

            btnSave.Click += (sender, e) =>
            {
                if (!ValidateInputs(txtName.Text, numCurrentValue.Value))
                    return;
                bool isZakatApplicable = numCurrentValue.Value >= 450000;
                try
                {
                    EditedAsset.UpdateAsset(
                        txtName.Text,
                        numCurrentValue.Value,
                        isZakatApplicable
                    );
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error saving changes: {ex.Message}",
                                  "Error",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Error);
                }
            };
        }

        /// <summary>
        /// Validates the form inputs
        /// </summary>
        /// <param name="name">The asset name to validate</param>
        /// <param name="value">The asset value to validate</param>
        /// <returns>True if inputs are valid, false otherwise</returns>
        private bool ValidateInputs(string name, decimal value)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Asset name cannot be empty",
                              "Validation Error",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Warning);
                return false;
            }

            if (value <= 0)
            {
                MessageBox.Show("Current value must be positive",
                              "Validation Error",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
    }
}