using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrackerServer
{
	public partial class AddUser : Form
	{
		TrackerDbContext context = new TrackerDbContext();
		public AddUser()
		{
			InitializeComponent();
		}

		private void AddUser_FormClosed(object sender, FormClosedEventArgs e)
		{
			Menu menu = new Menu();
			menu.Show();
		}

		private void regbutton_Click(object sender, EventArgs e)
		{
			var existingUser = context.Users.Where(u => u.UserName == regusername.Text).FirstOrDefault();
			if (existingUser == null)
			{
				User user = new User();
				{
					user.UserName = regusername.Text;
					user.Password = regpassword.Text;
					user.Plate = regplate.Text;
				}
				context.Add(user);
				context.SaveChanges();
				MessageBox.Show("Kullanıcı oluşturuldu");
				Taxi taxi = new Taxi();
				{
					taxi.StateId = 2;
					taxi.UserId = user.Id;
				}
				context.Add(taxi);
				context.SaveChanges();
				return;

			}
			MessageBox.Show("Bu kullanıcı adına sahip bir kullanıcı zaten mevcut.");

		}
	}
}
