using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TARSTestJosue.ViewModels
{
	public class EditModel
	{
		public IList<SelectListItem> StatusOptions { get; set; } = Models.Status.All()
						  .Select(s => new SelectListItem()
						  {
							  Value = s.Description,
							  Text = s.Description
						  }).ToList();
		public string[] Categorys { get; set; }
		public string[] Brands { get; set; }
		public string[] Names { get; set; }

		public int? Id { get; set; }
		[MaxLength(100)]
		public string Requirement { get; set; }
		public string Status { get; set; }
		[Required]
		[MaxLength(100)]
		public string Name { get; set; }
		[MaxLength(100)]
		public string Product { get; set; }
		[MaxLength(100)]
		public string Company { get; set; }
		[MaxLength(100)]
		public string Version { get; set; }
		[DataType(DataType.Date)]
		public DateTime? DateBuy { get; set; }
		public decimal? DolarRealBuy { get; set; }
		[Required]
		[MaxLength(100)]
		public string Category { get; set; }
		[MaxLength(300)]
		public string URL { get; set; }
		[MaxLength(200)]
		public string Extra { get; set; }
		public int Priority { get; set; }
		public string[] URLs { get; set; }
		public string[] Store { get; set; }
		public decimal[] Amount { get; set; }
		public string[] Currency { get; set; }
	}
}
