using System;
using System.Collections.Generic;
using System.Text;

namespace SqueezeBill.Services.Models.ResponseModels
{
   public class ComapreRatesByZipcodeResponse
    {
       
        public CListResponse response { get; set; }
    }
   
    public class SupplierList
    {
        public string companyName { get; set; }
        public int companyId { get; set; }
        public double rate { get; set; }
        public double futureAnnualSavings { get; set; }
        public string logo { get; set; }
       
    }

    public class RetailerList
    {
        
        public int planid { get; set; }
        public string offer { get; set; }
        public int duration { get; set; }
        public double rate { get; set; }
        public string imagePath { get; set; }
        public string retailerName { get; set; }
        public int retailerId { get; set; }
        public int companyId { get; set; }
        public bool isResidential { get; set; }
        public string serviceType { get; set; }
        public string Unit { get; set; }
        public string phoneNumber { get; set; }
        public string disclosureLink { get; set; }
    }

    public class CompareListDetails
    {
        public double futureAnnualSavings { get; set; }
        public List<SupplierList> supplierList { get; set; }
        public List<RetailerList> retailerList { get; set; }
    }

    public class CListResponse
    {
        public CompareListDetails compareListDetails { get; set; }
        public string message { get; set; }
        public int statusCode { get; set; }
    }

   
}



