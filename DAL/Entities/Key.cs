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
    [Column("KID")]
    public long Kid { get; set; }

    [Column("type")]
    public bool Type { get; set; }

    [Column("private_key")]
    [Unicode(false)]
    public string PrivateKey { get; set; } = null!;

    [Column("public_key")]
    [Unicode(false)]
    public string? PublicKey { get; set; }

    [Column("algo")]
    [StringLength(30)]
    [Unicode(false)]
    public string Algo { get; set; } = null!;

    [InverseProperty("KidNavigation")]
    public virtual ICollection<Jwt> Jwts { get; } = new List<Jwt>();
}
