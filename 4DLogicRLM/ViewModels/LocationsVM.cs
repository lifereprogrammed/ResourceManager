using _4DLogicRLM.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _4DLogicRLM.ViewModels
{
    public class LocationsVM
    {
        public int? LocationID { get; set; }
        public string LocationName { get; set; }
        public string LocationDescription { get; set; }
        public string LocationString { get; set; }
        public string LatLon { get; set; }
        public int CountryID { get; set; }
        public List<Country> Countries { get; set; }
        public string CountryName { get; set; }
        public int ProvinceID { get; set; }
        public List<Province> Provinces { get; set; }
        public string ProvinceName { get; set; }
        public string ConvertedLatLon { get; set; }
        public string UserID { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string ResourceName { get; set; }
        public int ResourceID { get; set; }
        public int ResourceTypeID { get; set; }
        public List<ResourceType> ResourceTypes { get; set; }
        public string ResourceTypeName { get; set; }
        public int ResourceQty { get; set; }
        public int ResourceQtyTypeID { get; set; }
        public List<ResourceQuantityType> QuantityTypes { get; set; }
        public string ResourceQType { get; set; }
        public string LegalSubdivision { get; set; }
        public byte Section { get; set; }
        public byte Township { get; set; }
        public byte Range { get; set; }
        public string Meridian { get; set; }
        public bool LocationActive { get; set; }
        public string CompanyID { get; set; }
    }

    public class LocationsJSON
    {
        public DateTime ExpirationDate { get; set; }
        public int LocationID { get; set; }
        public string LocationName { get; set; }
        public string LatLon { get; set; }
        public string LocationDLS { get; set; }
        public string ResourceName { get; set; }
        public string ResourceType { get; set; }
        public int ResourceQty { get; set; }
        public string ResourceQtyType { get; set; }
        public string CompanyName { get; set; }
    }

    public class geoJSON
    {
        public string type { get; set; }
        public List<geoJSONFeatures> features { get; set; }
    }
    public class geoJSONFeatures
    {
        public string type { get; set; }
        public geoJSONFeaturesGeometry geometry { get; set; }
        public geoJSONFeaturesProperties properties { get; set; }
        
    }
    public class geoJSONFeaturesGeometry
    {
        public string type { get; set; }
        public double[] coordinates { get; set; }
    }
    public class geoJSONFeaturesProperties
    {
        public string title { get; set; }
        public string description { get; set; }
    }

    public class ConvertDLS
    {
        public string legalSubdivision { get; set; }
        public byte section { get; set; }
        public byte township { get; set; }
        public byte range { get; set; }
        public string meridian { get; set; }
        public string quarter { get; set; }
    }

    public class LegalSubdivision
    {
        public string LSD { get; set; }
    }
    public class section
    {
        public byte Section { get; set; }
    }
    public class township
    {
        public byte Township { get; set; }
    }
    public class range
    {
        public byte Range { get; set; }
    }
    public class meridian
    {
        public string Meridian { get; set; }
    }
}
