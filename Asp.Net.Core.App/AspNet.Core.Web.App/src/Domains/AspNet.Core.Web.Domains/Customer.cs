using System.Collections.Generic;

namespace AspNet.Core.Web.Domains
{
    public class Customer
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }    

        public List<Address> Addresses { get; set; } 
    }
}
