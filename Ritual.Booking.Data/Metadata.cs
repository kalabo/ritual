using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ritual.Booking.Data
{
    public class QuarterlyAssessmentMetadata
    {
        [Range(0, 10)]
        [Display(Name = "Client RPE")]
        public Nullable<int> QAClientRPE { get; set; }
    }

    public class LocationMetadata
    {

    }

    public class OpeningHourMetadata
    {
        [Display(Name = "Open Time")]
        public string OpenTime { get; set; }

        [Display(Name = "Close Time")]
        public string CloseTime { get; set; }
    }

    public class MemberMetadata
    {
        [Display(Name = "Title")]
        public string Salutation { get; set; }

        [Display(Name = "Firstname")]
        public string FirstName { get; set; }

        [Display(Name = "Lastname")]
        public string LastName { get; set; }

        [Display(Name = "ID Number")]
        public string IdentificationNumber { get; set; }
        
        [Display(Name = "Email Opt Out")]
        public Nullable<bool> EmailOptOut { get; set; }

        [Display(Name = "Birthday")]
        public Nullable<System.DateTime> Birthday { get; set; }

        [Display(Name = "Home Phone")]
        public string HomePhone { get; set; }

        [Display(Name = "Mobile Phone")]
        public string MobilePhone { get; set; }

        [Display(Name = "Home Location")]
        public int HomeLocationId { get; set; }
    }
}
