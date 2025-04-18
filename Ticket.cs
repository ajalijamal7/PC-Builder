using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PC_Builder
{
    public partial class Ticket: Form
    {

        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["mydb"].ToString());
        private string ticketText = "";

        public Ticket()
        {
            InitializeComponent();
            this.Load += Ticket_Load;
        }

        private void Ticket_Load(object sender, EventArgs e)
        {
            txt_Ticket.Font = new Font("Consolas", 10); // Monospaced font
            txt_Ticket.Multiline = true;
            txt_Ticket.ScrollBars = ScrollBars.Vertical;
            txt_Ticket.ReadOnly = true;

            LoadOrderSummary();
        }

        private void LoadOrderSummary()
        {
            try
            {
                con.Open();
                string query = @"
                    SELECT 
                        First_Name, 
                        Last_Name, 
                        Item_Type, 
                        Quantity, 
                        Price, 
                        (Quantity * Price) AS Total
                    FROM O_Ticket";

                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();

                txt_Ticket.Clear();
                txt_Ticket.AppendText("=== ORDER HISTORY ===\r\n\r\n");

                while (reader.Read())
                {
                    string orderLine =
                        $"{reader["First_Name"],-10} {reader["Last_Name"],-10}\r\n" +
                        $"{reader["Item_Type"],-15} x{reader["Quantity"],-3} @ {Convert.ToDecimal(reader["Price"]):C}\r\n" +
                        $"Total: {Convert.ToDecimal(reader["Total"]):C}\r\n\r\n";

                    txt_Ticket.AppendText(orderLine);
                }

                txt_Ticket.AppendText("=== END OF REPORT ===");

                ticketText = txt_Ticket.Text; // Save for printing
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading orders:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
        }

        private void btn_Print_Click(object sender, EventArgs e)
        {
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(PrintPage);
            PrintDialog printDlg = new PrintDialog();
            printDlg.Document = pd;

            if (printDlg.ShowDialog() == DialogResult.OK)
            {
                pd.Print();
            }
        }

     
        private void PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawString(ticketText, new Font("Consolas", 10), Brushes.Black, new RectangleF(40, 40, e.MarginBounds.Width, e.MarginBounds.Height));
        }



        private void txt_component_1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
