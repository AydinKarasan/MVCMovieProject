using AppCoreV2.Records.Bases;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Entities
{
    public class Tur : RecordBase // iliþkileri kur ve kontrol et 
    {
        [Required]
        [StringLength(100)]
        public string Adi { get; set; }
        public List<FilmTur> FilmTurler { get; set; } // bir türün birden çok filmi olabilir // many to many
    }
}
