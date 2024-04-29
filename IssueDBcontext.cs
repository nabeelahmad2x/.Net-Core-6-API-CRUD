using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace myCoreAPI.Data
{
    public class IssueDBcontext : DbContext
    {
        public IssueDBcontext(DbContextOptions<IssueDBcontext> options) : base(options)
        {

        }
        public DbSet<Issue> Issues { get; set; }
    }
}