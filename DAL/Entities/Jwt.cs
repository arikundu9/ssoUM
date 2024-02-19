using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ssoUM.DAL.Entities;

[Table("jwt")]
[Index("Kid", Name = "IX_jwt_kid")]
public partial class Jwt
{
    [Key]
    [Column("jid")]
    public long Jid { get; set; }

    [Column("description")]
    [StringLength(30)]
    public string Description { get; set; } = null!;

    [Column("kid")]
    public long? Kid { get; set; }

    [InverseProperty("JidNavigation")]
    public virtual ICollection<App> Apps { get; } = new List<App>();

    [ForeignKey("Kid")]
    [InverseProperty("Jwts")]
    public virtual Key? KidNavigation { get; set; }
}
