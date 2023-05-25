using System.ComponentModel.DataAnnotations;

namespace DVDRental.Models
{
    public class DVDCategory
    {
        public DVDCategory()
        {
            DVDTitle = new HashSet<DVDTitle>();
        }
        [Key]
        public int CategoryNumber { get; set; }


        public string CategoryDescription { get; set; }

        public Boolean AgeRestricted { get; set; }
        public virtual ICollection<DVDTitle> DVDTitle { get; set; }
    }
}
