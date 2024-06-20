using ConsoleTestApp;
using FolkerKinzel.VCards;
using FolkerKinzel.VCards.Extensions;

// =================================================================================
// WORKING !!!!!!!!!!
// =================================================================================

var main = new FileWorker();
// main.GeneralMethod();

// =================================================================================
// TESTING :
// =================================================================================

string fileVcfPath = GIT_IGNORE.fileVcfPath;

IList<VCard> vCards = Vcf.Load(fileVcfPath);

var vCard = vCards[0];

string PrefferedMail = vCard.EMails.PrefOrNull()?.Value;

string PrefferedPhone = vCard.Phones.PrefOrNull()?.Value;

var TEST = true;

//var TESTT2 = result.FirstOrDefault().Select(x => x.Addresses).Count(); //.FirstOrDefault();
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

// https://4js.com/online_documentation/fjs-fgl-3.00.05-manual-html/c_fgl_odiagsqt_017.html

Console.WriteLine("\r\nFinished.\r\n");
Console.ReadLine();