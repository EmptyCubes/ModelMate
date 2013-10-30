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
                       Email = "godwhj@gmail.com"
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
                       CompanyName = "Nerdy Dude Designs",
                       CustomerName = "Jack Godwin",
                       Email = "godwhj@gmail.com",
                       Phone = "904.238.1284"
                   };
        }

        private static dynamic GetCompany()
        {
            return new
                   {
                       DBA = "Nerdy Dude Designs",
                       PhoneNumber = "904.238.1284"
                   };
        }

        private static IEnumerable<dynamic> GetAddresses()
        {
            yield return new
                         {
                             City = "Orange Park",
                             State = "Florida",
                             Street1 = "3417 Crane Hill CT.",
                             Street2 = string.Empty,
                             ZipCode = 32065
                         };

            yield return new
                         {
                             City = "Jacksonville",
                             State = "Florida",
                             Street1 = "4600 Touchton Rd.",
                             Street2 = "Building 900; 12th Floor",
                             ZipCode = 32256
                         };
        }
    }
}