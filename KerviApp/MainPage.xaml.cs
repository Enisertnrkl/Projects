using Microsoft.Data.SqlClient;
using System;
using System.Threading.Tasks;

namespace KerviApp
{
	public partial class MainPage : ContentPage
	{
		private bool isTimerRunning = false;
		private string connectionString = "Server=10.147.17.3;Database=KerviDb;User Id=enis.ertnrkl;password=enis2002;TrustServerCertificate=True;";

		public MainPage()
		{
			InitializeComponent();
		}

		private void StartTimer()
		{
			Device.StartTimer(TimeSpan.FromSeconds(5), () =>
			{
				if (!isTimerRunning)
					return false;

				GetCurrentLocation();
				return true; // True to continue running, false to stop
			});
		}

		private void onWay_Clicked(object sender, EventArgs e)
		{
			isTimerRunning = true;
			StartTimer();
		}

		private void StopTimer()
		{
			isTimerRunning = false;
		}

		private async Task GetCurrentLocation()
		{
			try
			{
				GeolocationRequest request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));
				Location location = await Geolocation.GetLocationAsync(request);

				if (location != null)
				{
					string username = await SecureStorage.GetAsync("username");
					if (!string.IsNullOrEmpty(username))
					{
						int userId = await GetIdByUsername(username);
						if (userId != -1)
						{
							await UpsertLocationToDatabase(userId, location.Latitude, location.Longitude, DateTime.Now);
						}
						else
						{
							await DisplayAlert("Error", "User not found.", "OK");
						}
					}
					else
					{
						await DisplayAlert("Error", "Username could not be retrieved.", "OK");
					}
				}
			}
			catch (FeatureNotSupportedException fnsEx)
			{
				await DisplayAlert("Error", "Location feature not supported on this device.", "OK");
			}
			catch (FeatureNotEnabledException fneEx)
			{
				await DisplayAlert("Error", "Location services are not enabled.", "OK");
			}
			catch (PermissionException pEx)
			{
				await DisplayAlert("Error", "Location permissions are not granted.", "OK");
			}
			catch (Exception ex)
			{
				await DisplayAlert("Error", $"An error occurred while getting location: {ex.Message}", "OK");
			}
		}

		private async Task UpsertLocationToDatabase(int userId, double latitude, double longitude, DateTime timestamp)
		{
			try
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					await connection.OpenAsync();
					using (SqlCommand command = new SqlCommand(
						"IF EXISTS (SELECT 1 FROM Locations WHERE UserId = @userId) " +
						"UPDATE Locations SET Latitude = @latitude, Longtitude = @longitude, Timestamp = @timestamp WHERE UserId = @userId " +
						"ELSE " +
						"INSERT INTO Locations (UserId, Latitude, Longtitude, Timestamp) VALUES (@userId, @latitude, @longitude, @timestamp)", connection))
					{
						command.Parameters.AddWithValue("@userId", userId);
						command.Parameters.AddWithValue("@latitude", latitude);
						command.Parameters.AddWithValue("@longitude", longitude);
						command.Parameters.AddWithValue("@timestamp", timestamp);
						await command.ExecuteNonQueryAsync();
					}
				}
			}
			catch (Exception ex)
			{
				await DisplayAlert("Error", $"An error occurred while adding to database: {ex.Message}", "OK");
			}
		}

		private async Task<int> GetIdByUsername(string username)
		{
			try
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();
					using (SqlCommand command = new SqlCommand("SELECT Id FROM Users WHERE UserName = @username", connection))
					{
						command.Parameters.AddWithValue("@username", username);
						object result = command.ExecuteScalar();
						if (result != null)
						{
							return Convert.ToInt32(result);
						}
					}
				}
			}	
			catch (Exception ex)
			{
				await DisplayAlert("Error", $"An error occurred while querying database: {ex.Message}", "OK");
			}
			return -1;
		}

		private void Stop_Clicked(object sender, EventArgs e)
		{
			StopTimer();
		}
	}
}