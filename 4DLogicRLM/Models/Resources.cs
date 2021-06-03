using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace _4DLogicRLM.Models
{
    public class Resources
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ResourceID { get; set; }
        public string ResourceName { get; set; }
        public string ResourceDescription { get; set; }
        public int ResourceTypeID { get; set; }
        public double RescourceQty { get; set; }
        public int ResourceQtyTypeID { get; set; }
        public int LocationID { get; set; }
        public bool MakePublic { get; set; }
    }

    public class ResourceType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ResourceTypeID { get; set; }
        public string ResourceTypeName { get; set; }
        public string ResourceTypeShortName { get; set; }
        public string ResourceTypeDescription { get; set; }

    }

    public class ResourceQuantityType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ResourceQuantityTypeID { get; set; }
        public string ResournceQuantityTypeName { get; set; }
        public string ResournceQuantityTypeDescription { get; set; }
        public string ResourceQuantityTypeShortName { get; set; }

    }
}
