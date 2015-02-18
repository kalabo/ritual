using System.Text;
using System.Web.Mvc;
using System;
using System.IO;
namespace Ritual.Web.Members.Controls
{
public class MvcTextBox : MvcInput
{
	#region MvcControlBuilder Members

	protected override void RenderHtml(StringWriter writer, ViewContext viewContext)
	{
		if (writer == null)
		{
			throw new ArgumentNullException("writer");
		}

		if (viewContext == null)
		{
			throw new ArgumentNullException("viewContext");
		}

		MvcControlHelper.RenderWatermarkScript(writer, viewContext, ID, Name, WatermarkedCssClass, WatermarkText);
	}

	#endregion

	public int Columns
	{
		set { Attributes.Merge("size", value.ToString()); }
	}
	public string MaximumLength
	{
		set { Attributes.Merge("maxlength", value); }
	}

	public string WatermarkedCssClass { get; set; }

	public string WatermarkText { get; set; }

	public object Value
	{
		set { Attributes.Merge("value", value); }
	}

	public MvcTextBox(string name)
		: base(InputType.Text, name)
	{
		WatermarkedCssClass = "input-watermarked";
	}
}
}
