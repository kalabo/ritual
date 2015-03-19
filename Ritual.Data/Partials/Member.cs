using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web.Mvc;

namespace Ritual.Data
{
    public class MembershipEditViewModel
    {
        [Display(Name = "Opt out of Emails")]
        public bool? EmailOptOut { get; set; }

        [Display(Name = "Salutation")]
        public string Salutation { get; set; }
        public SelectList Salutations { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Gender")]
        public string Gender { get; set; }
        public SelectList Genders { get; set; }

        [Display(Name = "Birthday")]
        public DateTime Birthday { get; set; }

        [Display(Name = "Home Phone")]
        public string HomePhone { get; set; }

        [Display(Name = "Mobile Phone")]
        public string MobilePhone { get; set; }

        [Display(Name = "Shirt Size")]
        public string ShirtSize { get; set; }
        public SelectList ShirtSizes { get; set; }

        [Display(Name = "Short Size")]
        public string ShortSize { get; set; }
        public SelectList ShortSizes { get; set; }

        [Required]
        [Display(Name = "Emergency Contact Name")]
        public string EmergencyContactName { get; set; }

        [Required]
        [Display(Name = "Emergency Contact Number")]
        public string EmergencyContactNumber { get; set; }

        [Required]
        [Display(Name = "Address Line 1")]
        public string AddressLine1 { get; set; }

        [Display(Name = "Address Line 2")]
        public string AddressLine2 { get; set; }

        [Required]
        [Display(Name = "Blood Type")]
        public string BloodType { get; set; }
        public SelectList BloodTypes { get; set; }

        [Required]
        [Display(Name = "City")]
        public string City { get; set; }

        [Required]
        [Display(Name = "Country")]
        public string Country { get; set; }

        public SelectList Countries { get; set; }

        [Required]
        [Display(Name = "Postcode / Zip")]
        public string PostCodeZip { get; set; }

        [Required]
        [Display(Name = "Identification Type")]
        public string IDType { get; set; }

        public SelectList IDTypes { get; set; }

        [Required]
        [Display(Name = "Identification No.")]
        public string IDNumber { get; set; }

        public int MemberId { get; set; }

    }

    
    public class MembershipProfileEditViewModel
    {
        [Display(Name = "Opt out of Emails")]
        public bool? EmailOptOut { get; set; }

        [Display(Name = "Birthday")]
        public DateTime Birthday { get; set; }

        [Display(Name = "Home Phone")]
        public string HomePhone { get; set; }

        [Display(Name = "Mobile Phone")]
        public string MobilePhone { get; set; }

        [Display(Name = "Shirt Size")]
        public string ShirtSize { get; set; }
        public SelectList ShirtSizes { get; set; }

        [Display(Name = "Short Size")]
        public string ShortSize { get; set; }
        public SelectList ShortSizes { get; set; }

        [Required]
        [Display(Name = "Emergency Contact Name")]
        public string EmergencyContactName { get; set; }

        [Required]
        [Display(Name = "Emergency Contact Number")]
        public string EmergencyContactNumber { get; set; }

        [Required]
        [Display(Name = "Address Line 1")]
        public string AddressLine1 { get; set; }

        [Display(Name = "Address Line 2")]
        public string AddressLine2 { get; set; }

        [Required]
        [Display(Name = "Blood Type")]
        public string BloodType { get; set; }

        [Required]
        [Display(Name = "City")]
        public string City { get; set; }

        [Required]
        [Display(Name = "Country")]
        public string Country { get; set; }

        public SelectList Countries { get; set; }

        [Required]
        [Display(Name = "Postcode / Zip")]
        public string PostCodeZip { get; set; }

        [Required]
        [Display(Name = "Identification Type")]
        public string IDType { get; set; }

        public SelectList IDTypes { get; set; }

        [Required]
        [Display(Name = "Identification No.")]
        public string IDNumber { get; set; }

        public int MemberId { get; set; }

    }

    public class MemberAddMembershipModel
    {
        public decimal selectedpackagemonthly { get; set; }
        public decimal selectedpackagetotal { get; set; }
        public decimal selectedpackagediscount { get; set; }
        public string selectedpackagediscountreason { get; set; }
        public decimal selectedpackagemonthlydiscount { get; set; }
        public decimal selectedpackagetotaldiscount { get; set; }
        public DateTime membershipstartdate { get; set; }
        public DateTime membershipenddate { get; set; }
        public decimal selectedpackageinitialpayment { get; set; }
        public Package package { get; set; }
        public Member member { get; set; }
    }

    public class MemberDetailData
    {
        public Member Member { get; set; }
        public Membership ActiveMembership { get; set; }
        public IEnumerable<Membership> PastMemberships { get; set; }
        public IEnumerable<QuarterlyAssessment> QuarterlyAssessments { get; set; }
        public IEnumerable<SessionBookingModel> UpcomingBookings { get; set; }
        public IEnumerable<SessionBookingModel> PastBookings { get; set; }
    }

    public class MemberAddMembershipData
    {
        public Member Member { get; set; }
        public Membership ActiveMembership { get; set; }
        public MemberAddMembershipModel AddMembershipModel { get; set; }
        public IEnumerable<Membership> PastMemberships { get; set; }
        public IEnumerable<Package> AvailablePackages { get; set; }
        public IEnumerable<PackageLocationPrice> LocationPackagePrices { get; set; }
    }

    public class MemberListingData
    {
        public IEnumerable<Member> Members { get; set; }
        public string LastNameSortParam { get; set; }
        public string FirstNameSortParam { get; set; }
    }

    [MetadataType(typeof(MemberMetadata))]
    public partial class Member
    {
        private RitualDBEntities db = new RitualDBEntities();

        [Column("FullName", TypeName = "string")]
        public string FullName
        {
            get { return string.Format("{0} {1}", this.AspNetUser.FirstName, this.AspNetUser.LastName); }
        }

        [Column("LastName", TypeName = "string")]
        public string LastName
        {
            get { return string.Format("{0}", this.AspNetUser.LastName); }
        }

        [Column("FirstName", TypeName = "string")]
        public string FirstName
        {
            get { return string.Format("{0}", this.AspNetUser.FirstName); }
        }

        public bool isActiveMembershipSuspended()
        {
            if (this.getActiveMembership().isSuspended())
            {
                return true;
            }
            return false;
        }

        public bool hasActiveMembership()
        {
            if (this.getActiveMembership() != null)
            {
                return true;
            }
            return false;
        }

        public Member getMemberById()
        {
            return db.Members.Single(m => m.AspNetUserId == this.AspNetUserId);
        }

        public Location getUserHomeLocation()
        {
            return db.Locations.FirstOrDefault(l => l.Id == this.HomeLocationId);
        }

        public List<Location> getAvailableBookingLocations()
        {
            List<Location> locations = new List<Location>();

            //TODO Calculate based on membership type what locations are available (Country / Global Pass)
            if (this.getActiveMembership().Package.PackageTypeId == 5)
            {
                locations = db.Locations.ToList();
            }
            else
            {
                locations.Add(this.getUserHomeLocation());
            }

            return locations;
        }

        public Membership getActiveMembership()
        {
            DateTime currentDate = DateTime.UtcNow.AddHours(this.getUserHomeLocation().TimeZoneOffset);
            //Get active memberships which have started.
            return db.Memberships.FirstOrDefault(m => (m.MemberId == this.Id && m.MembershipStateId == 1) && m.StartDate <= currentDate);
        }

        public Membership getLatestMembership()
        {
            DateTime currentDate = DateTime.UtcNow.AddHours(this.getUserHomeLocation().TimeZoneOffset);
            //Get active memberships which have started.
            return db.Memberships.Where(m => (m.MemberId == this.Id)).OrderByDescending(m => m.StartDate).Take(1).SingleOrDefault();
        }

        public List<Membership> getExpiredMemberships()
        {
            return db.Memberships.Where(m => m.MemberId == this.Id && m.MembershipStateId != 1).ToList();
        }

        public int getNumberOfSuspensions()
        {
            return this.getActiveMembership().getNumberOfSuspensions();
        }

        public SessionBooking getLastAttendedSession()
        {
            return
                db.SessionBookings.Where(m => m.MemberId == this.Id && m.LocationId == this.HomeLocationId && m.BookingStateId == 3)
                    .OrderByDescending(m => m.Date)
                    .ThenBy(m => m.TimeSlot.StartTime)
                    .FirstOrDefault();
        }

        public List<SessionBookingModel> getUpcomingBookings()
        {
            DateTime currentDate = DateTime.UtcNow.AddHours(this.getUserHomeLocation().TimeZoneOffset);
            List<SessionBookingModel> sessionBookingModel = new List<SessionBookingModel>();

            List<SessionBooking> bookings = db.SessionBookings.Where(m => m.MemberId == this.Id && m.LocationId == this.HomeLocationId).OrderByDescending(m => m.Date).ThenBy(m => m.TimeSlot.StartTime).ToList();

            foreach (SessionBooking b in bookings)
            {
                sessionBookingModel.Add(new SessionBookingModel
                {
                    BookingState = b.SessionBookingState.Name,
                    Date = b.Date,
                    Id = b.Id,
                    Location = b.Location.Name,
                    MemberName = b.Member.AspNetUser.FullName,
                    RPEFeeling = b.RPEFeeling,
                    RPEPush = b.RPEPush,
                    StartTime = b.TimeSlot.StartTime,
                    TimeSlotDateTime = b.Date.Add(b.TimeSlot.StartTime)
                });
            }
            //Filter results by current date time only..
            sessionBookingModel = sessionBookingModel.Where(t => t.TimeSlotDateTime >= currentDate).OrderBy(t => t.TimeSlotDateTime).ToList();

            return sessionBookingModel;
        }

        public List<SessionBookingModel> getPastBookings()
        {
            DateTime currentDate = DateTime.UtcNow.AddHours(this.getUserHomeLocation().TimeZoneOffset);
            List<SessionBookingModel> sessionBookingModel = new List<SessionBookingModel>();

            List<SessionBooking> bookings = db.SessionBookings.Where(m => m.MemberId == this.Id && m.LocationId == this.HomeLocationId).OrderByDescending(m => m.Date).ThenBy(m => m.TimeSlot.StartTime).ToList();

            foreach (SessionBooking b in bookings)
            {
                sessionBookingModel.Add(new SessionBookingModel
                {
                    BookingState = b.SessionBookingState.Name,
                    Date = b.Date,
                    Id = b.Id,
                    Location = b.Location.Name,
                    MemberName = b.Member.AspNetUser.FullName,
                    RPEFeeling = b.RPEFeeling,
                    RPEPush = b.RPEPush,
                    StartTime = b.TimeSlot.StartTime,
                    TimeSlotDateTime = b.Date.Add(b.TimeSlot.StartTime)
                });
            }
            //Filter results by current date time only..
            sessionBookingModel = sessionBookingModel.Where(t => t.TimeSlotDateTime < currentDate).OrderBy(t => t.TimeSlotDateTime).ToList();

            return sessionBookingModel;
        }


        public List<SessionBookingJSONModel> getUpcomingBookings(int limit)
        {
            DateTime currentDate = DateTime.UtcNow.AddHours(this.getUserHomeLocation().TimeZoneOffset);
            List<SessionBookingJSONModel> sessionBookingJSONModelList = new List<SessionBookingJSONModel>();

            List<SessionBooking> bookings = db.SessionBookings.Where(m => m.MemberId == this.Id && m.LocationId == this.HomeLocationId).OrderByDescending(m => m.Date).ThenBy(m => m.TimeSlot.StartTime).ToList();

            foreach (SessionBooking b in bookings)
            {
                sessionBookingJSONModelList.Add(new SessionBookingJSONModel
                {
                    BookingState = b.SessionBookingState.Name,
                    Date = b.Date,
                    Id = b.Id,
                    Location = b.Location.Name,
                    MemberName = b.Member.AspNetUser.FullName,
                    RPEFeeling = b.RPEFeeling,
                    RPEPush = b.RPEPush,
                    StartTime = b.TimeSlot.StartTime,
                    TimeSlotDateTime = b.Date.Add(b.TimeSlot.StartTime)
                });
            }
            //Filter results by current date time only..
            sessionBookingJSONModelList = sessionBookingJSONModelList.Where(t => t.TimeSlotDateTime >= currentDate).OrderBy(t => t.TimeSlotDateTime).Take(limit).ToList();

            return sessionBookingJSONModelList;
        }

        public List<SessionBookingJSONModel> getPastBookings(int limit)
        {
            DateTime currentDate = DateTime.UtcNow.AddHours(this.getUserHomeLocation().TimeZoneOffset);
            List<SessionBookingJSONModel> sessionBookingJSONModelList = new List<SessionBookingJSONModel>();

            List<SessionBooking> bookings = db.SessionBookings.Where(m => m.MemberId == this.Id && m.LocationId == this.HomeLocationId).OrderByDescending(m => m.Date).ThenBy(m => m.TimeSlot.StartTime).ToList();

            foreach (SessionBooking b in bookings)
            {
                sessionBookingJSONModelList.Add(new SessionBookingJSONModel
                {
                    BookingState = b.SessionBookingState.Name,
                    Date = b.Date,
                    Id = b.Id,
                    Location = b.Location.Name,
                    MemberName = b.Member.AspNetUser.FullName,
                    RPEFeeling = b.RPEFeeling,
                    RPEPush = b.RPEPush,
                    StartTime = b.TimeSlot.StartTime,
                    TimeSlotDateTime = b.Date.Add(b.TimeSlot.StartTime)
                });
            }
            //Filter results by current date time only..
            sessionBookingJSONModelList = sessionBookingJSONModelList.Where(t => t.TimeSlotDateTime < currentDate).OrderBy(t => t.TimeSlotDateTime).Take(limit).ToList();

            return sessionBookingJSONModelList;

        }

        public List<QuarterlyAssessment> getQuarterlyAssessments(int limit)
        {
            return db.QuarterlyAssessments.Where(qa => qa.MemberId == this.Id).OrderByDescending(qa => qa.QADateTime).Take(limit).ToList();
        }
    }
}
