using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ritual.Data
{
    public class LocationDetailData
    {
        public Location Location { get; set; }
        public IEnumerable<OpeningHour> OpeningHours { get; set; }
        public IEnumerable<OpeningHourOverride> OpeningHourOverrides { get; set; }
        public IEnumerable<Member> Members { get; set; }
    }

    public class LocationChartData
    {
        public int value {get; set;}
        public string color {get; set;}
        public string label {get; set;}
    }
    
    public class RitualLocations
    {
        public decimal latitude { get; set; }
        public decimal longitude { get; set; }
        public string name { get; set; }
        public string address { get; set; }

        public RitualLocations(decimal latitude, decimal longitude, string name, string address)
        {
            this.latitude = latitude;
            this.longitude = longitude;
            this.name = name;
            this.address = address;
        }
    }

    [MetadataType(typeof(LocationMetadata))]
    public partial class Location
    {

        private RitualDBEntities db = new RitualDBEntities();

        public List<LocationChartData> getLocationPaymentMethodChart()
        {
            List<LocationChartData> data = new List<LocationChartData>();

            data.Add(new LocationChartData() { value = this.getMembersByPackagePaymentModel(false, true).Count(), color = "#444", label = "Monthly Reoccuring" });
            data.Add(new LocationChartData() { value = this.getMembersByPackagePaymentModel(true, false).Count(), color = "#222", label = "Paid in Full" });

            return data;
        }

        public List<Member> getMembers()
        {
            return db.Members.Where(m => m.HomeLocationId == this.Id).ToList();
        }

        public List<DateTime> getDaysOpen(int numberOfDays, DateTime start)
        {
            List<byte> openDays = this.getOpeningHoursDays();
            List<DateTime> nextNOpenDays = new List<DateTime>();
            
            while (nextNOpenDays.Count < numberOfDays)
            {
                if (openDays.Contains(Convert.ToByte(start.DayOfWeek)))
                    nextNOpenDays.Add(start);
                start = start.AddDays(1);
            }
            return nextNOpenDays;
        }

        public List<byte> getOpeningHoursDays()
        {
            return db.OpeningHours.Where(oh => oh.LocationId == this.Id).Select(oh => oh.DateOfWeek).ToList();
        }

        public List<Member> getMembersByMembershipState(string membershipstate)
        {
            return db.Members.Where(m => m.HomeLocationId == this.Id && m.getActiveMembership().MembershipState.Name == membershipstate).ToList();
        }

        public List<Member> getMembersByPackageType(string packageType)
        {
            return db.Members.Where(m => m.HomeLocationId == this.Id && m.getActiveMembership().Package.PackageType.Name == packageType ).ToList(); 
        }

        public List<Member> getMembersByPackageTerm(int? packageTerm)
        {
            return db.Members.Where(m => m.HomeLocationId == this.Id && m.getActiveMembership().Package.PackagePeriodMonths == packageTerm).ToList();
        }

        public List<Member> getMembersByPackagePaymentModel(bool payinfull, bool payreoccuring)
        {
            
            if (payinfull && !payreoccuring)
            {
                var query = db.Members.Where(m => m.HomeLocationId == this.Id
                                  && m.Memberships
                                      .Any(ms => ms.MembershipStateId == 1
                                              && ms.Package.PackagePayInFull == true)).ToList();
                return query;
            }
            else if (!payinfull && payreoccuring)
            {
                var query = db.Members.Where(m => m.HomeLocationId == this.Id
                                  && m.Memberships
                                      .Any(ms => ms.MembershipStateId == 1
                                              && ms.Package.PackageIsReoccuring == true)).ToList();
                return query;
            }
            else
            {
                return null;
            }
            
        }
    }


}
