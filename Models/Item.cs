using System;
using System.ComponentModel.DataAnnotations;
using TARSTestJosue.Models.Shared;

namespace TARSTestJosue.Models
{
	public class Item : Entity
	{
		public Item(string store, string currency, decimal amount, string url = "", int? component = 0)
		{
			Store = store;
			URL = url;
			Price = new Price(currency, amount);
			ComponentId = (int)component;
			LastUpdated = DateTime.Now;
		}

		private Item() { }

		public int ComponentId { get; private set; }
		public Component Component { get; private set; }
		public string URL { get; private set; }
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
