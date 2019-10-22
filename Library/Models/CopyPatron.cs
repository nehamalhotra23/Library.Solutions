using System.ComponentModel.DataAnnotations.Schema;
namespace Library.Models
{
    public class CopyPatron
    {
        public int CopyPatronId { get; set; }
        public int CopyId { get; set; }
        public int PatronId { get; set; }
        //checkout date
        //checkin date
        //returned (?)

        [ForeignKey("CopyId")]
        public Copy Copy { get; set; }
        [ForeignKey("PatronId")]
        public Patron Patron { get; set; }
    }
}