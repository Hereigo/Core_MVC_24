using System.Text;
using Core_MVC_24.Models;
using TinyCsvParser;
using TinyCsvParser.Mapping;

namespace Core_MVC_24.Infrastructure
{
    public class CsvProfileParser
    {
        public void ParseCsv(string csvFile, Encoding encoding)
        {
            if (File.Exists(csvFile))
            {
                CsvParserOptions csvParserOptions = new CsvParserOptions(false, ';');
                CsvProfileMapping csvMapper = new CsvProfileMapping();
                CsvParser<Profile> csvParser = new CsvParser<Profile>(csvParserOptions, csvMapper);

                List<CsvMappingResult<Profile>> result = csvParser
                    .ReadFromFile(csvFile, encoding ?? Encoding.ASCII)
                    .ToList();

                var TEST = true;
            }
        }
    }

    public class CsvProfileMapping : CsvMapping<Profile>
    {
        public CsvProfileMapping()
            : base()
        {
            MapProperty(0, x => x.ProfileID);
            MapProperty(1, x => x.AType);
            MapProperty(2, x => x.Name);
            MapProperty(3, x => x.GivenName);
            MapProperty(4, x => x.AdditionalName);
            MapProperty(5, x => x.FamilyName);
            MapProperty(6, x => x.YomiName);
            MapProperty(7, x => x.GivenNameYomi);
            MapProperty(8, x => x.AdditionalNameYomi);
            MapProperty(9, x => x.FamilyNameYomi);
            MapProperty(10, x => x.NamePrefix);
            MapProperty(11, x => x.NameSuffix);
            MapProperty(12, x => x.Initials);
            MapProperty(13, x => x.Nickname);
            MapProperty(14, x => x.ShortName);
            MapProperty(15, x => x.MaidenName);
            MapProperty(16, x => x.Birthday);
            MapProperty(17, x => x.Gender);
            MapProperty(18, x => x.Location);
            MapProperty(19, x => x.BillingInformation);
            MapProperty(20, x => x.DirectoryServer);
            MapProperty(21, x => x.Mileage);
            MapProperty(22, x => x.Occupation);
            MapProperty(23, x => x.Hobby);
            MapProperty(24, x => x.Sensitivity);
            MapProperty(25, x => x.Priority);
            MapProperty(26, x => x.Subject);
            MapProperty(27, x => x.Notes);
            MapProperty(28, x => x.Language);
            MapProperty(29, x => x.Photo);
            MapProperty(30, x => x.GroupMembership);
            MapProperty(31, x => x.Email1type);
            MapProperty(32, x => x.Email1value);
            MapProperty(33, x => x.Email2type);
            MapProperty(34, x => x.Email2value);
            MapProperty(35, x => x.Email3type);
            MapProperty(36, x => x.Email3value);
            MapProperty(37, x => x.IM1type);
            MapProperty(38, x => x.IM1Service);
            MapProperty(39, x => x.IM1value);
            MapProperty(40, x => x.Phone1type);
            MapProperty(41, x => x.Phone1value);
            MapProperty(42, x => x.Phone2type);
            MapProperty(43, x => x.Phone2value);
            MapProperty(44, x => x.Phone3type);
            MapProperty(45, x => x.Phone3value);
            MapProperty(46, x => x.Address1type);
            MapProperty(47, x => x.Address1Formatted);
            MapProperty(48, x => x.Address1Street);
            MapProperty(49, x => x.Address1City);
            MapProperty(50, x => x.Address1POBox);
            MapProperty(51, x => x.Address1Region);
            MapProperty(52, x => x.Address1PostalCode);
            MapProperty(53, x => x.Address1Country);
            MapProperty(54, x => x.Address1ExtendedAddress);
            MapProperty(55, x => x.Org1type);
            MapProperty(56, x => x.Org1Name);
            MapProperty(57, x => x.Org1YomiName);
            MapProperty(58, x => x.Org1Title);
            MapProperty(59, x => x.Org1Department);
            MapProperty(60, x => x.Org1Symbol);
            MapProperty(61, x => x.Org1Location);
            MapProperty(62, x => x.Org1JobDescription);
            MapProperty(63, x => x.Website1type);
            MapProperty(64, x => x.Website1value);
            MapProperty(65, x => x.Website2type);
            MapProperty(66, x => x.Website2value);
            MapProperty(67, x => x.Event1type);
            MapProperty(68, x => x.Event1value);
            MapProperty(69, x => x.CustomField1type);
            MapProperty(70, x => x.CustomField1value);
        }
    }
}
