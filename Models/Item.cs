using System;
using System.ComponentModel.DataAnnotations;
using TARSTestJosue.Models.Shared;

namespace TARSTestJosue.Models
{
	public class Item : Entity
	{
		private Item() { }

		public int ComponentId { get; private set; }
		public Component Component { get; private set; }
		public string Store { get; private set; }
		public Price Price { get; private set; }
		[DataType(DataType.Date)]
		public DateTime? LastUpdated { get; private set; }

		public override string ToString()
		{
			return $"{Store} {Price}";
		}
	}
}
