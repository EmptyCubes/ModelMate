using System.Collections.Generic;
using System.Linq;

namespace UnitTest.Data
{
    public class DynamicDataProvider : IDataProvider
    {
        public object GetSource()
        {
            return new
                   {
                       Addresses = GetAddresses(),
                       Company = GetCompany(),
                       CustomerName = "Jack Godwin",
                       Email = "g****@gmail.com"
                   };
        }

        public object GetExpected()
        {
            return new
                   {
                       Addresses = GetAddresses()
                           .Select(m => new
                                        {
                                            City = m.City,
                                            State = m.State,
                                            Street = m.Street1,
                                            Zip = m.ZipCode
                                        })
                           .ToArray(),
                       CompanyName = "Fubar Industries",
                       CustomerName = "Jack Godwin",
                       Email = "g****@gmail.com",
                       Phone = "123.456.7890"
                   };
        }

        private static dynamic GetCompany()
        {
            return new
                   {
                       DBA = "Foobar",
                       PhoneNumber = "123.456.7890"
                   };
        }

        private static IEnumerable<dynamic> GetAddresses()
        {
            yield return new
                         {
                             City = "Orange Park",
                             State = "Florida",
                             Street1 = "1234 Some Road.",
                             Street2 = string.Empty,
                             ZipCode = 32065
                         };

            yield return new
                         {
                             City = "Jacksonville",
                             State = "Florida",
                             Street1 = "1234 Some Lane.",
                             Street2 = "Building 900; 12th Floor",
                             ZipCode = 32256
                         };
        }
    }
}
