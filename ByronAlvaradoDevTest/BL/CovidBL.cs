using ByronAlvaradoDevTest.Models;
using ByronAlvaradoDevTest.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ByronAlvaradoDevTest.BL
{
    public class CovidBL
    {
        public List<Region> GetRegions()
        {
            RegionReport response = new RegionReport();
            try
            {
                string url = SystemConfig.APIUrl() + "regions";
                HttpServiceClient client = new HttpServiceClient();
                response = client.Get<RegionReport>(url);
                if (!client.success)
                {
                    response = null;
                }
            }
            catch (Exception ex)
            {
                response = null;
            }
            return response.Regions;
        }
        public List<Province> GetProvinces(string pISO)
        {
            ProvinceReport response = new ProvinceReport();
            try
            {
                string url = SystemConfig.APIUrl() + "provinces?iso=" + pISO;
                HttpServiceClient client = new HttpServiceClient();
                response = client.Get<ProvinceReport>(url);
                if (!client.success)
                {
                    response = null;
                }
            }
            catch (Exception)
            {
                response = null;
            }
            return response.Provinces;
        }

        public List<Data> GetReports(string pISO, string pDate, string pQ, string pRegionName, string pRegionProvince, string pCityName)
        {
            Report response = new Report();
            try
            {
                bool firstParamenter = true;
                string url = SystemConfig.APIUrl() + "reports";
                #region UrlParameters
                if (!string.IsNullOrEmpty(pDate))
                {
                    url += "?date=" + pDate;
                    firstParamenter = false;
                }

                if (!string.IsNullOrEmpty(pQ))
                {
                    if (firstParamenter)
                    {
                        url += "?q=" + pQ;
                        firstParamenter = false;
                    }
                    else
                    {
                        url += "&q=" + pQ.Replace(" ", "%");
                    }
                }

                if (!string.IsNullOrEmpty(pRegionName))
                {
                    if (firstParamenter)
                    {
                        url += "?region_name=" + pRegionName;
                        firstParamenter = false;
                    }
                    else
                    {
                        url += "&region_name=" + pRegionName.Replace(" ", "%");
                    }
                }

                if (!string.IsNullOrEmpty(pISO))
                {
                    if (pISO=="Regions")
                    {
                        pISO = string.Empty;
                    }
                    if (firstParamenter)
                    {
                        url += "?iso=" + pISO;
                        firstParamenter = false;
                    }
                    else
                    {
                        url += "&iso=" + pISO.Replace(" ", "%");
                    }
                }

                if (!string.IsNullOrEmpty(pRegionProvince))
                {
                    if (firstParamenter)
                    {
                        url += "?region_province=" + pRegionProvince;
                        firstParamenter = false;
                    }
                    else
                    {
                        url += "&region_province=" + pRegionProvince.Replace(" ", "%");
                    }
                }

                if (!string.IsNullOrEmpty(pCityName))
                {
                    if (firstParamenter)
                    {
                        url += "?city_name=" + pCityName;
                        firstParamenter = false;
                    }
                    else
                    {
                        url += "&city_name=" + pCityName.Replace(" ", "%");
                    }
                }
                #endregion

                HttpServiceClient client = new HttpServiceClient();
                response = client.Get<Report>(url);
                if (!client.success)
                {
                    response = null;
                }
            }
            catch (Exception)
            {
                response = null;
            }
            return response.data;
        }


    }
}