using System.Web.Mvc;
namespace Ritual.Booking.Web.Controls
{
public class MvcEndForm : MvcControl
{
	public MvcEndForm()
		: base("form", TagRenderMode.EndTag) { }
}
}
