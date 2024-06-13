using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Windows.Forms;

namespace TrackerServer
{
	public partial class Menu : Form
	{
		private TrackerDbContext _context;
		private GMapOverlay markersOverlay;


		public Menu()
		{
			InitializeComponent();
			_context = new TrackerDbContext();
			markersOverlay = new GMapOverlay("markers");

			// Initialize the timer
			timer.Interval = 5000; // 5 seconds
			timer.Tick += new EventHandler(timer_Tick);
			timer.Start();
		}

		private void Menu_Load(object sender, EventArgs e)
		{
			// Map settings
			gMapControl1.MapProvider = GMap.NET.MapProviders.BingMapProvider.Instance;
			GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;

			// Load initial markers and data
			LoadMarkers();
			LoadData();
		}

		private void LoadMarkers()
		{
			try
			{
				// Clear existing markers
				markersOverlay.Markers.Clear();

				// Get the latest locations from the database
				var locations = _context.Locations.OrderByDescending(p => p.Id).ToList();

				foreach (var location in locations)
				{
					var latitude = location.Latitude;
					var longitude = location.Longtitude;

					// Get additional information such as username
					var user = _context.Users.FirstOrDefault(u => u.Id == location.UserId);
					string userName = user != null ? user.UserName : "Bilinmeyen Kullanıcı";

					// Create and add the marker
					GMapMarker marker = new GMarkerGoogle(new PointLatLng(latitude, longitude), GMarkerGoogleType.red_dot);
					marker.ToolTipText = $"Kullanıcı: {userName}";
					marker.ToolTipMode = MarkerTooltipMode.OnMouseOver; // Tooltip only shown on mouse over

					markersOverlay.Markers.Add(marker);
				}

				// Add markers overlay to the map
				if (!gMapControl1.Overlays.Contains(markersOverlay))
				{
					gMapControl1.Overlays.Add(markersOverlay);
				}

				// Set map position to the last added location (if any)
				if (locations.Any())
				{
					var lastLocation = locations.First();
					gMapControl1.Position = new PointLatLng(lastLocation.Latitude, lastLocation.Longtitude);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Marker eklenirken bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void timer_Tick(object sender, EventArgs e)
		{
			// Refresh data context to get the latest data
			_context = new TrackerDbContext();

			// Reload markers and data on timer tick
			LoadMarkers();
			LoadData();
		}

		private void addUserToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// Show the add user form
			AddUser addUser = new AddUser();
			addUser.Show();
			this.Hide();
		}

		private void LoadData()
		{
			var taxis = _context.Taxis
				.OrderBy(t => t.QueueNumber)
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
