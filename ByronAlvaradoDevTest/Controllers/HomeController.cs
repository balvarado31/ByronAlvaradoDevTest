using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Xml.Serialization;
using ByronAlvaradoDevTest.BL;
using ByronAlvaradoDevTest.Models;
using ByronAlvaradoDevTest.Tools;
using Newtonsoft.Json;

namespace ByronAlvaradoDevTest.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            
            return View();
        }

        public JsonResult GetRegions()
        {
            var Regions = new CovidBL().GetRegions();
            return Json(Regions, JsonRequestBehavior.AllowGet);
        
        }

        public JsonResult GetReports(string pRegion = null)
        {
            string parameter = string.Empty;
            var Reports = new List<Data>();
            Reports = new CovidBL().GetReports(pRegion, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty);
            Reports = Reports.OrderByDescending(x => x.Confirmed).Take(10).ToList();
            return Json(Reports, JsonRequestBehavior.AllowGet);

        }

        public ActionResult ToJson(string pRegion = null)
        {
            var data = JsonConvert.SerializeObject(this.GetReports(pRegion));
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(data);
            var output = new FileContentResult(bytes, "application/octet-stream");
            output.FileDownloadName = "CovidCases.json";

            return output;
        }

        public ActionResult ToCSV(string pRegion = null)
        {
            string parameter = string.Empty;
            IOTools iO = new IOTools();
            var Reports = new List<Data>();
            Reports = new CovidBL().GetReports(pRegion, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty);
            Reports = Reports.OrderByDescending(x => x.Confirmed).Take(10).ToList();
            var data = iO.CreateCSV(Reports);
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(data);
            var output = new FileContentResult(bytes, "application/octet-stream");
            output.FileDownloadName = "CovidCases.csv";

            return output;
        }

        public ActionResult ToXML(string pRegion = null)
        {
            string parameter = string.Empty;
            var Reports = new List<Data>(); 
            IOTools iO = new IOTools();
            Reports = new CovidBL().GetReports(pRegion, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty);
            Reports = Reports.OrderByDescending(x => x.Confirmed).Take(10).ToList();
            var data = iO.CreateXML(Reports);
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(data);
            var output = new FileContentResult(bytes, "application/octet-stream");
            output.FileDownloadName = "CovidCases.xml";

            return output;
        }


     
    }
}