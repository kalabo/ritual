using System.Web.Mvc;
namespace Ritual.Web.Members.Controls
{
public class MvcEndForm : MvcControl
{
	public MvcEndForm()
		: base("form", TagRenderMode.EndTag) { }
}
}
