using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ritual.Booking.Data
{
    [MetadataType(typeof(QuarterlyAssessmentMetadata))]
    public partial class QuarterlyAssessment
    {
    }

    public partial class Member
    {
        [Column("FullName", TypeName = "string")]
        public string FullName
        {
            get
            {
                return string.Format("{0} {1}", FirstName, LastName);
            }
        }
    }
    
    public partial class Trainer
    {
        [Column("FullName", TypeName = "string")]
        public string FullName
        {
            get
            {
                return string.Format("{0} {1}", FirstName, LastName);
            }
        }
    }
}
