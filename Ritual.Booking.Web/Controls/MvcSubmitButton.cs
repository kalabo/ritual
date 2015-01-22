namespace Ritual.Booking.Web.Controls
{
	public class MvcSubmitButton : MvcInput
	{
		public object Value
		{
			set { Attributes.Merge("value", value); }
		}

		public MvcSubmitButton(string name)
			: base(InputType.Submit, name) { }
	}
}