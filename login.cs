using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace PC_Builder
{


    public partial class frm_Login : Form
    {
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["mydb"].ToString());
       

        public frm_Login()
        {
            InitializeComponent();
            //ThemeManager.ApplyTheme(this);
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void frm_Login_Load(object sender, EventArgs e)
        {

        }

  
        private void btn_login_Click(object sender, EventArgs e)
        {
            pnl_invalid_username.Visible = false;
            pnl_invalid_password.Visible = false;

            string username = txt_username.Text;
            string password = txt_Password.Text;


            string query = "SELECT ID, U_Password,First_Name,Last_Name,Phone FROM Users WHERE Company_Email = @Username AND U_Role LIKE 'Admin'";

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Username", username);
            if (con.State == ConnectionState.Closed)
                con.Open();

            SqlDataReader reader = cmd.ExecuteReader();


            if (reader.HasRows)
            {
                reader.Read();
                string storedPassword = reader["U_Password"].ToString();


                if (password == storedPassword)
                {
                    Name = "";
                    Session.LoggedInUser = new User
                    {

                        Name = reader["First_Name"].ToString() + " " + reader["Last_Name"].ToString(),
                        Email = username,
                        phone = reader["Phone"].ToString(),


                    };

                    this.Hide();
                    new frm_admin().Show();
                }
                else
                {
                    pnl_invalid_password.Show();
                }
            }

            else
            {
                pnl_invalid_username.Show();
            }

            reader.Close();

            if (con.State == ConnectionState.Open)
                con.Close();

        }






        private void txt_Password_TextChanged(object sender, EventArgs e)
        {

        }



        private void pic_pcbuilder_logo_Click(object sender, EventArgs e)
        {

        }

        private void btn_login_Employee_Click(object sender, EventArgs e)
        {


            pnl_invalid_username.Visible = false;
            pnl_invalid_password.Visible = false;

            string username = txt_username.Text;
            string password = txt_Password.Text;

            string query = "SELECT ID, U_Password, First_Name, Last_Name, Phone \r\nFROM Users \r\nWHERE Company_Email = @Username \r\n  AND (U_Role = 'Employee' OR U_Role = 'Admin')\r\n";

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Username", username);
            if (con.State == ConnectionState.Closed)
                con.Open();

            SqlDataReader reader = cmd.ExecuteReader();


            if (reader.HasRows)
            {
                reader.Read();
                string storedPassword = reader["U_Password"].ToString();





                if (password == storedPassword)
                {


                    Session.LoggedInUser = new User
                    {
                        Name = reader["First_Name"].ToString() + " " + reader["Last_Name"].ToString(),
                        Email = username,
                        phone = reader["Phone"].ToString(),


                    };

                    this.Hide();
                    new employee_home().Show();



                }
                else
                {
                    pnl_invalid_password.Show();
                }
            }

            else
            {
                pnl_invalid_username.Show();
            }

            reader.Close();

            if (con.State == ConnectionState.Open)
                con.Close();

        }
    }

}
