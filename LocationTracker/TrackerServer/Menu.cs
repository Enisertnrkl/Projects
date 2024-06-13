using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaxiServer
{
	public partial class Menu : Form
	{
		TrackerDbContext context;
		public Menu()
		{
			context = new TrackerDbContext();
			InitializeComponent();
		}

		private void Form2_Load(object sender, EventArgs e)
		{
			timer1.Interval = 5000;
			timer1.Enabled = true;
			timer1.Tick += timer1_Tick;
			timer1.Start();
			gMapControl1.MapProvider = GMap.NET.MapProviders.BingMapProvider.Instance;
			GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;
			gMapControl1.Zoom = 14;
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			ListTaxis();
		}
		private void ListTaxis()
		{
			var taxis = context.Taxis.OrderBy(t => t.Id)
				.Select(t => new
				{
					Kişi = t.User.UserName,
					Plaka = t.User.Plate,
					Durum = t.State.Status,
					Sıra = t.QueueNumber,
				})
				.ToList();
			dataGridView1.DataSource = taxis;
		}
	}
}
