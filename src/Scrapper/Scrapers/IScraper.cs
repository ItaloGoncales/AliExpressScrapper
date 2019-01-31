namespace Scraper.Scrapers
{
    public interface IScraper
    {
        string URL { get; set; }
        string Username { get; set; }
        string Password { get; set; }
    }
}