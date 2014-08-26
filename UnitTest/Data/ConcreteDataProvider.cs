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
                       Email = "g****@gmail.com"
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

                       CompanyName = "Fubar Industries",
                       CustomerName = "Jack Gordon",
                       Email = "g****@gmail.com",
                       Phone = "123.456.7890"
                   };
        }

        private static Company GetCompany()
        {
            return new Company
                   {
                       DBA = "FooBar",
                       PhoneNumber = "123.456.7890"
                   };
        }

        private static IEnumerable<Address> GetAddresses()
        {
            yield return new Address
                         {
                             City = "Orange Park",
                             State = "Florida",
                             Street1 = "1234 Some road",
                             Street2 = string.Empty,
                             ZipCode = 32065
                         };

            yield return new Address
                         {
                             City = "Jacksonville",
                             State = "Florida",
                             Street1 = "1234 Some road",
                             Street2 = "Building 900; 12th Floor",
                             ZipCode = 32256
                         };
        }
    }
}
