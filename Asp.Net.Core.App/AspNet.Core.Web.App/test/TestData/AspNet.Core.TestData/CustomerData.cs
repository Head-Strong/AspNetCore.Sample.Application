using AspNet.Core.Web.Domains;

namespace AspNet.Core.TestData
{
    public static class CustomerData
    {
        public static Customer PrepareCustomer()
        {
            var customer = new Customer
            {
                Name = "Adi",
                LastName = "Magotra"
            };
            return customer;
        }
    }
}
