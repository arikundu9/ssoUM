using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using Microsoft.EntityFrameworkCore;

namespace ssoUM.DAL.Entities;

[Table("app")]
[Index("Jid", Name = "IX_app_jid")]
[Serializable]
[DataContract(IsReference = true)]
public partial class App
{
    [Key]
    [Column("aid")]
    [XmlElement("Aid")]
    public long Aid { get; set; }

    [Column("redirecturl")]
    [StringLength(100)]
    [XmlElement("Redirecturl")]
    public string Redirecturl { get; set; } = null!;

    [XmlElement("Jid")]
    [Column("jid")]
    public long? Jid { get; set; }

    [Column("app_name")]
    [XmlElement("AppName")]
    [StringLength(30)]
    public string AppName { get; set; } = null!;

    [ForeignKey("Jid")]
    [InverseProperty("Apps")]
    [XmlElement("JidNavigation")]
    public virtual Jwt? JidNavigation { get; set; }

    [InverseProperty("AidNavigation")]
    [XmlElement("Roles")]
    public virtual ICollection<Role> Roles { get; } = new List<Role>();

    [InverseProperty("AidNavigation")]
    [XmlElement("Users")]
    public virtual ICollection<User> Users { get; } = new List<User>();
}
