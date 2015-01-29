using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ritual.Booking.Data
{
    public class MembershipsDetailData
    {
        public Membership Membership { get; set; }
    }

    [MetadataType(typeof(MembershipMetadata))]
    public partial class Membership
    {

    }
}
