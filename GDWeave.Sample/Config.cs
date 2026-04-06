using System.Text.Json.Serialization;

namespace Shaderade;

public class Config(ConfigFileSchema configFile)
{
	[JsonInclude]
	public float red = configFile.red;
	public float green = configFile.green;
	public float blue = configFile.blue;
}
