using System;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Windows.Forms;

namespace Stockmanagement
{
    public partial class RemoveProduct : Form
    {
        public RemoveProduct()
        {
            InitializeComponent();
        }

        //listboxu yeniler
      

        private void DeleteProduct()
        {
            string query = "DELETE FROM Urunler WHERE Urun_Ad = @urunad";
            using (SqlConnection conn = new SqlConnection(Database.DatabaseString))
            {

                conn.Open();
                string selectedProduct;
                int affectedrows;
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    selectedProduct = listBox1.SelectedItem.ToString();
                    cmd.Parameters.AddWithValue("urunad", selectedProduct);
                    affectedrows = cmd.ExecuteNonQuery();
                }
                if (affectedrows > 0)
                {
                    string LogFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "log.txt");
                    MessageBox.Show("ürün başarıyla silindi");
                    using (StreamWriter write = File.AppendText(LogFilePath))
                    {
                        write.WriteLine("Ürün Silme");
                        write.WriteLine(new string('-', 50));
                        write.WriteLine($"Silinen Ürün Adı :{selectedProduct}");
                        write.WriteLine($"Ürünün Silinme Tarihi : {DateTime.Now}");
                        write.WriteLine($"Ürünü Silen Kişi : {UserCredentials.Name}");
                        write.WriteLine(new string('-', 50));
                        write.WriteLine(new string('-', 50));

                    }
                    ListBoxEvents.AddOneColumnToListBox(listBox1,"Urun_Ad", "Urunler");
                }
            }

        }

        private void DeletedProducts()
        {
            using (SqlConnection conn = new SqlConnection(Database.DatabaseString))
            { 
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("INSERT INTO SilinenUrunler (Urun_Ad, KategoriId, BirimId, Miktar, Stok, Fiyat,SilinmeTarihi,UserId) " +
                                                        "SELECT Urun_Ad, KategoriId, BirimId, Miktar, Stok, Fiyat,@silinmetarihi,@userid " +
                                                        "FROM Urunler" +
                                                        " WHERE Urun_Ad = @urunad", conn))
                {
                    var productName = listBox1.SelectedItem.ToString();
                    cmd.Parameters.AddWithValue("@urunad", productName);
                    cmd.Parameters.AddWithValue("@silinmetarihi", DateTime.Now);
                    cmd.Parameters.AddWithValue("@userid",UserCredentials.Id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void RemoveProduct_Load(object sender, EventArgs e)
        {
			ListBoxEvents.AddOneColumnToListBox(listBox1, "Urun_Ad", "Urunler");
		}

        private void button1_Click(object sender, EventArgs e)
        {
	        if (listBox1.SelectedItem != null)
	        {
		        DeletedProducts();
		        DeleteProduct();
	        }
	        else
	        {
		        MessageBox.Show("Ürün seçiniz.");
	        }

        }
        private void RemoveProduct_FormClosed(object sender, FormClosedEventArgs e)
        {
       
            Menu menu = new Menu();
            menu.Show();
        }
    }
}
