
// Namespaces You need

using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Ritual.Data
{
    public class Country
    {
        public string ID { get; set; }
        public string Name { get; set; }
    }
    public class Salutation
    {
        public string ID { get; set; }
        public string Name { get; set; }
    }

    public class IDType
    {
        public string ID { get; set; }
        public string Name { get; set; }
    }

    public class Size
    {
        public string ID { get; set; }
        public string Name { get; set; }
    }
    
    public class Gender
    {
        public string ID { get; set; }
        public string Name { get; set; }
    }

    public class BloodTypes
    {
        public string ID { get; set; }
        public string Name { get; set; }
    }

    public class IEnumerables
    {

        public static IEnumerable<Country> GetCountries()
        {
            return CultureInfo.GetCultures(CultureTypes.SpecificCultures)
                 .Select(x => new Country
                 {
                     ID = new RegionInfo(x.LCID).EnglishName,
                     Name = new RegionInfo(x.LCID).EnglishName
                 })
                                 .GroupBy(c => c.ID)
                                 .Select(c => c.First())
                                 .OrderBy(x => x.Name);
        }

        public static IEnumerable<Salutation> GetSalutations()
        {
            List<Salutation> s = new List<Salutation>();
            s.Add(new Salutation(){ ID = "Mr", Name = "Mr"});
            s.Add(new Salutation() { ID = "Mrs", Name = "Mrs" });
            s.Add(new Salutation() { ID = "Miss", Name = "Miss" });
            s.Add(new Salutation() { ID = "Ms", Name = "Ms" });
            s.Add(new Salutation() { ID = "Dr", Name = "Dr" });
            s.Add(new Salutation() { ID = "Prof", Name = "Prof" });
            s.Add(new Salutation() { ID = "Rev", Name = "Rev" });
            return s;
        }

        public static IEnumerable<IDType> GetIDTypes()
        {
            List<IDType> s = new List<IDType>();
            s.Add(new IDType() { ID = "NRIC", Name = "NRIC" });
            s.Add(new IDType() { ID = "FIN", Name = "FIN" });
            s.Add(new IDType() { ID = "Passport", Name = "Passport" });
            s.Add(new IDType() { ID = "Driving Licence", Name = "Driving Licence" });
            return s;
        }

        public static IEnumerable<Size> GetShirtSizes()
        {
            List<Size> s = new List<Size>();
            s.Add(new Size() { ID = "S", Name = "S" });
            s.Add(new Size() { ID = "M", Name = "M" });
            s.Add(new Size() { ID = "L", Name = "L" });
            s.Add(new Size() { ID = "XL", Name = "XL" });
            s.Add(new Size() { ID = "XXL", Name = "XXL" });
            return s;
        }

        public static IEnumerable<Size> GetShortSizes()
        {
            List<Size> s = new List<Size>();
            s.Add(new Size() { ID = "S", Name = "S" });
            s.Add(new Size() { ID = "M", Name = "M" });
            s.Add(new Size() { ID = "L", Name = "L" });
            s.Add(new Size() { ID = "XL", Name = "XL" });
            s.Add(new Size() { ID = "XXL", Name = "XXL" });
            return s;
        }

        public static IEnumerable<Gender> GetGenders()
        {
            List<Gender> s = new List<Gender>();
            s.Add(new Gender() { ID = "Male", Name = "Male" });
            s.Add(new Gender() { ID = "Female", Name = "Female" });
            return s;
        }

        public static IEnumerable<BloodTypes> GetBloodTypes()
        {
            List<BloodTypes> s = new List<BloodTypes>();
            s.Add(new BloodTypes() { ID = "O−", Name = "O−" });
            s.Add(new BloodTypes() { ID = "O+", Name = "O+" });
            s.Add(new BloodTypes() { ID = "A+", Name = "A+" });
            s.Add(new BloodTypes() { ID = "A-", Name = "A-" });
            s.Add(new BloodTypes() { ID = "B+", Name = "B+" });
            s.Add(new BloodTypes() { ID = "B-", Name = "B-" });
            s.Add(new BloodTypes() { ID = "AB-", Name = "AB-" });
            s.Add(new BloodTypes() { ID = "AB+", Name = "AB+" });
            return s;
        }
    }
}