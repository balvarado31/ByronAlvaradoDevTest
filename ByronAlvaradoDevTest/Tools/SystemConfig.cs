using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace ByronAlvaradoDevTest.Tools
{
    public static class SystemConfig
    {
        public static string APIUrl()
        {
            return ConfigurationManager.AppSettings["APIUrl"];
        }
        public static string APIKey()
        {
            return ConfigurationManager.AppSettings["APIKey"];
        }
        public static string APIHost()
        {
            return ConfigurationManager.AppSettings["APIHost"];
        }
        public static string APIHeaderKey()
        {
            return ConfigurationManager.AppSettings["APIHeaderKey"];
        }
        public static string APIHostKey()
        {
            return ConfigurationManager.AppSettings["APIHostKey"];
        }
    }
}