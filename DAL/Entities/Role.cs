using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ssoUM.DAL.Entities;

[Table("role")]
[Index("Aid", Name = "IX_role_aid")]
[Index("RPid", Name = "IX_role_r_pid")]
public partial class Role
{
	[Key]
	[Column("rid")]
	public long Rid { get; set; }

	[Column("r_pid")]
	public long? RPid { get; set; }

	[Column("role_code")]
	[StringLength(30)]
	public string RoleCode { get; set; } = null!;

	[Column("aid")]
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
	public virtual ICollection<UserHasRole> UserHasRoles { get; } = new List<UserHasRole>();
}
