namespace SizeTracker.Parsers
{
    public interface ISiteParser
    {
        public static string SiteName { get; }

        public bool IsSizeAvailable(string clothingUrl, string size);
    }
}
