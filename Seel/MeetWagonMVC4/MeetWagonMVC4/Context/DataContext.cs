using MeetWagonMVC4.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MeetWagonMVC4.Context
{
	public class DataContext : DbContext
	{
		public DataContext()
			: base("DefaultConnection")
		{
		}

		public DbSet<UserProfile> UserProfiles { get; set; }
		public DbSet<Wagon> Wagons { get; set; }
	}
}