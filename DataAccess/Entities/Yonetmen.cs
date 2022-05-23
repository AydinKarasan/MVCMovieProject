using AppCoreV2.Records.Bases;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Entities
{
    public class Yonetmen : RecordBase
    {
        [Required]
        [StringLength(100)]
        public string Adi { get; set; }
        public List<Film> Filmler { get; set; }
    }
}
