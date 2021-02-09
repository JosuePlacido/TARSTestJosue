using System;
using System.ComponentModel.DataAnnotations;
using TARSTestJosue.Models.Shared;

namespace TARSTestJosue.Models
{
	public class Status : IEquatable<Status>
	{
		private Status(string status, string color = "#ffffff")
		{
			Description = status;
			Color = color;
		}

		public static readonly Status Studyng = new Status("studying", "#ffaaaa");
		public static readonly Status Selected = new Status("Selected", "#ff5500");
		public static readonly Status Purchased = new Status("Purchased", "#aaccff");
		public static readonly Status Comparing = new Status("Comparing", "#ffffaa");
		public static readonly Status Alternative = new Status("Alternative", "#aaffbb");
		public string Description { get; private set; }
		public string Color { get; private set; }

		public bool Equals(Status other)
		{
			if (object.ReferenceEquals(other, null)) return false;
			if (object.ReferenceEquals(other, this)) return true;
			return this.Description.Equals(other.Description) && this.Color.Equals(other.Color);
		}

		public override bool Equals(object obj)
		{
			return Equals(obj as Status);
		}

		public override int GetHashCode()
		{
			return this.Description.GetHashCode() ^ this.Color.GetHashCode();
		}

		public override string ToString()
		{
			return Description;
		}
	}
}
