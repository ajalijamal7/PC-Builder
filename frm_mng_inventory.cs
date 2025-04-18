using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace PC_Builder
{
    public partial class frm_mng_inventory : Form
    {
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["mydb"].ToString());
        private string currentTable = "CPU";  // Default table

        public frm_mng_inventory()
        {
            InitializeComponent();
            dgv_Component.CellClick += dgv_Component_CellClick; // Connect the click event
        }

        private void frm_mng_inventory_Load(object sender, EventArgs e)
        {
            // Call loaddgv() initially to load CPU data
            loaddgv();
        }

        private void loaddgv()
        {
            try
            {
                txt_component_1.Text = "";
                txt_component_2.Text = "";
                txt_component_3.Text = "";
                txt_component_4.Text = "";
                txt_component_5.Text = "";
                txt_component_6.Text = "";
                txt_component_7.Text = "";
                txt_component_8.Text = "";
                txt_component_9.Text = "";
                txt_component_10.Text = "";
                txt_component_11.Text = "";
                RemoveDeleteButton();
                string query="";
                if (currentTable == "CPU")
                {
                    query = "SELECT * FROM CPU";
                }
                else if(currentTable=="GPU")
                {
                    query = "SELECT * FROM GPU";
                }
                else if (currentTable == "Motherboard")
                {
                    query = "SELECT * FROM Motherboard";
                }
                else if (currentTable == "PSU")
                {
                    query = "SELECT * FROM PSU";
                }
                else if (currentTable == "PC_Case")
                {
                    query = "SELECT * FROM PC_Case";
                }
                else if (currentTable == "RAM")
                {
                    query = "SELECT * FROM RAM";
                }
                else if (currentTable == "Storage")
                {
                    query = "SELECT * FROM Storage";
                }
                else if (currentTable=="Laptops")
                {
                    query = "SELECT * FROM Laptops";
                }else if (currentTable == "Accessories")
                {
                    query = "SELECT * FROM Accessories";
                }

                    SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                DataTable componentTable = new DataTable();
                adapter.Fill(componentTable);
                dgv_Component.DataSource = componentTable;

                AddDeleteButton(); 
            }
            catch (Exception)
            {
                MessageBox.Show("An Error has occurred. Try again later.");
            }
        }

        private void RemoveDeleteButton()
        {
            if (dgv_Component.Columns.Contains("btnDelete"))
            {
                dgv_Component.Columns.Remove("btnDelete");
            }
        }

        private void Appear()
        {
            pic_pcbuilder_logo.Visible = false;
            pic_Slogan.Visible = false;
            if (currentTable == "PSU")
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


                lbl_component_6.Visible = false;
                txt_component_6.Visible = false;
                lbl_component_7.Visible = false;
                txt_component_7.Visible = false;
                lbl_component_8.Visible = false;
                txt_component_8.Visible = false;
                lbl_component_9.Visible = false;
                txt_component_9.Visible = false;
                lbl_component_10.Visible = false;
                txt_component_10.Visible = false;
                lbl_component_11.Visible = false;
                txt_component_11.Visible = false;
                lbl_component_12.Visible = false;
                lbl_component_13.Visible = false;
            }

           

            if (currentTable == "RAM" || currentTable=="Accessories")
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
                lbl_component_7.Visible = false;
                txt_component_7.Visible = false;
                lbl_component_8.Visible = false;
                txt_component_8.Visible = false;
                lbl_component_9.Visible = false;
                txt_component_9.Visible = false;
                lbl_component_10.Visible = false;
                txt_component_10.Visible = false;
                lbl_component_11.Visible = false;
                txt_component_11.Visible = false;
                lbl_component_12.Visible = false;
                txt_component_12.Visible = false;
                lbl_component_13.Visible = false;
                txt_component_13.Visible = false;

            }
            else if (currentTable == "Custom_PC" || currentTable == "PC_Case" || currentTable == "Storage" || currentTable == "Users" ||currentTable == "CPU" || currentTable == "GPU")
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

                lbl_component_8.Visible = false;
                txt_component_8.Visible = false;
                lbl_component_9.Visible = false;
                txt_component_9.Visible = false;
                lbl_component_10.Visible = false;
                txt_component_10.Visible = false;
                lbl_component_11.Visible = false;
                txt_component_11.Visible = false;
                lbl_component_12.Visible = false;
                txt_component_12.Visible = false;
                lbl_component_13.Visible = false;
                txt_component_13.Visible = false;
            }
            else if (currentTable == "Motherboard")
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

                lbl_component_10.Visible = true;
                txt_component_10.Visible = true;
                lbl_component_11.Visible = true;
                txt_component_11.Visible = true;
                lbl_component_12.Visible = false;
                txt_component_12.Visible = false;
                lbl_component_13.Visible = false;
                txt_component_13.Visible = false;
            }
            else if (currentTable == "Laptops")
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

                lbl_component_10.Visible = true;
                txt_component_10.Visible = true;
                lbl_component_11.Visible = true;
                txt_component_11.Visible = true;
                lbl_component_12.Visible = true;
                txt_component_12.Visible = true;
                lbl_component_13.Visible = true;
                txt_component_13.Visible = true;
            }





                btn_add_component.Visible = true;
            dgv_Component.Visible = true;
        }






        private void AddDeleteButton()
        {
            // Prevent duplicate delete columns
             if(!dgv_Component.Columns.Contains("btnDelete"))
            {
                DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn();
                btnDelete.Name = "btnDelete";
                btnDelete.HeaderText = "";
                btnDelete.Text = "Delete";
                btnDelete.UseColumnTextForButtonValue = true;
                dgv_Component.Columns.Add(btnDelete);

                // Set delete button to be the first column
                btnDelete.DisplayIndex = dgv_Component.Columns.Count - 1;  // First column position
                
            }
        }

        private void dgv_Component_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Only run if the clicked cell is in the Delete column
                if (e.RowIndex >= 0 && dgv_Component.Columns[e.ColumnIndex].Name == "btnDelete")
                {
                    string componentName = dgv_Component.Rows[e.RowIndex].Cells[GetComponentNameColumn()].Value.ToString();
                    string tableName = currentTable;

                    DialogResult result = MessageBox.Show($"Are you sure you want to delete '{componentName}'?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            string query = $"DELETE FROM {tableName} WHERE {GetComponentNameColumn()} = @ComponentName";
                            SqlCommand cmd = new SqlCommand(query, con);
                            cmd.Parameters.AddWithValue("@ComponentName", componentName);

                            if (con.State == ConnectionState.Closed)
                                con.Open();

                            cmd.ExecuteNonQuery();

                            if (con.State == ConnectionState.Open)
                                con.Close();

                            MessageBox.Show($"{componentName} deleted successfully.");
                            loaddgv(); // Refresh the grid
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("An error occurred while deleting.");
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("An error occurred while deleting.");
            }
        }

       
        private string GetComponentNameColumn()
        {
            switch (currentTable)
            {
                case "CPU":
                    return "CPU_Name";
                case "GPU":
                    return "GPU_Name";
                case "Motherboard":
                    return "M_Name";
                case "PSU":
                    return "PSU_Name";
                case "PC_Case":
                    return "PC_Case_Name";
                case "RAM":
                    return "RAM_Name";
                case "Storage":
                    return "S_Name";
                case "Laptops":
                    return "Laptop_Name";
                case "Accessories":
                    return "Name";
                default:
                    throw new Exception("Unknown component table.");
            }
        }


        private void btn_add_component_Click(object sender, EventArgs e)
        {
            if (currentTable == "CPU")
            {
                try
                {

                    string insert_cpu = "INSERT INTO CPU VALUES (@CPU_Name, @CPU_Socket, @Max_Memory, @CPU_Power, @Price, @Quantity, @Warranty)";
                    SqlCommand command = new SqlCommand(insert_cpu, con);

                    command.Parameters.AddWithValue("@CPU_Name", txt_component_1.Text);
                    command.Parameters.AddWithValue("@CPU_Socket", txt_component_2.Text);
                    command.Parameters.AddWithValue("@Max_Memory", Int32.Parse(txt_component_3.Text));
                    command.Parameters.AddWithValue("@CPU_Power", Int32.Parse(txt_component_5.Text));
                    command.Parameters.AddWithValue("@Price", Double.Parse(txt_component_6.Text));
                    command.Parameters.AddWithValue("@Quantity", Int32.Parse(txt_component_7.Text));
                    command.Parameters.AddWithValue("@Warranty", Int32.Parse(txt_component_4.Text));

                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    command.ExecuteNonQuery();
                    DialogResult result = MessageBox.Show($"CPU Added Successfully", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Clear input fields after adding
                    txt_component_1.Text = "";
                    txt_component_2.Text = "";
                    txt_component_3.Text = "";
                    txt_component_4.Text = "";
                    txt_component_5.Text = "";
                    txt_component_6.Text = "";
                    txt_component_7.Text = "";
                    txt_component_8.Text = "";
                    txt_component_9.Text = "";
                    txt_component_10.Text = "";
                    txt_component_11.Text = "";



                    if (con.State == ConnectionState.Open)
                        con.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("An Error has occurred. Try Again Later.");
                } 
            }
            else if(currentTable == "GPU") {
                try
                {

                    string insert_gpu = "INSERT INTO GPU VALUES (@GPU_Name, @Lenght, @GPU_Power, @Price, @Quantity, @Warranty, @Color)";
                    SqlCommand command = new SqlCommand(insert_gpu, con);

                    command.Parameters.AddWithValue("@GPU_Name", txt_component_1.Text);
                    command.Parameters.AddWithValue("@Lenght", Int32.Parse(txt_component_2.Text));
                    command.Parameters.AddWithValue("@Color", (txt_component_3.Text));
                    command.Parameters.AddWithValue("@GPU_Power", Int32.Parse(txt_component_5.Text));
                    command.Parameters.AddWithValue("@Price", Double.Parse(txt_component_6.Text));
                    command.Parameters.AddWithValue("@Quantity", Int32.Parse(txt_component_7.Text));
                    command.Parameters.AddWithValue("@Warranty", Int32.Parse(txt_component_4.Text));

                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    command.ExecuteNonQuery();
                    DialogResult result = MessageBox.Show($"GPU Added Successfully", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Clear input fields after adding
                    txt_component_1.Text = "";
                    txt_component_2.Text = "";
                    txt_component_3.Text = "";
                    txt_component_4.Text = "";
                    txt_component_5.Text = "";
                    txt_component_6.Text = "";
                    txt_component_7.Text = "";
                    txt_component_8.Text = "";
                    txt_component_9.Text = "";
                    txt_component_10.Text = "";
                    txt_component_11.Text = "";

                    if (con.State == ConnectionState.Open)
                        con.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("An Error has occurred. Try Again Later.");
                }
            } else if (currentTable == "Motherboard")
                try
                {
                    {
                        string insert_motherboard = "INSERT INTO Motherboard VALUES (@M_Name, @M_Socket, @Memory_Type, @Memory_Slots,@HDD_Storage_Slots,@SSD_Storage_Slots,@Max_Memory,@Form_Factor,@Price, @Quantity, @Warranty)";
                        SqlCommand command = new SqlCommand(insert_motherboard, con);

                        command.Parameters.AddWithValue("@M_Name", txt_component_1.Text);
                        command.Parameters.AddWithValue("@M_Socket", txt_component_2.Text);
                        command.Parameters.AddWithValue("@Memory_Type", (txt_component_3.Text));
                        command.Parameters.AddWithValue("@Memory_Slots", Int32.Parse(txt_component_4.Text));
                        command.Parameters.AddWithValue("@HDD_Storage_Slots", Int32.Parse(txt_component_5.Text));
                        command.Parameters.AddWithValue("@SSD_Storage_Slots", Int32.Parse(txt_component_6.Text));
                        command.Parameters.AddWithValue("@Max_Memory", Int32.Parse(txt_component_7.Text));
                        command.Parameters.AddWithValue("@Form_Factor", txt_component_8.Text);
                        command.Parameters.AddWithValue("@Price", double.Parse(txt_component_9.Text));
                        command.Parameters.AddWithValue("@Quantity", Int32.Parse(txt_component_10.Text));
                        command.Parameters.AddWithValue("@Warranty", Int32.Parse(txt_component_11.Text));

                        if (con.State == ConnectionState.Closed)
                            con.Open();

                        command.ExecuteNonQuery();
                        DialogResult result = MessageBox.Show($"Motherboard Added Successfully", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Clear input fields after adding
                        txt_component_1.Text = "";
                        txt_component_2.Text = "";
                        txt_component_3.Text = "";
                        txt_component_4.Text = "";
                        txt_component_5.Text = "";
                        txt_component_6.Text = "";
                        txt_component_7.Text = "";
                        txt_component_8.Text = "";
                        txt_component_9.Text = "";
                        txt_component_10.Text = "";
                        txt_component_11.Text = "";

                        if (con.State == ConnectionState.Open)
                            con.Close();
                    }
                }
                catch (Exception)
                {

                    MessageBox.Show("An Error has occurred. Try Again Later.");
                }
            else if (currentTable == "PSU")
            {

                try
                {
                    string insert_motherboard = "INSERT INTO PSU VALUES (@PSU_Name, @Wattage, @Rate,@Price,@Quantity)";
                    SqlCommand command = new SqlCommand(insert_motherboard, con);
                    command.Parameters.AddWithValue("@PSU_Name", txt_component_1.Text);
                    command.Parameters.AddWithValue("@Wattage", txt_component_2.Text);
                    command.Parameters.AddWithValue("@Rate", txt_component_3.Text);
                    command.Parameters.AddWithValue("@Price", Int32.Parse(txt_component_4.Text));
                    command.Parameters.AddWithValue("@Quantity", Int32.Parse(txt_component_5.Text));
                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    command.ExecuteNonQuery();
                    DialogResult result = MessageBox.Show($"Power Supply Added Successfully", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Clear input fields after adding
                    txt_component_1.Text = "";
                    txt_component_2.Text = "";
                    txt_component_3.Text = "";
                    txt_component_4.Text = "";
                    txt_component_5.Text = "";
                    txt_component_6.Text = "";
                    txt_component_7.Text = "";
                    txt_component_8.Text = "";
                    txt_component_9.Text = "";
                    txt_component_10.Text = "";
                    txt_component_11.Text = "";

                    if (con.State == ConnectionState.Open)
                        con.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("An Error has occurred. Try Again Later.");
                }
            }
            else if (currentTable == "PC_Case")
            {
                try
                {
                    string insert_case = "INSERT INTO PC_Case VALUES (@PC_Case_Name, @Edition, @Form_Factor, @Max_Gpu_lenght, @Price, @Color, @Quantity)";
                    SqlCommand command = new SqlCommand(insert_case, con);

                    command.Parameters.AddWithValue("@PC_Case_Name", txt_component_1.Text);
                    command.Parameters.AddWithValue("@Edition", txt_component_2.Text);
                    command.Parameters.AddWithValue("@Form_Factor", txt_component_3.Text);
                    command.Parameters.AddWithValue("@Max_Gpu_lenght", double.Parse(txt_component_4.Text));
                    command.Parameters.AddWithValue("@Price", double.Parse(txt_component_5.Text));
                    command.Parameters.AddWithValue("@Color", txt_component_6.Text);
                    command.Parameters.AddWithValue("@Quantity", int.Parse(txt_component_7.Text));

                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    command.ExecuteNonQuery();
                    DialogResult result = MessageBox.Show($"PC Case Added Successfully", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Clear input fields after adding
                    txt_component_1.Text = "";
                    txt_component_2.Text = "";
                    txt_component_3.Text = "";
                    txt_component_4.Text = "";
                    txt_component_5.Text = "";
                    txt_component_6.Text = "";
                    txt_component_7.Text = "";
                    txt_component_8.Text = "";
                    txt_component_9.Text = "";
                    txt_component_10.Text = "";
                    txt_component_11.Text = "";

                    if (con.State == ConnectionState.Open)
                        con.Close();
                }
                catch (Exception)
                {

                    MessageBox.Show("An Error has occurred. Try Again Later.");
                }

            }else if (currentTable == "RAM")
            {
                string insert_ram = "INSERT INTO RAM VALUES (@RAM_Name, @RAM_Size, @Speed, @RAM_Type, @Price, @Quantity)";
                SqlCommand command = new SqlCommand(insert_ram, con);

                try
                {
                    command.Parameters.AddWithValue("@RAM_Name", txt_component_1.Text);
                    command.Parameters.AddWithValue("@RAM_Size", int.Parse(txt_component_2.Text));
                    command.Parameters.AddWithValue("@Speed", int.Parse(txt_component_3.Text));
                    command.Parameters.AddWithValue("@RAM_Type", txt_component_4.Text);
                    command.Parameters.AddWithValue("@Price", double.Parse(txt_component_5.Text));
                    command.Parameters.AddWithValue("@Quantity", int.Parse(txt_component_6.Text));
                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    command.ExecuteNonQuery();
                    DialogResult result = MessageBox.Show($"RAM Added Successfully", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Clear input fields after adding
            
                    txt_component_1.Text = "";
                    txt_component_2.Text = "";
                    txt_component_3.Text = "";
                    txt_component_4.Text = "";
                    txt_component_5.Text = "";
                    txt_component_6.Text = "";
       

                    if (con.State == ConnectionState.Open)
                        con.Close();
                }
                catch (Exception)
                {

                    MessageBox.Show("An Error has occurred. Try Again Later.");
                }

            }else if (currentTable == "Storage")
            {
                string insert_storage = "INSERT INTO Storage VALUES (@S_Name, @S_Type, @S_Size, @Read_Speed, @Write_Speed, @Price, @Quantity)";
                SqlCommand command = new SqlCommand(insert_storage, con);

                try
                {
                    command.Parameters.AddWithValue("@S_Name", txt_component_1.Text);
                    command.Parameters.AddWithValue("@S_Type", (txt_component_2.Text));
                    command.Parameters.AddWithValue("@S_Size", int.Parse(txt_component_3.Text));
                    command.Parameters.AddWithValue("@Read_Speed", int.Parse(txt_component_4.Text));
                    command.Parameters.AddWithValue("@Write_Speed", int.Parse(txt_component_5.Text));
                    command.Parameters.AddWithValue("@Price", double.Parse(txt_component_6.Text));
                    command.Parameters.AddWithValue("@Quantity", int.Parse(txt_component_7.Text));
                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    command.ExecuteNonQuery();
                    DialogResult result = MessageBox.Show($"Storage Added Successfully", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Clear input fields after adding

                    txt_component_1.Text = "";
                    txt_component_2.Text = "";
                    txt_component_3.Text = "";
                    txt_component_4.Text = "";
                    txt_component_5.Text = "";
                    txt_component_6.Text = "";
                    txt_component_7.Text = "";


                    if (con.State == ConnectionState.Open)
                        con.Close();
                }
                catch (Exception)
                {

                    MessageBox.Show("An Error has occurred. Try Again Later.");
                }
            }
            else if (currentTable == "Laptops")
            {
                string insert_Laptops = "INSERT INTO Laptops VALUES (@laptop_Name, @Brand, @Color, @CPU, @GPU, @Motherboard, @RAM,@Storage,@Storage_Type,@Quantity,@Warranty,@RAM_Type,@Price)";
                SqlCommand command = new SqlCommand(insert_Laptops, con);

                command.Parameters.AddWithValue("@laptop_Name", txt_component_1.Text);
                command.Parameters.AddWithValue("@Brand", txt_component_2.Text);
                command.Parameters.AddWithValue("@Color",txt_component_3.Text);
                command.Parameters.AddWithValue("@CPU", txt_component_4.Text);
                command.Parameters.AddWithValue("@GPU", txt_component_5.Text);
                command.Parameters.AddWithValue("@Motherboard",txt_component_6.Text);
                command.Parameters.AddWithValue("@RAM",int.Parse(txt_component_7.Text));
                command.Parameters.AddWithValue("@RAM_Type", txt_component_8.Text);
                command.Parameters.AddWithValue("@Storage",int.Parse(txt_component_9.Text));
                command.Parameters.AddWithValue("@Storage_Type", txt_component_10.Text);
                command.Parameters.AddWithValue("@Quantity", int.Parse(txt_component_11.Text));
                command.Parameters.AddWithValue("@Warranty", int.Parse(txt_component_12.Text));
                command.Parameters.AddWithValue("@Price", double.Parse(txt_component_13.Text));
                if (con.State == ConnectionState.Closed)
                    con.Open();

                command.ExecuteNonQuery();
                DialogResult result = MessageBox.Show($"Laptop Added Successfully", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Clear input fields after adding

                txt_component_1.Text = "";
                txt_component_2.Text = "";
                txt_component_3.Text = "";
                txt_component_4.Text = "";
                txt_component_5.Text = "";
                txt_component_6.Text = "";
                txt_component_7.Text = "";
                txt_component_8.Text = "";
                txt_component_9.Text = "";
                txt_component_10.Text = "";
                txt_component_11.Text = "";
                txt_component_12.Text = "";
                txt_component_13.Text = "";



                if (con.State == ConnectionState.Open)
                    con.Close();

            }
            else if (currentTable == "Accessories")
            {

                string insert_Accessories = "INSERT INTO Accessories VALUES (@Name, @Brand, @Type, @Color, @Quantity, @Price)";
                SqlCommand command = new SqlCommand(insert_Accessories, con);

                command.Parameters.AddWithValue("@Name", txt_component_1.Text);
                command.Parameters.AddWithValue("@Brand", txt_component_2.Text);
                command.Parameters.AddWithValue("@Type", txt_component_3.Text);
                command.Parameters.AddWithValue("@Color", txt_component_4.Text);
                command.Parameters.AddWithValue("@Quantity", txt_component_5.Text);
                command.Parameters.AddWithValue("@Price", txt_component_6.Text);
                if (con.State == ConnectionState.Closed)
                    con.Open();

                command.ExecuteNonQuery();
                DialogResult result = MessageBox.Show($"Accessories Added Successfully", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Clear input fields after adding

                txt_component_1.Text = "";
                txt_component_2.Text = "";
                txt_component_3.Text = "";
                txt_component_4.Text = "";
                txt_component_5.Text = "";
                txt_component_6.Text = "";
                txt_component_7.Text = "";
                txt_component_8.Text = "";
                txt_component_9.Text = "";
                txt_component_10.Text = "";
                txt_component_11.Text = "";
                txt_component_12.Text = "";
                txt_component_13.Text = "";



                if (con.State == ConnectionState.Open)
                    con.Close();


            }
            loaddgv(); // Refresh the grid
        }
      




        private void btn_GPU_Click(object sender, EventArgs e)
        {
            lbl_component_1.Text = "GPU Name";
            lbl_component_2.Text = "GPU Length";
            lbl_component_3.Text = "GPU Color";
            lbl_component_4.Text = "GPU Warranty";
            lbl_component_5.Text = "GPU Power";
            lbl_component_6.Text = "GPU Price";
            lbl_component_7.Text = "GPU Quantity";
            currentTable = "GPU";  // Switch to GPU
            Appear();
            loaddgv();
        }

        private void btn_CPU_Click(object sender, EventArgs e)
        {
            lbl_component_1.Text = "CPU Name";
            lbl_component_2.Text = "CPU Socket";
            lbl_component_3.Text = "MAX Memory";
            lbl_component_4.Text = "CPU Warranty";
            lbl_component_5.Text = "CPU Power";
            lbl_component_6.Text = "CPU Price";
            lbl_component_7.Text = "CPU Quantity";
            currentTable = "CPU";  // Switch to CPU
            Appear();
            loaddgv();
        }

        // Optional: These are default event handlers, you can remove if not used
        private void bunifuLabel4_Click(object sender, EventArgs e) { }
        private void panel1_Paint(object sender, PaintEventArgs e) { }
        private void bunifuDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

        private void btn_Motherboard_Click(object sender, EventArgs e)
        {

            lbl_component_1.Text = "Motherboard Name";
            lbl_component_2.Text = "Motherboard Socket";
            lbl_component_3.Text = "Memory Type";
            lbl_component_4.Text = "Memory Slots";
            lbl_component_5.Text = "HDD Storage Slots";
            lbl_component_6.Text = "SSD Storage Slots";
            lbl_component_7.Text = "Max_Memory";
            lbl_component_8.Text = "Form Factor";
            lbl_component_9.Text = "Price ($)";
            lbl_component_10.Text = "Quantity";
            lbl_component_11.Text = "Warranty";

            currentTable = "Motherboard";
            Appear();
            loaddgv();
        }

        private void txt_component_7_TextChanged(object sender, EventArgs e)
        {

        }


        private void bunifuTextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_Power_Supply_Click(object sender, EventArgs e)
        {
            lbl_component_1.Text = "PSU Name";
            lbl_component_2.Text = "Wattage (Watt)";
            lbl_component_3.Text = "Rate (Bronze,Silver,Gold,Platinum)";
            lbl_component_4.Text = "Price ($)";
            lbl_component_5.Text = "Quantity";


            currentTable = "PSU";
            Appear();
            loaddgv();
        }

        private void bunifuSeparator1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuSeparator3_Click(object sender, EventArgs e)
        {

        }

        private void btn_PC_Case_Click(object sender, EventArgs e)
        {
            lbl_component_1.Text = "PC Case Name";
            lbl_component_2.Text = "Edition";
            lbl_component_3.Text = "Form Factor";
            lbl_component_4.Text = "Max GPU Length";
            lbl_component_5.Text = "Price";
            lbl_component_6.Text = "Color";
            lbl_component_7.Text = "Quantity";
            
            currentTable = "PC_Case";
            Appear();
            loaddgv();
        }

        private void btn_Memory_Click(object sender, EventArgs e)
        {
            
            lbl_component_1.Text = "RAM Name";
            lbl_component_2.Text = "RAM Size";
            lbl_component_3.Text = "Speed";
            lbl_component_4.Text = "RAM Type";
            lbl_component_5.Text = "Price";
            lbl_component_6.Text = "Quantity";
            currentTable = "RAM";
            Appear();
            loaddgv();

        }

        private void btn_Storage_Click(object sender, EventArgs e)
        {
            lbl_component_1.Text = "Storage Name";
            lbl_component_2.Text = "Storage Type";
            lbl_component_3.Text = "Storage Size";
            lbl_component_4.Text = "Read Speed";
            lbl_component_5.Text = "Write Speed";
            lbl_component_6.Text = "Price";
            lbl_component_7.Text = "Quantity";
            currentTable = "Storage";
            Appear();
            loaddgv();
        }

        private void Manage_Laptops_Click(object sender, EventArgs e)
        {
            lbl_component_1.Text = "Laptop Name";
            lbl_component_2.Text = "Brand";
            lbl_component_3.Text = "Color";
            lbl_component_4.Text = "CPU";
            lbl_component_5.Text = "GPU";
            lbl_component_6.Text = "Motherboard";
            lbl_component_7.Text = "RAM";
            lbl_component_8.Text = "RAM Type";
            lbl_component_9.Text = "Storage";
            lbl_component_10.Text = "Storage Type";
            lbl_component_11.Text = "Quantity";
            lbl_component_12.Text = "Warranty";
            lbl_component_13.Text = "Price($)";
            currentTable = "Laptops";
            Appear();
            loaddgv();

            
        }

        private void Manage_Accessories_Click(object sender, EventArgs e)
        {
            lbl_component_1.Text = "Name";
            lbl_component_2.Text = "Brand";
            lbl_component_3.Text = "Type";
            lbl_component_4.Text = "Color";
            lbl_component_5.Text = "Quantity";
            lbl_component_6.Text = "Price";
            currentTable = "Accessories";

            Appear();
            loaddgv();
        }

        private void lbl_Component_12_Click(object sender, EventArgs e)
        {

        }
    }
}
