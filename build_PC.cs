using System;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;
using Bunifu.UI.WinForms;

namespace PC_Builder
{
    public partial class build_PC : Form
    {
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["mydb"].ToString());
        private string currentTable = "CPU";
        string socket = "";
        string ram_type = "";
        int power = 0;
        int count_RAM = 1;
        int RAM_Slots;
        int quantity_RAM;
        public build_PC()
        {
            
            InitializeComponent();
            this.dgv_Component.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Component_CellContentClick);

        }

       private void  loadPSU( int Power)
        {
            try
            {

                RemoveAddButtonColumn();
                string query = $"SELECT * FROM PSU WHERE Wattage > {Power}";
                SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                DataTable componentTable = new DataTable();
                adapter.Fill(componentTable);
                dgv_Component.DataSource = componentTable;
                AddButton();

            }
            catch
            {
                MessageBox.Show("An Error has occurred. Try again later.");
            }
        }

        private void loadMotherboard(string socket)
        {
            RemoveAddButtonColumn();

            string query =$"SELECT * FROM Motherboard WHERE M_Socket LIKE '{socket}'";

            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            DataTable componentTable = new DataTable();
            adapter.Fill(componentTable);
            dgv_Component.DataSource = componentTable;
            AddButton();

        }



        private void loadCPU(string socket)
        {

            RemoveAddButtonColumn();

            string query = $"SELECT * FROM CPU WHERE CPU_Socket LIKE '{socket}'";

            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            DataTable componentTable = new DataTable();
            adapter.Fill(componentTable);
            dgv_Component.DataSource = componentTable;
            AddButton();
        } 


        private void loadRAM(string RAM_Type)
        {
            RemoveAddButtonColumn();
            string query = $"SELECT * FROM RAM WHERE (RAM_Type LIKE '{RAM_Type}' AND Quantity != 0)";
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            DataTable componentTable = new DataTable();
            adapter.Fill(componentTable);
            dgv_Component.DataSource = componentTable;
            AddButton();
        }
        private void loaddgv()
        {
            try
            {
                
                Appear();

                RemoveAddButtonColumn();
               

                string query = "";
                if (currentTable == "CPU") query = "SELECT * FROM CPU";
                else if (currentTable == "GPU") query = "SELECT * FROM GPU";
                else if (currentTable == "Motherboard") query = $"SELECT * FROM Motherboard";
                else if (currentTable == "PSU") query = "SELECT * FROM PSU";
                else if (currentTable == "PC_Case") query = "SELECT * FROM PC_Case";
                else if (currentTable == "RAM") query = "SELECT * FROM RAM";
                else if (currentTable == "Storage") query = "SELECT * FROM Storage";
                else if (currentTable == "Laptops") query = "SELECT * FROM Laptops";
                else if (currentTable == "Accessories") query = "SELECT * FROM Accessories";

                SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                DataTable componentTable = new DataTable();
                adapter.Fill(componentTable);
                dgv_Component.DataSource = componentTable;
                AddButton();
            }
            catch (Exception)
            {
                MessageBox.Show("An Error has occurred. Try again later.");
            }
        }

        private void Appear()
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
            txt_quantity_RAM.Visible = true;
           
            pic_pcbuilder_logo.Visible = false;
            pic_Slogan.Visible = false;

            dgv_Component.Visible = true;
        }

        private void AddButton()
        {
            if (!dgv_Component.Columns.Contains("Addbutton"))
            {
                DataGridViewButtonColumn btnAdd = new DataGridViewButtonColumn();
                btnAdd.Name = "btn_Add";
                btnAdd.HeaderText = "";
                btnAdd.Text = "Add";
                btnAdd.UseColumnTextForButtonValue = true;
                dgv_Component.Columns.Add(btnAdd);
                btnAdd.DisplayIndex = dgv_Component.Columns.Count - 1;
            }
        }

        private void RemoveAddButtonColumn()
        {
            string columnName = "btn_Add";
            if (dgv_Component.Columns.Contains(columnName))
            {
                dgv_Component.Columns.Remove(columnName);
            }
        }

        private void dgv_Component_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgv_Component.Columns[e.ColumnIndex].Name == "btn_Add")
            {
                try
                {

                    DataGridViewRow selectedRow = dgv_Component.Rows[e.RowIndex];
                    string componentName;


                    // Assuming 'Name' column contains the component name



                    // Use if-else statements to populate the correct textbox based on the currentTable
                    if (currentTable == "CPU")
                    {

                        componentName = selectedRow.Cells["CPU_Name"].Value?.ToString();
                        socket = selectedRow.Cells["CPU_Socket"].Value?.ToString();
                        power += Convert.ToInt32(selectedRow.Cells["CPU_Power"].Value);
                        txt_component_1.Text = componentName;
                    }
                    else if (currentTable == "GPU")
                    {
                        power += Convert.ToInt32(selectedRow.Cells["GPU_Power"].Value);
                        componentName = selectedRow.Cells["GPU_Name"].Value?.ToString();
                        txt_component_2.Text = componentName;
                    }
                    else if (currentTable == "Motherboard")
                    {
                        
                        socket = selectedRow.Cells["M_Socket"].Value?.ToString();
                        RAM_Slots = Convert.ToInt32(selectedRow.Cells["Memory_Slots"].Value);
                        ram_type = selectedRow.Cells["Memory_Type"].Value?.ToString();
                        componentName = selectedRow.Cells["M_Name"].Value?.ToString();
                        txt_component_3.Text = componentName;

                    }
                    else if (currentTable == "PSU")
                    {

                        componentName = selectedRow.Cells["ID"].Value?.ToString();
                        componentName += " / " + selectedRow.Cells["PSU_Name"].Value?.ToString();
                        txt_component_4.Text = componentName;
                    }
                    else if (currentTable == "PC_Case")
                    {
                        componentName = selectedRow.Cells["ID"].Value?.ToString();
                        componentName += " / " + selectedRow.Cells["PC_Case_Name"].Value?.ToString();
                        txt_component_5.Text = componentName;
                    }
                    else if (currentTable == "RAM")
                    {
                        
                        string check;
                        componentName = "";
                        componentName = selectedRow.Cells["ID"].Value?.ToString();
                        componentName += "/" + selectedRow.Cells["RAM_Name"].Value?.ToString()+" ";

                        check = txt_component_6.Text;

                        if (count_RAM < RAM_Slots)
                        {
                            if (check == componentName)
                            {
                                count_RAM++;
                                txt_component_6.Text = componentName;
                                txt_quantity_RAM.Text = "X" + count_RAM.ToString();
                            }
                            else txt_component_6.Text =  componentName;
                        }


                    }
                    else if (currentTable == "Storage")
                    {
                        componentName = selectedRow.Cells["ID"].Value?.ToString();
                        componentName += " / " + selectedRow.Cells["S_Name"].Value?.ToString();
                        txt_component_7.Text = componentName;
                    }
                    
                }


                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while loading data: " + ex.Message);
                }
            }
        }

        private void btn_CPU_Click(object sender, EventArgs e)
        {
            currentTable = "CPU";
            if (txt_component_3.Text == "")
                loaddgv();
            else loadCPU(socket);
        }

        private void btn_GPU_Click_1(object sender, EventArgs e)
        {
            currentTable = "GPU";
            loaddgv();
        }

        private void btn_Motherboard_Click(object sender, EventArgs e)
        {
            currentTable = "Motherboard";
            if (txt_component_1.Text == "")
                loaddgv();
            else
                loadMotherboard(socket);
        }

        private void btn_Power_Supply_Click(object sender, EventArgs e)
        {
            Appear();
            currentTable = "PSU";
            loadPSU(power);

        }

        private void btn_PC_Case_Click(object sender, EventArgs e)
        {
            currentTable = "PC_Case";
            loaddgv ();
        }

        private void btn_Memory_Click(object sender, EventArgs e)
        {
            
            currentTable = "RAM";
            if (lbl_component_3.Text == "")
                loaddgv();
            else
                loadRAM(ram_type);

                
        }

        private void btn_Storage_Click(object sender, EventArgs e)
        {
            currentTable = "Storage";
            loaddgv ();
        }   

        private void Manage_Laptops_Click(object sender, EventArgs e)
        {
        
            currentTable = "Laptops";
            loaddgv();
        }

        private void Manage_Accessories_Click(object sender, EventArgs e)
        {
       
            currentTable = "Accessories";
            loaddgv();
        }

        // Unused event handlers
        private void txt_component_1_TextChanged(object sender, EventArgs e) { }
        private void txt_component_2_TextChanged(object sender, EventArgs e) { }
        private void bunifuLabel1_Click(object sender, EventArgs e) { }
        private void bunifuLabel5_Click(object sender, EventArgs e) { }
        private void bunifuSeparator2_Click(object sender, EventArgs e) { }
        private void bunifuDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void frm_place_order_Load(object sender, EventArgs e) { }

        private void txt_component_6_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgv_Component_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txt_quantity_RAM_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
