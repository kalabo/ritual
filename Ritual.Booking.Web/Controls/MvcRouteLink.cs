﻿using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace Ritual.Booking.Web.Controls
{
	public class MvcRouteLink : MvcControl
	{
		#region MvcControlBuilder Members

		protected override void Initialise(ViewContext viewContext)
		{
			UrlHelper urlHelper = new UrlHelper(new RequestContext(viewContext.HttpContext, viewContext.RouteData));
			Attributes.Merge("href", urlHelper.GenerateUrl(RouteName, null /* actionName */, null /* controllerName */, Protocol, HostName, Fragment, new RouteValueDictionary(Values)));
		}

		#endregion

		public string Fragment { protected get; set; }

		public string HostName { protected get; set; }

		public string Protocol { protected get; set; }

		public string RouteName { protected get; set; }

		public object Values { protected get; set; }

		public MvcRouteLink(string text, string routeName)
			: base("a")
		{
			if (string.IsNullOrEmpty(text))
			{
				throw new ArgumentException("Value cannot be null or empty.", "text");
			}

			if (string.IsNullOrEmpty(routeName))
			{
				throw new ArgumentException("Value cannot be null or empty.", "routeName");
			}

			SetInnerText(text);

			RouteName = routeName;
		}
	}
}
