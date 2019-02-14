using HtmlAgilityPack;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using WebColletctions;

namespace Scraper.Parsers
{
    public class AliExpressParser : IParser
    {
        private HtmlDocument dom;
        private IList<AliExpressItem> items;

        public string NextPage { get; set; }
        public string Category { get; set; }

        public AliExpressParser(HtmlDocument dom)
        {
            this.dom = dom;
            this.items = new List<AliExpressItem>();
        }

        public void ParseDocument()
        {
            if (dom.DocumentNode.SelectSingleNode("//a[contains(@class, 'page-next')]") != null)
                this.NextPage = "https:" + dom.DocumentNode.SelectSingleNode("//a[contains(@class, 'page-next')]").Attributes["href"].Value;
            if (dom.DocumentNode.SelectSingleNode("//span[contains(@class, 'current-cate')]") != null)
                this.Category = dom.DocumentNode.SelectSingleNode("//span[contains(@class, 'current-cate')]").InnerText;

            foreach (var item in dom.DocumentNode.SelectSingleNode("//ul[contains(@class, 'son-list')]").ChildNodes)
            {
                if (item.Name == "#text")
                {
                    continue;
                }

                var newDom = new HtmlDocument();
                newDom.LoadHtml(item.OuterHtml);
                var newItem = newDom.DocumentNode.FirstChild;

                var aliItem = new AliExpressItem();
                var reg = new Regex(@"\|(?<Code>\d+)\|");
                var match = reg.Match(newItem.Attributes["qrdata"].Value);

                if (match.Success)
                {
                    aliItem.Code = match.Groups["Code"].Value;
                }

                aliItem.Name = newItem.SelectSingleNode("//a[contains(@class, 'product')]").InnerText;
                aliItem.SiteAddress = newItem.SelectSingleNode("//a[contains(@class, 'product')]").Attributes["href"].Value;
                aliItem.Price = newItem.SelectSingleNode("//span[contains(@class, 'price')]/span[contains(@class, 'value')]").InnerText;

                this.items.Add(aliItem);
            }
        }

        public void WriteOutput(Stream source)
        {
            var jsonPage = JsonConvert.SerializeObject(this.items, Formatting.Indented);

            if (source.CanWrite)
            {
                var writer = new StreamWriter(source);
                writer.AutoFlush = true;

                writer.Write(jsonPage);
            }
        }
    }
}