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
    public partial class frm_profile: Form
    {
        public frm_profile()
        {
            InitializeComponent();
            //ThemeManager.ApplyTheme(this);
            txt_Full_Name.Text = Session.LoggedInUser.Name;
            txt_Email.Text = Session.LoggedInUser.Email;
            txt_Phone.Text = Session.LoggedInUser.phone;

        }

        private void bunifuLabel3_Click(object sender, EventArgs e)
        {

        }

        private void frm_profile_Load(object sender, EventArgs e)
        {
            

        }

        private void bunifuLabel1_Click(object sender, EventArgs e)
        {

        }

        private void txt_Full_Name_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
