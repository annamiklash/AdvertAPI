using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdvertAPI.Models
{
    public class Building
    {
        public int IdBuilding { get; set; }
        public string Street { get; set; }
        public int StreetNumber { get; set; }
        public string City { get; set; }
        [Column(TypeName = "decimal(6, 2)")]
        public decimal Height { get; set; }

        public virtual IEnumerable<Campaign> CampaignFrom { get; set; }
        public virtual IEnumerable<Campaign> CampaignTo { get; set; }

    }
}