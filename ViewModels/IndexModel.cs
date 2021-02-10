using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TARSTestJosue.Models;

namespace TARSTestJosue.ViewModels
{
	public class IndexModel
	{
		public string Category { get; set; }
		public int Page { get; set; }
		public int Take { get; set; }
		public int Total { get; set; }
		public Component[] Items { get; set; }
	}
}
