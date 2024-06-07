using System.ComponentModel.DataAnnotations;

namespace ssoUM.DTOs;
public class KeyInsertDto
{
	public short Type { get; set; }

	public string PrivateKey { get; set; } = null!;

	public string? PublicKey { get; set; }

	[StringLength(30)]
	public string Algo { get; set; } = null!;
}
