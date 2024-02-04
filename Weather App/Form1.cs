using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Text.Json;
using DotNetEnv;
using Microsoft.Extensions.Configuration.UserSecrets;
using Microsoft.Extensions.Configuration;

namespace Weather_App
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}
		private async void button1_Click(object sender, EventArgs e)
		{

			if (!string.IsNullOrEmpty(cityName.Text))
			{	
				HttpClient httpClient = new HttpClient();
				HttpResponseMessage response = await httpClient.GetAsync(
					$" https://api.openweathermap.org/data/2.5/weather?q={cityName.Text}&units=metric&lang=tr&appid=");
				if (response.IsSuccessStatusCode)
				{
					string jsonString = await response.Content.ReadAsStringAsync();
					var weatherData = JsonSerializer.Deserialize<WeatherData>(jsonString);
					string city = cityName.Text;
					label3.Text = char.ToUpper(city[0]) + city.Substring(1);
					long unixSunrise = weatherData.sys.sunrise;
					long unixSunset = weatherData.sys.sunset;
					DateTime timeSunrise = DateTimeOffset.FromUnixTimeSeconds(unixSunrise).UtcDateTime;
					DateTime timeSunset = DateTimeOffset.FromUnixTimeSeconds(unixSunset).UtcDateTime;
					string sunrise = timeSunrise.Hour + 3.ToString("00") + ":" + timeSunrise.Minute.ToString("00");
					string sunset = timeSunset.Hour + 3.ToString("00") + ":" + timeSunset.Minute.ToString("00");
					string pictureUrl = $"https://openweathermap.org/img/wn/{weatherData.weather[0].icon}@2x.png";
					if (weatherData.weather[0].icon == "01d")
					{
						Color bgColor = ColorTranslator.FromHtml("#ffcc80");
						this.BackColor = bgColor;
						label1.ForeColor = ColorTranslator.FromHtml("#333333");
						label3.ForeColor = ColorTranslator.FromHtml("#333333");
						label2.ForeColor = ColorTranslator.FromHtml("#333333");
						label4.ForeColor = ColorTranslator.FromHtml("#333333");
						label5.ForeColor = ColorTranslator.FromHtml("#333333");

					}
					else if (weatherData.weather[0].icon == "01n")
					{
						this.BackColor = ColorTranslator.FromHtml("#2f2f2f");
						label1.ForeColor = ColorTranslator.FromHtml("#ffffff");
						label3.ForeColor = ColorTranslator.FromHtml("#ffffff");
						label2.ForeColor = ColorTranslator.FromHtml("#ffffff");
						label4.ForeColor = ColorTranslator.FromHtml("#ffffff");
						label5.ForeColor = ColorTranslator.FromHtml("#ffffff");
					}
					pictureBox1.ImageLocation = pictureUrl;
					
					label2.Text = "Hava durumu "+weatherData.weather[0].description;
					label4.Text = "Sıcaklık: "+weatherData.main.temp.ToString()+" C";
					label5.Text = "Rüzgar Hızı: "+weatherData.wind.speed.ToString()+" km/h";

				}

				else
				{
					MessageBox.Show("The weather with this city name could not found.");
				}
			}
			else
			{
				MessageBox.Show("City name cannot be empty.");
			}
		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}

		private void label3_Click(object sender, EventArgs e)
		{

		}

		private void label2_Click(object sender, EventArgs e)
		{

		}
	}
}
