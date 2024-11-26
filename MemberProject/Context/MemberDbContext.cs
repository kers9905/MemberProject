using MemberProject.Models.DBModel;
using Microsoft.EntityFrameworkCore;

namespace MemberProject.Context
{
    public class MemberDbContext : DbContext
    {
        public MemberDbContext(DbContextOptions<MemberDbContext> options)
    : base(options)
        {
        }
        public DbSet<Member> Member { get; set; }
    }
}
