using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ritual.Booking.Data
{
    public partial class Employee
    {
        [Column("FullName", TypeName = "string")]
        public string FullName
        {
            get
            {
                return string.Empty;
                //return string.Format("{0} {1}", this.AspNetUser.AspNetUserDetails, LastName);
            }
        }
    }
}
