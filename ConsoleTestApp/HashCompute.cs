using System.Security.Cryptography;

namespace ConsoleTestApp
{
    internal class HashCompute
    {
        internal string FileHashCompute(string fileFullPath)
        {
            string hashString = string.Empty;

            if (File.Exists(fileFullPath))
            {
                using (var md5 = MD5.Create())
                {
                    using (var stream = File.OpenRead(fileFullPath))
                    {
                        byte[] hashBytes = md5.ComputeHash(stream);

                        hashString = BitConverter.ToString(hashBytes).Replace("-", "").ToLowerInvariant();
                    }
                }
            }
            return hashString;
        }
    }
}