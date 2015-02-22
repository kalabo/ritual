using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ritual.Data
{
    public partial class Employee
    {
        [Column("FullName", TypeName = "string")]
        public string FullName
        {
            get
            {
                return string.Format("{0} {1}", this.AspNetUser.FirstName, this.AspNetUser.LastName);
            }
        }

        [Column("LastName", TypeName = "string")]
        public string LastName
        {
            get
            {
                return string.Format("{0}", this.AspNetUser.LastName);
            }
        }

        [Column("FirstName", TypeName = "string")]
        public string FirstName
        {
            get
            {
                return string.Format("{0}", this.AspNetUser.FirstName);
            }
        }
    }
}
