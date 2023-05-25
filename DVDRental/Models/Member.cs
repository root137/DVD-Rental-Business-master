using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DVDRental.Models
{
    public class Member
    {
        public Member()
        {
            Loan = new HashSet<Loan>();
        }
        [Key]
        public int MemberNumber { get; set; }

        public string MemberLastName { get; set; }

        public string MemberFirstName { get; set; }

        public string MemberAddress { get; set; }

        [Column(TypeName = "Date")]
        public DateTime MemberDateOfBirth { get; set; }

        [ForeignKey("MembershipCategory")]
        public int MemberCategoryNumber { get; set; }

        public virtual MembershipCategory MembershipCategory { get; set; }

        public virtual ICollection<Loan> Loan { get; set; }
        [NotMapped]
        public virtual int LoanCount { get; set; }

    }
}
