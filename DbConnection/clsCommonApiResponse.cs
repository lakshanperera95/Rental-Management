using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DbConnection
{
    public class clsCommonApiResponse
    {

        public string ErrResponse { get; set; }
        public string StatusCode { get; set; }
        public int StatusDescription { get; set; }
        public string objDynamicResult { get; set; }

        public DataSet datasetResponse { get; set; }
        public List<CommonParameters> commonParas { get; set; }
    }

    public class clsTokenResponse
    {
         public string Emp_Name { get; set; }
        public string Token { get; set; }
    }
    public class clsTokenDetails
    {
        public string id { get; set; }
        public int nbf { get; set; }
        public int exp { get; set; }
        public int iat { get; set; }
    }
}
