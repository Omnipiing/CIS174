using Microsoft.EntityFrameworkCore;

namespace MDPwebApp.Areas.Admin.Models
{
    public class RequestContext : DbContext
    {
        public RequestContext(DbContextOptions<RequestContext> options)
           : base(options)
        { }

        public DbSet<Requestor> Requests { get; set; } = null!;

    }
}
