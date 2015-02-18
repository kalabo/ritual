using System;
using System.Globalization;
using System.Web.Mvc;

namespace Ritual.Web.Members.Controls
{
	public static class ViewDataExtensions
	{
		public static bool EvalBoolean(this ViewDataDictionary viewData, string key)
		{
			return Convert.ToBoolean(viewData.Eval(key), CultureInfo.InvariantCulture);
		}

		public static string EvalString(this ViewDataDictionary viewData, string key)
		{
			return Convert.ToString(viewData.Eval(key), CultureInfo.CurrentCulture);
		}

		public static string GetModelAttemptedValue(this ViewDataDictionary viewData, string key)
		{
			ModelState modelState;

			if (viewData != null && viewData.ModelState != null && viewData.ModelState.TryGetValue(key, out modelState))
			{
				return modelState.Value.AttemptedValue;
			}

			return null;
		}
	}
}
