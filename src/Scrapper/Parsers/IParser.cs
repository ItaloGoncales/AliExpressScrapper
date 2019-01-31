using System.IO;

namespace Scraper.Parsers
{
    public interface IParser
    {
        void ParseDocument();
        void WriteOutput(Stream source);
    }
}