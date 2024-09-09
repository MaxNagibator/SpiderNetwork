using Microsoft.AspNetCore.Rewrite;

namespace SpiderNetwork.Client
{
    public static class Globals
    {
        public static Settings Settings { get; set; }
    }

    public class Settings
    {
        public int ClientId { get; set; }
    }
}
