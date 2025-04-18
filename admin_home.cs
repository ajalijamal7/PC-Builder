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
    public partial class frm_admin: Form
    {

        


        public frm_admin()
        {
            InitializeComponent();
            //ThemeManager.ApplyTheme(this);
           
        }

        public void LoadForm(Form formToLoad)
        {
           
            if (this.pnl_A_main.Tag is Form previousForm)
            {
                previousForm.Close();
                previousForm.Dispose();
            }

            if (formToLoad != null)
            {
                formToLoad.TopLevel = false;
                formToLoad.Dock = DockStyle.Fill;
                this.pnl_A_main.Controls.Clear(); 
                this.pnl_A_main.Controls.Add(formToLoad);
                this.pnl_A_main.Tag = formToLoad;
                formToLoad.Show();
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
            
        }


       


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Pnl_left_Admin_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btn_Analytics_Click(object sender, EventArgs e)
        {
            LoadForm(new frm_analytics());
        }
  
        private void btn_mng_inventory_Click(object sender, EventArgs e)
        {
            LoadForm(new frm_mng_inventory());
        }

        private void btn_Logout_Click(object sender, EventArgs e)
        {
            yes_or_no_logout confirmlogout = new yes_or_no_logout(this);
            confirmlogout.ShowDialog();
        }

        private void btn_profile_Click(object sender, EventArgs e)
        {
            LoadForm(new frm_profile());
        }

        private void btn_mng_employees_Click(object sender, EventArgs e)
        {
            LoadForm(new frm_mng_employees());
        }

        private void btn_settings_Click(object sender, EventArgs e)
        {
            LoadForm(new frm_settings());
        }

        private void btn_Dashboard_Click(object sender, EventArgs e)
        {
           
        }

        private void btn_Place_order_Click(object sender, EventArgs e)
        {
            LoadForm(new build_PC());
        }

        private void btn_Place_Order_Click_1(object sender, EventArgs e)
        {
            LoadForm(new Place_Order());
        }
    }
}
