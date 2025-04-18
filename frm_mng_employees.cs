using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PC_Builder
{
    public partial class frm_mng_employees: Form
    {
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["mydb"].ToString());
        private string currentTable = "";
        public frm_mng_employees()
        {
            InitializeComponent();
            dgv_Users.CellClick += dgv_Users_CellClick;
        }

        private void loaddgv()
        {

            try
            {


                pic_pcbuilder_logo.Visible = false;
                pic_Slogan.Visible = false;
                txt_component_1.Text = "";
                txt_component_2.Text = "";
                txt_component_3.Text = "";
                txt_component_4.Text = "";
                txt_component_5.Text = "";
                txt_component_6.Text = "";
              
                txt_component_8.Text = "";
                txt_component_9.Text = "";

                RemoveDeleteButton();


                string query;



                if (currentTable == "Customer")
                {
                    query = "SELECT ID,First_Name, Last_Name, Phone FROM Users WHERE U_Role LIKE 'Customer'";
                }
                else if (currentTable == "Employee")
                {
                    query = "SELECT * FROM Users WHERE U_Role LIKE 'Employee'";
                }
                else query = "SELECT * FROM Users WHERE U_Role LIKE 'Admin'";


                SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                DataTable User_Table = new DataTable();
                adapter.Fill(User_Table);
                dgv_Users.DataSource = User_Table;
                AddDeleteButton();
            }
            catch (Exception)
            {

                MessageBox.Show("An Error has occurred. Try again later.");
            }
        }

        private void Appear()
        {
            if(currentTable=="Employee" || currentTable == "Admin")
            {
                lbl_component_1.Visible = true;
                lbl_component_3.Visible = true;
                lbl_component_5.Visible = true;
                lbl_component_2.Visible = true;
                lbl_component_4.Visible = true;

                txt_component_1.Visible = true;
                txt_component_3.Visible = true;
                txt_component_5.Visible = true;
                txt_component_2.Visible = true;
                txt_component_4.Visible = true;
                lbl_component_6.Visible = true;
                txt_component_6.Visible = true;

                lbl_component_7.Visible = true;
                txt_component_7.Visible = true;

                lbl_component_8.Visible = true;
                txt_component_8.Visible = true;

                lbl_component_9.Visible = true;
                txt_component_9.Visible = true;

                btn_add_User.Visible = true;

            }
            else
            {
                lbl_component_1.Visible = true;
                lbl_component_3.Visible = true;
                lbl_component_5.Visible = false;
                lbl_component_2.Visible = true;
                lbl_component_4.Visible = false;

                txt_component_1.Visible = true;
                txt_component_3.Visible = true;
                txt_component_5.Visible = false; ;
                txt_component_2.Visible = true;
                txt_component_4.Visible = false;
                lbl_component_6.Visible = false;
                txt_component_6.Visible = false;

                lbl_component_7.Visible = false;
                txt_component_7.Visible = false;

                lbl_component_8.Visible = false;
                txt_component_8.Visible = false;

                lbl_component_9.Visible = false;
                txt_component_9.Visible = false;

                btn_add_User.Visible =true;
            }
            dgv_Users.Visible = true;
        }


        private void dgv_Users_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Only run if the clicked cell is in the Delete column
                if (e.RowIndex >= 0 && dgv_Users.Columns[e.ColumnIndex].Name == "btnDelete")
                {
                    // Get the ID value for the selected row
                    int userId = Convert.ToInt32(dgv_Users.Rows[e.RowIndex].Cells["ID"].Value); // Use the "ID" column as the unique identifier

                    DialogResult result = MessageBox.Show($"Are you sure you want to delete the user with ID '{userId}'?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            string query = "DELETE FROM Users WHERE ID = @UserId"; // Use ID column to delete the record
                            SqlCommand cmd = new SqlCommand(query, con);
                            cmd.Parameters.AddWithValue("@UserId", userId); // Pass the User ID for deletion

                            if (con.State == ConnectionState.Closed)
                                con.Open();

                            cmd.ExecuteNonQuery();

                            if (con.State == ConnectionState.Open)
                                con.Close();

                            MessageBox.Show($"User with ID {userId} deleted successfully.");
                            loaddgv(); // Refresh the grid
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"An error occurred while deleting: {ex.Message}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while deleting: {ex.Message}");
            }
        }

        private void AddDeleteButton()
        {
            // Prevent duplicate delete columns 
             if(!dgv_Users.Columns.Contains("btnDelete"))
            {
                DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn();
                btnDelete.Name = "btnDelete";
                btnDelete.HeaderText = "";
                btnDelete.Text = "Delete";
                btnDelete.UseColumnTextForButtonValue = true;
                dgv_Users.Columns.Add(btnDelete);

                // Set delete button to be the first column
                btnDelete.DisplayIndex = dgv_Users.Columns.Count - 1;  // First column position
                
            }
        }




        private void RemoveDeleteButton()
        {
            if (dgv_Users.Columns.Contains("btnDelete"))
            {
                dgv_Users.Columns.Remove("btnDelete");
            }
        }
        private void txt_Full_Name_TextChanged(object sender, EventArgs e)
        {

        }

        private void frm_mng_employees_Load(object sender, EventArgs e)
        {

        }

        private void bunifuDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bunifuSeparator3_Click(object sender, EventArgs e)
        {

        }

        private void dgv_Component_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_mng_Admin_Click(object sender, EventArgs e)
        {
            currentTable = "Admin";
            Appear();
            loaddgv();
            txt_component_7.Text = "Admin";
        }

        private void btn_add_User_Click(object sender, EventArgs e)
        {
            if (currentTable == "Employee" || currentTable == "Admin")
            {

                try
                {

                    string insert_user = "INSERT INTO Users VALUES (@First_Name, @Last_Name, @Email, @Company_Email, @U_Password, @Phone, @U_Role, @Birthdate, @Salary)";
                    SqlCommand command = new SqlCommand(insert_user, con);

                    command.Parameters.AddWithValue("@First_Name", txt_component_1.Text);
                    command.Parameters.AddWithValue("@Last_Name", txt_component_2.Text);
                    command.Parameters.AddWithValue("@Email", txt_component_3.Text);
                    command.Parameters.AddWithValue("@Company_Email", txt_component_4.Text);
                    command.Parameters.AddWithValue("@U_Password", txt_component_5.Text);
                    command.Parameters.AddWithValue("@Phone", txt_component_6.Text);
                    command.Parameters.AddWithValue("@U_Role", txt_component_7.Text);
                    command.Parameters.AddWithValue("@Birthdate", txt_component_8.Text);
                    command.Parameters.AddWithValue("@Salary", Double.Parse(txt_component_9.Text));


                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    command.ExecuteNonQuery();
                    DialogResult result = MessageBox.Show($"User Added Successfully", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Clear input fields after adding


                    if (con.State == ConnectionState.Open)
                        con.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("An Error has occurred. Try Again Later.");
                }
            }else if (currentTable == "Customer")
            {
                try
                {

                    string insert_user = "INSERT INTO Users VALUES (@First_Name, @Last_Name, @Email, @Company_Email, @U_Password, @Phone, @U_Role, @Birthdate, @Salary)";
                    SqlCommand command = new SqlCommand(insert_user, con);

                    command.Parameters.AddWithValue("@First_Name", txt_component_1.Text);
                    command.Parameters.AddWithValue("@Last_Name", txt_component_2.Text);
                    command.Parameters.AddWithValue("@Email", DBNull.Value);
                    command.Parameters.AddWithValue("@Company_Email", DBNull.Value);
                    command.Parameters.AddWithValue("@U_Password", DBNull.Value);
                    command.Parameters.AddWithValue("@Phone", txt_component_3.Text);
                    command.Parameters.AddWithValue("@U_Role", "Customer");
                    command.Parameters.AddWithValue("@Birthdate", DBNull.Value);
                    command.Parameters.AddWithValue("@Salary", DBNull.Value);


                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    command.ExecuteNonQuery();
                    DialogResult result = MessageBox.Show($"User Added Successfully", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Clear input fields after adding


                    if (con.State == ConnectionState.Open)
                        con.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("An Error has occurred. Try Again Later.");
                }
            }
                loaddgv();
        }

        private void bunifuPanel1_Click(object sender, EventArgs e)
        {

        }

        private void btn_mng_empoyee_Click(object sender, EventArgs e)
        {
            currentTable = "Employee";
            Appear();
            loaddgv();
            txt_component_7.Text = "Employee";
        }

        private void btn_View_Customer_Click(object sender, EventArgs e)
        {
            lbl_component_3.Text="Phone";
            currentTable = "Customer";
            Appear();
            loaddgv();
        }
    }
}
