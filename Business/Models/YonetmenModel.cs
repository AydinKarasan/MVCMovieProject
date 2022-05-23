using AppCoreV2.Records.Bases;
using System.ComponentModel.DataAnnotations;

namespace Business.Models
{
    public class YonetmenModel : RecordBase
    {
        #region
        [Required]
        [StringLength(100)]
        public string Adi { get; set; }
        #endregion
    }
}
