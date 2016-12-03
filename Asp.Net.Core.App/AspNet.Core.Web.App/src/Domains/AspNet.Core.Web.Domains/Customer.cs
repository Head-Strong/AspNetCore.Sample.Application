using System.Collections.Generic;
using Newtonsoft.Json;

namespace AspNet.Core.Web.Domains
{
    public class Customer
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public List<Address> Addresses { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class CustomErrorDto
    {
        public string ErrorMessage { get; set; }    

        public int ErrorType { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
