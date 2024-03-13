using System.Security.Cryptography;
using System.Text;

public static class Cryptonic
{
    public static void GenerateAESKey(string keyFilePath)
    {
        using AesManaged aes = new();
        aes.KeySize = 256;
        aes.GenerateKey();
        // Initialization Vector (IV) used for encryption is prepended to the encrypted file.
        aes.GenerateIV();
        File.WriteAllBytes(keyFilePath, aes.Key);
        File.WriteAllBytes(keyFilePath + ".iv", aes.IV);
    }

    public static void Encrypt(string decrypted, string encrypted, string key_File_)
    {
        using FileStream fsInput = new(decrypted, FileMode.Open);
        using FileStream fsOutput = new(encrypted, FileMode.Create);
        ICryptoTransform encryptor = CreateAesCryptorByPass(false, key_File_);
        using CryptoStream cs = new CryptoStream(fsOutput, encryptor, CryptoStreamMode.Write);
        fsInput.CopyTo(cs);
    }

    public static void Decrypt(string encrypted, string decrypted, string key_File_)
    {
        using FileStream fsInput = new(encrypted, FileMode.Open);
        using FileStream fsOutput = new(decrypted, FileMode.Create);
        ICryptoTransform decryptor = CreateAesCryptor(true, key_File_);
        using CryptoStream cs = new CryptoStream(fsOutput, decryptor, CryptoStreamMode.Write);
        fsInput.CopyTo(cs);
    }

    public static ICryptoTransform CreateAesCryptor(bool isDecrypt, string key_File_)
    {
        using AesManaged aes = new();
        aes.Key = File.ReadAllBytes(key_File_);
        aes.IV = File.ReadAllBytes(key_File_ + ".iv");
        return isDecrypt
            ? aes.CreateDecryptor()
            : aes.CreateEncryptor();
    }

    public static ICryptoTransform CreateAesCryptorByPass(bool isDecrypt, string password)
    {
        UnicodeEncoding UE = new UnicodeEncoding();
        using AesManaged aes = new();
        byte[] passwordBytes = UE.GetBytes(password);
        byte[] aesKey = SHA256.Create().ComputeHash(passwordBytes);
        byte[] aesIV = MD5.Create().ComputeHash(passwordBytes);
        aes.Key = aesKey;
        aes.IV = aesIV;
        aes.Mode = CipherMode.CBC;
        aes.Padding = PaddingMode.PKCS7;
        return isDecrypt
            ? aes.CreateDecryptor()
            : aes.CreateEncryptor();
    }

    public static void EncryptByPass(string decrypted, string encrypted, string password)
    // public static async Task EncryptByPass(string decrypted, string encrypted, string password)
    {
        using FileStream fsInput = new(decrypted, FileMode.Open);
        using FileStream fsOutput = new(encrypted, FileMode.Create);
        ICryptoTransform encryptor = CreateAesCryptorByPass(false, password);
        using CryptoStream cs = new CryptoStream(fsOutput, encryptor, CryptoStreamMode.Write);
        fsInput.CopyTo(cs);

        System.Threading.Thread.Sleep(3000);
    }

    public static void DecryptByPass(string encrypted, string decrypted, string password)
    // public static async Task DecryptByPass(string encrypted, string decrypted, string password)
    {
        using FileStream fsInput = new(encrypted, FileMode.Open);
        using FileStream fsOutput = new(decrypted, FileMode.Create);
        ICryptoTransform decryptor = CreateAesCryptorByPass(true, password);
        using CryptoStream cs = new CryptoStream(fsOutput, decryptor, CryptoStreamMode.Write);
        fsInput.CopyTo(cs);

        System.Threading.Thread.Sleep(3000);
    }
}
