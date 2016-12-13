using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFramework.Core.Models
{
    [Table("Profiles")]
    public class Profiles
    {
        [Key]
        [Column("idProfile")]
        public int IdProfile { get; set; }

        [Column("profileName")]
        public string ProfileName { get; set; }

        //[ForeignKey("ProfileRoleLink")]
        public virtual ICollection<ProfileRoleLink> ProfileRoleLinks { get; set; }

        public Profiles()
        {
            this.ProfileRoleLinks = new List<ProfileRoleLink>();
        }
    }

    [Table("Roles")]
    public class Roles
    {
        [Key]
        [Column("idRole")]
        public int IdRole { get; set; }

        [Column("roleName")]
        public string RoleName { get; set; }

        //[ForeignKey("ProfileRoleLink")]
        public virtual ICollection<ProfileRoleLink> ProfileRoleLinks { get; set; }

        public Roles()
        {
            this.ProfileRoleLinks = new List<ProfileRoleLink>();
        }
    }

    [Table("Profile_Role_Link")]
    public class ProfileRoleLink
    {
        /// <summary>
        /// 
        /// </summary>
        [Column("idProfile", Order = 0), Key]
        public int IdProfile { get; set; }

        [ForeignKey("IdProfile")]
        public virtual Profiles Profile { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("idRole", Order = 1), Key]
        public int IdRole { get; set; }

        [ForeignKey("IdRole")]
        public virtual Roles Role { get; set; }
    }
}
