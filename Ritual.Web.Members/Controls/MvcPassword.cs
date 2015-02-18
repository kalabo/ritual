namespace Ritual.Web.Members.Controls
{
    public class MvcPassword : MvcTextBox
    {
        public MvcPassword(string name)
            : base(name)
        {
            Type = InputType.Password;
        }
    }
}
