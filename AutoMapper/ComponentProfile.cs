using System;
using System.Linq;
using AutoMapper;
using TARSTestJosue.Models;
using TARSTestJosue.ViewModels;

namespace TARSTestJosue.AutoMapper
{
	public class ComponentProfile : Profile
	{
		public ComponentProfile()
		{
			CreateMap<Component, EditModel>()
				.ForMember(dst => dst.Currency, opt => opt.MapFrom(src =>
					src.Prices.Select(p => p.Price.Currency)))
				.ForMember(dst => dst.Amount, opt => opt.MapFrom(src =>
					src.Prices.Select(p => p.Price.Amount)))
				.ForMember(dst => dst.Store, opt => opt.MapFrom(src =>
					src.Prices.Select(p => p.Store)))
				.ForMember(dst => dst.URLs, opt => opt.MapFrom(src =>
					src.Prices.Select(p => p.URL)))
				.ForMember(dst => dst.Brands, opt => opt.Ignore())
				.ForMember(dst => dst.Categorys, opt => opt.Ignore());

			CreateMap<EditModel, Component>()
				.ForMember(dst => dst.Prices, opt => opt.MapFrom(src =>
					src.Store.Select((item, index) => new Item(
						item,
						src.Currency[index],
						src.Amount[index],
						src.URLs[index],
						src.Id))
				))
				.ForMember(dst => dst.Status, opt => opt.MapFrom(src => Status.ByName(src.Status)))
				.ForMember(dst => dst.LastUpdated, opt => opt.MapFrom(sourceMember => DateTime.Now));
		}

	}
}
