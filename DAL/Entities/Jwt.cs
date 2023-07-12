using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ssoUM.DAL.Entities;

[Table("jwt")]
public partial class Jwt
{
    [Key]
    [Column("JID")]
    public long Jid { get; set; }

    [Column("description")]
    [StringLength(30)]
    [Unicode(false)]
    public string Description { get; set; } = null!;

    [Column("KID")]
    public long? Kid { get; set; }

    [InverseProperty("JidNavigation")]
    public virtual ICollection<App> Apps { get; } = new List<App>();

    [ForeignKey("Kid")]
    [InverseProperty("Jwts")]
    public virtual Key? KidNavigation { get; set; }
}
