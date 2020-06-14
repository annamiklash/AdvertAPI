using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdvertAPI.Models
{
    public class Campaign
    {
        public int IdCampaign { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        [Column(TypeName = "decimal(6, 2)")]
        public decimal PricePerSquareMeter { get; set; }
        public virtual IEnumerable<Banner> Banner { get; set; }
        public int FromIdBuilding { get; set; }
        public virtual Building FromBuilding { get; set; }
        public int ToIdBuilding { get; set; }
        public virtual Building ToBuilding { get; set; }
        public int IdClient { get; set; }
        public virtual Client Client { get; set; }

    }
}