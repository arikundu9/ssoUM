﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ssoUM.DAL.Entities;

[Table("app")]
[Index("Jid", Name = "IX_app_jid")]
public partial class App
{
    [Key]
    [Column("aid")]
    public long Aid { get; set; }

    [Column("redirecturl")]
    [StringLength(100)]
    public string Redirecturl { get; set; } = null!;

    [Column("jid")]
    public long? Jid { get; set; }

    [Column("app_name")]
    [StringLength(30)]
    public string AppName { get; set; } = null!;

    [ForeignKey("Jid")]
    [InverseProperty("Apps")]
    public virtual Jwt? JidNavigation { get; set; }

    [InverseProperty("AidNavigation")]
    public virtual ICollection<Role> Roles { get; } = new List<Role>();

    [InverseProperty("AidNavigation")]
    public virtual ICollection<User> Users { get; } = new List<User>();
}
