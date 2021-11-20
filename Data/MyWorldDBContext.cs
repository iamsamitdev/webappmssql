using webappmssql.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace webappmssql.Data
{
    public class MyWorldDBContext: DbContext
    {
        public MyWorldDBContext(DbContextOptions<MyWorldDBContext> options): base(options)
        {

        }

        public DbSet<Gadgets> Gadgets {get; set; }
    }
}
