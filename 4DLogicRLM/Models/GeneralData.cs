using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace _4DLogicRLM.Models
{
    public class GeneralData
    {
    }
    public class Account
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid AccountID { get; set; }
        public string AccountName { get; set; }
        public string AccountUserID { get; set; }
        public int SubscriptionID { get; set; }
        public double SubscriptionPlanFee { get; set; }
        public int SubscriptionUserCount { get; set; }
        public string CompanyID { get; set; }
        public int TrialPeriod { get; set; }
        public DateTime TrialExpiration { get; set; }
    }

    public class BillingInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid BillingID { get; set; }
        public string BillingAddress1 { get; set; }
        public string BillingAddress2 { get; set; }
        public string BillingState { get; set; }
        public string BillingCity { get; set; }
        public string BillingZip { get; set; }
        public string BillingCountry { get; set; }
        public string BillingPhone { get; set; }
        public DateTime BillingRecentDate { get; set; }
        public DateTime BillingExpireDate { get; set; }
        public int AccountID { get; set; }
        public string CompanyID { get; set; }
    }

    public class Company
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid CompanyID { get; set; }
        public string CompanyName { get; set; }
        //public string CompanyCode { get; set; }
        public string Picture { get; set; }
        public string ContactPhone { get; set; }
        public string ContactEmail { get; set; }
        public string ContactName { get; set; }
    }

    public class SubscriptionPlans
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SubscriptionPlanID { get; set; }
        public string SubscriptionPlanName { get; set; }
        public string SubscriptionPlanDescription { get; set; }
        public double SubscriptionPlanFee { get; set; }
        public int SubscriptionUserCount { get; set; }

    }

    
}
