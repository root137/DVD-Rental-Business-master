using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DVDRental.Models
{
    public class Loan
    {
        [Key]
        public int LoanNumber { get; set; }

        [Column(TypeName="Date")]
        public DateTime DateOut { get; set; }

        [Column(TypeName="Date")]
        public DateTime DateDue { get; set; }

        [Column(TypeName="Date")]
        public DateTime? DateReturned { get; set; }

        [ForeignKey("LoanType")]
        public int LoanTypeNumber { get; set; }

        [ForeignKey("DVDCopy")]
        public int CopyNumber { get; set; }

        [ForeignKey("Member")]
        public int MemberNumber { get; set; }

        public virtual DVDCopy DVDCopy { get; set; }
        public virtual LoanType LoanType{ get; set; }
        public virtual Member Member{ get; set; }

    }
}
