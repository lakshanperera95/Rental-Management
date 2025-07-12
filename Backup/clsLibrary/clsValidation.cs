using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Globalization;
using DbConnection;
using System.Data.SqlClient;
namespace clsLibrary
{
    public class clsValidation
    {
        string strTextString;
        int intfeildLength;
        string strFieldType;
        bool blnIsBlank;
        string strNamefield;
        public string TextString
        {
            get { return strTextString; }
            set { strTextString = value; }
        }

        public int FeildLength
        {
            get { return intfeildLength; }
            set { intfeildLength = value; }
        }

        public string FieldType
        {
            get { return strFieldType; }
            set { strFieldType = value; }
        }

        public bool IsBlank
        {
            get { return blnIsBlank; }
            set { blnIsBlank = value; }
        }

        public string Namefield
        {
            get { return strNamefield; }
            set { strNamefield = value; }
        }

        private string strBarcode; 
        public string Barcode
        {
            get { return strBarcode; }
            set { strBarcode = value; }
        }

        private string strBarcodeTrim;

        public string BarcodeTrim
        {
            get { return strBarcodeTrim; }
            set { strBarcodeTrim = value; }
        }



        public void Validation()
        {
            try
            {
                if ((IsBlank == false) && (strTextString.Trim() == ""))
                {
                    throw new ArgumentException(Namefield + " Field Cannot be blank. Please enter required data");
                }
                if (strTextString.Contains("'"))
                {
                    throw new ArgumentException("Invalid characters in " + Namefield + " Please check the characters entered.");
                }
                if (TextString.Length == 0)
                {
                    throw new ArgumentException("Length is exceeding in field " + Namefield + ". Please limit the length to the accepted length.");
                }
                if (FieldType == "NUM" && strTextString.IsNormalized() == true)
                {
                    throw new ArgumentException("A numeric field " + Namefield + " is containing alpha characters. Please check the data entered");
                }
            }
            catch (Exception e)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'clsValidation 001. Error Description " + e.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
                    // read from file or write to file
                }
                finally
                {
                    m_streamWriter.Close();
                    fileStream.Close();
                }
                MessageBox.Show(e.Message.ToString(), "Error Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public static bool isNumeric(string val, System.Globalization.NumberStyles NumberStyle)
        {
            Double result;
            return Double.TryParse(val, NumberStyle, System.Globalization.CultureInfo.CurrentCulture, out result);
        }

        public static void maskTexValidate(MaskedTextBox TextBox_TextChanged, NumberStyles NumberStyle)
        {
            TextBox_TextChanged.TextChanged += delegate(object sender, EventArgs e)
               {
                   if (TextBox_TextChanged.Text != string.Empty && isNumeric(TextBox_TextChanged.Text, NumberStyle) == false)
                   {
                       TextBox_TextChanged.Text = TextBox_TextChanged.Text.Remove(TextBox_TextChanged.Text.Length - 1);
                       TextBox_TextChanged.Select(TextBox_TextChanged.Text.Length, TextBox_TextChanged.Text.Length);
                   }
               };
        }

        public static void TextChanged(TextBox TextBox_TextChanged, NumberStyles NumberStyle)
        {
            TextBox_TextChanged.TextChanged += delegate(object sender, EventArgs e)
               {
                   if (TextBox_TextChanged.Text != string.Empty && isNumeric(TextBox_TextChanged.Text, NumberStyle) == false)
                   {
                       TextBox_TextChanged.Text = TextBox_TextChanged.Text.Remove(TextBox_TextChanged.Text.Length - 1);
                       TextBox_TextChanged.Select(TextBox_TextChanged.Text.Length, TextBox_TextChanged.Text.Length);
                   }
               };
        }

        public static void TextEnter(TextBox TextBox_TextChanged, NumberStyles NumberStyle)
        {
            TextBox_TextChanged.Enter += delegate(object sender, EventArgs e)
               {
                   if (TextBox_TextChanged.Text != string.Empty && isNumeric(TextBox_TextChanged.Text, NumberStyle) == false)
                   {
                       TextBox_TextChanged.Text = TextBox_TextChanged.Text.Remove(TextBox_TextChanged.Text.Length - 1);
                       TextBox_TextChanged.Select(TextBox_TextChanged.Text.Length, TextBox_TextChanged.Text.Length);
                   }
               };
        }

        public bool HasRecordFor(string  strSqlString)
        {
            try
            {
               System.Data.SqlClient.SqlDataReader DataReader = DbConnection.dbcon.GetReader(strSqlString);
               return DataReader.HasRows;
            }
            finally
            {
                DbConnection.dbcon.CloseReader();
            }
        }

        public void ReadProductCode(string strSqlString, ref string code)
        {
            try
            {
                SqlDataReader DataReader = dbcon.GetReader(strSqlString);
                if (DataReader.Read())
                {
                    code = DataReader["Prod_Code"].ToString().Trim();
                }
                else
                {
                    code = "";
                }
            }
            finally
            {
                dbcon.CloseReader();
            }
        }

        public void BarcodeRead(string strSqlString)
        {
            try
            {
                SqlDataReader DataReader = dbcon.GetReader(strSqlString);
                if (DataReader.Read())
                {
                    strBarcode = DataReader["Barcode"].ToString().Trim();
                }
                else
                {
                    strBarcode = "";
                }
            }
            finally
            {
                dbcon.CloseReader();
            }
        }

       


        public void checkNumeric(KeyPressEventArgs e, string txtvalue)
        {
            if (e.KeyChar == (char)Keys.Back)
            {
                e.Handled = false;
            }
            else
            {
                decimal value;
                e.Handled = !decimal.TryParse(txtvalue + e.KeyChar, out value);
            }
        }

        public void Errormsg(Exception ex, string Location)
        {

            //Write to Log
            DateTime dtCurrentDate = DateTime.Now;
            FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
            StreamWriter m_streamWriter = new StreamWriter(fileStream);
            try
            {
                m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' " + Location + " 004. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
                // read from file or write to file
            }
            finally
            {
                m_streamWriter.Close();
                fileStream.Close();
            }
            MessageBox.Show(ex.Message.ToString(), "Error Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}