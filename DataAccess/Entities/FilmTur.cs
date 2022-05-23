
using AppCoreV2.Records.Bases;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entities
{
    public class FilmTur 
    {
        [Key]
        [Column(Order = 0)]
        public int FilmId { get; set; }
        public Film Film { get; set; }
        [Key]
        [Column(Order =1 )]
        public int TurId { get; set; }
        public Tur Tur { get; set; }
    }
}
