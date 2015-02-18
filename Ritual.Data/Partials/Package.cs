using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ritual.Data
{
    public class PackagesDetailData
    {
        public Package Package { get; set; }
    }

    [MetadataType(typeof(PackagesMetadata))]
    public partial class Package
    {

    }
}
