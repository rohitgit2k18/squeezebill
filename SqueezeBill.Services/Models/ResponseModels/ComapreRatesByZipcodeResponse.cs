using System;
using System.Collections.Generic;
using System.Text;

namespace SqueezeBill.Services.Models.ResponseModels
{
   public class ComapreRatesByZipcodeResponse
    {
        //public Response response { get; set; }
        public CListResponse response { get; set; }
    }
    //public class SupplierList
    //{
    //    public string CompanyName { get; set; }
    //    public Nullable<decimal> Rate { get; set; }
    //}

    //public class RetailerList
    //{
    //    public int? Planid { get; set; }
    //    public string Offer { get; set; }
    //    public int? Duration { get; set; }
    //    public Nullable<decimal> Rate { get; set; }
    //    public string ImagePath { get; set; }
    //    public string RetailerName { get; set; }
    //    public int RetailerId { get; set; }
    //}
    //public class CompanyList
    //{
    //    public CompanyList()
    //    {
    //        SupplierList = new List<SupplierList>();
    //        RetailerList = new List<RetailerList>();
    //    }
    //    public Nullable<decimal> FutureAnnualSavings { get; set; }
    //    public List<SupplierList> SupplierList { get; set; }
    //    public List<RetailerList> RetailerList { get; set; }
    //}
    //public class CompareListDetails
    //{
    //    public CompareListDetails()
    //    {
    //        CompareDetails = new CompanyList();
    //    }
    //    public CompanyList CompareDetails { get; set; }
    //    public string Message { get; set; }
    //    public Int32 StatusCode { get; set; }
    //}

    //public class Response
    //{
    //    public Response()
    //    {
    //        compareListDetails = new CompareListDetails();
    //    }
    //    public CompareListDetails compareListDetails { get; set; }
    //    //public string message { get; set; }
    //    //public int statusCode { get; set; }
    //}

    public class SupplierList
    {
        public string companyName { get; set; }
        public int companyId { get; set; }
        public double rate { get; set; }
        public double futureAnnualSavings { get; set; }
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
        public bool isResidential { get; set;}
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
