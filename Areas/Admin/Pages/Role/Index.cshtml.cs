using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace App.Admin.Role
{
    public class IndexModel : RolePageModel
    {
        public IndexModel(RoleManager<IdentityRole> roleManager, AppDbContext appDbContext) : base(roleManager, appDbContext)
        {
        }

        public List<IdentityRole> roles {set;get;}

        public async Task OnGet()
        {
            roles = await _roleManager.Roles.OrderBy(r => r.Name).ToListAsync();
        }
        
        public void OnPost() => RedirectToPage();
    }
}
