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
    /// <summary>
    /// Form for connecting to the bank system (placeholder implementation)
    /// </summary>
    public partial class ConnectToBankSystem : Form
    {
        /// <summary>
        /// Initializes a new ConnectToBankSystem form
        /// </summary>
        public ConnectToBankSystem()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the save button click
        /// </summary>
        private void btn_Save_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}