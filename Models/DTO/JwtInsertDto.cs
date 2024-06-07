using System.ComponentModel.DataAnnotations;

namespace ssoUM.DTOs;
public class JwtInsertDto
{
	[StringLength(30)]
	public string Description { get; set; } = null!;
	public long? Kid { get; set; }
}
