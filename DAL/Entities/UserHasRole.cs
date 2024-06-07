using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ssoUM.DAL.Entities;

[Table("user_has_role")]
public partial class UserHasRole
{
	[Key]
	[Column("mapping_id")]
	public long MappingId { get; set; }

	[Column("uid")]
	public long Uid { get; set; }

	[Column("rid")]
	public long Rid { get; set; }

	[ForeignKey("Rid")]
	[InverseProperty("UserHasRoles")]
	public virtual Role RidNavigation { get; set; } = null!;

	[ForeignKey("Uid")]
	[InverseProperty("UserHasRoles")]
	public virtual User UidNavigation { get; set; } = null!;
}
