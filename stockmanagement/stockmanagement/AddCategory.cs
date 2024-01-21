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
using Stockmanagement;
using Menu = Stockmanagement.Menu;

namespace stockmanagement
{
	public partial class AddCategory : Form
	{
		public AddCategory()
		{
			InitializeComponent();
		}

		//textbox parametresindeki kategori verisinin veritabanında karşılığı olup olmadığına bakar
		public static bool IsCategoryExists(TextBox textbox)
		{
			using (SqlConnection conn = new SqlConnection(Database.DatabaseString))
			{
				conn.Open();
				using (SqlCommand cmd = new SqlCommand("SELECT KategoriAd FROM Kategori WHERE KategoriAd = @kategoriad",conn))
				{
					cmd.Parameters.AddWithValue("@kategoriad", textbox.Text);
					using(SqlDataReader reader = cmd.ExecuteReader())
					{
						return reader.HasRows;
					}
				}
			}
		}

		private void AddCategory_Load(object sender, EventArgs e)
		{
			ListBoxEvents.AddOneColumnToListBox(listBox1, "KategoriAd", "Kategori");
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (!IsCategoryExists(textBox1))
			{
				if (!string.IsNullOrEmpty(textBox1.Text))
				{
					using (SqlConnection conn = new(Database.DatabaseString))
					{
						conn.Open();
						using (SqlCommand cmd = new("INSERT INTO Kategori (KategoriAd) VALUES (@kategoriad) ", conn))
						{
							cmd.Parameters.AddWithValue("@kategoriad", textBox1.Text);
							int affectedrows = cmd.ExecuteNonQuery();
							if (affectedrows > 0)
							{
								MessageBox.Show("Kategori Eklendi");
								ListBoxEvents.AddOneColumnToListBox(listBox1, "KategoriAd", "Kategori");

							}
						}

					}
				}
				else
				{
					MessageBox.Show("Kutucuğu boş bırakamazsınız");
				}
			}
			else
			{
				MessageBox.Show("Bu kategori zaten mevcut");
			}
		}

		private void AddCategory_FormClosing(object sender, FormClosingEventArgs e)
		{
			Menu menu = new Menu();
			menu.Show();
		}
	}
}
