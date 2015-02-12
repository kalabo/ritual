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
        [Display(Name = "Name")]
        public string Name { get; set; }
        
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Postcode")]
        public string PostCode { get; set; }

        [Display(Name = "Country")]
        public string Country { get; set; }

        [Display(Name = "Timezone Offset")]
        public short TimeZoneOffset { get; set; }
        
        [Display(Name = "Currency")]
        public string Currency { get; set; }

        [Display(Name = "Available Slots")]
        public short AvailableSlots { get; set; }
    }

    public class OpeningHourMetadata
    {
        [Display(Name = "Open Time")]
        public string OpenTime { get; set; }

        [Display(Name = "Close Time")]
        public string CloseTime { get; set; }
    }

    public class PackagesMetadata
    {
        [Display(Name = "Name")]
        public string Name { get; set; }
        
        [Display(Name = "Type")]
        public string PackageType { get; set; }
        
        [Display(Name = "Period (Months)")]
        public Nullable<int> PackagePeriodMonths { get; set; }
        
        [Display(Name = "Suspension Limit")]
        public Nullable<int> PackageSuspensionLimit { get; set; }
        
        [Display(Name = "Visit Limit")]
        public Nullable<int> PackageVisitLimit { get; set; }
        
        [Display(Name = "Active")]
        public Nullable<bool> PackageIsActive { get; set; }
        
        [Display(Name = "Reoccuring")]
        public Nullable<bool> PackageIsReoccuring { get; set; }
        
        [Display(Name = "Full Payment")]
        public Nullable<bool> PackagePayInFull { get; set; }
    }

    public class MembershipMetadata
    {
        [Display(Name = "Member Id")]
        public int MemberId { get; set; }
        
        [Display(Name = "Package Id")]
        public int PackageId { get; set; }

        [Display(Name = "Start Date")]
        public System.DateTime StartDate { get; set; }

        [Display(Name = "End Date")]
        public System.DateTime EndDate { get; set; }

        [Display(Name = "Trial?")]
        public bool Trial { get; set; }

        [Display(Name = "State")]
        public int MembershipStateId { get; set; }

        [Display(Name = "Cancellation Date")]
        public Nullable<System.DateTime> CancellationDate { get; set; }

        [Display(Name = "Paid?")]
        public bool Paid { get; set; }

        [Display(Name = "Initial Payment Date")]
        public Nullable<System.DateTime> InitialPaymentDate { get; set; }

        [Display(Name = "Initial Payment")]
        public Nullable<decimal> InitialPayment { get; set; }

        [Display(Name = "Monthly Price")]
        public Nullable<decimal> MonthlyPrice { get; set; }

        [Display(Name = "Total Price")]
        public Nullable<decimal> TotalPrice { get; set; }

        [Display(Name = "Discount Percentage")]
        public Nullable<decimal> DiscountPercentage { get; set; }

        [Display(Name = "Discount Price")]
        public Nullable<decimal> DiscountPrice { get; set; }

        [Display(Name = "Reason for Discount")]
        public string DiscountReason { get; set; }
    }

    public class MemberMetadata
    {
        //[Display(Name = "Title")]
        //public string Salutation { get; set; }

        //[Display(Name = "Firstname")]
        //public string FirstName { get; set; }

        //[Display(Name = "Lastname")]
        //public string LastName { get; set; }

        //[Display(Name = "ID Number")]
        //public string IdentificationNumber { get; set; }
        
        [Display(Name = "Email Opt Out")]
        public Nullable<bool> EmailOptOut { get; set; }

        //[Display(Name = "Birthday")]
        //public Nullable<System.DateTime> Birthday { get; set; }

        //[Display(Name = "Home Phone")]
        //public string HomePhone { get; set; }

        //[Display(Name = "Mobile Phone")]
        //public string MobilePhone { get; set; }

        [Display(Name = "Home Location")]
        public int HomeLocationId { get; set; }
    }
}
