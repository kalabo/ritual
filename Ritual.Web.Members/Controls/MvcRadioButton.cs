using System;

namespace Ritual.Web.Members.Controls
{
	public class MvcRadioButton : MvcInput
	{
		public bool Checked
		{
			set
			{
				if (value)
				{
					Attributes["checked"] = "checked";
				}
				else
				{
					Attributes.Remove("checked");
				}
			}
		}

		public object Value
		{
			set { Attributes.Merge("value", value); }
		}

		public MvcRadioButton(string name, object value)
			: base(InputType.RadioButton, name)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}

			Value = value;
		}
	}
}
