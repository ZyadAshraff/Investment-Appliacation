namespace InvestApp
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.bt_addasset = new System.Windows.Forms.Button();
            this.dgvAssets = new System.Windows.Forms.DataGridView();
            this.assetsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblTotalValue = new System.Windows.Forms.Label();
            this.bt_removeasset = new System.Windows.Forms.Button();
            this.bt_editasset = new System.Windows.Forms.Button();
            this.assetsBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.chb_isconnected = new System.Windows.Forms.CheckBox();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.purchasePriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.currentValueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.acquisitionDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isZakatApplicableDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.zakatAmountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.assetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.portfolioBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.assetTypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAssets)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.assetsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.assetsBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.assetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.portfolioBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.assetTypeBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // bt_addasset
            // 
            this.bt_addasset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.bt_addasset.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_addasset.Location = new System.Drawing.Point(49, 308);
            this.bt_addasset.Name = "bt_addasset";
            this.bt_addasset.Size = new System.Drawing.Size(211, 54);
            this.bt_addasset.TabIndex = 0;
            this.bt_addasset.Text = "Add Asset";
            this.bt_addasset.UseVisualStyleBackColor = false;
            this.bt_addasset.Click += new System.EventHandler(this.bt_addasset_Click);
            // 
            // dgvAssets
            // 
            this.dgvAssets.AutoGenerateColumns = false;
            this.dgvAssets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAssets.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn,
            this.purchasePriceDataGridViewTextBoxColumn,
            this.currentValueDataGridViewTextBoxColumn,
            this.acquisitionDateDataGridViewTextBoxColumn,
            this.isZakatApplicableDataGridViewCheckBoxColumn,
            this.zakatAmountDataGridViewTextBoxColumn});
            this.dgvAssets.DataSource = this.assetBindingSource;
            this.dgvAssets.Location = new System.Drawing.Point(12, 12);
            this.dgvAssets.Name = "dgvAssets";
            this.dgvAssets.RowHeadersWidth = 51;
            this.dgvAssets.RowTemplate.Height = 24;
            this.dgvAssets.Size = new System.Drawing.Size(1102, 222);
            this.dgvAssets.TabIndex = 1;
            // 
            // assetsBindingSource
            // 
            this.assetsBindingSource.DataMember = "Assets";
            this.assetsBindingSource.DataSource = this.portfolioBindingSource;
            // 
            // lblTotalValue
            // 
            this.lblTotalValue.AutoSize = true;
            this.lblTotalValue.Location = new System.Drawing.Point(742, 272);
            this.lblTotalValue.Name = "lblTotalValue";
            this.lblTotalValue.Size = new System.Drawing.Size(44, 16);
            this.lblTotalValue.TabIndex = 2;
            this.lblTotalValue.Text = "label1";
            // 
            // bt_removeasset
            // 
            this.bt_removeasset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.bt_removeasset.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_removeasset.Location = new System.Drawing.Point(533, 308);
            this.bt_removeasset.Name = "bt_removeasset";
            this.bt_removeasset.Size = new System.Drawing.Size(211, 54);
            this.bt_removeasset.TabIndex = 4;
            this.bt_removeasset.Text = "Remove Asset";
            this.bt_removeasset.UseVisualStyleBackColor = false;
            this.bt_removeasset.Click += new System.EventHandler(this.bt_removeasset_Click);
            // 
            // bt_editasset
            // 
            this.bt_editasset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.bt_editasset.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_editasset.Location = new System.Drawing.Point(291, 308);
            this.bt_editasset.Name = "bt_editasset";
            this.bt_editasset.Size = new System.Drawing.Size(211, 54);
            this.bt_editasset.TabIndex = 5;
            this.bt_editasset.Text = "Edit Asset";
            this.bt_editasset.UseVisualStyleBackColor = false;
            this.bt_editasset.Click += new System.EventHandler(this.bt_editasset_Click);
            // 
            // assetsBindingSource1
            // 
            this.assetsBindingSource1.DataMember = "Assets";
            this.assetsBindingSource1.DataSource = this.portfolioBindingSource;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(864, 308);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(234, 54);
            this.button1.TabIndex = 6;
            this.button1.Text = "Connect To Bank";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // chb_isconnected
            // 
            this.chb_isconnected.AutoSize = true;
            this.chb_isconnected.Enabled = false;
            this.chb_isconnected.Location = new System.Drawing.Point(942, 272);
            this.chb_isconnected.Name = "chb_isconnected";
            this.chb_isconnected.Size = new System.Drawing.Size(104, 20);
            this.chb_isconnected.TabIndex = 7;
            this.chb_isconnected.Text = "IsConnected";
            this.chb_isconnected.UseVisualStyleBackColor = false;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Type";
            this.nameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.Width = 125;
            // 
            // purchasePriceDataGridViewTextBoxColumn
            // 
            this.purchasePriceDataGridViewTextBoxColumn.DataPropertyName = "PurchasePrice";
            this.purchasePriceDataGridViewTextBoxColumn.HeaderText = "PurchasePrice";
            this.purchasePriceDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.purchasePriceDataGridViewTextBoxColumn.Name = "purchasePriceDataGridViewTextBoxColumn";
            this.purchasePriceDataGridViewTextBoxColumn.ReadOnly = true;
            this.purchasePriceDataGridViewTextBoxColumn.Width = 125;
            // 
            // currentValueDataGridViewTextBoxColumn
            // 
            this.currentValueDataGridViewTextBoxColumn.DataPropertyName = "CurrentValue";
            this.currentValueDataGridViewTextBoxColumn.HeaderText = "CurrentValue";
            this.currentValueDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.currentValueDataGridViewTextBoxColumn.Name = "currentValueDataGridViewTextBoxColumn";
            this.currentValueDataGridViewTextBoxColumn.ReadOnly = true;
            this.currentValueDataGridViewTextBoxColumn.Width = 125;
            // 
            // acquisitionDateDataGridViewTextBoxColumn
            // 
            this.acquisitionDateDataGridViewTextBoxColumn.DataPropertyName = "AcquisitionDate";
            this.acquisitionDateDataGridViewTextBoxColumn.HeaderText = "AcquisitionDate";
            this.acquisitionDateDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.acquisitionDateDataGridViewTextBoxColumn.Name = "acquisitionDateDataGridViewTextBoxColumn";
            this.acquisitionDateDataGridViewTextBoxColumn.ReadOnly = true;
            this.acquisitionDateDataGridViewTextBoxColumn.Width = 125;
            // 
            // isZakatApplicableDataGridViewCheckBoxColumn
            // 
            this.isZakatApplicableDataGridViewCheckBoxColumn.DataPropertyName = "IsZakatApplicable";
            this.isZakatApplicableDataGridViewCheckBoxColumn.HeaderText = "IsZakatApplicable";
            this.isZakatApplicableDataGridViewCheckBoxColumn.MinimumWidth = 6;
            this.isZakatApplicableDataGridViewCheckBoxColumn.Name = "isZakatApplicableDataGridViewCheckBoxColumn";
            this.isZakatApplicableDataGridViewCheckBoxColumn.ReadOnly = true;
            this.isZakatApplicableDataGridViewCheckBoxColumn.Width = 125;
            // 
            // zakatAmountDataGridViewTextBoxColumn
            // 
            this.zakatAmountDataGridViewTextBoxColumn.DataPropertyName = "ZakatAmount";
            this.zakatAmountDataGridViewTextBoxColumn.HeaderText = "ZakatAmount";
            this.zakatAmountDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.zakatAmountDataGridViewTextBoxColumn.Name = "zakatAmountDataGridViewTextBoxColumn";
            this.zakatAmountDataGridViewTextBoxColumn.ReadOnly = true;
            this.zakatAmountDataGridViewTextBoxColumn.Width = 125;
            // 
            // assetBindingSource
            // 
            this.assetBindingSource.DataSource = typeof(InvestApp.Asset);
            // 
            // portfolioBindingSource
            // 
            this.portfolioBindingSource.DataSource = typeof(InvestApp.Portfolio);
            // 
            // assetTypeBindingSource
            // 
            this.assetTypeBindingSource.DataSource = typeof(InvestApp.AssetType);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1142, 450);
            this.Controls.Add(this.chb_isconnected);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.bt_editasset);
            this.Controls.Add(this.bt_removeasset);
            this.Controls.Add(this.lblTotalValue);
            this.Controls.Add(this.dgvAssets);
            this.Controls.Add(this.bt_addasset);
            this.Name = "MainForm";
            this.Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvAssets)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.assetsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.assetsBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.assetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.portfolioBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.assetTypeBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bt_addasset;
        private System.Windows.Forms.DataGridView dgvAssets;
        private System.Windows.Forms.BindingSource portfolioBindingSource;
        private System.Windows.Forms.BindingSource assetsBindingSource;
        private System.Windows.Forms.BindingSource assetTypeBindingSource;
        private System.Windows.Forms.Label lblTotalValue;
        private System.Windows.Forms.BindingSource assetBindingSource;
        private System.Windows.Forms.Button bt_removeasset;
        private System.Windows.Forms.Button bt_editasset;
        private System.Windows.Forms.BindingSource assetsBindingSource1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn purchasePriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn currentValueDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn acquisitionDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isZakatApplicableDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn zakatAmountDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox chb_isconnected;
    }
}