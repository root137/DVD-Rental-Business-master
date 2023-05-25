using System.ComponentModel.DataAnnotations;

namespace DVDRental.Models
{
    public class Producer
    {
        public Producer()
        {
            DVDTitle = new HashSet<DVDTitle>();
        }
        [Key]
        public int ProducerNumber { get; set; }

        public string ProducerName { get; set; }
        public virtual ICollection<DVDTitle> DVDTitle{ get; set; }    
    }
}
