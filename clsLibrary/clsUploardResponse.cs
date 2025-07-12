using System;
using System.Collections.Generic;
using System.Text;

namespace clsLibrary
{
   public class clsUploardResponse
    {

        private string _batchCode;

        public string batchCode
        {
            get { return _batchCode; }
            set { _batchCode = value; }
        }

        private string _returnStatus;

        public string returnStatus
        {
            get { return _returnStatus; }
            set { _returnStatus = value; }
        }


        private string _recordsReceived;

        public string recordsReceived
        {
            get { return _recordsReceived; }
            set { _recordsReceived = value; }
        }

        private string _recordsImported;

        public string recordsImported
        {
            get { return _recordsImported; }
            set { _recordsImported = value; }
        }

        private string _errorDetails;

        public string errorDetails
        {
            get { return _errorDetails; }
            set { _errorDetails = value; }
        }

        private string _defectiveRowNos;

        public string defectiveRowNos
        {
            get { return _defectiveRowNos; }
            set { _defectiveRowNos = value; }
        }




        


    }
}
