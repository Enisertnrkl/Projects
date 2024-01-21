using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using System.Runtime.CompilerServices;

namespace Stockmanagement
{
    public partial  class classes: Form
    {
        public classes()
        {
            InitializeComponent();
        }       

    }

    public class ComboBoxEvents
    {
	    //Query'e göre yazılan combobox'u doldurur.
	    public static void FillCombobox(string TableName, string ColumnName, ComboBox combobox)
	    {
		    using (SqlConnection conn = new SqlConnection(Database.DatabaseString))
		    {
			    conn.Open();
			    using (SqlCommand cmd = new SqlCommand($"SELECT {ColumnName} FROM {TableName}", conn))
			    {
				    using (SqlDataReader reader = cmd.ExecuteReader())
				    {
					    while (reader.Read())
					    {
						    combobox.Items.Add(reader[0].ToString());
					    }
				    }
			    }
		    }
	    }
    }

    public class GetId
    {
	    //Query'e göre seçilen tablodaki combobox'tan gelen parametrenin id'sini döndürür
	    public static int GetIdByParameter(string TableName, string ColumnName, ComboBox Parameter)
	    {
		    using (SqlConnection conn = new SqlConnection(Database.DatabaseString))
		    {
			    conn.Open();
			    using (SqlCommand cmd = new SqlCommand($"SELECT Id FROM {TableName} WHERE {ColumnName} = @{ColumnName}",
				           conn))
			    {
				    cmd.Parameters.AddWithValue($"@{ColumnName}", Parameter.SelectedItem.ToString());
				    return (int)cmd.ExecuteScalar();
			    }
		    }
	    }
	    //query'e göre seçilen tablodaki string den gelen parametrenin id'sini döndürür.
	    public static int GetIdByParameter(string TableName, string ColumnName, string Parameter)
	    {
		    using (SqlConnection conn = new SqlConnection(Database.DatabaseString))
		    {
			    conn.Open();
			    using (SqlCommand cmd = new SqlCommand($"SELECT Id FROM {TableName} WHERE {ColumnName} = @{ColumnName}",
				           conn))
			    {
				    cmd.Parameters.AddWithValue($"@{ColumnName}", Parameter);
				    return (int)cmd.ExecuteScalar();
			    }
		    }
	    }
	}

    public class ListBoxEvents
    {
        //seçilen listboxa query göre tek bir sütunun verisini ekler
	    public static void AddOneColumnToListBox(ListBox listBox, string column, string table)
	    {
		    try
		    {
			    string query = $"SELECT {column} FROM {table}";
			    using (SqlConnection conn = new SqlConnection(Database.DatabaseString))
			    {
				    conn.Open();
				    using (SqlCommand cmd = new SqlCommand(query, conn))
				    {
					    SqlDataReader reader = cmd.ExecuteReader();
					    listBox.Items.Clear();
					    while (reader.Read())
					    {
						    listBox.Items.Add(reader[$"{column}"]);
					    }   
				    }

			    }
		    }
		    catch (Exception ex)
		    {
			    MessageBox.Show(ex.Message);
		    }
	    }
	}
    //ürün adına göre stoğu döndürür
    public  class Stock
    {
        public static string GetStock(string urunad)
        {
            using (SqlConnection conn = new SqlConnection(Database.DatabaseString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT Stok FROM Urunler WHERE Urun_Ad = @urunad", conn))
                {
                    cmd.Parameters.AddWithValue("@urunad", urunad);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        return dr[0].ToString();
                    }
                }
            }

            return null;
        }
    }

    //ürün adına göre fiyatı döndürür
    public class Price
    {
        public static decimal GetPrice(string urunad)
        {
            using (SqlConnection conn = new SqlConnection(Database.DatabaseString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT  Fiyat FROM Urunler WHERE Urun_Ad =@urunad", conn))
                {
                    cmd.Parameters.AddWithValue("@urunad", urunad);
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            return decimal.Parse(dr[0].ToString());
                        }
                    }
                }
            }

            return 0;
        }
    }

    //ürün adına göre birimi döndürür
    public  class Unit
    {
        public static string GetUnit(string urunad)
        {
            using (SqlConnection conn = new SqlConnection(Database.DatabaseString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT BirimTablo.Birim FROM Urunler INNER JOIN BirimTablo ON Urunler.BirimId = BirimTablo.Id WHERE Urun_Ad = @urunad", conn))
                {
                    cmd.Parameters.AddWithValue("@urunad", urunad);
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            return dr["Birim"].ToString();
                        }
                    }
                }
            }

            return null;
        }
    }

    //ürün adına göre miktarı döndürür
    public class Quantity
    {
        public static string GetQuantity(string urunad)
        {
            using (SqlConnection conn = new SqlConnection(Database.DatabaseString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT Miktar FROM Urunler WHERE Urun_Ad = @urunad", conn))
                {
                    cmd.Parameters.AddWithValue("@urunad", urunad);
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            {
                                return dr[0].ToString();
                            }
                        }
                    }
                }
            }

            return null;
        }
    }

    //Ürün adına göre kategoriyi döndürür
    public class Category
    {
        public static string GetCategory(string urunad)
        {
            using (SqlConnection conn = new SqlConnection(Database.DatabaseString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT Kategori.KategoriAd FROM Urunler  INNER JOIN Kategori ON Urunler.KategoriId = Kategori.Id WHERE Urun_Ad = @urunad", conn))
                {
                    cmd.Parameters.AddWithValue("@urunad", urunad);
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            return dr["KategoriAd"].ToString();
                        }
                    }
                }
            }

            return null;
        }
    }

   
    // kullanıcı bilgilerini içeren class
    public static class UserCredentials
    {
	
	    public static int Id { get; private set; }
	    public static string UserName { get; private set; }
	    public static string Password { get; private set; }
	    public static string Name { get; private set; }
	    public static string LastName { get; private set; }
	    public static string Role { get; private set; }

	    public class UserManager
	    {
            //Kullanıcı adına göre veritabanında karşılık gelen kullanıcı bilgilerini UserCredentials nesnesine doldurur
		    public static void GetCurrentUserInfo(string username)
		    {
			    using (SqlConnection conn = new SqlConnection(Database.DatabaseString))
			    {

				    conn.Open();
				    using (SqlCommand cmd =
				           new SqlCommand(
					           "SELECT UserList.Id,Username,Password,Name,Surname,Roles.Role FROM UserList INNER JOIN Roles ON UserList.RoleId = Roles.Id WHERE Username = @username",
					           conn))
				    {
					    cmd.Parameters.AddWithValue("@username", username);
					    using (SqlDataReader reader = cmd.ExecuteReader())
					    {

						    if (reader.Read())
						    {
							    UserCredentials .Id = reader.GetInt32(0);
							    UserCredentials .UserName = reader.GetString(1);
							    UserCredentials .Password = reader.GetString(2);
							    UserCredentials .Name = reader.GetString(3);
							    UserCredentials .LastName = reader.GetString(4);
							    UserCredentials .Role = reader.GetString(5);
						    }
					    }
				    }
			    }
		    }
	    }
    }


    //Product sınıfından oluşturulan nesneleri içeren liste
    public class ProductList
    {
	    public static List<Product> _Products = new();
    }

    //ürün bilgilerini içeren class
    public class Product 
    {
        public string ProductName { get; set; }
        public string Category { get; set; }
        public string Unit { get; set; }
        public string Quantity { get; set; }
        public int Stock { get; set; } 
        [Browsable(false)]
        public int OldStock { get; set; }
        public decimal SellPrice { get; set; }
        public decimal Profit { get; set; }
        public decimal PercentProfit { get; set; }
        public string AddedByUser =>  UserCredentials.Name + " " + UserCredentials.LastName;
    }

    //Stoğun kontrol edilip edilmediğini kontrol eden class
    public class StokKontrol
    {
        public static bool IsControlled { get; set; } 
    }
}
//veritabanı connectionstring'i
public class Database
{ 
	public static string DatabaseString => "Data Source =MYPCDOG\\SQLEXPRESS; Initial Catalog=Management; Integrated Security=True;Connect Timeout=30;Encrypt=False;";
}

