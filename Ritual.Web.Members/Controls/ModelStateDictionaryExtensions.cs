using System;
using System.Web.Mvc;

namespace Ritual.Web.Members.Controls
{
	public static class ModelStateDictionaryExtensions
	{
		public static ModelErrorCollection GetErrors(this ModelStateDictionary modelStateDictionary, string modelName)
		{
			ModelErrorCollection modelErrors = null;

			ModelState modelState;

			if (modelStateDictionary.TryGetValue(modelName, out modelState))
			{
				modelErrors = modelState.Errors;
			}

			return modelErrors;
		}
	}
}
