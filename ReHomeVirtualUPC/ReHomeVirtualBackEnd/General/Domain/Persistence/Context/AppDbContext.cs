using Microsoft.EntityFrameworkCore;


namespace ReHomeVirtualBackEnd.General.General.Persistence.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        
            //builder.ApplySnakeCaseNamingConvention();
    }

}
