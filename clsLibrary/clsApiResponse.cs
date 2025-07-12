using System;
using System.Collections.Generic;
using System.Text;

namespace clsLibrary
{
    public class clsApiResponse
    {
        private string _strErorr;
        private string _strStatus;

        private string _acsess_token;

        public string access_token
        {
            get { return _acsess_token; }
            set { _acsess_token = value; }
        }

        public string error; 
        public string status;
       
     

        public ComrewCon rewardConfirmation;
   
    }

    public class ComrewCon
    {
        public string userId;  
        public string receiptNumber; 
        public string receiptDateTime; 
        public string posId ; 
        public string totalAmount; 
        public string totalReward; 
        public string transNo; 

    
        public List<ComrevTransaction> rewardTransactions;
     

    }


    public class ComrevTransaction {

 

        public string rewardSubType; 
        public string serialNumber ; 
        public string rewardValue; 
        public string rewardName; 


    }


   




    
  

}
