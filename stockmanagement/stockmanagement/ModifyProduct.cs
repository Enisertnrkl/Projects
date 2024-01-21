using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.IO;
using System.Linq;

namespace Stockmanagement
{
    public partial class ModifyProduct : Form
    {
        public ModifyProduct()
        {
            InitializeComponent();
        }


        private void ModifyProduct_Load(object sender, EventArgs e)
        {
            try
            {
                //mevcut formdaki tüm kontrolleri devre dışı bırakır
                foreach (Control control in this.Controls)
                {
                    control.Enabled = false;
                    listBox1.Enabled = true;
                }
				ListBoxEvents.AddOneColumnToListBox(listBox1, "Urun_Ad", "Urunler");
				ComboBoxEvents.FillCombobox("Kategori","KategoriAd",comboBox1);
				ComboBoxEvents.FillCombobox("BirimTablo","Birim",comboBox2);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

        }


        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
              
                foreach (Control control in this.Controls)
                {
                    control.Enabled = true;
                    textBox4.Enabled = false;
                }
                string query = "SELECT Urun_Ad,Kategori.KategoriAd,BirimTablo.Birim,Miktar,Stok,Fiyat  FROM Urunler INNER JOIN Kategori ON Urunler.KategoriId = Kategori.Id INNER JOIN BirimTablo ON Urunler.BirimId = BirimTablo.Id WHERE Urun_Ad = @urunad";
                using(SqlConnection conn = new SqlConnection(Database.DatabaseString))
                {
                    if (listBox1.SelectedIndex != -1)
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("urunad", listBox1.SelectedItem.ToString());
                            SqlDataReader record = cmd.ExecuteReader();
                            while(record.Read()) { 
                          
	                            textBox4.Text = record["Urun_Ad"].ToString();
	                            comboBox1.SelectedItem = record["KategoriAd"].ToString();
	                            comboBox2.SelectedItem = record["Birim"].ToString();
	                            if (record["Birim"].ToString() != "Adet")
	                            {
		                            textBox1.Text = record["Miktar"].ToString().Trim();
	                            }
	                            else
	                            {
		                            textBox1.Enabled = false;
	                            }

	                            textBox2.Text = record["Stok"].ToString();
	                            textBox3.Text = record["Fiyat"].ToString();
                            }
                        }
                    }
                }
                SaveOriginalValue();
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex != -1)
            {
                if (comboBox2.SelectedItem.ToString() != "Adet")
                {
                    textBox1.Enabled = true;
                }
                else
                {
                    textBox1.Text = null;
                    textBox1.Enabled = false;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
	        if (listBox1.SelectedIndex != -1)
	        {
		        try
		        {
			        LogOldProduct();
			        string query =
				        "UPDATE Urunler SET KategoriId = @kategoriid, BirimId = @birimid, Miktar = @miktar, Stok = @stok, Fiyat = @fiyat,EklenmeTarihi = @zaman, UserId = @userid WHERE Urun_Ad = @urunad ";
			        using (SqlConnection conn = new SqlConnection(Database.DatabaseString))
			        {
				        if (IsProductModified())
				        {
					        conn.Open();

					        using (SqlCommand cmd = new SqlCommand(query, conn))
					        {
						        DateTime now = DateTime.Now;
						        cmd.Parameters.AddWithValue("@urunad", textBox4.Text);
						        cmd.Parameters.AddWithValue("@kategoriid",
							        GetId.GetIdByParameter("Kategori", "KategoriAd", comboBox1));
						        cmd.Parameters.AddWithValue("@birimid",
							        GetId.GetIdByParameter("BirimTablo", "Birim", comboBox2));
						        cmd.Parameters.AddWithValue("@miktar",
							        string.IsNullOrEmpty(textBox1.Text) ? (object)DBNull.Value : textBox1.Text);
						        cmd.Parameters.AddWithValue("@stok", textBox2.Text);
						        cmd.Parameters.AddWithValue("@fiyat", decimal.Parse(textBox3.Text));
						        cmd.Parameters.AddWithValue("userid",
							        GetId.GetIdByParameter("UserList", "Name", UserCredentials.Name));
						        cmd.Parameters.AddWithValue("@zaman", now);
						        int rowsChanged = cmd.ExecuteNonQuery();
						        if (rowsChanged > 0)
						        {
							        MessageBox.Show("Ürün başarıyla güncellendi!    ");

							        LogUpdatedProduct(textBox4.Text, comboBox1.SelectedItem.ToString(),
								        comboBox2.SelectedItem.ToString(), textBox1?.Text, textBox2.Text,
								        decimal.Parse(textBox3.Text), now);
							        ListBoxEvents.AddOneColumnToListBox(listBox1, "Urun_Ad", "Urunler");
									listBox1.SelectedItem = textBox4.Text;

						        }
						        else
						        {
							        MessageBox.Show("Ürün Güncellenemedi");
						        }


					        }

				        }
				        else
				        {
					        MessageBox.Show("Hiçbir değişiklik yapılmadı");
				        }
			        }
		        }
		        catch (Exception ex)
		        {
			        MessageBox.Show("bilgiler güncellenirken bir hatayla karşılaşıldı", ex.Message);

		        }
	        }
	        else
	        {
		        MessageBox.Show("Ürün seçiniz");
	        }
        }

        //üründe herhangi bir değişiklik yapılıp yapılmadığına bakar
        private bool IsProductModified()
        {
            return comboBox1?.SelectedItem?.ToString() != comboBox1.Tag?.ToString() ||
                   comboBox2?.SelectedItem?.ToString() != comboBox2.Tag?.ToString() ||
                   textBox1.Text != textBox1.Tag.ToString() ||
                   textBox2.Text != textBox2.Tag.ToString() ||
                   textBox3.Text != textBox3.Tag.ToString() ||
                   textBox4.Text != textBox4.Tag.ToString();    

        }

        //kontrollerdeki orjinal veriyi Tag özelliğinin içine atar(ekstra bilgi saklanabilen bir özellik)
        private void SaveOriginalValue()
        {
            comboBox1.Tag = comboBox1.SelectedItem?.ToString();
            comboBox2.Tag = comboBox2.SelectedItem?.ToString();
            textBox1.Tag = textBox1.Text;
            textBox2.Tag = textBox2.Text;
            textBox3.Tag = textBox3.Text;
            textBox4.Tag = textBox4.Text;
        }

        private void ModifyProduct_FormClosing(object sender, FormClosingEventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.SelectedIndex = -1;
            foreach (Control control in this.Controls)
            {
                control.Enabled = false;
                listBox1.Enabled = true;
            }
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            comboBox1.SelectedItem = null;
            comboBox2.SelectedItem = null;
        }

        //ürünün veritabanındaki değişmeden önceki verileri masaüstünde log.txt yoksa oluşturup  içine yazdırır var ise direkt yazdırır.
        private void LogOldProduct()
        {
            string LogFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "log.txt");
            
            try
            {
                using (SqlConnection conn = new SqlConnection(Database.DatabaseString))
                {
                    conn.Open();
                    string query = "SELECT Urun_Ad,Kategori.KategoriAd,BirimTablo.Birim,Miktar,Stok,Fiyat,EklenmeTarihi,UserList.Name FROM Urunler INNER JOIN Kategori ON Urunler.KategoriId = Kategori.Id INNER JOIN BirimTablo ON Urunler.BirimId = BirimTablo.Id INNER JOIN UserList ON Urunler.UserId = UserList.Id WHERE Urun_Ad = @urunad";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@urunad",listBox1.SelectedItem.ToString());
                        using (SqlDataReader record = cmd.ExecuteReader())
                        {
                            while(record.Read()) { 
                           
	                            using (StreamWriter writer = File.AppendText(LogFilePath))
	                            {
		                            writer.WriteLine("Ürünün eski bilgileri");
		                            writer.WriteLine(new string('-', 50));
		                            writer.WriteLine($"Ürün Adı :{record.GetString(0)}");
		                            writer.WriteLine($"Eski Kategori :{record.GetString(1)}");
		                            writer.WriteLine($"Eski Birim : {record.GetString(2)}");
			                            writer.WriteLine($"Eski Miktar : {record.GetInt32(3)}");
		                            writer.WriteLine($"Eski Stok: {record.GetInt32(4)} Adet");
		                            writer.WriteLine($"Eski Fiyat: {record.GetDecimal(5)} TL");
		                            writer.WriteLine($"Eklenme Tarihi: {record.GetDateTime(6)}");
		                            writer.WriteLine($"Ekleyen Kişi: {record.GetString(7)}");
		                            writer.WriteLine(new string('-', 50));
								}
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Hata Oluştu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //veritabanındaki veri değiştiğinde(örnek : ürün düzenle formundaki ürünün değiştirilip güncelle butonuna basıp veritabanına yeni veriyi yazdırdıktan sonra)log.txt içine yazar
        private void LogUpdatedProduct(string productname, string category, string unit, string quantity, string stock, decimal price, DateTime time)
        {
            try
            {
                string LogFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "log.txt");
                using (StreamWriter writer = File.AppendText(LogFilePath))
                {
                    writer.WriteLine("Ürünün yeni bilgileri"); 
                    writer.WriteLine(new string('-', 50));
                    writer.WriteLine($"Ürün Adı : {productname}");
                    writer.WriteLine($"Yeni Kategori: {category}");
                    writer.WriteLine($"Yeni Birim : {unit}");
                    if (!string.IsNullOrEmpty(quantity))
                    {
                        writer.WriteLine($"Yeni Miktar :{quantity}");
                    }
                    writer.WriteLine($"Yeni Stok : {stock} Adet");
                    writer.WriteLine($"Yeni Fiyat : {price} TL");
                    writer.WriteLine($"Değiştirme Tarihi :{time}");
                    writer.WriteLine($"Değiştiren Kişi :{UserCredentials.Name}");
                    writer.WriteLine(new string('-', 50));
                    writer.WriteLine(new string('-', 50));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Hata Oluştu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
