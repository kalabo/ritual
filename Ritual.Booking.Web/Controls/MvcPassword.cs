namespace Ritual.Booking.Web.Controls
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
