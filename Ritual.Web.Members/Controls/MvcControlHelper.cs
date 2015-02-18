using System;
using System.Web.Mvc;
using System.IO;

namespace Ritual.Web.Members.Controls
{
	public static class MvcControlHelper
	{
		public static InputType GetInputTypeEnum(object type)
		{
			if (type == null)
			{
				throw new ArgumentNullException("type");
			}

			return GetInputTypeEnum(type.ToString());
		}

		public static InputType GetInputTypeEnum(string type)
		{
			if (string.IsNullOrEmpty(type))
			{
				throw new ArgumentException("Value cannot be null or empty.", "type");
			}

			InputType inputType;

			if (type.Equals("checkbox", StringComparison.InvariantCultureIgnoreCase))
			{
				inputType = InputType.CheckBox;
			}
			else if (type.Equals("hidden", StringComparison.InvariantCultureIgnoreCase))
			{
				inputType = InputType.Hidden;
			}
			else if (type.Equals("password", StringComparison.InvariantCultureIgnoreCase))
			{
				inputType = InputType.Password;
			}
			else if (type.Equals("radio", StringComparison.InvariantCultureIgnoreCase))
			{
				inputType = InputType.RadioButton;
			}
			else if (type.Equals("submit", StringComparison.InvariantCultureIgnoreCase))
			{
				inputType = InputType.Submit;
			}
			else if (type.Equals("text", StringComparison.InvariantCultureIgnoreCase))
			{
				inputType = InputType.Text;
			}
			else
			{
				throw new InvalidInputTypeException();
			}

			return inputType;
		}

		public static string GetInputTypeString(InputType type)
		{
			string inputType;

			switch (type)
			{
				case InputType.CheckBox:
					{
						inputType = "checkbox";

						break;
					}
				case InputType.Hidden:
					{
						inputType = "hidden";

						break;
					}
				case InputType.Password:
					{
						inputType = "password";

						break;
					}
				case InputType.RadioButton:
					{
						inputType = "radio";

						break;
					}
				case InputType.Submit:
					{
						inputType = "submit";

						break;
					}
				case InputType.Text:
					{
						inputType = "text";

						break;
					}
				default:
					{
						throw new NotImplementedException();
					}
			}

			return inputType;
		}

		public static string GetScriptTypeString(ScriptType type)
		{
			string scriptType;

			switch (type)
			{
				case ScriptType.JavaScript:
					{
						scriptType = "text/javascript";

						break;
					}
				default:
					{
						throw new NotImplementedException();
					}
			}

			return scriptType;
		}

		public static void RenderWatermarkScript(StringWriter writer, ViewContext viewContext, string controlID, string modelName, string watermarkCssClass, string watermarkText)
		{
			if (writer == null)
			{
				throw new ArgumentNullException("writer");
			}

			if (viewContext == null)
			{
				throw new ArgumentNullException("viewContext");
			}

			ViewDataDictionary viewData = viewContext.ViewData;

			if (viewData == null)
			{
				throw new ArgumentNullException("viewData");
			}

			if (!string.IsNullOrEmpty(controlID)
				&& !string.IsNullOrEmpty(watermarkCssClass)
				&& !string.IsNullOrEmpty(watermarkText))
			{
				ModelErrorCollection modelErrors = viewData.ModelState.GetErrors(modelName);

				if ((modelErrors == null || modelErrors.Count == 0))
				{
					string innerHtml = "$(function(){$('#" + controlID + "').addWatermark('" + watermarkCssClass + "', '" + watermarkText + "');});";

					MvcScript watermarkScript = new MvcScript(ScriptType.JavaScript, innerHtml);

					writer.Write(watermarkScript.Html(viewContext));
				}
			}
		}
	}
}
