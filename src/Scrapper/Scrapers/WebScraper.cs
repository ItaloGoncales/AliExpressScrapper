using HtmlAgilityPack;
using System.Net;

namespace Scraper.Scrapers
{
    public class WebScraper : IScraper
    {
        private WebClient webClient;
        private HtmlDocument dom;

        public WebScraper(string url)
        {
            URL = url;

            this.webClient = new WebClient();
            this.dom = new HtmlDocument();
        }

        public WebScraper(string url, string username, string password)
        : this(url)
        {
            Username = username;
            Password = password;
        }

        public HtmlDocument LoadPage()
        {
            this.dom.LoadHtml(this.webClient.DownloadString(this.URL));

            return this.dom;
        }

        public void Authenticate() { }

        public void Authenticate(string username, string password)
        {
            this.Username = username;
            this.Password = password;

            this.Authenticate();
        }

        public string URL { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}