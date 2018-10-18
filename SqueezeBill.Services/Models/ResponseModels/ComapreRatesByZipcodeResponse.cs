using System;
using System.Collections.Generic;
using System.Text;

namespace SqueezeBill.Services.Models.ResponseModels
{
   public class ComapreRatesByZipcodeResponse
    {
        public Response response { get; set; }
    }
    public class SupplierList
    {
        public string companyName { get; set; }
        public int rate { get; set; }
    }

    public class RetailerList
    {
        public int planid { get; set; }
        public string offer { get; set; }
        public int duration { get; set; }
        public int rate { get; set; }
        public string imagePath { get; set; }
        public string retailerName { get; set; }
        public int retailerId { get; set; }
    }

    public class CompareListDetails
    {
        public CompareListDetails()
        {
            supplierList = new List<SupplierList>();
            retailerList = new List<RetailerList>();
        }
        public int futureAnnualSavings { get; set; }
        public List<SupplierList> supplierList { get; set; }
        public List<RetailerList> retailerList { get; set; }
    }

    public class Response
    {
        public Response()
        {
            compareListDetails = new CompareListDetails();
        }
        public CompareListDetails compareListDetails { get; set; }
        public string message { get; set; }
        public int statusCode { get; set; }
    }

   
}
