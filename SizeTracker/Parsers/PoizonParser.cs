using HtmlAgilityPack;

namespace SizeTracker.Parsers
{
    internal class PoizonParser : ISiteParser
    {
        public static string SiteName { get; } = "poizon";

        public bool IsSizeAvailable(string clothingUrl, string userInputSize)
        { 
            try
            {
                var sizes = GetShoeSizes(clothingUrl);

                Console.WriteLine($"Доступные размеры:");
                sizes.ToList().ForEach(Console.WriteLine);

                foreach (var currentSize in sizes)
                {
                    if (currentSize == userInputSize)
                    {
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
            }
            return false;
        }

        static string[] GetShoeSizes(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = client.GetAsync(url).Result;
                response.EnsureSuccessStatusCode();
                string pageContents = response.Content.ReadAsStringAsync().Result;

                HtmlDocument doc = new HtmlDocument();
                doc.LoadHtml(pageContents);

                var sizeNodes = doc.DocumentNode.SelectNodes(".//div[@class='SkuPanel_value__BAJ1p']");

                if (sizeNodes != null)
                {
                    string[] sizes = new string[sizeNodes.Count];
                    for (int i = 0; i < sizeNodes.Count; i++)
                    {
                        sizes[i] = sizeNodes[i].InnerText.Trim();
                    }
                    return sizes;
                }
                else
                {
                    throw new Exception("Не удалось найти размеры на странице.");
                }
            }
        }
    }
}
