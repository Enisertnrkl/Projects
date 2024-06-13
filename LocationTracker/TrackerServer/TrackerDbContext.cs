using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace TrackerServer
{
	internal class TrackerDbContext : DbContext
	{
		public DbSet<User> Users { get; set; }
		public DbSet<State> States { get; set; }
		public DbSet<Taxi> Taxis { get; set; }
		public DbSet<Location> Locations { get; set; }
		protected override void OnConfiguring(DbContextOptionsBuilder opt)
		{
			opt.UseSqlServer("Server=10.147.17.3,1433;User ID=enis.ertnrkl;password=enis2002;Database=KerviDb;TrustServerCertificate=True;");
		}
		protected override void OnModelCreating(ModelBuilder model)
		{
			model.Entity<Taxi>()
				.HasOne(t => t.User)
				.WithMany()
				.HasForeignKey(t => t.UserId);
			model.Entity<Taxi>()
				.HasOne(t => t.State)
				.WithMany()
				.HasForeignKey(t => t.StateId);
			model.Entity<Location>()
				.HasOne(t => t.User)
				.WithMany()
				.HasForeignKey(t => t.UserId);
		}
	}
	public class User
	{
		public int Id { get; set; }
		public string UserName { get; set; }
		public string Password { get; set; }
		public string Plate { get; set; }
	}
	public class State
	{
		public int Id { get; set; }
		public string Status { get; set; }
	}

	public class Taxi
	{
		[Key]
		public int Id { get; set; }
		public int UserId { get; set; }
		public int StateId { get; set; }
		public int QueueNumber { get; set; }
		public User User { get; set; }
		public State State { get; set; }
	}
	public class Location
	{
		public int Id { get; set; }
		public int UserId { get; set; }
		public double Latitude { get; set; }
		public double Longtitude { get; set; }
		public DateTime Timestamp { get; set; }
		public User User { get; set; }
	}
}

