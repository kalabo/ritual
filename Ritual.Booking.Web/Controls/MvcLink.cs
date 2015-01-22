using System;
using System.Web.Mvc;

namespace Ritual.Booking.Web.Controls
{
	public class MvcLink : MvcControl
	{
		private string Uri
		{
			set { Attributes.Merge("href", value); }
		}

		public MvcLink(string text, string uri)
			: base("a")
		{
			if (string.IsNullOrEmpty(text))
			{
				throw new ArgumentException("Value cannot be null or empty.", "text");
			}

			if (string.IsNullOrEmpty(uri))
			{
				throw new ArgumentException("Value cannot be null or empty.", "uri");
			}

			SetInnerText(text);

			Uri = uri;
		}
	}
}
