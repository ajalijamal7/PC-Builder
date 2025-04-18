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
using System.Configuration;
using static PC_Builder.mydb;

namespace PC_Builder
{
    public partial class Place_Order : Form
    {
        decimal Price;
        int Quantity;
        string TYPE;


        public Place_Order()
        {

            InitializeComponent();
            dgv_Ticket.CellClick += dgv_Ticket_CellClick; // Connect the click event
        }
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["mydb"].ToString());
        private string currentTable = "";


        private void Appear()
        {
            pic_pcbuilder_logo.Visible = false;
            pic_Slogan.Visible = false;

            lbl_component_1.Visible = true;
            lbl_component_2.Visible = true;
            lbl_component_3.Visible = true;

            txt_component_1.Visible = true;
            txt_component_2.Visible = true;
            txt_component_3.Visible = true;

            dgv_Component.Visible = true;
            dgv_Ticket.Visible = true;




        }



        private void loadTicket()
        {
            RemoveDeleteButton();
            string query = "SELECT * FROM O_Ticket";

            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            DataTable componentTable = new DataTable();
            adapter.Fill(componentTable);
            dgv_Ticket.DataSource = componentTable;
            AddDeleteButton();
        }





        private void loaddrp()
        {
            string query = "";
            // Select query based on the currentTable value
            switch (currentTable)
            {
                case "CPU":
                    query = "SELECT * FROM CPU";
                    break;
                case "GPU":
                    query = "SELECT * FROM GPU";
                    break;
                case "Motherboard":
                    query = "SELECT * FROM Motherboard";
                    break;
                case "PSU":
                    query = "SELECT * FROM PSU";
                    break;
                case "PC_Case":
                    query = "SELECT * FROM PC_Case";
                    break;
                case "RAM":
                    query = "SELECT * FROM RAM";
                    break;
                case "Storage":
                    query = "SELECT * FROM Storage";
                    break;
                case "Laptops":
                    query = "SELECT * FROM Laptops";
                    break;
                case "Accessories":
                    query = "SELECT * FROM Accessories";
                    break;
                default:
                    MessageBox.Show("Invalid product type selected.");
                    return;
            }

            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                DataTable componentTable = new DataTable();
                adapter.Fill(componentTable);
                drp_Order.DataSource = componentTable;

                // Set DisplayMember and ValueMember dynamically based on the selected table
                switch (currentTable)
                {
                    case "CPU":
                        drp_Order.DisplayMember = "CPU_Name";
                        drp_Order.ValueMember = "CPU_Name";
                        break;
                    case "GPU":
                        drp_Order.DisplayMember = "GPU_Name";
                        drp_Order.ValueMember = "GPU_Name";
                        break;
                    case "Motherboard":
                        drp_Order.DisplayMember = "M_Name";
                        drp_Order.ValueMember = "M_Name";
                        break;
                    case "PSU":
                        drp_Order.DisplayMember = "PSU_Name";
                        drp_Order.ValueMember = "ID";
                        break;
                    case "PC_Case":
                        drp_Order.DisplayMember = "PC_Case_Name";
                        drp_Order.ValueMember = "ID";
                        break;
                    case "RAM":
                        drp_Order.DisplayMember = "RAM_Name";
                        drp_Order.ValueMember = "ID";
                        break;
                    case "Storage":
                        drp_Order.DisplayMember = "S_Name";
                        drp_Order.ValueMember = "ID";
                        break;
                    case "Laptops":
                        drp_Order.DisplayMember = "laptop_Name";
                        drp_Order.ValueMember = "ID";
                        break;
                    case "Accessories":
                        drp_Order.DisplayMember = "Name";
                        drp_Order.ValueMember = "ID";
                        break;


                    default:
                        MessageBox.Show("Invalid product type selected.");
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading products: " + ex.Message);
            }
        }






        private void loaddgv()
        {
            try
            {
                Appear();
                string query = "";
                string idColumn = ""; // For WHERE condition
                bool useName = false;

                if (currentTable == "CPU")
                {
                    query = $"SELECT * FROM CPU WHERE CPU_Name = @value";
                    idColumn = "CPU_Name";
                    useName = true;
                }
                else if (currentTable == "GPU")
                {
                    query = $"SELECT * FROM GPU WHERE GPU_Name = @value";
                    idColumn = "GPU_Name";
                    useName = true;
                }
                else if (currentTable == "Motherboard")
                {
                    query = $"SELECT * FROM Motherboard WHERE M_Name = @value";
                    idColumn = "M_Name";
                    useName = true;
                }
                else if (currentTable == "Laptops")
                {
                    query = "SELECT * FROM Laptops WHERE ID = @value";
                    idColumn = "ID";
                    useName = false;
                }
                else
                {
                    query = $"SELECT * FROM {currentTable} WHERE ID = @value";
                    idColumn = "ID";
                }

                SqlCommand cmd = new SqlCommand(query, con);

                // ====== MODIFIED SECTION ======
                object selectedValue = drp_Order.SelectedValue;

                if (selectedValue is DataRowView drv)
                {
                    // Get the actual value from the row
                    selectedValue = useName ? drv[idColumn] : drv["ID"];
                }

                if (useName)
                {
                    cmd.Parameters.AddWithValue("@value", selectedValue.ToString());
                }
                else
                {
                    try
                    {
                        // Safely convert to int
                        if (int.TryParse(selectedValue.ToString(), out int intValue))
                        {
                            cmd.Parameters.AddWithValue("@value", intValue);
                        }
                        else
                        {
                            MessageBox.Show("Invalid ID value selected");
                            return;
                        }
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
                // ====== END MODIFIED SECTION ======

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable componentTable = new DataTable();
                adapter.Fill(componentTable);
                dgv_Component.DataSource = componentTable;

                if (componentTable.Rows.Count == 1)
                {
                    DataRow row = componentTable.Rows[0];

                    // Try-catch to handle conversion safely
                    try
                    {
                        Price = Convert.ToDecimal(row["Price"]);
                    }
                    catch (Exception ex)
                    {
                      
                        MessageBox.Show($"Error: {ex.Message}");
                    }

                    try
                    {
                        Quantity = Convert.ToInt32(row["Quantity"]);
                    }
                    catch
                    {
                        Quantity = 0;
                    }

                    if (currentTable == "Accessories")
                    {
                        try
                        {
                            TYPE = row["Type"].ToString();
                        }
                        catch
                        {
                            // Handle exception if needed
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}\n\nStack Trace: {ex.StackTrace}");
                // Or log to a file:

            }
        }


        private void AddDeleteButton()
        {
            // Prevent duplicate delete columns
            // Check if the delete column already exists
            if (dgv_Ticket.Columns["btnDelete"] == null)
            {
                DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn();
                btnDelete.Name = "btnDelete";
                btnDelete.HeaderText = "";
                btnDelete.Text = "Delete";
                btnDelete.UseColumnTextForButtonValue = true;

                // Add the column to the DataGridView
                dgv_Ticket.Columns.Add(btnDelete);

                // Set as first column
                btnDelete.DisplayIndex = dgv_Ticket.Columns.Count - 1;
            }
        }


        private void dgv_Ticket_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && dgv_Ticket.Columns[e.ColumnIndex].Name == "btnDelete")
                {
                    // Get all row data
                    DataGridViewRow row = dgv_Ticket.Rows[e.RowIndex];
                    int TicketID = Convert.ToInt32(row.Cells["ID"].Value);
                    string itemName = row.Cells["Item_Name"].Value?.ToString();
                    string itemType = row.Cells["Item_Type"].Value?.ToString();
                    int orderQuantity = Convert.ToInt32(row.Cells["Quantity"].Value);

                    if (string.IsNullOrEmpty(itemName))
                    {
                        MessageBox.Show("Could not identify item to delete.");
                        return;
                    }

                    DialogResult result = MessageBox.Show(
                        $"Delete {itemName} ({itemType}) and restore {orderQuantity} to inventory?",
                        "Confirm",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        // Open connection once at the start
                        if (con.State == ConnectionState.Closed)
                            con.Open();

                        using (SqlTransaction transaction = con.BeginTransaction())
                        {
                            try
                            {
                                // 1. Delete from ticket table
                                string deleteQuery = @"DELETE FROM O_Ticket WHERE ID = @ID";
                                using (SqlCommand deleteCmd = new SqlCommand(deleteQuery, con, transaction))
                                {
                                    deleteCmd.Parameters.AddWithValue("@ID", TicketID);
                                    int rowsAffected = deleteCmd.ExecuteNonQuery();

                                    if (rowsAffected == 0)
                                    {
                                        transaction.Rollback();
                                        MessageBox.Show("Item not found in ticket.");
                                        return;
                                    }
                                }

                                // 2. Update inventory
                                string updateQuery = GetInventoryUpdateQuery(itemType);
                                using (SqlCommand updateCmd = new SqlCommand(updateQuery, con, transaction))
                                {
                                    updateCmd.Parameters.AddWithValue("@Quantity", orderQuantity);
                                    updateCmd.Parameters.AddWithValue("@Name", itemName);
                                    updateCmd.ExecuteNonQuery();
                                }

                                transaction.Commit();
                                MessageBox.Show("Item deleted and inventory updated!");
                                loadTicket();
                                loaddgv();
                            }
                            catch (Exception ex)
                            {
                                transaction.Rollback();
                                MessageBox.Show($"Error: {ex.Message}");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Application error: {ex.Message}");
            }
            finally
            {
                // Ensure connection is closed when done
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
        }


        private string GetInventoryUpdateQuery(string itemType)
        {
            string tableName = itemType;
            string nameColumn = "Name"; // default

            switch (currentTable)
            {
                case "CPU": nameColumn = "CPU_Name"; break;
                case "GPU": nameColumn = "GPU_Name"; break;
                case "Motherboard": nameColumn = "M_Name"; break;
                case "PSU": nameColumn = "PSU_Name"; break;
                case "RAM": nameColumn = "RAM_Name"; break;
                case "Storage": nameColumn = "S_Name"; break;
                case "PC_Cases":
                    tableName = "PC_Case";
                    nameColumn = "PC_Case_Name";
                    break;
                case "Laptops":
                    tableName = "laptops";
                    nameColumn = "laptop_Name"; 
                    break;
                case "Accessories": tableName = "Accessories";nameColumn = "Name";
                        break;
            }

            return $"UPDATE {tableName} SET Quantity = Quantity + @Quantity WHERE {nameColumn} = @Name";
        }




        private void RemoveDeleteButton()
        {
            if (dgv_Ticket.Columns.Contains("btnDelete"))
            {
                dgv_Ticket.Columns.Remove("btnDelete");
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgv_Component_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void lbl_component_1_Click(object sender, EventArgs e)
        {

        }

        private void txt_component_3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Quantity < Int32.Parse(txt_component_3.Text))
                {
                    DialogResult result = MessageBox.Show($"The quantity you entered is unavaliable", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_component_3.Text = Quantity.ToString();
                }
            }
            catch
            {

            }

        }

        private void txt_component_2_TextChanged(object sender, EventArgs e)
        {

        }

        private void lbl_component_2_Click(object sender, EventArgs e)
        {

        }

        private void txt_component_1_TextChanged(object sender, EventArgs e)
        {

        }

        private void lbl_component_3_Click(object sender, EventArgs e)
        {

        }

        private void txt_component_4_TextChanged(object sender, EventArgs e)
        {

        }

        private void Place_Order_Load(object sender, EventArgs e)
        {


        }

        private void CPU_Menu_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkedListBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void bunifuDropdown1_SelectedIndexChanged(object sender, EventArgs e)
        {

            Appear();

            if (drp_Product.SelectedItem.ToString() == "CPU")
            {
                currentTable = "CPU";
            }
            else if (drp_Product.SelectedItem.ToString() == "GPU")
            {
                currentTable = "GPU";
            }
            else if (drp_Product.SelectedItem.ToString() == "Motherboard")
            {
                currentTable = "Motherboard";
            }
            else if (drp_Product.SelectedItem.ToString() == "Laptops")
            {
                currentTable = "Laptops";
            }
            else if (drp_Product.SelectedItem.ToString() == "PSU")
            {
                currentTable = "PSU";
            }
            else if (drp_Product.SelectedItem.ToString() == "RAM")
            {
                currentTable = "RAM";
            }
            else if (drp_Product.SelectedItem.ToString() == "Storage")
            {
                currentTable = "Storage";
            }
            else if (drp_Product.SelectedItem.ToString() == "Accessories")
            {
                currentTable = "Accessories";
            }
            else if (drp_Product.SelectedItem.ToString() == "PC_Cases")
            {
                currentTable = "PC_Case";
            }
            else if (drp_Product.SelectedItem.ToString() == "Custom_PC")
            {
                currentTable = "Custom_PC";
            }

            loaddrp();

        }

        private void drp_Order_SelectedIndexChanged(object sender, EventArgs e)
        {
            loaddgv();
        }

        private void dgv_Component_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pic_pcbuilder_logo_Click(object sender, EventArgs e)
        {

        }

        private void pic_Slogan_Click(object sender, EventArgs e)
        {

        }

        private void cPUBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void ticketBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void btn_Submit_Click(object sender, EventArgs e)
        {
            loaddrp();
            loaddgv();
            ResetTicketTable();
            loadTicket();
          

        }

        private void btn_info_Click(object sender, EventArgs e)
        {

        }
        private void ResetTicketTable()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["mydb"].ToString()))
                {
                    con.Open();

                    string deleteQuery = "DELETE FROM O_Ticket;";
                    string resetIdentity = "DBCC CHECKIDENT ('O_Ticket', RESEED, 0);";

                    using (SqlCommand deleteCmd = new SqlCommand(deleteQuery, con))
                    {
                        deleteCmd.ExecuteNonQuery();
                    }

                    using (SqlCommand resetCmd = new SqlCommand(resetIdentity, con))
                    {
                        resetCmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("O_Ticket table has been reset successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error resetting table:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btn_add_component_Click(object sender, EventArgs e)
        {



            loaddgv();


            try
            {
                if (Quantity < Int32.Parse(txt_component_3.Text))
                {
                    DialogResult result = MessageBox.Show($"The quantity you entered is unavaliable", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_component_3.Text = Quantity.ToString();
                }
            }
            catch
            {

            }

            if (currentTable == "CPU")
            {
                try
                {
                    if (!int.TryParse(txt_component_3.Text, out int quantity) || quantity <= 0)
                    {
                        MessageBox.Show("Please enter a valid quantity");
                        return;
                    }

                    string update_cpu = $"UPDATE CPU SET Quantity = Quantity - {Int32.Parse(txt_component_3.Text)} WHERE CPU_Name = '{drp_Order.SelectedValue.ToString()}'";
                    SqlCommand update = new SqlCommand(update_cpu, con);







                    string insert_cpu = "INSERT INTO O_Ticket VALUES (@Item_Name, @Price, @Item_Type, @Quantity, @First_Name, @Last_Name, @Order_Taken_BY,@Order_Date)";
                    SqlCommand command = new SqlCommand(insert_cpu, con);

                    command.Parameters.AddWithValue("@Item_Name", drp_Order.SelectedValue.ToString());
                    command.Parameters.AddWithValue($"@Price", Price);
                    command.Parameters.AddWithValue("@Item_Type", "CPU");
                    command.Parameters.AddWithValue("@Quantity", Int32.Parse(txt_component_3.Text));

                    command.Parameters.AddWithValue("@First_Name", txt_component_1.Text.ToString());
                    command.Parameters.AddWithValue("@Last_Name", txt_component_2.Text.ToString());
                    command.Parameters.AddWithValue("@Order_Taken_BY", Session.LoggedInUser.Name.ToString());
                    command.Parameters.Add("@Order_Date", SqlDbType.DateTime).Value = DateTime.Today;




                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    update.ExecuteNonQuery();
                    command.ExecuteNonQuery();
                    DialogResult result = MessageBox.Show($"CPU Added Successfully", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    if (con.State == ConnectionState.Open)
                        con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}\n\nStack Trace: {ex.StackTrace}");
                    // Or log to a file:

                }
            }
            else if (currentTable == "GPU")
            {
                try
                {
                    string update_gpu = $"UPDATE GPU SET Quantity = Quantity - {Int32.Parse(txt_component_3.Text)} WHERE GPU_Name = '{drp_Order.SelectedValue.ToString()}'";
                    SqlCommand update = new SqlCommand(update_gpu, con);


                    string insert_gpu = "INSERT INTO O_Ticket VALUES (@Item_Name, @Price, @Item_Type, @Quantity, @First_Name, @Last_Name, @Order_Taken_BY,@Order_Date)";
                    SqlCommand command = new SqlCommand(insert_gpu, con);





                    command.Parameters.AddWithValue("@Item_Name", drp_Order.SelectedValue.ToString());
                    command.Parameters.AddWithValue($"@Price", Price);
                    command.Parameters.AddWithValue("@Item_Type", "GPU");

                    command.Parameters.AddWithValue("@Quantity", Int32.Parse(txt_component_3.Text));
                    command.Parameters.AddWithValue("@First_Name", txt_component_1.Text.ToString());
                    command.Parameters.AddWithValue("@Last_Name", txt_component_2.Text.ToString());
                    command.Parameters.AddWithValue("@Order_Taken_BY", Session.LoggedInUser.Name.ToString());
                    command.Parameters.Add("@Order_Date", SqlDbType.DateTime).Value = DateTime.Now;



                    ;


                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    update.ExecuteNonQuery();
                    command.ExecuteNonQuery();

                    DialogResult result = MessageBox.Show($"GPU Added Successfully", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    if (con.State == ConnectionState.Open)
                        con.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("An Error has occurred. Try Again Later.");
                }
            }
            else if (currentTable == "Motherboard")
                try
                {
                    {
                        string update_Motherboard = $"UPDATE Motherboard SET Quantity = Quantity - {Int32.Parse(txt_component_3.Text)} WHERE M_Name = '{drp_Order.SelectedValue.ToString()}'";
                        SqlCommand update = new SqlCommand(update_Motherboard, con);

                        string insert_motherboard = "INSERT INTO O_Ticket VALUES (@Item_Name, @Price, @Item_Type, @Quantity, @First_Name, @Last_Name, @Order_Taken_BY,@Order_Date)";
                        SqlCommand command = new SqlCommand(insert_motherboard, con);


                        command.Parameters.AddWithValue("@Item_Name", drp_Order.SelectedValue.ToString());
                        command.Parameters.AddWithValue($"@Price", Price);
                        command.Parameters.AddWithValue("@Item_Type", "Motherboard");

                        command.Parameters.AddWithValue("@Quantity", Int32.Parse(txt_component_3.Text));
                        command.Parameters.AddWithValue("@First_Name", txt_component_1.Text.ToString());
                        command.Parameters.AddWithValue("@Last_Name", txt_component_2.Text.ToString());
                        command.Parameters.AddWithValue("@Order_Taken_BY", Session.LoggedInUser.Name.ToString());
                        command.Parameters.Add("@Order_Date", SqlDbType.DateTime).Value = DateTime.Now;



                        if (con.State == ConnectionState.Closed)
                            con.Open();

                        update.ExecuteNonQuery();
                        command.ExecuteNonQuery();

                        DialogResult result = MessageBox.Show($"Motherboard Added Successfully", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Clear input fields after adding


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

                    string update_PSU = $"UPDATE PSU SET Quantity = Quantity - {Int32.Parse(txt_component_3.Text)} WHERE ID = {Convert.ToInt32(drp_Order.SelectedValue)}";
                    SqlCommand update = new SqlCommand(update_PSU, con);

                    string insert_motherboard = "INSERT INTO O_Ticket VALUES (@Item_Name, @Price, @Item_Type, @Quantity, @First_Name, @Last_Name, @Order_Taken_BY,@Order_Date)";
                    SqlCommand command = new SqlCommand(insert_motherboard, con);

                    command.Parameters.AddWithValue("@Item_Name", drp_Order.Text.ToString());
                    command.Parameters.AddWithValue($"@Price", Price);
                    command.Parameters.AddWithValue("@item_Type", "PSU");
                    command.Parameters.AddWithValue("@Quantity", Int32.Parse(txt_component_3.Text));
                    command.Parameters.AddWithValue("@First_Name", txt_component_1.Text.ToString());
                    command.Parameters.AddWithValue("@Last_Name", txt_component_2.Text.ToString());
                    command.Parameters.AddWithValue("@Order_Taken_BY", Session.LoggedInUser.Name.ToString());
                    command.Parameters.Add("@Order_Date", SqlDbType.DateTime).Value = DateTime.Now;
                    ;

                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    update.ExecuteNonQuery();
                    command.ExecuteNonQuery();

                    DialogResult result = MessageBox.Show($"Power Supply Added Successfully", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Clear input fields after adding


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

                    string update_PC_CASE = $"UPDATE PC_Case SET Quantity = Quantity - {Int32.Parse(txt_component_3.Text)} WHERE ID = {Convert.ToInt32(drp_Order.SelectedValue)}";
                    SqlCommand update = new SqlCommand(update_PC_CASE, con);

                    string insert_case = "INSERT INTO O_Ticket VALUES (@Item_Name, @Price, @Item_Type, @Quantity, @First_Name, @Last_Name, @Order_Taken_BY,@Order_Date)";
                    SqlCommand command = new SqlCommand(insert_case, con);


                    command.Parameters.AddWithValue("@Item_Name", drp_Order.Text.ToString());
                    command.Parameters.AddWithValue($"@Price", Price);
                    command.Parameters.AddWithValue("@item_Type", "PC " +
                        "" +
                        "Case");
                    command.Parameters.AddWithValue("@Quantity", Int32.Parse(txt_component_3.Text));
                    command.Parameters.AddWithValue("@First_Name", txt_component_1.Text.ToString());
                    command.Parameters.AddWithValue("@Last_Name", txt_component_2.Text.ToString());
                    command.Parameters.AddWithValue("@Order_Taken_BY", Session.LoggedInUser.Name.ToString());
                    command.Parameters.Add("@Order_Date", SqlDbType.DateTime).Value = DateTime.Now;


                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    update.ExecuteNonQuery();
                    command.ExecuteNonQuery();

                    DialogResult result = MessageBox.Show($"PC Case Added Successfully", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    if (con.State == ConnectionState.Open)
                        con.Close();
                }
                catch (Exception)
                {

                    MessageBox.Show("An Error has occurred. Try Again Later.");
                }

            }
            else if (currentTable == "RAM")
            {
                string update_RAM = $"UPDATE RAM SET Quantity = Quantity - {Int32.Parse(txt_component_3.Text)} WHERE ID = {Convert.ToInt32(drp_Order.SelectedValue)}";
                SqlCommand update = new SqlCommand(update_RAM, con);

                string insert_ram = "INSERT INTO O_Ticket VALUES (@Item_Name, @Price, @Item_Type, @Quantity, @First_Name, @Last_Name, @Order_Taken_BY,@Order_Date)";
                SqlCommand command = new SqlCommand(insert_ram, con);

                try
                {

                    command.Parameters.AddWithValue("@Item_Name", drp_Order.Text.ToString());
                    command.Parameters.AddWithValue($"@Price", Price);
                    command.Parameters.AddWithValue("@item_Type", "RAM");
                    command.Parameters.AddWithValue("@Quantity", Int32.Parse(txt_component_3.Text));
                    command.Parameters.AddWithValue("@First_Name", txt_component_1.Text.ToString());
                    command.Parameters.AddWithValue("@Last_Name", txt_component_2.Text.ToString());
                    command.Parameters.AddWithValue("@Order_Taken_BY", Session.LoggedInUser.Name.ToString());
                    command.Parameters.Add("@Order_Date", SqlDbType.DateTime).Value = DateTime.Now;


                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    update.ExecuteNonQuery();
                    command.ExecuteNonQuery();

                    DialogResult result = MessageBox.Show($"RAM Added Successfully", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Clear input fields after adding




                    if (con.State == ConnectionState.Open)
                        con.Close();
                }
                catch (Exception)
                {

                    MessageBox.Show("An Error has occurred. Try Again Later.");
                }

            }
            else if (currentTable == "Storage")
            {
                string update_Storage = $"UPDATE Storage SET Quantity = Quantity - {Int32.Parse(txt_component_3.Text)} WHERE ID =  {Convert.ToInt32(drp_Order.SelectedValue)}";
                SqlCommand update = new SqlCommand(update_Storage, con);

                string insert_storage = "INSERT INTO O_Ticket VALUES (@Item_Name, @Price, @Item_Type, @Quantity, @First_Name, @Last_Name, @Order_Taken_BY,@Order_Date)";
                SqlCommand command = new SqlCommand(insert_storage, con);

                try
                {

                    command.Parameters.AddWithValue("@Item_Name", drp_Order.Text.ToString());
                    command.Parameters.AddWithValue($"@Price", Price);
                    command.Parameters.AddWithValue("@item_Type", "Storage");
                    command.Parameters.AddWithValue("@Quantity", Int32.Parse(txt_component_3.Text));
                    command.Parameters.AddWithValue("@First_Name", txt_component_1.Text.ToString());
                    command.Parameters.AddWithValue("@Last_Name", txt_component_2.Text.ToString());
                    command.Parameters.AddWithValue("@Order_Taken_BY", Session.LoggedInUser.Name.ToString());
                    command.Parameters.Add("@Order_Date", SqlDbType.DateTime).Value = DateTime.Now;



                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    update.ExecuteNonQuery();
                    command.ExecuteNonQuery();

                    DialogResult result = MessageBox.Show($"Storage Added Successfully", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Clear input fields after adding




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

                try
                {
                    string update_Laptops = $"UPDATE Laptops SET Quantity = Quantity - {Int32.Parse(txt_component_3.Text)} WHERE ID =  {Convert.ToInt32(drp_Order.SelectedValue)}";
                    SqlCommand update = new SqlCommand(update_Laptops, con);

                    string insert_Laptops = "INSERT INTO O_Ticket VALUES (@Item_Name, @Price, @Item_Type, @Quantity, @First_Name, @Last_Name, @Order_Taken_BY,@Order_Date)";
                    SqlCommand command = new SqlCommand(insert_Laptops, con);


                    command.Parameters.AddWithValue("@Item_Name", drp_Order.Text.ToString());
                    command.Parameters.AddWithValue($"@Price", Price);
                    command.Parameters.AddWithValue("@item_Type", "Laptops");
                    command.Parameters.AddWithValue("@Quantity", Int32.Parse(txt_component_3.Text));
                    command.Parameters.AddWithValue("@First_Name", txt_component_1.Text.ToString());
                    command.Parameters.AddWithValue("@Last_Name", txt_component_2.Text.ToString());
                    command.Parameters.AddWithValue("@Order_Taken_BY", Session.LoggedInUser.Name.ToString());
                    command.Parameters.Add("@Order_Date", SqlDbType.DateTime).Value = DateTime.Now;




                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    update.ExecuteNonQuery();
                    command.ExecuteNonQuery();
                    DialogResult result = MessageBox.Show($"Laptop Added Successfully", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);





                    if (con.State == ConnectionState.Open)
                        con.Close();
                }
                catch (Exception)
                {


                }

            }
            else if (currentTable == "Accessories")
            {
                try
                {
                    string update_Accessories = $"UPDATE Accessories SET Quantity = Quantity - {Int32.Parse(txt_component_3.Text)} WHERE ID =  {Convert.ToInt32(drp_Order.SelectedValue)}";
                    SqlCommand update = new SqlCommand(update_Accessories, con);
                    string insert_Accessories = "INSERT INTO O_Ticket VALUES (@Item_Name, @Price, @Item_Type, @Quantity, @First_Name, @Last_Name, @Order_Taken_BY,@Order_Date)";
                    SqlCommand command = new SqlCommand(insert_Accessories, con);


                    command.Parameters.AddWithValue("@Item_Name", drp_Order.Text.ToString());
                    command.Parameters.AddWithValue("@Price", Price);
                    command.Parameters.AddWithValue("@item_Type", TYPE);
                    command.Parameters.AddWithValue("@Quantity", Int32.Parse(txt_component_3.Text));
                    command.Parameters.AddWithValue("@First_Name", txt_component_1.Text.ToString());
                    command.Parameters.AddWithValue("@Last_Name", txt_component_2.Text.ToString());
                    command.Parameters.AddWithValue("@Order_Taken_BY", Session.LoggedInUser.Name.ToString());
                    command.Parameters.Add("@Order_Date", SqlDbType.DateTime).Value = DateTime.Now;

                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    update.ExecuteNonQuery();
                    command.ExecuteNonQuery();
                    DialogResult result = MessageBox.Show($"Accessories Added Successfully", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (con.State == ConnectionState.Open)
                        con.Close();

                }
                catch (Exception)
                {

                    throw;
                }

            }
            loaddgv(); // Refresh the grid
            loadTicket();
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }
    }
}
