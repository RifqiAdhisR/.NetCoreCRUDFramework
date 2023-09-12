using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using webcoretest.Model;

namespace webcoretest.Data
{
    public class webcoretestContext : DbContext
    {
        public webcoretestContext (DbContextOptions<webcoretestContext> options)
            : base(options)
        {
        }

        public DbSet<webcoretest.Model.UserApp> UserApp { get; set; } = default!;
    }
}
