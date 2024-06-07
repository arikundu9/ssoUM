namespace ssoUM.DTOs;
public class AppInsertDto
{
	public string Redirecturl { get; set; } = null!;

	public long? Jid { get; set; }

	public string AppName { get; set; } = null!;
}
