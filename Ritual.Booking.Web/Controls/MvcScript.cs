using System;
using System.Web.Mvc;

namespace Ritual.Booking.Web.Controls
{
	public class MvcScript : MvcControl
	{
		protected ScriptType Type
		{
			set { Attributes.Merge("type", MvcControlHelper.GetScriptTypeString(value)); }
		}

		public MvcScript(ScriptType type, string innerHtml)
			: base("script")
		{
			InnerHtml = innerHtml;
			Type = type;
		}
	}
}
