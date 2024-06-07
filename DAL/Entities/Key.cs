using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ssoUM.DAL.Entities;

[Table("keys")]
public partial class Key
{
    [Key]
    [Column("kid")]
    public long Kid { get; set; }

    [Column("type")]
    public short Type { get; set; }

    [Column("private_key", TypeName = "character varying")]
    public string PrivateKey { get; set; } = null!;

    [Column("public_key", TypeName = "character varying")]
    public string? PublicKey { get; set; }

    [Column("algo")]
    [StringLength(30)]
    public string Algo { get; set; } = null!;

    [InverseProperty("KidNavigation")]
    public virtual ICollection<Jwt> Jwts { get; } = new List<Jwt>();
}
