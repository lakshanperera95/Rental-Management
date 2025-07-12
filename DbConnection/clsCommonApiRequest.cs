using System;
using System.Collections.Generic;
using System.Text;

namespace DbConnection
{
    public class clsCommonApiRequest
    {
        public string sqltext { get; set; }
        public string dsName { get; set; }

        public string SpName { get; set; }
        public string HasReturnData { get; set; }
        public List<CommonParameters> Parameters { get; set; }
    }

    public class clsTokenRequest
    {
        public string username { get; set; }

        public string password { get; set; }

        public string loca{ get; set; }

    }
    public class clsImageUpdate
    {
        public string Prod_Code { get; set; }
        public byte[] Prod_Image { get; set; }
    }
}
