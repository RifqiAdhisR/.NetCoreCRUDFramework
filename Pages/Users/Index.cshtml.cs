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
    public class IndexModel : PageModel
    {
        private readonly webcoretest.Data.webcoretestContext _context;

        public IndexModel(webcoretest.Data.webcoretestContext context)
        {
            _context = context;
        }

        public IList<UserApp> UserApp { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.UserApp != null)
            {
                UserApp = await _context.UserApp.ToListAsync();
            }
        }
    }
}
