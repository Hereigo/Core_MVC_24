using FolkerKinzel.VCards;
using FolkerKinzel.VCards.Extensions;

namespace ConsoleTestApp
{
    internal static class VcfProfileParserFK
    {
        public static void VcfParseRun()
        {
            string fileVcfPath = GIT_IGNORE.fileVcfPath;

            IList<VCard> vCards = Vcf.Load(fileVcfPath);

            var vCard = vCards[0];

            System.Collections.ObjectModel.ReadOnlyCollection<string>? GivenName = vCard.NickNames.PrefOrNull()?.Value;

            FolkerKinzel.VCards.Models.PropertyParts.Name? AdditionalName = vCard.NameViews.PrefOrNull()?.Value;

            var TEST = new Profile();
            //{
            //    // ProfileID = vCard.AAAAA.PrefOrNull()?.Value,
            //    AaaType = $"Export-{DateTime.Now:yyMMdd_HH}", // vCard.AAAAA.PrefOrNull()?.Value,
            //    Name = vCard.DisplayNames.PrefOrNull()?.Value,
                
            //    GivenName = vCard.NickNames.PrefOrNull()?.Value,

            //    AdditionalName = vCard.NameViews.PrefOrNull()?.Value,

            //    FamilyName = vCard.DirectoryName.PrefOrNull()?.Value,
            //    YomiName = vCard.DirectoryName.PrefOrNull()?.Value,

            //    // GivenNameYomi = vCard.AAAAA.PrefOrNull()?.Value,
            //    // AdditionalNameYomi = vCard.AAAAA.PrefOrNull()?.Value,
            //    // FamilyNameYomi = vCard.AAAAA.PrefOrNull()?.Value,
            //    // NamePrefix = vCard.AAAAA.PrefOrNull()?.Value,
            //    // NameSuffix = vCard.AAAAA.PrefOrNull()?.Value,
            //    // Initials = vCard.AAAAA.PrefOrNull()?.Value,
            //    // Nickname = vCard.AAAAA.PrefOrNull()?.Value,
            //    // ShortName = vCard.AAAAA.PrefOrNull()?.Value,
            //    // MaidenName = vCard.AAAAA.PrefOrNull()?.Value,

            //    Birthday = vCard.BirthDayViews.PrefOrNull()?.Value,
            //    Gender = vCard.GenderViews.PrefOrNull()?.Value,
            //    Location = vCard.GeoCoordinates.PrefOrNull()?.Value,

            //    // BillingInformation = vCard.AAAAA.PrefOrNull()?.Value,
            //    // DirectoryServer = vCard.AAAAA.PrefOrNull()?.Value,
            //    // Mileage = vCard.AAAAA.PrefOrNull()?.Value,
            //    Occupation = vCard.AAAAA.PrefOrNull()?.Value,
            //    Hobby = vCard.AAAAA.PrefOrNull()?.Value,
            //    Sensitivity = vCard.AAAAA.PrefOrNull()?.Value,
            //    Priority = vCard.AAAAA.PrefOrNull()?.Value,
            //    Subject = vCard.AAAAA.PrefOrNull()?.Value,
            //    Notes = vCard.AAAAA.PrefOrNull()?.Value,
            //    Language = vCard.AAAAA.PrefOrNull()?.Value,
            //    Photo = vCard.AAAAA.PrefOrNull()?.Value,
            //    GroupMembership = vCard.AAAAA.PrefOrNull()?.Value,
            //    Email1type = vCard.AAAAA.PrefOrNull()?.Value,
            //    Email1value = vCard.AAAAA.PrefOrNull()?.Value,
            //    Email2type = vCard.AAAAA.PrefOrNull()?.Value,
            //    Email2value = vCard.AAAAA.PrefOrNull()?.Value,
            //    Email3type = vCard.AAAAA.PrefOrNull()?.Value,
            //    Email3value = vCard.AAAAA.PrefOrNull()?.Value,
            //    IM1type = vCard.AAAAA.PrefOrNull()?.Value,
            //    IM1Service = vCard.AAAAA.PrefOrNull()?.Value,
            //    IM1value = vCard.AAAAA.PrefOrNull()?.Value,
            //    Phone1type = vCard.AAAAA.PrefOrNull()?.Value,
            //    Phone1value = vCard.AAAAA.PrefOrNull()?.Value,
            //    Phone2type = vCard.AAAAA.PrefOrNull()?.Value,
            //    Phone2value = vCard.AAAAA.PrefOrNull()?.Value,
            //    Phone3type = vCard.AAAAA.PrefOrNull()?.Value,
            //    Phone3value = vCard.AAAAA.PrefOrNull()?.Value,
            //    Address1type = vCard.AAAAA.PrefOrNull()?.Value,
            //    Address1Formatted = vCard.AAAAA.PrefOrNull()?.Value,
            //    Address1Street = vCard.AAAAA.PrefOrNull()?.Value,
            //    Address1City = vCard.AAAAA.PrefOrNull()?.Value,
            //    Address1POBox = vCard.AAAAA.PrefOrNull()?.Value,
            //    Address1Region = vCard.AAAAA.PrefOrNull()?.Value,
            //    Address1PostalCode = vCard.AAAAA.PrefOrNull()?.Value,
            //    Address1Country = vCard.AAAAA.PrefOrNull()?.Value,
            //    Address1ExtendedAddress = vCard.AAAAA.PrefOrNull()?.Value,
            //    Org1type = vCard.AAAAA.PrefOrNull()?.Value,
            //    Org1Name = vCard.AAAAA.PrefOrNull()?.Value,
            //    Org1YomiName = vCard.AAAAA.PrefOrNull()?.Value,
            //    Org1Title = vCard.AAAAA.PrefOrNull()?.Value,
            //    Org1Department = vCard.AAAAA.PrefOrNull()?.Value,
            //    Org1Symbol = vCard.AAAAA.PrefOrNull()?.Value,
            //    Org1Location = vCard.AAAAA.PrefOrNull()?.Value,
            //    Org1JobDescription = vCard.AAAAA.PrefOrNull()?.Value,
            //    Website1type = vCard.AAAAA.PrefOrNull()?.Value,
            //    Website1value = vCard.AAAAA.PrefOrNull()?.Value,
            //    Website2type = vCard.AAAAA.PrefOrNull()?.Value,
            //    Website2value = vCard.AAAAA.PrefOrNull()?.Value,
            //    Event1type = vCard.AAAAA.PrefOrNull()?.Value,
            //    Event1value = vCard.AAAAA.PrefOrNull()?.Value,
            //    CustomField1type = vCard.AAAAA.PrefOrNull()?.Value,
            //    CustomField1value = vCard.AAAAA.PrefOrNull()?.Value
            //};
        }
    }
}
