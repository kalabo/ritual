using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ritual.Booking.Web.Controls
{
	public class MvcExternalScript : MvcScript
	{
		protected string Uri
		{
			set { Attributes.Merge("src", value); }
		}

		public MvcExternalScript(ScriptType type, string uri)
			: base(type, null)
		{
			Uri = uri;
		}
	}
}
