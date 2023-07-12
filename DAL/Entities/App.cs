using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ssoUM.DAL.Entities;

[Table("App")]
public partial class App
{
    [Key]
    [Column("AID")]
    public long Aid { get; set; }

    [Column("redirectUrl")]
    [StringLength(100)]
    [Unicode(false)]
    public string RedirectUrl { get; set; } = null!;

    [Column("JID")]
    public long? Jid { get; set; }

    [ForeignKey("Jid")]
    [InverseProperty("Apps")]
    public virtual Jwt? JidNavigation { get; set; }

    [InverseProperty("AidNavigation")]
    public virtual ICollection<Role> Roles { get; } = new List<Role>();

    [InverseProperty("AidNavigation")]
    public virtual ICollection<User> Users { get; } = new List<User>();
}
