using MemberProject.Context;
using MemberProject.Manager;
using MemberProject.Models.DBModel;
using MemberProject.Models.ViewModel;
using MemberProject.Utils;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MemberProject.Service
{
    public class MemberService : MemberManager
    {
        public MemberService(MemberDbContext db):base(db)
        {
            _db = db;
        }
        public async Task<int> Save(ApplicViewModel applicViewModel)
        {
            string password = EncryptUtil.EncryptAES(applicViewModel.memberPass);

            Member member = new Member();
            member.memberAccount = applicViewModel.memberAcc;
            member.memberPassword = password;
            member.firstName = applicViewModel.firstName;
            member.lastName = applicViewModel.lastName;
            member.email = applicViewModel.email;
            member.createDate = DateTime.Now;
            member.creator = applicViewModel.firstName + applicViewModel.lastName;
            member.isDelete = false;
            _db.Entry(member).State = EntityState.Added;
            return await _db.SaveChangesAsync();
        }
    }
}
