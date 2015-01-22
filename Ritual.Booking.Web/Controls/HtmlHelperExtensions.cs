using System;
using System.Web.Mvc;

namespace Ritual.Booking.Web.Controls
{
	public static class HtmlHelperExtensions
	{
		public static string MvcControl(this HtmlHelper htmlHelper, MvcControl mvcControl)
		{
			if (mvcControl == null)
			{
				throw new ArgumentNullException("control");
			}

			return mvcControl.Html(htmlHelper.ViewContext);
		}
	}
}
