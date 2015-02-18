namespace Ritual.Web.Members.Controls
{
	public class MvcLabel : MvcControl
	{
		private string AssociatedControlID
		{
			set { Attributes.Merge("for", value); }
		}

		protected string Text
		{
			get { return InnerHtml; }
			private set { InnerHtml = value; }
		}

		public MvcLabel(string associatedControlID, string text)
			: base("label")
		{
			AssociatedControlID = associatedControlID;
			Text = text;
		}
	}
}
