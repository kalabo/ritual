using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ritual.Booking.Data
{

    [MetadataType(typeof(OpeningHourMetadata))]
    public partial class OpeningHour
    {
        [Column("Day Of Week", TypeName = "string")]
        public string DayOfWeekText
        {
            get
            {
                return ((DayOfTheWeek)Convert.ToInt16(DateOfWeek)).ToString() ;
            }
        }
    }

}
