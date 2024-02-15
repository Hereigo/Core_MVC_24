using ConsoleTestApp;

string decrypted = iGor.decrypted;
string encrypted = iGor.encrypted;
string key_File_ = iGor.key_File_;
string password_ = iGor.password_;

bool useKeyPass = true;

try
{
    if (!useKeyPass && !File.Exists(key_File_))
    {
        Console.WriteLine("Key is generating...");
        Cryptonic.GenerateAESKey(key_File_);
        Console.WriteLine("Key has generated.");
    }
    else if (File.Exists(decrypted))
    {
        if (File.Exists(encrypted))
        {
            Console.WriteLine("Decrypted BackUping...");
            File.Move(encrypted, encrypted + "." + DateTime.Now.ToString("MMddHHmm"));
            Console.WriteLine("Decrypted BackUped.");
        }
        else
        {
            Console.WriteLine("Encrypting...");

            if (useKeyPass)
                Cryptonic.EncryptByPass(decrypted, encrypted, password_);
            else
                Cryptonic.Encrypt(decrypted, encrypted, key_File_);

            Console.WriteLine("Encrypted finished.");

            // TODO:
            // should also remove Decrypted after test.
        }
    }
    else if (!File.Exists(decrypted) && File.Exists(encrypted))
    {
        Console.WriteLine("Decrypting...");

        if (useKeyPass)
            Cryptonic.DecryptByPass(encrypted, decrypted, password_);
        else
            Cryptonic.Decrypt(encrypted, decrypted, key_File_);

        Console.WriteLine("Decrypted finished.");
    }
    else
    {
        Console.WriteLine("Nothing to do...");
    }
}
catch (Exception ex)
{
    Console.WriteLine("Error: " + ex.Message);
}

Console.WriteLine("\r\n Finished.");
