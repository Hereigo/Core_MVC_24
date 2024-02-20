using Core_MVC_24.Models;

namespace Core_MVC_24.Data
{
    public static class DbInitializer
    {
        public static void Initialize(AppDataContext context)
        {
            context.Database.EnsureCreated();

            if (context.Profiles.Any())
            {
                return; // DB has been seeded already.
            }

            var profiles = new Profile[]
            {
                new() {
                    AType="AAAA",
                    Name="AAAA",
                    GivenName="AAAA",
                    AdditionalName="AAAA",
                    FamilyName="AAAA",
                    YomiName="AAAA",
                    GivenNameYomi="AAAA",
                    AdditionalNameYomi="AAAA",
                    FamilyNameYomi="AAAA",
                    NamePrefix="AAAA",
                    NameSuffix="AAAA",
                    Initials="AAAA",
                    Nickname="AAAA",
                    ShortName="AAAA",
                    MaidenName="AAAA",
                    Birthday="AAAA",
                    Gender="AAAA",
                    Location="AAAA",
                    BillingInformation="AAAA",
                    DirectoryServer="AAAA",
                    Mileage="AAAA",
                    Occupation="AAAA",
                    Hobby="AAAA",
                    Sensitivity="AAAA",
                    Priority="AAAA",
                    Subject="AAAA",
                    Notes="AAAA",
                    Language="AAAA",
                    Photo="AAAA",
                    GroupMembership="AAAA",
                    Email1type="AAAA",
                    Email1value="AAAA",
                    Email2type="AAAA",
                    Email2value="AAAA",
                    Email3type="AAAA",
                    Email3value="AAAA",
                    IM1type="AAAA",
                    IM1Service="AAAA",
                    IM1value="AAAA",
                    Phone1type="AAAA",
                    Phone1value="AAAA",
                    Phone2type="AAAA",
                    Phone2value="AAAA",
                    Phone3type="AAAA",
                    Phone3value="AAAA",
                    Address1type="AAAA",
                    Address1Formatted="AAAA",
                    Address1Street="AAAA",
                    Address1City="AAAA",
                    Address1POBox="AAAA",
                    Address1Region="AAAA",
                    Address1PostalCode="AAAA",
                    Address1Country="AAAA",
                    Address1ExtendedAddress="AAAA",
                    Org1type="AAAA",
                    Org1Name="AAAA",
                    Org1YomiName="AAAA",
                    Org1Title="AAAA",
                    Org1Department="AAAA",
                    Org1Symbol="AAAA",
                    Org1Location="AAAA",
                    Org1JobDescription="AAAA",
                    Website1type="AAAA",
                    Website1value="AAAA",
                    Website2type="AAAA",
                    Website2value="AAAA",
                    Event1type="AAAA",
                    Event1value="AAAA",
                    CustomField1type="AAAA",
                    CustomField1value="AAAA"
                }
            };

            foreach (Profile p in profiles)
            {
                context.Profiles.Add(p);
            }

            context.SaveChanges();
        }
    }
}
