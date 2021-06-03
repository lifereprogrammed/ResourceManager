using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace _4DLogicRLM.Models
{
    public class Locations
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LocationID { get; set; }
        public string LocationName { get; set; }
        public string Description { get; set; }
        public int LocationType { get; set; }
        public string Location { get; set; }
        public string LatLon { get; set; }
        public int ProvinceID { get; set; }
        public int CountryID { get; set; }
        public string ConvertedLatLon { get; set; }
        public string CompanyID { get; set; }
        public string UserID { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool LocationActive { get; set; }
    }

    public class LocationType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LocationTypeID { get; set; }
        public string LocationTypeName { get; set; }
        public string LocationTypeDescription { get; set; }
    }

    public class Province
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProvinceID { get; set; }
        public int CountryID { get; set; }
        public string ProvinceName { get; set; }
        public string ProvinceShortName { get; set; }
        public string KMLFile { get; set; }

    }

    public class Country
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CountryID { get; set; }
        public string CountryName { get; set; }
        public string CountryShortName { get; set; }
        public string KMLFile { get; set; }
    }
}
