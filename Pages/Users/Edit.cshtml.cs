using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using webcoretest.Data;
using webcoretest.Model;

namespace webcoretest.Pages.Users
{
    public class EditModel : PageModel
    {
        private readonly webcoretest.Data.webcoretestContext _context;

        public EditModel(webcoretest.Data.webcoretestContext context)
        {
            _context = context;
        }

        [BindProperty]
        public UserApp UserApp { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.UserApp == null)
            {
                return NotFound();
            }

            var userapp =  await _context.UserApp.FirstOrDefaultAsync(m => m.Id == id);
            if (userapp == null)
            {
                return NotFound();
            }
            UserApp = userapp;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(UserApp).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserAppExists(UserApp.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool UserAppExists(int id)
        {
          return (_context.UserApp?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
