using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DVDRental.Models;

namespace DVDRental.Models
{
    public class DVDCopy
    {
        public DVDCopy()
        {
            Loan = new HashSet<Loan>();
        }
        [Key]
        public int CopyNumber { get; set; }

        [Column(TypeName = "Date")]
        public DateTime DatePurchased { get; set; }

        [ForeignKey("DVDTitle")]
        public int DVDNumber { get; set; }

        public virtual DVDTitle DVDTitle{ get; set; }
        public virtual IEnumerable<Loan> Loan{ get; set; }
    }
}
