using System.Text;
using Core_MVC_24.Models;
using TinyCsvParser;
using TinyCsvParser.Mapping;

namespace Core_MVC_24.Infrastructure
{
    public static class VcfProfileParser
    {
        public static void ParseVcf(string vcfFile)
        {
            if (File.Exists(vcfFile))
            {
                const Int32 BufferSize = 256;
                using (var fileStream = File.OpenRead(vcfFile))
                using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize))
                {
                    String line;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        // Process line



                    }
                }
                var TEST = true;
            }
        }
    }
}
