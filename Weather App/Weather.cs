using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather_App
{

	public class WeatherData
	{
		public int id { get; set; }
		public Weather[] weather { get; set; }
		public Main main { get; set; }
		public Wind wind { get; set; }
		public Sys sys { get; set; }
	}

	public class Weather
	{
		public int id { get; set; }
		public string main { get; set; }
		public string description { get; set; }
		public string icon { get; set; }

	}
		
	public class Main
	{
		public float temp { get; set; }
		public float feelslike { get; set; }
		public float pressure { get; set; }
		public float humidity { get; set; }
	}

	public class Wind
	{
		public float speed { get; set; }
		public float deg { get; set; }
	}

	public class Sys
	{
		public long sunrise { get; set; }
		public long sunset { get; set; }
	}

}
