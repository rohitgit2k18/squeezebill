using SqueezeBill.Services.ApiHandler;
using SqueezeBill.Services.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SqueezeBill.Services.Models.ResponseModels
{
   public class FAQResponse
    {
       // private Detail _oldproduct;
        public FAQRealResponse response { get; set; }

        private Detail _detail { get; set; }
        public Detail Detail
        {
            get { return _detail; }
            set
            {
                if (_detail != value)
                {
                    _detail = value;
                  //  HideShowPrpduct(_detail);
                }
            }
        }

       
    }

    

    public class Detail: BaseResponseModel
    {
        public int id { get; set; }
        public string question { get; set; }
        public string answer { get; set; }
        private bool _iSVisible { get; set; }
        private string _icontext { get; set; }
        public string IconText
        {
            get { return _icontext; }
            set
            {
                if (_icontext != value)
                {
                    _icontext = value;
                    OnPropertyChanged();
                }
            }
        }
        public bool IsVisible
        {
            get { return _iSVisible; }
            set
            {
                if (_iSVisible != value)
                {
                    _iSVisible = value;
                    OnPropertyChanged();
                }
            }
        }
    }

    public class FAQRealResponse
    {
        public List<Detail> details { get; set; }
        public string message { get; set; }
        public int statusCode { get; set; }
    }

   
}
