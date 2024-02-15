﻿using System.Security.Cryptography;

internal static class Cryptonic
{
    internal static void GenerateAESKey(string keyFilePath)
    {
        using AesManaged aes = new();
        aes.KeySize = 256;

        aes.GenerateKey();
        // Initialization Vector (IV) used for encryption is prepended to the encrypted file.
        aes.GenerateIV();

        File.WriteAllBytes(keyFilePath, aes.Key);
        File.WriteAllBytes(keyFilePath + ".iv", aes.IV);
    }

    internal static void Encrypt(string decrypted, string encrypted, string key_File_)
    {
        using FileStream fsInput = new(decrypted, FileMode.Open);
        using FileStream fsOutput = new(encrypted, FileMode.Create);

        using AesManaged aes = new();
        aes.Key = File.ReadAllBytes(key_File_);
        aes.IV = File.ReadAllBytes(key_File_ + ".iv");

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
