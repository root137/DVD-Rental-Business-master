using System.ComponentModel.DataAnnotations;

namespace DVDRental.Models
{
    public class Studio
    {
        public Studio()
        {
            DVDTitle = new HashSet<DVDTitle>();
        }
        [Key]
        public int StudioNumber { get; set; }
        public string StudioName { get; set; }
        public virtual ICollection<DVDTitle> DVDTitle { get; set; }
    }
}
