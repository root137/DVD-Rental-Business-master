using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DVDRental.Models
{

    [Microsoft.EntityFrameworkCore.Keyless]
    public class CastMember
    {
        [ForeignKey("DVDTitle")]
        public int DVDNumber { get; set; }

        [ForeignKey("Actor")]
        public int ActorNumber { get; set; }

        public virtual DVDTitle DVDTitle { get; set; }
        public virtual Actor Actor{ get; set; }
    }
}
