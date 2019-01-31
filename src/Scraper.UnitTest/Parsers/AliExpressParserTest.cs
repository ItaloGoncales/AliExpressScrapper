using HtmlAgilityPack;
using Newtonsoft.Json;
using NUnit.Framework;
using Scraper.Parsers;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using WebColletctions;

namespace Scraper.UnitTest.Parsers
{
    [TestFixture]
    public class AliExpressParserTest
    {
        private HtmlDocument dom;
        private AliExpressParser parser;
        private string outputFile = @"..\..\..\..\resources\output.json";

        [SetUp]
        void SetUp()
        {
            dom = new HtmlDocument();
            dom.Load(@"..\..\..\..\resources\category_page.html");
        }

        [Test]
        public void parseDocument_validDocument_parseOk()
        {
            // Prepare
            parser = new AliExpressParser(dom);
            string output;
            // Act
            parser.ParseDocument();

            using (var stream = new FileStream(outputFile, FileMode.CreateNew))
            {
                parser.WriteOutput(stream);
            }

            output = File.ReadAllText(outputFile);

            var aliList = JsonConvert.DeserializeObject<List<AliExpressItem>>(output);

            File.Delete(outputFile);
            // Assert

            Assert.That(aliList.First().Code, Is.EqualTo("32710766482"));
            Assert.That(aliList.First().Name, Is.EqualTo("WolfRule Handbag Cover Flip PU Leather Silicone Wallet Phone Case Pro Case For Doogee"));
            Assert.That(aliList.First().Price, Is.EqualTo("US $2.64"));
        }

        [Test]
        public void parseDocument_lastPage_parseOl()
        {
            // Prepare
            dom.Load(@"..\..\..\..\resources\category_page_last.html");
            parser = new AliExpressParser(dom);
            string output;

            // Act
            parser.ParseDocument();

            using (var stream = new FileStream(outputFile, FileMode.CreateNew))
            {
                parser.WriteOutput(stream);
            }

            output = File.ReadAllText(outputFile);

            var aliList = JsonConvert.DeserializeObject<List<AliExpressItem>>(output);

            File.Delete(outputFile);
            // Assert

            Assert.That(aliList.First().Code, Is.EqualTo("32217250589"));
            Assert.That(aliList.First().Name, Is.EqualTo("Luxo Caso De Couro Real Para LG Optimus G3 D850 D855 Telefone Tampa Traseira Fique Livro Estilo Com Suporte de CartÃ£o"));
            Assert.That(aliList.First().Price, Is.EqualTo("US $3.78"));
            Assert.That(parser.NextPage, Is.Null);

        }
    }
}