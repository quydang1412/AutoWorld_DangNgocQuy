using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoWorld.Common
{
    public static class MyHelper
    {
		public static string ToProductImageUrl(this string relativeUrl)
		{
			string productImageDir = System.Configuration.ConfigurationManager.AppSettings.Get("autoworld:uploadsDir:products");
			string host = System.Configuration.ConfigurationManager.AppSettings.Get("autoworld:host");
			if (string.IsNullOrEmpty(productImageDir))
			{
				throw new Exception("Configuration missed: \"autoworld:uploadsDir:products\"");
			}
			if (string.IsNullOrEmpty(host))
			{
				throw new Exception("Configuration missed: \"autoworld:host\"");
			}

			return host + HttpContext.Current.Server.UrlDecode(relativeUrl);
		}
	}
}