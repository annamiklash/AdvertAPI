using System.ComponentModel.DataAnnotations.Schema;

namespace AdvertAPI.Models
{
    public class Banner
    {
        public int IdAdvertisement { get; set; }
        public string Name { get; set; }
        [Column(TypeName = "decimal(6, 2)")]
        public decimal Price { get; set; }
        [Column(TypeName = "decimal(6, 2)")]
        public decimal Area { get; set; }

        public int IdCampaign { get; set; }
        public virtual Campaign Campaign { get; set; }

    }
}