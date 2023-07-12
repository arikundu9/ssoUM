using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ssoUM.DAL.Entities;

[Table("role")]
public partial class Role
{
    [Key]
    [Column("RID")]
    public long Rid { get; set; }

    [Column("R_PID")]
    public long? RPid { get; set; }

    [Column("role_code")]
    [StringLength(30)]
    [Unicode(false)]
    public string RoleCode { get; set; } = null!;

    [Column("AID")]
    public long? Aid { get; set; }

    [ForeignKey("Aid")]
    [InverseProperty("Roles")]
    public virtual App? AidNavigation { get; set; }

    [InverseProperty("RP")]
    public virtual ICollection<Role> InverseRP { get; } = new List<Role>();

    [ForeignKey("RPid")]
    [InverseProperty("InverseRP")]
    public virtual Role? RP { get; set; }

    [InverseProperty("RidNavigation")]
    public virtual ICollection<User> Users { get; } = new List<User>();
}
