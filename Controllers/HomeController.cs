using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TARSTestJosue.Data.DAO;
using TARSTestJosue.Models;
using TARSTestJosue.ViewModels;
using AutoMapper;

namespace TARSTestJosue.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly IDAOComponent _dao;
		private readonly IMapper _mapper;

		public HomeController(ILogger<HomeController> logger, IDAOComponent dao, IMapper mapper)
		{
			_dao = dao;
			_logger = logger;
			_mapper = mapper;
		}

		public async Task<IActionResult> Index(string category = "", int page = 1, int take = 15)
		{
			return View(new IndexModel
			{
				Category = category,
				Page = page,
				Take = take,
				Total = await _dao.Count(category),
				Items = await _dao.GetList(category, page, take)
			});
		}
		public async Task<IActionResult> Component(int id)
		{
			return View(await _dao.GetById(id));
		}
		public async Task<IActionResult> Edit(int? id)
		{
			EditModel viewModel;
			if (id == null)
			{
				viewModel = new EditModel();

			}
			else
			{
				Component result = await _dao.GetById((int)id);
				viewModel = result == null ? new EditModel() :
					_mapper.Map<EditModel>(result);
			}

			viewModel.Categorys = await _dao.GetCategorys();
			viewModel.Brands = await _dao.GetCompanys();
			viewModel.Names = await _dao.GetNames();
			return View(viewModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(EditModel form)
		{
			if (ModelState.IsValid)
			{
				try
				{
					Component component = _mapper.Map<Component>(form);
					if (component.Id == null)
					{
						await _dao.Add(component);
					}
					else
					{
						await _dao.UpdateItems(component.Prices.ToArray());
						await _dao.Update(component);
					}
					await _dao.Commit();
					return RedirectToAction(nameof(Index));
				}
				catch (Exception ex)
				{
					_logger.LogError(ex.Message);
				}
			}
			return View(form);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Delete(int id)
		{
			try
			{
				Component component = await _dao.GetById(id);
				await _dao.Delete(component);
				await _dao.Commit();
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
				return BadRequest();
			}
			return RedirectToAction(nameof(Index));
		}
		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
