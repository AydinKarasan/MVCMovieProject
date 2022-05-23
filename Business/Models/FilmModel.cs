using AppCoreV2.Records.Bases;
using System.ComponentModel.DataAnnotations;

namespace Business.Models
{
    public class FilmModel : RecordBase
    {
        #region
        [Required]
        [StringLength(200)]
        public string Adi { get; set; }
        public string Aciklamasi { get; set; }
        public DateTime? VizyonTarihi { get; set; }
        [Required]
        public int YapimYili { get; set; }       
        public double ImdbPuaný { get; set; }
        #endregion
    }
}
