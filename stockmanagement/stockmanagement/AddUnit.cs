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
	public partial class AddUnit : Form
	{
		public AddUnit()
		{
			InitializeComponent();
		}

		private void AddUnit_Load(object sender, EventArgs e)
		{
			ListBoxEvents.AddOneColumnToListBox(listBox1,"Birim","BirimTablo");
		}

		private void button1_Click(object sender, EventArgs e)
		{
			using (SqlConnection conn = new SqlConnection(Database.DatabaseString))
			{
				conn.Open();
				using (SqlCommand cmd = new SqlCommand("INSERT INTO BirimTablo (Birim) VALUES (@birim)",conn))
				{
					cmd.Parameters.AddWithValue("@birim", textBox1.Text);
					int affectedrows = cmd.ExecuteNonQuery();
					if (affectedrows > 0)
					{
						MessageBox.Show("Birim eklendi");
						ListBoxEvents.AddOneColumnToListBox(listBox1, "Birim", "BirimTablo");

					}
					else
					{
						MessageBox.Show("Birim eklenirken bir sorun oluştu.");
					}
				}
			}
		}

		private void AddUnit_FormClosing(object sender, FormClosingEventArgs e)
		{
			Menu menu = new Menu();
			menu.Show();

		}
	}
}
