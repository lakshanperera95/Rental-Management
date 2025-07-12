using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace clsLibrary
{
    public class clsClear
    {
        static clsClear clear = new clsClear();
        public static clsClear getclear()
        {
            return clear;
        }

        #region clear all data feilds used & Focus
        public void clearfeilds(Control GrbHeader, Control focus)
        {
            try
            {
                for (int i = 0; i < GrbHeader.Controls.Count; i++)
                {
                    if (GrbHeader.Controls[i].GetType() == typeof(TextBox))
                    {
                        ((TextBox)GrbHeader.Controls[i]).Text = string.Empty;
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            finally
            {
                focus.Focus();
            }
        }
        #endregion


        //#region select all data feilds used
        //public void SelectTextBoxText(Control GrbHeader, Control focus)
        //{
        //    try
        //    {
        //        for (int i = 0; i < GrbHeader.Controls.Count; i++)
        //        {
        //            if (GrbHeader.Controls[i].GetType() == typeof(TextBox))
        //            {
        //                //((TextBox)GrbHeader.Controls[i]).Text = string.Empty;
        //                ((TextBox)GrbHeader.Controls[i]).SelectAll();
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ex.Message.ToString();
        //    }
        //}
        //#endregion

        public static void ErrMessage(string error, string errorLocation)
        {
            for (int i = 0; i < errorLocation.Length; i++)
            {
                int a = errorLocation.IndexOf(" at ");
                if (i != 10 && a >= 0)
                {
                    errorLocation = errorLocation.Remove(0, a + 3);
                    a = -3;
                }
            }

            DateTime dtCurrentDate = DateTime.Now;
            FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
            StreamWriter m_streamWriter = new StreamWriter(fileStream);
            try
            {
                m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'Error Location  : " + errorLocation + ".   Error Description  :" + error.ToString() + " 'Location :'" + LoginManager.LocaCode.Trim() + "'User Name :'" + LoginManager.UserName.Trim() + "'");
            }
            finally
            {
                m_streamWriter.Close();
                fileStream.Close();
            }
            MessageBox.Show(error.ToString(), "Error Found", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
        public static void ApiRespomse(string Res)
        {


            DateTime dtCurrentDate = DateTime.Now;
            FileStream fileStream = new FileStream(@"..\ApiResponseLog.txt", FileMode.Append);
            StreamWriter m_streamWriter = new StreamWriter(fileStream);
            try
            {
                m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'Response  : " + Res + ". ");
            }
            finally
            {
                m_streamWriter.Close();
                fileStream.Close();
            }

        }
        public static void Err(string error, string errorLocation)
        {
            for (int i = 0; i < errorLocation.Length; i++)
            {
                int a = errorLocation.IndexOf(" at ");
                if (i != 10 && a >= 0)
                {
                    errorLocation = errorLocation.Remove(0, a + 3);
                    a = -3;
                }
            }

            DateTime dtCurrentDate = DateTime.Now;
            FileStream fileStream = new FileStream(@"..\ApiErrorLog.txt", FileMode.Append);
            StreamWriter m_streamWriter = new StreamWriter(fileStream);
            try
            {
                m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'Error Location  : " + errorLocation + ".   Error Description  :" + error.ToString() + " ");
            }
            finally
            {
                m_streamWriter.Close();
                fileStream.Close();
            }


        }
    }
}
