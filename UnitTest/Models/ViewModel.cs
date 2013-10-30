using System.Collections.Generic;

namespace UnitTest.Models
{
    class ViewModel
    {
        public string CustomerName { get; set; }
        public string CompanyName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public IEnumerable<AddressViewModel> Addresses { get; set; }
    }

    class AddressViewModel
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zip { get; set; }
    }
}
