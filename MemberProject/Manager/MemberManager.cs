using MemberProject.Context;
using MemberProject.Models.DBModel;
using Microsoft.EntityFrameworkCore;

namespace MemberProject.Manager
{
    public class MemberManager
    {
        public MemberDbContext _db;
        public MemberManager(MemberDbContext db)
        {
            _db = db;
        }
        public IQueryable<Member> GetEntitiesQ(bool isTracking = false)
        {
            if (isTracking)
                return _db.Member.Where(item => !item.isDelete);
            else
                return _db.Member.AsNoTracking().Where(item => !item.isDelete);
        }
    }
}
