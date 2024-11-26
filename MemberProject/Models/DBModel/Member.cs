using System.ComponentModel.DataAnnotations.Schema;

namespace MemberProject.Models.DBModel
{
    public class Member
    {
        [NotMapped]
        public const string TABLE_NAME = "Member";
        public int id { get; set; }
        public string memberAccount { get; set; }
        public string memberPassword { get; set; }
        public string email { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public DateTime createDate { get; set; }
        public string creator { get; set; }
        public DateTime? modifyDate { get; set; }
        public string? modifier { get; set; }
        public bool isDelete { get; set; }
    }
}
