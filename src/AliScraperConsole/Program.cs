using Scraper.Parsers;
using Scraper.Scrapers;
using System;
using System.Configuration;
using System.IO;

namespace AliScraperConsole
{
    public class Program
    {
        static void Main(string[] args)
        {
            string outputPath = ConfigurationManager.AppSettings.Get("OutputPath");

            Console.WriteLine("Digit the AliExpress URL that you want to scrap data:");
            var url = Console.ReadLine();

            var scraper = new WebScraper(url);

            int num_pages = 0;

            do
            {
                Console.WriteLine("How many pages do you want to scrap?");

                try
                {
                    num_pages = Int32.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid input value. Try to use a valid number.");
                }
            } while (num_pages == 0);

            var parser = new AliExpressParser(scraper.LoadPage());

            int page_counter = 1;

            do
            {
                parser.ParseDocument();

                var outputFile = Path.Combine(outputPath, $"{parser.Category.ToLower().Replace(" ", String.Empty)}_page_{page_counter}.json");

                if (File.Exists(outputFile))
                {
                    File.Delete(outputFile);
                }

                using (var stream = new FileStream(outputFile, FileMode.CreateNew))
                {
                    Console.WriteLine($"Saving page {page_counter} into {outputFile}");
                    parser.WriteOutput(stream);
                }

                if (!String.IsNullOrEmpty(parser.NextPage))
                {
                    scraper = new WebScraper(parser.NextPage);
                    parser = new AliExpressParser(scraper.LoadPage());
                    page_counter++;
                }
            } while (page_counter <= num_pages);
        }
    }
}
