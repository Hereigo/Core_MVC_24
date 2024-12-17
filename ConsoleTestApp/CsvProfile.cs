using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace APP_4_TESTS
{
    public class CsvProfile
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string ID { get; set; }

        [Column("Name")]
        [DisplayName("Name")]
        public string Name { get; set; }

        [Column("GivenName")]
        [DisplayName("Given Name")]
        public string GivenName { get; set; }

        [Column("AdditionalName")]
        [DisplayName("Additional Name")]
        public string AdditionalName { get; set; }

        [Column("FamilyName")]
        [DisplayName("Family Name")]
        public string FamilyName { get; set; }

        [Column("YomiName")]
        [DisplayName("Yomi Name")]
        public string YomiName { get; set; }

        [Column("GivenNameYomi")]
        [DisplayName("Given Name Yomi")]
        public string GivenNameYomi { get; set; }

        [Column("AdditionalNameYomi")]
        [DisplayName("Additional Name Yomi")]
        public string AdditionalNameYomi { get; set; }

        [Column("FamilyNameYomi")]
        [DisplayName("Family Name Yomi")]
        public string FamilyNameYomi { get; set; }

        [Column("NamePrefix")]
        [DisplayName("Name Prefix")]
        public string NamePrefix { get; set; }

        [Column("NameSuffix")]
        [DisplayName("Name Suffix")]
        public string NameSuffix { get; set; }

        [Column("Initials")]
        [DisplayName("Initials")]
        public string Initials { get; set; }

        [Column("Nickname")]
        [DisplayName("Nickname")]
        public string Nickname { get; set; }

        [Column("ShortName")]
        [DisplayName("Short Name")]
        public string ShortName { get; set; }

        [Column("MaidenName")]
        [DisplayName("Maiden Name")]
        public string MaidenName { get; set; }

        [Column("Birthday")]
        [DisplayName("Birthday")]
        public string Birthday { get; set; }

        [Column("Gender")]
        [DisplayName("Gender")]
        public string Gender { get; set; }

        [Column("Location")]
        [DisplayName("Location")]
        public string Location { get; set; }

        [Column("BillingInformation")]
        [DisplayName("Billing Information")]
        public string BillingInformation { get; set; }

        [Column("DirectoryServer")]
        [DisplayName("Directory Server")]
        public string DirectoryServer { get; set; }

        [Column("Mileage")]
        [DisplayName("Mileage")]
        public string Mileage { get; set; }

        [Column("Occupation")]
        [DisplayName("Occupation")]
        public string Occupation { get; set; }

        [Column("Hobby")]
        [DisplayName("Hobby")]
        public string Hobby { get; set; }

        [Column("Sensitivity")]
        [DisplayName("Sensitivity")]
        public string Sensitivity { get; set; }

        [Column("Priority")]
        [DisplayName("Priority")]
        public string Priority { get; set; }

        [Column("Subject")]
        [DisplayName("Subject")]
        public string Subject { get; set; }

        [Column("Notes")]
        [DisplayName("Notes")]
        public string Notes { get; set; }

        [Column("Language")]
        [DisplayName("Language")]
        public string Language { get; set; }

        [Column("Photo")]
        [DisplayName("Photo")]
        public string Photo { get; set; }

        [Column("GroupMembership")]
        [DisplayName("Group Membership")]
        public string GroupMembership { get; set; }

        [Column("Email1Type")]
        [DisplayName("E-mail 1 - Type")]
        public string Email1Type { get; set; }

        [Column("Email1Value")]
        [DisplayName("E-mail 1 - Value")]
        public string Email1Value { get; set; }

        [Column("Email2Type")]
        [DisplayName("E-mail 2 - Type")]
        public string Email2Type { get; set; }

        [Column("Email2Value")]
        [DisplayName("E-mail 2 - Value")]
        public string Email2Value { get; set; }

        [Column("Email3Type")]
        [DisplayName("E-mail 3 - Type")]
        public string Email3Type { get; set; }

        [Column("Email3Value")]
        [DisplayName("E-mail 3 - Value")]
        public string Email3Value { get; set; }

        [Column("IM1Type")]
        [DisplayName("IM 1 - Type")]
        public string IM1Type { get; set; }

        [Column("IM1Service")]
        [DisplayName("IM 1 - Service")]
        public string IM1Service { get; set; }

        [Column("IM1Value")]
        [DisplayName("IM 1 - Value")]
        public string IM1Value { get; set; }

        [Column("IM2Type")]
        [DisplayName("IM 2 - Type")]
        public string IM2Type { get; set; }

        [Column("IM2Service")]
        [DisplayName("IM 2 - Service")]
        public string IM2Service { get; set; }

        [Column("IM2Value")]
        [DisplayName("IM 2 - Value")]
        public string IM2Value { get; set; }

        [Column("Phone1Type")]
        [DisplayName("Phone 1 - Type")]
        public string Phone1Type { get; set; }

        [Column("Phone1Value")]
        [DisplayName("Phone 1 - Value")]
        public string Phone1Value { get; set; }

        [Column("Phone2Type")]
        [DisplayName("Phone 2 - Type")]
        public string Phone2Type { get; set; }

        [Column("Phone2Value")]
        [DisplayName("Phone 2 - Value")]
        public string Phone2Value { get; set; }

        [Column("Phone3Type")]
        [DisplayName("Phone 3 - Type")]
        public string Phone3Type { get; set; }

        [Column("Phone3Value")]
        [DisplayName("Phone 3 - Value")]
        public string Phone3Value { get; set; }

        [Column("Address1Type")]
        [DisplayName("Address 1 - Type")]
        public string Address1Type { get; set; }

        [Column("Address1Formatted")]
        [DisplayName("Address 1 - Formatted")]
        public string Address1Formatted { get; set; }

        [Column("Address1Street")]
        [DisplayName("Address 1 - Street")]
        public string Address1Street { get; set; }

        [Column("Address1City")]
        [DisplayName("Address 1 - City")]
        public string Address1City { get; set; }

        [Column("Address1POBox")]
        [DisplayName("Address 1 - PO Box")]
        public string Address1POBox { get; set; }

        [Column("Address1Region")]
        [DisplayName("Address 1 - Region")]
        public string Address1Region { get; set; }

        [Column("Address1PostalCode")]
        [DisplayName("Address 1 - Postal Code")]
        public string Address1PostalCode { get; set; }

        [Column("Address1Country")]
        [DisplayName("Address 1 - Country")]
        public string Address1Country { get; set; }

        [Column("Address1ExtendedAddress")]
        [DisplayName("Address1Extended Address")]
        public string Address1ExtendedAddress { get; set; }

        [Column("Organization1Type")]
        [DisplayName("Organization 1 - Type")]
        public string Organization1Type { get; set; }

        [Column("Organization1Name")]
        [DisplayName("Organization 1 - Name")]
        public string Organization1Name { get; set; }

        [Column("Organization1YomiName")]
        [DisplayName("Organization 1 - Yomi Name")]
        public string Organization1YomiName { get; set; }

        [Column("Organization1Title")]
        [DisplayName("Organization 1 - Title")]
        public string Organization1Title { get; set; }

        [Column("Organization1Department")]
        [DisplayName("Organization 1 - Department")]
        public string Organization1Department { get; set; }

        [Column("Organization1Symbol")]
        [DisplayName("Organization 1 - Symbol")]
        public string Organization1Symbol { get; set; }

        [Column("Organization1Location")]
        [DisplayName("Organization 1 - Location")]
        public string Organization1Location { get; set; }

        [Column("OrganizationJobDescription")]
        [DisplayName("Organization 1 - Job Description")]
        public string Organization1JobDescription { get; set; }

        [Column("Website1Type")]
        [DisplayName("Website 1 - Type")]
        public string Website1Type { get; set; }

        [Column("Website1Value")]
        [DisplayName("Website 1 - Value")]
        public string Website1Value { get; set; }

        [Column("Website2Value")]
        [DisplayName("Website 2 - Value")]
        public string Website2Type { get; set; }

        [Column("Website2Value")]
        [DisplayName("Website 2 - Value")]
        public string Website2Value { get; set; }
    }
}

