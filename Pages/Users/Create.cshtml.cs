using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using webcoretest.Data;
using webcoretest.Model;

namespace webcoretest.Pages.Users
{
    public class CreateModel : PageModel
    {
        private readonly webcoretest.Data.webcoretestContext _context;

        public CreateModel(webcoretest.Data.webcoretestContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public UserApp UserApp { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
			//if (!ModelState.IsValid || _context.UserApp == null || UserApp == null)
			//  {
			//      return Page();
			//  }

			//  _context.UserApp.Add(UserApp);
			//  await _context.SaveChangesAsync();

			//  return RedirectToPage("./Index");

			var emptyUserApp = new UserApp();

			if (await TryUpdateModelAsync<UserApp>(
				emptyUserApp,
				"UserApp",   // Prefix for form value.
				u => u.Id, u => u.Name, u => u.Email))
			{
				_context.UserApp.Add(emptyUserApp);
				await _context.SaveChangesAsync();
				return RedirectToPage("./Index");
			}

			return Page();
		}
    }
}
