using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using webcoretest.Data;
using webcoretest.Model;

namespace webcoretest.Pages.Users
{
    public class DetailsModel : PageModel
    {
        private readonly webcoretest.Data.webcoretestContext _context;

        public DetailsModel(webcoretest.Data.webcoretestContext context)
        {
            _context = context;
        }

      public UserApp UserApp { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.UserApp == null)
            {
                return NotFound();
            }

            var userapp = await _context.UserApp.FirstOrDefaultAsync(m => m.Id == id);
            if (userapp == null)
            {
                return NotFound();
            }
            else 
            {
                UserApp = userapp;
            }
            return Page();
        }
    }
}
