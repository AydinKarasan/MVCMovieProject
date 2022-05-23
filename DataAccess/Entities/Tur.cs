using AppCoreV2.Records.Bases;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Entities
{
    public class Tur : RecordBase // ili�kileri kur ve kontrol et 
    {
        [Required]
        [StringLength(100)]
        public string Adi { get; set; }
        public List<FilmTur> FilmTurler { get; set; } // bir t�r�n birden �ok filmi olabilir // many to many
    }
}
