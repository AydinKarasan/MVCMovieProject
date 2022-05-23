using AppCoreV2.Records.Bases;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Entities
{
    public class Film : RecordBase // ili�kileri kur ve kontrol et 
    {
        [Required]
        [StringLength(200)]
        public string Adi { get; set; }
        public string Aciklamasi { get; set; }        
        public DateTime? VizyonTarihi { get; set; }  // null alabilir            
        public double ImdbPuan� { get; set; }
        
        public int YonetmenId { get; set; }
        public Yonetmen Yonetmen { get; set; } //bir filmin bir y�netmeni olabilir // one to one 
        public List<FilmTur> FilmTurler { get; set; } // bir filmin birden �ok t�r� olabilir / one to many
    }
}
