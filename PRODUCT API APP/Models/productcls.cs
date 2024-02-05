using Microsoft.EntityFrameworkCore;

namespace PRODUCT_API_APP.Models
{
    public class productcls:DbContext
    {
        public productcls(DbContextOptions<productcls> options):base(options) 
        { 
        }
        public DbSet<Products> Products { get; set; }
             
       
    }
}
