namespace SizeTracker.Parsers.FactoryParser
{
    public interface ISiteParserFactory
    {
        ISiteParser ChooseParser(string url);
    }
}
