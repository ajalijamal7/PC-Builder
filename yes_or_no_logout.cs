using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PC_Builder
{
    public partial class yes_or_no_logout : Form
    {
        private Form parentForm;

        public yes_or_no_logout(Form parentForm)
        {
            InitializeComponent();
            this.parentForm = parentForm;
        }

        private void btn_yes_Click(object sender, EventArgs e)
        {
            // Close or hide the parent form (admin or employee)
            parentForm.Hide();

            // Open the login form
            frm_Login loginform = new frm_Login();
            loginform.Show();

            // Close this confirmation dialog
            this.Close();
        }

        private void btn_no_Click(object sender, EventArgs e)
        {
            // Simply close the confirmation dialog
            this.Close();
        }

        private void yes_or_no_logout_Load(object sender, EventArgs e)
        {
            // Optional: Apply theme or focus settings
            // ThemeManager.ApplyTheme(this);
            this.AcceptButton = btn_yes;
            this.CancelButton = btn_no;
        }
    }
}
