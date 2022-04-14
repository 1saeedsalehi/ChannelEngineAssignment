namespace ChannelEngine.Core;

public class Settings
{
    public ChannelEngine ChannelEngine { get; set; }
}

public class ChannelEngine
{
    public string BaseUrl { get; set; }
    public string ApiKey { get; set; }
}

