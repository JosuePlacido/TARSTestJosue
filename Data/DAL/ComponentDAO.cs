using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TARSTestJosue.Models;

namespace TARSTestJosue.Data.DAO
{
	public class ComponentDAO : DAOBase<Component>, IDAOComponent
	{
		public ComponentDAO(ApplicationContext context) : base(context) { }
		public async Task<Component[]> GetList(string category, int page, int take)
		{
			category = category?.ToLower();
			return await _context.Components.Where(c => string.IsNullOrEmpty(category)
				|| c.Category.ToLower().Contains(category))
				.Include(c => c.Prices).OrderBy(c => c.Product)
				.Skip((page - 1) * take).Take(take).ToArrayAsync();
		}
		public override async Task<Component> GetById(int id)
		{
			return await _context.Components.Where(c => c.Id == id).Include(c => c.Prices)
				.FirstOrDefaultAsync();
		}

		public async Task<string[]> GetCategorys()
		{
			return await _context.Components.Select(c => c.Category).Distinct().ToArrayAsync();
		}

		public async Task<string[]> GetCompanys()
		{
			return await _context.Components.Select(c => c.Company).Distinct().ToArrayAsync();
		}
		public async Task UpdateItems(Item[] items)
		{
			if (items.Length > 0)
			{
				_context.Items.RemoveRange(_context.Items.Where(i => i.ComponentId == items[0].ComponentId));
				await _context.Items.AddRangeAsync(items);
			}
		}

		public async Task<string[]> GetNames()
		{
			return await _context.Components.Select(c => c.Name).Distinct().ToArrayAsync();
		}

		public async Task<int> Count(string category)
		{
			category = category?.ToLower();
			return await _context.Components.Where(c => string.IsNullOrEmpty(category)
				|| c.Category.ToLower().Contains(category)).CountAsync();
		}
	}
}
