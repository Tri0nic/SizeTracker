namespace SizeTracker.Parsers
{
    public abstract class SiteParserBase : ISiteParser
    {
        public abstract string[] GetAvailableSizes(string url);

        public bool IsSizeAvailable(string clothingUrl, string userInputSize)
        {
            try
            {
                var sizes = GetAvailableSizes(clothingUrl);

                Console.WriteLine("Доступные размеры:");
                sizes.ToList().ForEach(Console.WriteLine); //TODO: сделать в строку через запятую + вывод времени + вывод номера попытки

                return sizes.Contains(userInputSize);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}"); //TODO
                return false;
            }
        }
    }
}
