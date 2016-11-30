using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFramework.Core.Models
{
    [Table("Address")]
    [ComplexType]
    public partial class Address
    {
        [Key]
        [Column("AddressId")]
        public int Id { get; set; }

        [Column("CustomerId")]
        public int CustomerId { get; set; }

        [Column("Pin")]
        public string Pin { get; set; }

        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }
    }
}