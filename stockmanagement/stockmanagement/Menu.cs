using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using stockmanagement;

namespace Stockmanagement
{
    public partial class Menu : Form
    { 
        public Menu()
        {
            InitializeComponent();

        }

        //datagridview'e ürünler tablosunu doldurur
        private void FillData()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(Database.DatabaseString))
            {
                conn.Open();
                    using(SqlDataAdapter da = new SqlDataAdapter("SELECT Urun_Ad AS Urun,Kategori.KategoriAd AS Kategori,BirimTablo.Birim,Miktar,Stok,Fiyat,EklenmeTarihi AS Eklenme_Tarihi,UserList.Name AS Ekleyen_Kisi FROM Urunler" +
                                                                 " INNER JOIN Kategori ON Urunler.KategoriId = Kategori.Id  " +
                                                                 "INNER JOIN BirimTablo ON Urunler.BirimId = BirimTablo.Id" +
                                                                 " INNER JOIN UserList ON Urunler.UserId = UserList.Id",conn))
                {
                    da.Fill(dt);
                }

                foreach (DataColumn column  in dt.Columns)
                {
	                column.ColumnName = column.ColumnName.Replace("_", " ");
                }

				dataGridView1.DataSource = dt;
            }

		}
        //Ürünler tablosundaki ürün adını ve stoğu seçer eğer Stok(reader.GetInt32(1)) 5 den az ise notifyicon gösterir.
        private void StockWarning()
        {
            using (SqlConnection conn = new SqlConnection(Database.DatabaseString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT Urun_Ad,Stok FROM Urunler", conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
	                    reader.Cast<IDataRecord>().ToList().ForEach(record =>
	                    {
		                    if (record.GetInt32(1) < 5)
		                    {
			                    notifyIcon1.ShowBalloonTip(1000, "Önemli", $"{record[0]} adlı ürünün stoğu bitmek üzere",
				                    ToolTipIcon.Info);

		                    }

	                    });
                    }
                }
            }
        }

        private void Menu_Load(object sender, EventArgs e)
        {
	        çıkışYapToolStripMenuItem.Text = $"Çıkış Yap  ({UserCredentials.Name})";
			//StokKontrol classındaki IsControlled bool u false ise notifyicon'u çağırır ve true yapar(bu kod satırı program çalıştığında notifyicon'u sadece 1 kere çağırmak için).
			if (!StokKontrol.IsControlled)
            {
                StockWarning();
                StokKontrol.IsControlled = true;
            }
            ComboBoxEvents.FillCombobox("Kategori","KategoriAd",comboBox1);

            //Role göre kısıtlamalar
            if(UserCredentials.Role is "User")
            {
                ürünDüzenleToolStripMenuItem.Enabled = false; ürünSilToolStripMenuItem.Enabled = false; 
            }
            if (UserCredentials.Role is "User" or "Admin")
            {
                ürünSatışToolStripMenuItem.Enabled = false;
            }
            FillData();

        }

        private void Menu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //combobox değiştiğinde(kategori) sadece o kategoriye ait ürünleri getirir.
            if (comboBox1.SelectedIndex != -1)
            {
                using (SqlConnection conn = new SqlConnection(Database.DatabaseString))
                {
                    string query = "SELECT Urun_Ad AS Urun,Kategori.KategoriAd AS Kategori,BirimTablo.Birim,Miktar,Stok,Fiyat,EklenmeTarihi AS Eklenme_Tarihi,UserList.Name AS Ekleyen_Kisi FROM Urunler" +
                                   " INNER JOIN Kategori ON Urunler.KategoriId = Kategori.Id " +
                                   " INNER JOIN BirimTablo ON Urunler.BirimId = BirimTablo.Id " +
								   " INNER JOIN UserList ON Urunler.UserId = UserList.Id WHERE Kategori.KategoriAd = @kategori AND Urun_Ad LIKE '%' +  @urunad + '%' ";
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
	                    cmd.Parameters.AddWithValue("@urunad", textBox1.Text);
                        cmd.Parameters.AddWithValue("@kategori", comboBox1.SelectedItem.ToString());
                        SqlDataReader reader = cmd.ExecuteReader();
                        DataTable dt = new DataTable();
                        dt.Load(reader);
                        foreach (DataColumn column in dt.Columns)
                        {
	                        column.ColumnName.Replace("_", "-");
                        }
                        dataGridView1.DataSource = dt;
                    }
                }
            }
        }

        //temizle butonu
        private void button7_Click(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = -1;
            textBox1.Text = null;
            FillData();
        }

        //textboxta her bir giriş değiştiğinde(kelime) o girişe göre ürün adını getirir.
       private void textBox1_TextChanged(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(Database.DatabaseString))
            {
                conn.Open();
                string query = "SELECT Urun_Ad AS Urun,Kategori.KategoriAd AS Kategori,BirimTablo.Birim,Miktar,Stok,Fiyat,EklenmeTarihi AS Eklenme_Tarihi,UserList.Name AS Ekleyen_Kisi FROM Urunler INNER JOIN Kategori ON Urunler.KategoriId = Kategori.Id  INNER JOIN BirimTablo ON Urunler.BirimId = BirimTablo.Id  INNER JOIN UserList ON Urunler.UserId = UserList.Id WHERE Urun_Ad LIKE '%' +  @urunad + '%'";
               
                //eğer combobox boş değilse query'e kategoriyi de ekler.
				if (comboBox1.SelectedIndex != -1)
                {
                    query += "AND KategoriId = @kategoriid";
                }
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (comboBox1.SelectedIndex != -1)
                    {
                        cmd.Parameters.AddWithValue("@kategoriid", GetId.GetIdByParameter("Kategori", "KategoriAd", comboBox1));
                    }

                    cmd.Parameters.AddWithValue("@urunad", textBox1.Text);
                    SqlDataReader reader = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    dataGridView1.DataSource = dt;
                }
            }
        }
      
        private void ürünEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
			AddProduct addProduct = new AddProduct();
            addProduct.Show();
            this.Hide();
        }

        private void ürünDüzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModifyProduct modifyProduct = new ModifyProduct();
            modifyProduct.Show();
            this.Hide();
        }

        private void ürünSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveProduct removeProduct = new RemoveProduct();
            removeProduct.Show();
            this.Hide();
        }

        private void silmeGeçmişiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PastProducts pastProducts = new PastProducts();
            pastProducts.Show();
            this.Hide();
        }

        private void kullanıcıBilgileriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserInfo userInfo = new UserInfo();
            userInfo.Show();
            this.Hide();
        }

        private void ürünSatışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SellProduct sellProduct = new SellProduct();
            sellProduct.Show();
            this.Hide();
        }

        private void çıkışYapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Çıkış yapmak istediğine emin misin?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
	            StokKontrol.IsControlled = false;
	            ProductList._Products.Clear();
				Login login = new Login();
                login.Show();
                this.Hide();
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Hide();
        }

        private void Menu_Move(object sender, EventArgs e)
        {
        }

        private void stokKontrolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StockControl stockControl = new StockControl();
            stockControl.Show();
            this.Hide();
        }

		private void kategoriEkleToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			AddCategory addcategory = new AddCategory();
			addcategory.Show();
			this.Hide();
		}

		private void birimEkleToolStripMenuItem_Click(object sender, EventArgs e)
		{
            AddUnit addunit = new AddUnit();
            addunit.Show();
            this.Hide();
		}
	}
}
