using System;
using System.Collections.Generic;
using System.Text;

namespace SqueezeBill.Services.Models.ResponseModels
{
   public class NewsListResponse
    {
        public NewsResponse response { get; set; }
    }

    

    public class NewsDetail
    {
        public int id { get; set; }
        public string title { get; set; }
        public string shortDescription { get; set; }
        public string completeDescription { get; set; }
        public string image { get; set; }
    }

    public class NewsResponse
    {
        public List<NewsDetail> details { get; set; }
        public string message { get; set; }
        public int statusCode { get; set; }
    }

    
}
