using System.Collections.Generic;

namespace UnitTest.Models
{
    class Customer
    {
        public string CustomerName { get; set; }
        public string Email { get; set; }

        public Company Company { get; set; }
        public IEnumerable<Address> Addresses { get; set; } 
    }

    class Company
    {
        public string DBA { get; set; }
        public string PhoneNumber { get; set; }
    }

    class Address
    {
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }
    }
}
