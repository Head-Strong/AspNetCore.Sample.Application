using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Internal;

namespace EntityFramework.Core.Models
{
    [Table("Address")]
    public partial class Address
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Column("AddressId")]
        public int AddressId { get; set; }

        [Column("CustomerId")]
        public int CustomerId { get; set; }

        [Column("Pin")]
        public string Pin { get; set; }

        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }
    }
}