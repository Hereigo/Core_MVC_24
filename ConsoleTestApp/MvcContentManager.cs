using System.Collections.Concurrent;
using System.Security.Cryptography;

namespace ConsoleTestApp
{
    public interface IMvcContentManager
    {
        string GetVersionedContentFileLink(string wwwrootFile);
    }

    public class MvcContentManager : IMvcContentManager
    {
        private readonly ConcurrentDictionary<string, string> _cachedVersions = new();
        private readonly object _cachedVersionsLocker = new object();

        public string GetVersionedContentFileLink(string wwwrootFile)
        {
            string result;
            if (!_cachedVersions.TryGetValue(wwwrootFile, out result))
            {
                lock (_cachedVersionsLocker)
                {
                    if (!_cachedVersions.TryGetValue(wwwrootFile, out result))
                    {
                        result = CalcFileMD5Hash(Environment.CurrentDirectory + "\\wwwroot" + wwwrootFile);
                        _cachedVersions.TryAdd(wwwrootFile, result);
                    }
                }
            }
            return $"{wwwrootFile}?v={result}";
        }
        // USING :
        //
        // @inject IMvcContentManager mvcContentManager
        //
        // <link rel="stylesheet" href="@mvcContentManager.GetVersionedContentFileLink(Url.Content("\\bundles\\maincss.min.css"))" />
        //
        // public static void ConfigureServices(IServiceCollection services, IConfiguration config)
        // {
        //      services.AddSingleton<IMvcContentManager, MvcContentManager>();

        internal static string CalcFileMD5Hash(string fullFilePath)
        {
            string fileHash = string.Empty;

            if (File.Exists(fullFilePath))
            {
                using (var md5 = MD5.Create())
                {
                    using (var stream = File.OpenRead(fullFilePath))
                    {
                        fileHash = BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", "").ToLowerInvariant();
                    }
                }
            }
            return fileHash;
        }
    }
}