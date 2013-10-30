using System.Collections.Generic;
using System.Linq;
using UnitTest.Models;

namespace UnitTest.Data
{
    public class ConcreteDataProvider : IDataProvider
    {
        public object GetSource()
        {
            return new Customer
                   {
                       Addresses = GetAddresses(),
                       Company = GetCompany(),
                       CustomerName = "Jack Godwin",
                       Email = "godwhj@gmail.com"
                   };
        }

        public object GetExpected()
        {
            return new ViewModel
                   {
                       Addresses = GetAddresses()
                           .Select(m => new AddressViewModel
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

        private static Company GetCompany()
        {
            return new Company
                   {
                       DBA = "Nerdy Dude Designs",
                       PhoneNumber = "904.238.1284"
                   };
        }

        private static IEnumerable<Address> GetAddresses()
        {
            yield return new Address
                         {
                             City = "Orange Park",
                             State = "Florida",
                             Street1 = "3417 Crane Hill CT.",
                             Street2 = string.Empty,
                             ZipCode = 32065
                         };

            yield return new Address
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