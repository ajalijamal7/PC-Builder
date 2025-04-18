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
    public partial class employee_home: Form
    {
        public employee_home()
        {
            InitializeComponent();
        }

        public void LoadForm(Form formToLoad)
        {

            if (this.pnl_E_main.Tag is Form previousForm)
            {
                previousForm.Close();
                previousForm.Dispose();
            }

            if (formToLoad != null)
            {
                formToLoad.TopLevel = false;
                formToLoad.Dock = DockStyle.Fill;
                this.pnl_E_main.Controls.Clear();
                this.pnl_E_main.Controls.Add(formToLoad);
                this.pnl_E_main.Tag = formToLoad;
                formToLoad.Show();
            }
        }


        private void btn_profile_Click(object sender, EventArgs e)
        {
            LoadForm(new frm_profile());
        }


        private void employee_home_Load(object sender, EventArgs e)
        {
            LoadForm(new build_PC());
        }

     

        private void btn_settings_Click(object sender, EventArgs e)
        {
            LoadForm(new frm_settings());
        }

        private void btn_Logout_Click(object sender, EventArgs e)
        {
            yes_or_no_logout confirmlogout = new yes_or_no_logout(this);
            confirmlogout.ShowDialog();
        }

        private void pnl_E_main_Click(object sender, EventArgs e)
        {

        }

        private void btn_Build_PC_Click(object sender, EventArgs e)
        {
            LoadForm(new build_PC());
        }

        private void btn_Place_Order_Click(object sender, EventArgs e)
        {
            LoadForm(new Place_Order());
        }
    }
}
