
string decrypted = "";
string encrypted = "";
string key_File_ = "";

try
{
    Cryptonic.GenerateAESKey(key_File_);
    Cryptonic.Encrypt(decrypted, encrypted, key_File_);
    Cryptonic.Decrypt(encrypted, decrypted, key_File_);
}
catch (Exception ex)
{
    Console.WriteLine("Error: " + ex.Message);
}

Console.WriteLine("Done.");
