using System.Security.Cryptography;

internal static class Cryptonic2
{
    internal static void GenerateAESKey(string keyFilePath)
    {
        byte[] aesKey;

        using (Aes aesAlg = Aes.Create())
        {
            aesAlg.GenerateKey();
            aesKey = aesAlg.Key;
        }
        File.WriteAllBytes(keyFilePath, aesKey);
    }

    internal static void Encrypt(string inputFile, string encrypted, string key_File_)
    {
        using FileStream fsInput = new(inputFile, FileMode.Open);
        using FileStream fsOutput = new(encrypted, FileMode.Create);
        using AesManaged aes = new();

        aes.KeySize = 256;
        aes.GenerateKey();
        aes.GenerateIV();
        // Initialization Vector (IV) used for encryption is prepended to the encrypted file.

        File.WriteAllBytes(key_File_, aes.Key);
        File.WriteAllBytes(key_File_ + ".iv", aes.IV);

        ICryptoTransform encryptor = aes.CreateEncryptor();

        using CryptoStream cs = new CryptoStream(fsOutput, encryptor, CryptoStreamMode.Write);
        fsInput.CopyTo(cs);
    }

    internal static void Decrypt(string encrypted, string decrypted, string key_File_)
    {
        using FileStream fsInput = new(encrypted, FileMode.Open);
        using FileStream fsOutput = new(decrypted, FileMode.Create);
        using AesManaged aes = new();

        aes.Key = File.ReadAllBytes(key_File_);
        aes.IV = File.ReadAllBytes(key_File_ + ".iv");

        ICryptoTransform decryptor = aes.CreateDecryptor();

        using CryptoStream cs = new CryptoStream(fsOutput, decryptor, CryptoStreamMode.Write);
        fsInput.CopyTo(cs);
    }
}
