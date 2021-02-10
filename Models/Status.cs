using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using TARSTestJosue.Models.Shared;

namespace TARSTestJosue.Models
{
	public class Status : IEquatable<Status>
	{
		private Status(string description)
		{
			Description = description;
		}

		public static readonly Status Studyng = new Status("Studyng");
		public static readonly Status Selected = new Status("Selected");
		public static readonly Status Purchased = new Status("Purchased");
		public static readonly Status Comparing = new Status("Comparing");
		public static readonly Status Alternative = new Status("Alternative");
		private static readonly IDictionary<string, Status> _list = new Dictionary<string, Status>()
		{
			["Studyng"] = Studyng,
			["Selected"] = Selected,
			["Purchased"] = Purchased,
			["Comparing"] = Comparing,
			["Alternative"] = Alternative,
		};
		public static Status[] All()
		{
			return _list.Select(i => i.Value).ToArray();
		}
		public string Description { get; private set; }
		public string Color { get; private set; }

		public bool Equals(Status other)
		{
			if (object.ReferenceEquals(other, null)) return false;
			if (object.ReferenceEquals(other, this)) return true;
			return this.Description.Equals(other.Description);
		}

		public static Status ByName(string status)
		{
			return _list[status];
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
