namespace SizeTracker
{
    internal interface ISiteParser
    {
        public string SiteName { get; }

        public bool IsSizeAvailable(string clothingUrl, string size);
    }
}
