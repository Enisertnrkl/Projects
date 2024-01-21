using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Stockmanagement
{
    public partial class PastProducts : Form
    {
        public PastProducts()
        {
            InitializeComponent();
        }

        public void RefreshView()
        {
	        using (SqlConnection conn = new SqlConnection(Database.DatabaseString))
	        {
		        string query = "SELECT Urun_Ad,Kategori.KategoriAd,BirimTablo.Birim,Miktar,Stok,Fiyat,SilinmeTarihi,UserList.Name FROM SilinenUrunler INNER JOIN Kategori ON SilinenUrunler.KategoriId = Kategori.Id INNER JOIN BirimTablo ON SilinenUrunler.BirimId = BirimTablo.Id INNER JOIN UserList ON SilinenUrunler.UserId = UserList.Id";
		        using (SqlCommand cmd = new SqlCommand(query, conn))
		        {
			        DataTable dt = new DataTable();
			        SqlDataAdapter da = new SqlDataAdapter(cmd);
			        da.Fill(dt);
			        dataGridView1.DataSource = dt;
		        }
	        }
		}

        private void PastProducts_Load(object sender, EventArgs e)
        {
			RefreshView();
			DataGridViewButtonColumn button = new DataGridViewButtonColumn();
			{
				button.Name = "button";
				button.HeaderText = "";
				button.Text = "Geri getir";
				button.UseColumnTextForButtonValue = true;
				this.dataGridView1.Columns.Add(button);
				this.dataGridView1.CellClick += DataGridView1_CellClick;
			}
		}

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
	        if (e.ColumnIndex == dataGridView1.Columns["button"].Index)
	        {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                string selectedCategory = selectedRow.Cells["KategoriAd"].Value.ToString();
                string selectedUnit = selectedRow.Cells["Birim"].Value.ToString();
               using (SqlConnection conn = new SqlConnection(Database.DatabaseString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO Urunler (Urun_Ad,KategoriId,BirimId,Miktar,Stok,Fiyat,EklenmeTarihi,UserId) VALUES" +
																  " (@urunad,@kategoriid,@birimid,@miktar,@stok,@fiyat,@eklenmetarihi,@userid)",conn))
                    {
	                    cmd.Parameters.AddWithValue("@urunad", selectedRow.Cells["Urun_Ad"].Value.ToString());
	                    cmd.Parameters.AddWithValue("@kategoriid", GetId.GetIdByParameter("Kategori", "KategoriAd", selectedCategory));
	                    cmd.Parameters.AddWithValue("@birimid", GetId.GetIdByParameter("BirimTablo", "Birim", selectedUnit));
	                    cmd.Parameters.AddWithValue("@miktar", (int)selectedRow.Cells["Miktar"].Value);
	                    cmd.Parameters.AddWithValue("@stok", (int)selectedRow.Cells["Stok"].Value);
	                    cmd.Parameters.AddWithValue("@fiyat", (decimal)selectedRow.Cells["Fiyat"].Value);
	                    cmd.Parameters.AddWithValue("@eklenmetarihi", DateTime.Now);
	                    cmd.Parameters.AddWithValue("@userid",UserCredentials.Id);
						int affectedrows = cmd.ExecuteNonQuery();
						if (affectedrows > 0)
						{
							MessageBox.Show("Ürün geri getirildi.");
							string LogFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "log.txt");
							using (StreamWriter writer = File.AppendText(LogFilePath))
							{
								writer.WriteLine("Ürün Geri Getirme");
								writer.WriteLine(new string('-', 50));
								writer.WriteLine($"Geri Getirilen Ürün Adı : {selectedRow.Cells["Urun_Ad"].Value}");
								writer.WriteLine($"Kategori: {selectedRow.Cells["KategoriAd"].Value}");
								writer.WriteLine($"Birim : {selectedRow.Cells["Birim"].Value}");
								if (!string.IsNullOrEmpty(selectedRow.Cells["Miktar"].Value.ToString()))
								{
									writer.WriteLine($"Miktar: {(int)selectedRow.Cells["Miktar"].Value}");
								}
								writer.WriteLine($"Stok : {(int)selectedRow.Cells["Stok"].Value} Adet");
								writer.WriteLine($"Fiyat : {(decimal)selectedRow.Cells["Fiyat"].Value} TL");
								writer.WriteLine($"Geri Getirilme Tarihi :{DateTime.Now}");
								writer.WriteLine($"Geri Getiren Kişi :{UserCredentials.Name}");
								writer.WriteLine(new string('-', 50));

							}

						}

						using (SqlCommand cmd2 = new SqlCommand("DELETE FROM SilinenUrunler WHERE Urun_Ad = @urunad",conn))
	                    {
		                    cmd2.Parameters.AddWithValue("@urunad", selectedRow.Cells["Urun_Ad"].Value.ToString());
							int affectedRows = cmd2.ExecuteNonQuery();
							if (affectedRows > 0)
							{
								RefreshView();

							}

						}
                    }
                }
	        }
        }

		private void PastProducts_FormClosing(object sender, FormClosingEventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
        }
    }
}
