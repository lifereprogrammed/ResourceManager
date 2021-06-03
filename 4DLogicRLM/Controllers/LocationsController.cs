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

namespace _4DLogicRLM.Controllers
{
    [Authorize]
    public class LocationsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHostingEnvironment _hostingEnv;
        private readonly UserManager<_4DLogicRLMUser> _userManager;

        public LocationsController(
            ApplicationDbContext context,
            IHostingEnvironment hostingEnv, 
            UserManager<_4DLogicRLMUser> userManager)
        {
            _context = context;
            _hostingEnv = hostingEnv;
            _userManager = userManager;
        }

        // GET: Locations
        public async Task<IActionResult> Index()
        {
            List<LocationsVM> locationsVM = new List<LocationsVM>();
            List<Locations> locations = await _context.Locations.Where(e => e.ExpirationDate > DateTime.Today).ToListAsync();
            List<Resources> resources = await _context.Resources.ToListAsync();
            Resources resource = new Resources();
            foreach(var item in locations)
            {
                resource = resources.FirstOrDefault(i => i.LocationID == item.LocationID);
                locationsVM.Add(new LocationsVM
                {
                    ExpirationDate = item.ExpirationDate,
                    LocationID = item.LocationID,
                    LocationName = item.LocationName,
                    LocationDescription = item.Description,
                    LocationString = item.Location,
                    LatLon = item.ConvertedLatLon,
                    LocationActive = item.LocationActive,
                    CountryName = _context.Countries.FirstOrDefault(c => c.CountryID == item.CountryID).CountryName,
                    ProvinceName = _context.Provinces.FirstOrDefault(p => p.ProvinceID == item.ProvinceID).ProvinceName,
                    ResourceName = resource.ResourceName,
                    ResourceTypeName = _context.ResourceTypes.FirstOrDefault(i => i.ResourceTypeID == resource.ResourceTypeID).ResourceTypeName,
                    ResourceQty = (int)resource.RescourceQty,
                    ResourceQType = _context.ResourceQuantityTypes.FirstOrDefault(i => i.ResourceQuantityTypeID == resource.ResourceQtyTypeID).ResourceQuantityTypeShortName
                });
            }

            return View(locationsVM);
        }

        // GET: Locations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);

            if (id == null)
            {
                return NotFound();
            }
            
            var locations = await _context.Locations
                .FirstOrDefaultAsync(m => m.LocationID == id);
            if (locations == null)
            {
                return NotFound();
            }

            return View(locations);
        }

        // GET: Locations/Create
        [Authorize]
        public async Task<IActionResult> Create()
        {
            List<LegalSubdivision> LSD = new List<LegalSubdivision>();
            List<section> section = new List<section>();
            List<township> township = new List<township>();
            List<range> range = new List<range>();
            List<meridian> meridian = new List<meridian>();

            LSD.Add(new LegalSubdivision { LSD = "NE" });
            LSD.Add(new LegalSubdivision { LSD = "NW" });
            LSD.Add(new LegalSubdivision { LSD = "SE" });
            LSD.Add(new LegalSubdivision { LSD = "SW" });

            for (var i = 0; i < 15; i++)
            {
                if(i < 9)
                {
                    LSD.Add(new LegalSubdivision {  LSD = "0" + (i + 1) });
                }
                else
                {
                    LSD.Add(new LegalSubdivision {  LSD = (i + 1).ToString() });
                }
            }
            for (var i = 0; i < 35; i++)
            {
                section.Add(new section { Section = Convert.ToByte(i + 1) });
            }
            for (var i = 0; i < 127; i++)
            {
                township.Add(new ViewModels.township { Township = Convert.ToByte(i + 1) });
            }
            for (var i = 0; i < 33; i++)
            {
                range.Add(new ViewModels.range { Range = Convert.ToByte(i + 1) });
            }
            for (var i = 0; i < 5; i++)
            {
                meridian.Add(new ViewModels.meridian { Meridian = "W" + (i + 1) });
            }

            ViewData["LegalSubdivision"] = new SelectList(LSD, "LSD", "LSD");
            ViewData["Section"] = new SelectList(section, "Section", "Section");
            ViewData["Township"] = new SelectList(township, "Township", "Township");
            ViewData["Range"] = new SelectList(range, "Range", "Range");
            ViewData["Meridian"] = new SelectList(meridian, "Meridian", "Meridian");

            ViewData["Countries"] = new SelectList(await _context.Countries.ToListAsync(), "CountryID", "CountryName");
            ViewData["Provinces"] = new SelectList(await _context.Provinces.ToListAsync(), "ProvinceID", "ProvinceName");
            ViewData["ResourceType"] = new SelectList(await _context.ResourceTypes.ToListAsync(), "ResourceTypeID", "ResourceTypeName");
            ViewData["ResourceQuantityType"] = new SelectList(await _context.ResourceQuantityTypes.ToListAsync(), "ResourceQuantityTypeID", "ResournceQuantityTypeName");

            return View();
        }

        
        public JsonResult ConvertLSDtoLatLon (ConvertDLS dls)
        {
            DlsSystem lsd = new DlsSystem();
            dls.meridian = dls.meridian.Substring(1);
            switch (dls.legalSubdivision)
            {
                case "NW":
                    dls.legalSubdivision = "11";
                    break;
                case "NE":
                    dls.legalSubdivision = "10";
                    break;
                case "SW":
                    dls.legalSubdivision = "6";
                    break;
                case "SE":
                    dls.legalSubdivision = "7";
                    break;
            }
             string Error = "";
            string location = dls.quarter + dls.legalSubdivision + "-" + dls.section + "-" + dls.township + "-" + dls.range + "-W" + dls.meridian;
            DlsSystem lsd2 = new DlsSystem();
            try
            {
                lsd2 = DlsSystem.Parse(location, ParseOptions.AllowQuarters);
            }
            catch (CoordinateParseException e)
            {
                Error = e.ToString();
                return Json(Error);
            }
           
            LatLongCoordinate latlonC = new LatLongCoordinate();

            //if(dls.quarter == null)
            //{
            //    try
            //    {
            //       // lsd = new DlsSystem(Convert.ToByte(dls.legalSubdivision), dls.section, dls.township, dls.range, dls.meridian);
            //        latlonC = DlsSystemConverter.ToLatLong(lsd);
            //    }
            //    catch (CoordinateParseException e)
            //    {
            //        Error = e.ToString();
            //    }
                
            //}
            //else
            //{
                try
                {
                    latlonC = DlsSystemConverter.ToLatLong(lsd2);
                }
                catch(CoordinateParseException e)
                {
                    Error = e.ToString();
                }
                
           // }
            if(Error != "")
            {
                return Json(Error);
            }
            string ll = latlonC.Latitude.ToString() + ", " + latlonC.Longitude.ToString();
            //LatLongCoordinate latLongCoordinate = DlsSystemConverter.ToLatLong(lsd);
            return Json(ll);
        }

        // POST: Locations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LocationName, LocationDescription, LocationString, LatLon, CountryId, ProvinceID, ConvertedLatLon, ExpirationDate, ResourceName, ResourceTypeID, ResourceQty, ResourceQtyTypeID,LegalSubdivision, Section, Township, Range, Meridian")] LocationsVM locations)
        {
            var user = await _userManager.GetUserAsync(User);
            Resources resource = new Resources();
            Locations location2 = new Locations();
            string dls = locations.LegalSubdivision + "-" + locations.Section + "-" + locations.Township + "-" + locations.Range + locations.Meridian;
            DlsSystem dlsParsed = DlsSystem.Parse(dls);
            
            location2.LocationName = locations.LocationName;
            location2.Description = locations.LocationDescription;
            location2.Location = dlsParsed.ToString();
            location2.CountryID = locations.CountryID;
            location2.ProvinceID = locations.ProvinceID;
            location2.ConvertedLatLon = DlsSystemConverter.ToLatLong(dlsParsed).ToString();
            location2.UserID = await _userManager.GetUserIdAsync(user);
            location2.CreateDate = DateTime.Today;
            location2.ExpirationDate = locations.ExpirationDate;
            location2.CompanyID = user.CompanyID;
            location2.LocationActive = locations.LocationActive;
            resource.ResourceName = locations.ResourceName;
            resource.ResourceTypeID = locations.ResourceTypeID;
            resource.RescourceQty = locations.ResourceQty;
            resource.ResourceQtyTypeID = locations.ResourceQtyTypeID;


            if (ModelState.IsValid)
            {
                _context.Add(location2);
                await _context.SaveChangesAsync();
                resource.LocationID = location2.LocationID;
                _context.Add(resource);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(locations);
        }

        public async Task<JsonResult> GetProvinceByCountry (int id)
        {
            List<Province> provinces = await _context.Provinces.Where(c => c.CountryID == id).ToListAsync();
            return Json(new SelectList(provinces, "ProvinceID", "ProvinceName"));
        }


        // GET: Locations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            LocationsVM locationsVM = new LocationsVM();
            Resources resources = await _context.Resources.FirstOrDefaultAsync(i => i.LocationID == id);
            List<ResourceType> resourceTypes = await _context.ResourceTypes.ToListAsync();
            List<ResourceQuantityType> resourceQuantityTypes = await _context.ResourceQuantityTypes.ToListAsync();
            
            
            var locations = await _context.Locations.FindAsync(id);


            if (locations == null)
            {
                return NotFound();
            }
            locationsVM.LocationID = id ?? default(int);
            locationsVM.LocationName = locations.LocationName;
            locationsVM.LocationDescription = locations.Description;
            locationsVM.LocationString = locations.Location;
            locationsVM.LatLon = locations.LatLon;
            locationsVM.CountryID = locations.CountryID;
            locationsVM.Countries = await _context.Countries.ToListAsync();
            locationsVM.ProvinceID = locations.ProvinceID;
            locationsVM.Provinces = await _context.Provinces.ToListAsync();
            locationsVM.ConvertedLatLon = locations.ConvertedLatLon;
            locationsVM.UserID = locations.UserID;
            locationsVM.CompanyID = locations.CompanyID;
            locationsVM.CreatedDate = locations.CreateDate;
            locationsVM.ExpirationDate = locations.ExpirationDate;
            locationsVM.ResourceID = resources.ResourceID;
            locationsVM.ResourceName = resources.ResourceName;
            locationsVM.ResourceTypeID = resources.ResourceTypeID;
            locationsVM.ResourceTypes = resourceTypes;
            locationsVM.ResourceQty = Convert.ToInt32(resources.RescourceQty);
            locationsVM.ResourceQtyTypeID = resources.ResourceQtyTypeID;
            locationsVM.QuantityTypes = resourceQuantityTypes;
            ViewData["Countries"] = new SelectList(locationsVM.Countries, "CountryID", "CountryName");
            ViewData["Provinces"] = new SelectList(locationsVM.Provinces, "ProvinceID", "ProvinceName");
            ViewData["ResourceTypes"] = new SelectList(resourceTypes, "ResourceTypeID", "ResourceTypeName");
            ViewData["ResourceQuantityTypes"] = new SelectList(resourceQuantityTypes, "ResourceQuantityTypeID", "ResourceQuantityTypeShortName");

            DlsSystem dls = new DlsSystem();

            dls = DlsSystem.Parse(locations.Location);
            locationsVM.LegalSubdivision = dls.LegalSubdivision.ToString() ;
            locationsVM.Section = dls.Section;
            locationsVM.Township = dls.Township;
            locationsVM.Range = dls.Range;
            locationsVM.Meridian = dls.Direction + dls.Meridian.ToString();

            List<LegalSubdivision> LSD = new List<LegalSubdivision>();
            List<section> section = new List<section>();
            List<township> township = new List<township>();
            List<range> range = new List<range>();
            List<meridian> meridian = new List<meridian>();

            LSD.Add(new LegalSubdivision { LSD = "NE" });
            LSD.Add(new LegalSubdivision { LSD = "NW" });
            LSD.Add(new LegalSubdivision { LSD = "SE" });
            LSD.Add(new LegalSubdivision { LSD = "SW" });

            for (var i = 0; i < 15; i++)
            {
                if (i < 9)
                {
                    LSD.Add(new LegalSubdivision { LSD = "0" + (i + 1) });
                }
                else
                {
                    LSD.Add(new LegalSubdivision { LSD = (i + 1).ToString() });
                }
            }
            for (var i = 0; i < 35; i++)
            {
                section.Add(new section { Section = Convert.ToByte(i + 1) });
            }
            for (var i = 0; i < 127; i++)
            {
                township.Add(new ViewModels.township { Township = Convert.ToByte(i + 1) });
            }
            for (var i = 0; i < 33; i++)
            {
                range.Add(new ViewModels.range { Range = Convert.ToByte(i + 1) });
            }
            for (var i = 0; i < 5; i++)
            {
                meridian.Add(new ViewModels.meridian { Meridian = "W" + (i + 1) });
            }

            ViewData["LegalSubdivision"] = new SelectList(LSD, "LSD", "LSD");
            ViewData["Section"] = new SelectList(section, "Section", "Section");
            ViewData["Township"] = new SelectList(township, "Township", "Township");
            ViewData["Range"] = new SelectList(range, "Range", "Range");
            ViewData["Meridian"] = new SelectList(meridian, "Meridian", "Meridian");


            return View(locationsVM);
        }

        // POST: Locations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LocationName, LocationDescription, LocationString, LatLon, CountryId, ProvinceID, ConvertedLatLon, ExpirationDate, ResourceName, ResourceTypeID, ResourceQty, ResourceQtyTypeID,LegalSubdivision, Section, Township, Range, Meridian")] LocationsVM locationsVM)
        {
            var user = await _userManager.GetUserAsync(User);
            
            Locations locations = await _context.Locations.FirstOrDefaultAsync(i => i.LocationID == id);
            Resources resources = await _context.Resources.FirstOrDefaultAsync(i => i.LocationID == id);

            if(locations.CompanyID != user.CompanyID)
            {
                return RedirectToAction(nameof(Index));
            }

            locations.LocationName = locationsVM.LocationName;
            locations.Description = locationsVM.LocationDescription;
            locations.Location = locationsVM.LocationString;
            locations.ConvertedLatLon = locationsVM.ConvertedLatLon;
            locations.CountryID = locationsVM.CountryID;
            locations.ProvinceID = locationsVM.ProvinceID;
            locations.UserID = _userManager.GetUserId(User);
            locations.ExpirationDate = locationsVM.ExpirationDate;
            resources.ResourceName = locationsVM.ResourceName;
            resources.ResourceTypeID = locationsVM.ResourceTypeID;
            resources.RescourceQty = locationsVM.ResourceQty;
            resources.ResourceQtyTypeID = locationsVM.ResourceQtyTypeID;

            if (id != locationsVM.LocationID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(locations);
                    _context.Update(resources);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LocationsExists(locations.LocationID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(locations);
        }

        // GET: Locations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var user = await _userManager.GetUserAsync(User);


            if (id == null)
            {
                return NotFound();
            }

            var locations = await _context.Locations
                .FirstOrDefaultAsync(m => m.LocationID == id);
            if (locations == null)
            {
                return NotFound();
            }

            return View(locations);
        }

        // POST: Locations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var locations = await _context.Locations.FindAsync(id);
            _context.Locations.Remove(locations);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LocationsExists(int id)
        {
            return _context.Locations.Any(e => e.LocationID == id);
        }
    }
}
