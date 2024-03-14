using System.IO.Compression;
string _generalPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads\\EOS\\Tests\\");
string _dabaseFile = Path.Combine(_generalPath, "workFolder\\TestDb24.dat");
string _lockedFile = Path.Combine(_generalPath, "Tests.aaa");
string _packedFile = Path.Combine(_generalPath, "Tests.pax");
string _workFolder = Path.Combine(_generalPath, "workFolder\\");
string blablatest;
try
{
    if (isDbFileExists())
    {
        if (!SkipAction(false))
        {
            string lockedFileBkp = $"{_lockedFile}.B4.{DateTime.Now:ddHHmmss}";

            if (File.Exists(_lockedFile))
                File.Copy(_lockedFile, lockedFileBkp, true);

            if (File.Exists(lockedFileBkp))
            {
                File.Delete(_lockedFile);
                ZipFile.CreateFromDirectory(_workFolder, _packedFile, CompressionLevel.SmallestSize, true);
            }

            if (File.Exists(_packedFile))
                Cryptonic.EncryptByPass(_packedFile, _lockedFile, blablatest);

            if (File.Exists(_lockedFile))
            {
                Directory.Delete(_workFolder, true);
                File.Delete(_packedFile);
            }
            Console.WriteLine("Successfully Finished.");
        }
    }
    else if (!Directory.Exists(_workFolder) && !isDbFileExists())
    {
        if (!SkipAction(true))
        {
            Cryptonic.DecryptByPass(_lockedFile, _packedFile, blablatest);

            if (File.Exists(_packedFile))
                ZipFile.ExtractToDirectory(_packedFile, _generalPath);

            if (isDbFileExists())
                File.Delete(_packedFile);

            Console.WriteLine("Successfully Prepaired For Work.");
        }
    }
    Console.WriteLine("\r\n Finished.");
}
catch (Exception ex)
{
    Console.WriteLine("Error: " + ex.Message);
}

// =================================================================================

bool isDbFileExists()
{
    return
        File.Exists(_dabaseFile) && new FileInfo(_dabaseFile).Length > 0;
}

bool SkipAction(bool isStart)
{
    bool isWrong;
    Console.WriteLine(isStart ? "Write To Start Work?" : "Write To Finish?");
    blablatest = Console.ReadLine();
    if (isStart)
    {
        isWrong = string.IsNullOrEmpty(blablatest) || blablatest.Length < 12;
    }
    else
    {
        Console.WriteLine("Write again:");
        isWrong = string.IsNullOrEmpty(blablatest) || blablatest != Console.ReadLine();
    }

    if (isWrong)
        Console.WriteLine("\r\nWRONG Abrakadabra!");

    return isWrong;
}
