using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DVDRental.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public int UserNumber { get; set; }

        public string UserName { get; set; }

        public string UserType { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(100, MinimumLength = 5,
            ErrorMessage = "Password must contain between 5 and 100 characters")]
        public string UserPassword { get; set; }
    }
}
