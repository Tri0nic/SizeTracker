namespace SizeTracker.Parsers.FactoryParser
{
    public class SiteParserFactory : ISiteParserFactory
    {
        public ISiteParser ChooseParser(string url)
        {
            if (url.Contains(JoomParser.SiteName))
            {
                return new JoomParser();
            }
            else if (url.Contains(PoizonParser.SiteName))
            {
                return new PoizonParser();
            }
            else
            {
                throw new Exception("Неверная ссылка");
            }
        }
    }
}
