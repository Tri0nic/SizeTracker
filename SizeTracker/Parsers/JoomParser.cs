namespace SizeTracker.Parsers
{
    internal class JoomParser : ISiteParser
    {
        public static string SiteName { get; } = "joom";

        public bool IsSizeAvailable(string clothingUrl, string size)
        {
            throw new NotImplementedException();
        }
    }
}
