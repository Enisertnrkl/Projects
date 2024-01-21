using System;

using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Stockmanagement;
using Menu = Stockmanagement.Menu;

namespace stockmanagement
{
    public partial class StockControl : Form
    {
        public StockControl()
        {
            InitializeComponent();
        }

        //stoğu 11 den az ürünleri gösterir
        private void StockControl_Load(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(Database.DatabaseString))
            {
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM Urunler WHERE Stok < 11",conn))
                    {
                        DataTable dt = new DataTable();
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                                dt.Load(dr);
                                dataGridView1.DataSource = dt;
                
                        }
                    }
                }
            }
        }

        private void StockControl_FormClosing(object sender, FormClosingEventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
        }
    }
}
