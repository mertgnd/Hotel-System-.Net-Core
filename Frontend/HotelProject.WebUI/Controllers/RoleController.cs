using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Models.Role;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelProject.WebUI.Controllers
{
	public class RoleController : Controller
	{
		private readonly RoleManager<AppRole> _roleManager;

		public RoleController(RoleManager<AppRole> roleManager)
		{
			_roleManager = roleManager;
		}

		public IActionResult Index()
		{
			var roles = _roleManager.Roles.ToList();
			return View(roles);
		}

		[HttpGet]
		public IActionResult AddRole() 
		{
			return View();		
		}

        [HttpPost]
        public async Task<IActionResult> AddRole(AddRoleViewModel request)
        {
			AppRole appRole = new AppRole()
			{
				Name = request.RoleName
			};

			var result = await _roleManager.CreateAsync(appRole);
			if(result.Succeeded)
			{
				return RedirectToAction("Index");
			}

            return View();
        }

		public async Task<IActionResult> DeleteRole(int id)
		{
			var value = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
			await _roleManager.DeleteAsync(value);
			return RedirectToAction("Index");
		}

		[HttpGet]
		public IActionResult UpdateRole(int id)
		{
			var value = _roleManager.Roles.FirstOrDefault(x => x.Id == id);

			UpdateRoleViewModel updateRoleViewModel = new UpdateRoleViewModel()
			{
				RoleId = value.Id,
				RoleName = value.Name
			};

			return View(updateRoleViewModel);
		}

		[HttpPost]
		public async Task<IActionResult> UpdateRole(UpdateRoleViewModel request)
		{
			var value = await _roleManager.Roles.FirstOrDefaultAsync(x =>  x.Id == request.RoleId);
			value.Name = request.RoleName;
			await _roleManager.UpdateAsync(value);
			return RedirectToAction("Index");
		}
    }
}
