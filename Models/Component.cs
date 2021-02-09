using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TARSTestJosue.Models.Shared;

namespace TARSTestJosue.Models
{
	public class Component : Entity
	{
		private Component() { }
		public string Name { get; private set; }
		public string Company { get; private set; }
		public string Version { get; private set; }
		public Status Status { get; private set; }
		[DataType(DataType.Date)]
		public DateTime? DateBuy { get; private set; }
		public decimal? DolarRealBuy { get; private set; }
		public string Category { get; private set; }
		public string Requirement { get; private set; }
		public string Extra { get; private set; }
		public int Priority { get; private set; }
		public List<Item> Prices { get; private set; } = new List<Item>();


		public override string ToString()
		{
			return $"{Company} {Name} {Version}";
		}
	}
}
