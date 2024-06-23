namespace ConsoleTestApp
{
    public class Profile
    {
        public string ProfileID { get; set; }
        public string AaaType { get; set; }
        public string Name { get; set; }
        public string GivenName { get; set; }
        public string AdditionalName { get; set; }
        public string FamilyName { get; set; }
        public string YomiName { get; set; }
        public string GivenNameYomi { get; set; }
        public string AdditionalNameYomi { get; set; }
        public string FamilyNameYomi { get; set; }
        public string NamePrefix { get; set; }
        public string NameSuffix { get; set; }
        public string Initials { get; set; }
        public string Nickname { get; set; }
        public string ShortName { get; set; }
        public string MaidenName { get; set; }
        public string Birthday { get; set; }
        public string Gender { get; set; }
        public string Location { get; set; }
        public string BillingInformation { get; set; }
        public string DirectoryServer { get; set; }
        public string Mileage { get; set; }
        public string Occupation { get; set; }
        public string Hobby { get; set; }
        public string Sensitivity { get; set; }
        public string Priority { get; set; }
        public string Subject { get; set; }
        public string Notes { get; set; }
        public string Language { get; set; }
        public string Photo { get; set; }
        public string GroupMembership { get; set; }
        public string Email1type { get; set; }
        public string Email1value { get; set; }
        public string Email2type { get; set; }
        public string Email2value { get; set; }
        public string Email3type { get; set; }
        public string Email3value { get; set; }
        public string IM1type { get; set; }
        public string IM1Service { get; set; }
        public string IM1value { get; set; }
        public string Phone1type { get; set; }
        public string Phone1value { get; set; }
        public string Phone2type { get; set; }
        public string Phone2value { get; set; }
        public string Phone3type { get; set; }
        public string Phone3value { get; set; }
        public string Address1type { get; set; }
        public string Address1Formatted { get; set; }
        public string Address1Street { get; set; }
        public string Address1City { get; set; }
        public string Address1POBox { get; set; }
        public string Address1Region { get; set; }
        public string Address1PostalCode { get; set; }
        public string Address1Country { get; set; }
        public string Address1ExtendedAddress { get; set; }
        public string Org1type { get; set; }
        public string Org1Name { get; set; }
        public string Org1YomiName { get; set; }
        public string Org1Title { get; set; }
        public string Org1Department { get; set; }
        public string Org1Symbol { get; set; }
        public string Org1Location { get; set; }
        public string Org1JobDescription { get; set; }
        public string Website1type { get; set; }
        public string Website1value { get; set; }
        public string Website2type { get; set; }
        public string Website2value { get; set; }
        public string Event1type { get; set; }
        public string Event1value { get; set; }
        public string CustomField1type { get; set; }
        public string CustomField1value { get; set; }
    }

    //var TESTT2 = result.FirstOrDefault().Select(x => x.Addresses).Count();
    //var TESTT3 = result.FirstOrDefault().Select(x => x.AnniversaryViews).Count();
    //var TESTT4 = result.FirstOrDefault().Select(x => x.BirthDayViews).Count();
    //var TESTT5 = result.FirstOrDefault().Select(x => x.BirthPlaceViews).Count();
    //var TESTT6 = result.FirstOrDefault().Select(x => x.CalendarAccessUris).Count();
    //var TESTT7 = result.FirstOrDefault().Select(x => x.CalendarAddresses).Count();
    //var TESTT8 = result.FirstOrDefault().Select(x => x.CalendarUserAddresses).Count();
    //var TESTT9 = result.FirstOrDefault().Select(x => x.Categories).Count();
    //var TEST10 = result.FirstOrDefault().Select(x => x.DeathDateViews).Count();
    //var TEST11 = result.FirstOrDefault().Select(x => x.DeathPlaceViews).Count();
    //var TEST12 = result.FirstOrDefault().Select(x => x.DirectoryName).Count();
    //var TEST13 = result.FirstOrDefault().Select(x => x.DisplayNames).Count();
    //var TEST14 = result.FirstOrDefault().Select(x => x.EMails).Count();
    //var TEST15 = result.FirstOrDefault().Select(x => x.Entities).Count();
    //var TEST16 = result.FirstOrDefault().Select(x => x.Expertises).Count();
    //var TEST17 = result.FirstOrDefault().Select(x => x.FreeOrBusyUrls).Count();
    //var TEST18 = result.FirstOrDefault().Select(x => x.GenderViews).Count();
    //var TEST19 = result.FirstOrDefault().Select(x => x.GeoCoordinates).Count();
    //var TEST20 = result.FirstOrDefault().Select(x => x.GroupIDs).Count();
    //var TEST21 = result.FirstOrDefault().Select(x => x.Groups).Count();
    //var TEST22 = result.FirstOrDefault().Select(x => x.Hobbies).Count();
    //var TEST23 = result.FirstOrDefault().Select(x => x.ID).Count();
    //var TEST24 = result.FirstOrDefault().Select(x => x.Interests).Count();
    //var TEST25 = result.FirstOrDefault().Select(x => x.Keys).Count();
    //var TEST26 = result.FirstOrDefault().Select(x => x.Kind).Count();
    //var TEST27 = result.FirstOrDefault().Select(x => x.Languages).Count();
    //var TEST28 = result.FirstOrDefault().Select(x => x.Logos).Count();
    //var TEST29 = result.FirstOrDefault().Select(x => x.Mailer).Count();
    //var TEST30 = result.FirstOrDefault().Select(x => x.Members).Count();
    //var TEST31 = result.FirstOrDefault().Select(x => x.Messengers).Count();
    //var TEST32 = result.FirstOrDefault().Select(x => x.NameViews).Count();
    //var TEST33 = result.FirstOrDefault().Select(x => x.NickNames).Count();
    //var TEST34 = result.FirstOrDefault().Select(x => x.NonStandards).Count();
    //var TEST35 = result.FirstOrDefault().Select(x => x.Notes).Count();
    //var TEST36 = result.FirstOrDefault().Select(x => x.Organizations).Count();
    //var TEST37 = result.FirstOrDefault().Select(x => x.OrgDirectories).Count();
    //var TEST38 = result.FirstOrDefault().Select(x => x.Phones).Count();
    //var TEST39 = result.FirstOrDefault().Select(x => x.ProductID).Count();
    //var TEST40 = result.FirstOrDefault().Select(x => x.Profile).Count();
    //var TEST41 = result.FirstOrDefault().Select(x => x.Relations).Count();
    //var TEST42 = result.FirstOrDefault().Select(x => x.Roles).Count();
    //var TEST43 = result.FirstOrDefault().Select(x => x.Sounds).Count();
    //var TEST44 = result.FirstOrDefault().Select(x => x.Sources).Count();
    //var TEST45 = result.FirstOrDefault().Select(x => x.Sync).Count();
    //var TEST46 = result.FirstOrDefault().Select(x => x.TimeStamp).Count();
    //var TEST47 = result.FirstOrDefault().Select(x => x.TimeZones).Count();
    //var TEST48 = result.FirstOrDefault().Select(x => x.Titles).Count();
    //var TEST49 = result.FirstOrDefault().Select(x => x.Urls).Count();
    //var TEST50 = result.FirstOrDefault().Select(x => x.Version).Count();
    //var TEST51 = result.FirstOrDefault().Select(x => x.Xmls).Count();
    //var TEST52 = result.FirstOrDefault().Select(x => x.Access).Count();
}
