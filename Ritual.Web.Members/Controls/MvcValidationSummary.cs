using System;
using System.IO;
using System.Text;
using System.Web.Mvc;

namespace Ritual.Web.Members.Controls
{
	public class MvcValidationSummary : MvcControl
	{
		#region MvcControlBuilder Members

		protected override void Initialise(ViewContext viewContext)
		{
			if (viewContext == null)
			{
				throw new ArgumentNullException("viewContext");
			}

			ViewDataDictionary viewData = viewContext.ViewData;

			if (viewData == null)
			{
				throw new ArgumentNullException("viewData");
			}

			if (viewData.ModelState.IsValid)
			{
				return;
			}

			StringBuilder listItems = new StringBuilder();

			foreach (var modelStateKvp in viewData.ModelState)
			{
				foreach (var modelError in modelStateKvp.Value.Errors)
				{
					TagBuilder listItem = new TagBuilder("li");
					listItem.SetInnerText(modelError.ErrorMessage);

					listItems.AppendLine(listItem.ToString());
				}
			}

			InnerHtml = listItems.ToString();
		}

		#endregion

		public MvcValidationSummary()
			: base("ul")
		{
			// Set a default CSS class.
			Class = "summary-validation-errors";
		}
	}
}
