using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ritual.Booking.Data
{
    public class LocationDetailData
    {
        public Location Location { get; set; }
        public IEnumerable<OpeningHour> OpeningHours { get; set; }
        public IEnumerable<OpeningHourOverride> OpeningHourOverrides { get; set; }
        public IEnumerable<Member> Members { get; set; }
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

    }


}
