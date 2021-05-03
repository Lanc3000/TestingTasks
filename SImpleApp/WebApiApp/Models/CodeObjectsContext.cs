using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebApiApp.Models
{
    public class CodeObjectsContext: DbContext
    {
        public DbSet<CodeObject> CodeObjects { get; set; }

        public CodeObjectsContext(DbContextOptions<CodeObjectsContext> options): base(options)
        {
            Database.EnsureCreated();
        }
    }
}
