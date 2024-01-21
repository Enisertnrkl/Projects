using System;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace Stockmanagement
{
    public partial class AddProduct : Form
    {
        public AddProduct()
        {
            InitializeComponent();
        }

		//textbox boş ise true döndürür ve mesajı döndürür
        private bool IsNullOrEmpty(TextBox textbox,string message)
        {
            if(string.IsNullOrEmpty(textbox.Text))
            {
                MessageBox.Show(message);
                return true;
            }
            return false;
        }
      

        private bool AddNewProduct()
        {

                using (SqlConnection conn = new SqlConnection(Database.DatabaseString))
                {
                    conn.Open();
                    
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO Urunler (Urun_Ad,BirimId,Miktar,Fiyat,Stok,KategoriId,EklenmeTarihi,UserId) VALUES" +
                        "(@urunad,@birimid,@miktar,@fiyat,@stok,@kategoriid,@eklenmetarihi,@userid)", conn))
                    {
                        cmd.Parameters.AddWithValue("@urunad", textBox1.Text);
                        cmd.Parameters.AddWithValue("@birimid", GetId.GetIdByParameter("BirimTablo", "Birim", comboBox2));
                        cmd.Parameters.AddWithValue("@miktar", string.IsNullOrEmpty(textBox2.Text) ? (object)DBNull.Value : textBox2.Text);
                        cmd.Parameters.AddWithValue("@fiyat", decimal.Parse(textBox4.Text));
                        cmd.Parameters.AddWithValue("@stok", textBox3.Text);
                        cmd.Parameters.AddWithValue("kategoriid", GetId.GetIdByParameter("Kategori", "KategoriAd", comboBox1));
                        cmd.Parameters.AddWithValue("@eklenmetarihi", DateTime.Now);
                        cmd.Parameters.AddWithValue("@userid", UserCredentials.Id);
                        int affectedrows = cmd.ExecuteNonQuery();
                        return affectedrows > 0;
                    }
                }
        }


        private bool IsProductExists()
        {
            using (SqlConnection conn = new SqlConnection(Database.DatabaseString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT Urun_Ad FROM Urunler WHERE Urun_Ad = @urunad",conn))
                {
                    cmd.Parameters.AddWithValue("@urunad", textBox1.Text);
                    SqlDataReader reader = cmd.ExecuteReader();
                    return reader.Read();
                }
                
            }
        }

        private void AddProduct_Load(object sender, EventArgs e)
        {
            ComboBoxEvents.FillCombobox("Kategori","KategoriAd",comboBox1);
            ComboBoxEvents.FillCombobox("BirimTablo","Birim",comboBox2);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (IsNullOrEmpty(textBox1, "Ürün Adı boş bırakılamaz") ||
                IsNullOrEmpty(textBox3, "Stok miktarı boş bırakılamaz") ||
                IsNullOrEmpty(textBox4, "Fiyat seçimi boş bırakılamaz") ||
               (comboBox2.SelectedItem.ToString() == "Gram" && IsNullOrEmpty(textBox2, "Miktar seçimi boş bırakılamaz")))
            {
                return;
            }

            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Kategori seçimi boş bırakılamaz.");
                return;
            }
            if(comboBox2.SelectedIndex == -1)
            {
                MessageBox.Show("Birim seçimi boş bırakılamaz.");
                return;
            }

            if (IsProductExists())
            {
                MessageBox.Show("Ürün zaten mevcut");
                return;
            }

            DialogResult result = MessageBox.Show("Bilgilerin Doğruluğundan emin misiniz?", "", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                if(AddNewProduct())
                {
                        MessageBox.Show("Ürün Eklendi!");
                        string LogFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "log.txt");
                        using (StreamWriter writer = File.AppendText(LogFilePath))
                        {
                            writer.WriteLine("Ürün Ekleme");
                            writer.WriteLine(new string('-', 50));
                            writer.WriteLine($"Yeni Ürün Adı : {textBox1.Text}");
                            writer.WriteLine($"Kategori: {comboBox1.SelectedItem.ToString()}");
                            writer.WriteLine($"Birim : {comboBox2.SelectedItem.ToString()}");
                            if (comboBox2.SelectedItem.ToString() == "Gram" )
                            {
                                writer.WriteLine($"Miktar: {textBox2.Text} Gram");
                            }
                            if (comboBox2.SelectedItem.ToString() == "Kilogram" )
                            {
                                writer.WriteLine($"Miktar: {textBox2.Text} Kilogram");
                            }
                            writer.WriteLine($"Stok : {textBox3.Text} Adet");
                            writer.WriteLine($"Fiyat : {textBox4.Text} TL");
                            writer.WriteLine($"Eklenme Tarihi :{DateTime.Now}");
                            writer.WriteLine($"Ekleyen Kişi :{UserCredentials.Name}");
                            writer.WriteLine(new string('-', 50));
                          
                        }
                        textBox1.Text = null;
                        textBox2.Text = null;
                        textBox3.Text = null;
                        textBox4.Text = null;
                        comboBox1.SelectedItem = null; 
                        comboBox2.SelectedItem = null;
                        this.Close();
                }
                else
                {
                        MessageBox.Show("Ürün eklenirken bir hatayla karşılaşıldı!");
                }
            }
        }
        
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox2.SelectedIndex != -1)
            {
                if(comboBox2.SelectedItem.ToString() == "Adet")
                {
                    textBox2.Enabled = false;
                }
                else { textBox2.Enabled = true; }
            }
        }

        private void AddProduct_FormClosed(object sender, FormClosedEventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
        }
    }
}
