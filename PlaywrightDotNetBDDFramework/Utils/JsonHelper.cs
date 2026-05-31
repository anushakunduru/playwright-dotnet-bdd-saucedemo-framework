using System.Text.Json;

namespace PlaywrightDotNetBDDFramework.Utils;

public static class JsonHelper
{
    public static T? ReadJson<T>(string filePath)
    {
        var json = File.ReadAllText(filePath);
        return JsonSerializer.Deserialize<T>(json);
    }
}