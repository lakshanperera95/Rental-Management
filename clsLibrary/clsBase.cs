using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace clsLibrary
{
    public class clsBase
    {
        
        #region Form Move Property

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        #endregion

        public static void ErrorFound(string ErrorMessage, string errorLocation)
        {
            DateTime dtCurrentDate = DateTime.Now;
            FileStream fileStream = new FileStream(@"..\GiftVoucher_ErrorLog.txt", FileMode.Append);
            StreamWriter m_streamWriter = new StreamWriter(fileStream);
            try
            {
                m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'" + errorLocation + ". Error Description:- << " + ErrorMessage + " >> " + " 'User Name :' " + LoginManager.UserName + " '");
                // read from file or write to file
            }
            finally
            {
                m_streamWriter.Close();
                fileStream.Close();
            }
            MessageBox.Show(ErrorMessage, "Gift Voucher", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
    }
   
}
