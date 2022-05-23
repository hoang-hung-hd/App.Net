using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using App.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App.Admin.Role
{
    public class CreateModel : RolePageModel
    {
        public CreateModel(RoleManager<IdentityRole> roleManager, AppDbContext appDbContext) : base(roleManager, appDbContext)
        {
        }

        public class InputModel
        {
            [Display(Name ="Nhập tên vai trò mới")]
            [Required(ErrorMessage ="Phải nhập tên vai trò")]
            [StringLength(256, MinimumLength =3, ErrorMessage ="Độ dài {0} vai trò phải từ {2} -{1} ký tự")]
            public string Name {set;get;}
        }
        [BindProperty]
        public InputModel Input {set;get;}

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if  (!ModelState.IsValid)
            {
                return Page();
            }

            var newRole = new IdentityRole(Input.Name);
            var result = await _roleManager.CreateAsync(newRole);
            if (result.Succeeded)
            {
                StatusMessage = $"Bạn vừa tạo role mới: {Input.Name}";
                return RedirectToPage("./Index");
            }
            else
            {
                result.Errors.ToList().ForEach(error => {
                    ModelState.AddModelError(string.Empty, error.Description);
                });
            }

            return Page();
        }
    }
}
