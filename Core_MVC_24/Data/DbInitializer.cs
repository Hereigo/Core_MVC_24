using Core_MVC_24.Models;

namespace Core_MVC_24.Data
{
    public static class DbInitializer
    {
        public static void Initialize(DataContext context)
        {
            context.Database.EnsureCreated();

            if (context.Profiles.Any())
            {
                return; // DB has been seeded already.
            }

            var profiles = new Profile[]
            {
                new() {
                    AType="Aaa",
                    Name="Aaa",
                    GivenName="Aaa",
                    AdditionalName="Aaa",
                    FamilyName="Aaa",
                    YomiName="Aaa",
                    GivenNameYomi="Aaa",
                    AdditionalNameYomi="Aaa",
                    FamilyNameYomi="Aaa",
                    NamePrefix="Aaa",
                    NameSuffix="Aaa",
                    Initials="Aaa",
                    Nickname="Aaa",
                    ShortName="Aaa",
                    MaidenName="Aaa",
                    Birthday="Aaa",
                    Gender="Aaa",
                    Location="Aaa",
                    BillingInformation="Aaa",
                    DirectoryServer="Aaa",
                    Mileage="Aaa",
                    Occupation="Aaa",
                    Hobby="Aaa",
                    Sensitivity="Aaa",
                    Priority="Aaa",
                    Subject="Aaa",
                    Notes="Aaa",
                    Language="Aaa",
                    Photo="Aaa",
                    GroupMembership="Aaa",
                    Email1type="Aaa",
                    Email1value="Aaa",
                    Email2type="Aaa",
                    Email2value="Aaa",
                    Email3type="Aaa",
                    Email3value="Aaa",
                    IM1type="Aaa",
                    IM1Service="Aaa",
                    IM1value="Aaa",
                    Phone1type="Aaa",
                    Phone1value="Aaa",
                    Phone2type="Aaa",
                    Phone2value="Aaa",
                    Phone3type="Aaa",
                    Phone3value="Aaa",
                    Address1type="Aaa",
                    Address1Formatted="Aaa",
                    Address1Street="Aaa",
                    Address1City="Aaa",
                    Address1POBox="Aaa",
                    Address1Region="Aaa",
                    Address1PostalCode="Aaa",
                    Address1Country="Aaa",
                    Address1ExtendedAddress="Aaa",
                    Org1type="Aaa",
                    Org1Name="Aaa",
                    Org1YomiName="Aaa",
                    Org1Title="Aaa",
                    Org1Department="Aaa",
                    Org1Symbol="Aaa",
                    Org1Location="Aaa",
                    Org1JobDescription="Aaa",
                    Website1type="Aaa",
                    Website1value="Aaa",
                    Website2type="Aaa",
                    Website2value="Aaa",
                    Event1type="Aaa",
                    Event1value="Aaa",
                    CustomField1type="Aaa",
                    CustomField1value="Aaa"
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
