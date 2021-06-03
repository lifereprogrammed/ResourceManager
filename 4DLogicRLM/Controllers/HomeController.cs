using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using _4DLogicRLM.Data;
using _4DLogicRLM.Models;
using _4DLogicRLM.ViewModels;
using SurveyGridLibrary;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using _4DLogicRLM.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;
using System.Diagnostics;
using Microsoft.Extensions.Configuration;

namespace _4DLogicRLM.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<_4DLogicRLMUser> _userManager;

        public HomeController(
            ApplicationDbContext context,
            UserManager<_4DLogicRLMUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult Map([FromServices] IConfiguration config)
        {
            var token = config.GetValue<string>("MapboxToken");
            ViewData["MapboxToken"] = token;
            return View();
        }

        [Authorize]
        public async Task<JsonResult> GetLocations()
        {
            List<LocationsJSON> locations = new List<LocationsJSON>();
            List<Locations> modelLocations = await _context.Locations.Where(e => e.ExpirationDate > DateTime.Today).ToListAsync();
            List<Resources> modelResources = await _context.Resources.ToListAsync();
            List<Company> modelCompanies = await _context.Companies.ToListAsync();
            List<ResourceType> modelResourceTypes = await _context.ResourceTypes.ToListAsync();
            List<ResourceQuantityType> modelQuantityTypes = await _context.ResourceQuantityTypes.ToListAsync();

            geoJSON geoJSON = new geoJSON();
            geoJSON.type = "FeatureCollection";
            
            List<geoJSONFeatures> features = new List<geoJSONFeatures>();
            Double latitude = new double();
            Double longitude = new double();

            foreach(var item in modelLocations)
            {
                geoJSONFeaturesGeometry featuresGeometry = new geoJSONFeaturesGeometry();
                geoJSONFeaturesProperties featuresProperties = new geoJSONFeaturesProperties();
                latitude = Convert.ToDouble(item.ConvertedLatLon.Split(",").First());
                longitude = Convert.ToDouble(item.ConvertedLatLon.Split(",").Last());

                featuresGeometry.type = "Point";
                featuresGeometry.coordinates = new double[] { longitude, latitude };
                featuresProperties.title = item.LocationName;
                featuresProperties.description =
                    modelResourceTypes.FirstOrDefault(
                        i => i.ResourceTypeID == modelResources.FirstOrDefault(
                            r => r.LocationID == item.LocationID).ResourceTypeID).ResourceTypeName
                    + "<br />" +
                    modelResources.FirstOrDefault(r => r.LocationID == item.LocationID).RescourceQty
                    + " " + modelQuantityTypes.FirstOrDefault(q => q.ResourceQuantityTypeID == modelResources.FirstOrDefault(i => i.LocationID == item.LocationID).ResourceQtyTypeID).ResourceQuantityTypeShortName
                    + "<br />" + 
                    "<a href=\"~/Locations/Details/" + item.LocationID + "\">More Info</a>";

                features.Add(new geoJSONFeatures
                {
                    type = "Feature",
                    geometry = featuresGeometry,
                    properties = featuresProperties
                });
            }
            geoJSON.features = features;

            return Json(geoJSON);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
