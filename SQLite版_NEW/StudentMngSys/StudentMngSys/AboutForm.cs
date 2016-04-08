using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TJWCommon;

namespace TJWForms
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
        }

        private void AboutForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormShowHideFx.HideFXCenter(this.Handle, 500);
        }

        private void AboutForm_Load(object sender, EventArgs e)
        {

        }

        protected override void OnLostFocus(EventArgs e)
        {
            this.Close();
        }
    }
}
