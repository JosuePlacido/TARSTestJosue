using System.Threading.Tasks;
using TARSTestJosue.Models;

namespace TARSTestJosue.Data.DAO
{
	public interface IDAOComponent : IDAO<Component>
	{
		Task<Component[]> GetList(string category, int page, int take);
		Task<string[]> GetCategorys();
		Task<string[]> GetCompanys();
		Task UpdateItems(Item[] items);
		Task<string[]> GetNames();
		Task<int> Count(string category);
	}
}
