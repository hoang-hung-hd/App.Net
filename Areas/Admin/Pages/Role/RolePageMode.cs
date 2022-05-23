using App.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App.Admin.Role
{
    public class RolePageModel : PageModel
    {
        protected readonly RoleManager<IdentityRole> _roleManager;
        protected readonly AppDbContext _appDbContext;

        [TempData]
        public string StatusMessage {set;get;}

        public RolePageModel(RoleManager<IdentityRole> roleManager, AppDbContext appDbContext)
        {
            _roleManager = roleManager;
            _appDbContext = appDbContext;
        }


    }
}