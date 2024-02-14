﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ssoUM.DAL.Entities;

[Table("user")]
public partial class User
{
    [Key]
    [Column("uid")]
    public long Uid { get; set; }

    [Column("aid")]
    public long Aid { get; set; }

    [Column("rid")]
    public long? Rid { get; set; }

    [Column("username")]
    [StringLength(100)]
    public string Username { get; set; } = null!;

    [Column("password_hash")]
    [StringLength(100)]
    public string PasswordHash { get; set; } = null!;

    [Column("password_salt")]
    [StringLength(100)]
    public string PasswordSalt { get; set; } = null!;

    [ForeignKey("Aid")]
    [InverseProperty("Users")]
    public virtual App AidNavigation { get; set; } = null!;

    [ForeignKey("Rid")]
    [InverseProperty("Users")]
    public virtual Role? RidNavigation { get; set; }
}
