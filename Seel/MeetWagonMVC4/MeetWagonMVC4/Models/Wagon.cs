using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeetWagonMVC4.Models
{
	public class Wagon
	{
		public int WagonId { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public DateTime DateAdded { get; set; }

		public virtual ICollection<UserProfile> UserProfiles { get; set; }
	}

	public class WagonCreateRequest
	{
		public string Name { get; set; }
		public string Description { get; set; }
	}

	public class WagonEditRequest
	{
		public int WagonId { get; set; }
		public string Description { get; set; }
	}

	public class WagonDetailsResponse
	{
		public Wagon Wagon { get; set; }
		public string FbLikeButtonData { get; set; }
	}
}