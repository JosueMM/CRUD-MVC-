using Microsoft.EntityFrameworkCore;

namespace CRUD.Models
{
    public class CRUDContext : DbContext
    {
        public CRUDContext (DbContextOptions<CRUDContext> options)
            : base(options)
        {
            
        }

        public DbSet<CRUD.Models.CarModel> Car { get; set; }
        public DbSet<CRUD.Models.MakeModel> Make { get; set; }
       
    }
}