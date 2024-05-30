using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core_MVC_24.Models
{
    public class Profile
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string ProfileID { get; set; }
        [Required]
        [Display(Name = "Type")]
        public string AType { get; set; }
        [Required]
        public string Name { get; set; }
        [Display(Name = "GivenN.")]
        public string? GivenName { get; set; }
        [Display(Name = "AddN.")]
        public string? AdditionalName { get; set; }
        [Display(Name = "FamilyN.")]
        public string? FamilyName { get; set; }
        public string? YomiName { get; set; }
        public string? GivenNameYomi { get; set; }
        [Display(Name = "AddN.Yomi")]
        public string? AdditionalNameYomi { get; set; }
        public string? FamilyNameYomi { get; set; }
        public string? NamePrefix { get; set; }
        public string? NameSuffix { get; set; }
        public string? Initials { get; set; }
        public string? Nickname { get; set; }
        public string? ShortName { get; set; }
        public string? MaidenName { get; set; }
        public string? Birthday { get; set; }
        public string? Gender { get; set; }
        public string? Location { get; set; }
        [Display(Name = "Billing")]
        public string? BillingInformation { get; set; }
        [Display(Name = "Directory")]
        public string? DirectoryServer { get; set; }
        public string? Mileage { get; set; }
        public string? Occupation { get; set; }
        public string? Hobby { get; set; }
        public string? Sensitivity { get; set; }
        public string? Priority { get; set; }
        public string? Subject { get; set; }
        public string? Notes { get; set; }
        public string? Language { get; set; }
        public string? Photo { get; set; }
        [Display(Name = "Group")]
        public string? GroupMembership { get; set; }
        public string? Email1type { get; set; }
        public string? Email1value { get; set; }
        public string? Email2type { get; set; }
        public string? Email2value { get; set; }
        public string? Email3type { get; set; }
        public string? Email3value { get; set; }
        public string? IM1type { get; set; }
        public string? IM1Service { get; set; }
        public string? IM1value { get; set; }
        public string? Phone1type { get; set; }
        public string? Phone1value { get; set; }
        public string? Phone2type { get; set; }
        public string? Phone2value { get; set; }
        public string? Phone3type { get; set; }
        public string? Phone3value { get; set; }
        public string? Address1type { get; set; }
        public string? Address1Formatted { get; set; }
        public string? Address1Street { get; set; }
        public string? Address1City { get; set; }
        public string? Address1POBox { get; set; }
        public string? Address1Region { get; set; }
        public string? Address1PostalCode { get; set; }
        public string? Address1Country { get; set; }
        [Display(Name = "AddrXtend")]
        public string? Address1ExtendedAddress { get; set; }
        public string? Org1type { get; set; }
        public string? Org1Name { get; set; }
        public string? Org1YomiName { get; set; }
        public string? Org1Title { get; set; }
        public string? Org1Department { get; set; }
        public string? Org1Symbol { get; set; }
        public string? Org1Location { get; set; }
        [Display(Name = "JobDescrip")]
        public string? Org1JobDescription { get; set; }
        public string? Website1type { get; set; }
        public string? Website1value { get; set; }
        public string? Website2type { get; set; }
        public string? Website2value { get; set; }
        public string? Event1type { get; set; }
        public string? Event1value { get; set; }
        public string? CustomField1type { get; set; }
        public string? CustomField1value { get; set; }
    }
}
