using Microsoft.EntityFrameworkCore;

namespace DapperApp.DataContext
{
    public class ApplicationDBContext:DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }
    }
}
