using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;

namespace Ritual.Data
{
    public partial class TimeSlot
    {
        private RitualDBEntities db = new RitualDBEntities();
 
        public bool IsOffPeakSlot(int locationId)
        {
            int count = db.OffPeakHours.Count(o => (this.StartTime >= o.StartTime && this.StartTime <= o.EndTime) && o.LocationId == locationId);
            if (count > 0)
            {
                return true;
            }
            return false;
        }

        public bool IsTrialSlot(int locationId)
        {
            int count = db.TrialTimeBlocks.Count(o => (this.StartTime >= o.StartTime && this.StartTime <= o.EndTime) && o.LocationId == locationId);
            if (count > 0)
            {
                return true;
            }
            return false;
        }
    }
}
