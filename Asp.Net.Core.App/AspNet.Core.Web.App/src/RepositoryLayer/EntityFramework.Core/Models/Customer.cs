using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFramework.Core.Models
{
    public class Customer
    {
        public Customer()
        {
            Address = new HashSet<Address>();
        }
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public int Id { get; set; }

        [Column("Name")]
        public string Name { get; set; }

        [Column("LastName")]
        public string LastName { get; set; }

        //[Column("Address")]
        public virtual ICollection<Address> Address { get; set; }
    }
}
