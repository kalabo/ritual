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
        public string latitude { get; set; }
        public string longitude { get; set; }

        public RitualLocations(string latitude, string longitude)
        {
            this.latitude = latitude;
            this.longitude = longitude;
        }
    }

    [MetadataType(typeof(LocationMetadata))]
    public partial class Location
    {
        public string Latitude
        {
            get
            {
                return this.Coordinates.Latitude.ToString();
            }
        }
        public string Longitude
        {
            get
            {
                return this.Coordinates.Longitude.ToString();
            }
        }
    }


}
