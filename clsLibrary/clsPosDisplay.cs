using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using DbConnection;
//using Microsoft.PointOfService;
using System.IO.Ports;

namespace clsLibrary
{
    public class clsPosDisplay
    {
        public const string WelcomeMessage = "Welcome\r\n";
        //public PosExplorer posExplorer;
        //public LineDisplay posLineDisplay;
        //public DeviceInfo posLineDisplaydevice;

        public Boolean RecordFound
        {
            get { return blRecordFound; }
            set { blRecordFound = value; }
        }
        public string ItemName
        {
            get { return strItemName; }
            set { strItemName = value; }
        }
        public string SqlStatement
        {

            get { return strSqlStatement; }
            set { strSqlStatement = value; }
        }
        private SqlDataReader DataReader;
        private string strSqlStatement;
        private string strItemName;
        private Boolean blRecordFound;
        static SerialPort serialPort = new SerialPort();

        public static void PrintDisplay(string text1, string text2)
        {
            if(LoginManager.CustComPort=="")
            {
                return;
            }
            try
            {
                #region Old
                //PosExplorer posExplorer = new PosExplorer();
                //DeviceCollection dc = posExplorer.GetDevices("LineDisplay", DeviceCompatibilities.Opos);
                //posLineDisplaydevice = dc[0];
                //posLineDisplay = (LineDisplay)posExplorer.CreateInstance(posLineDisplaydevice);
                //posLineDisplay.Open();
                //posLineDisplay.Claim(1000);
                //posLineDisplay.DeviceEnabled = true;
                //posLineDisplay.ClearText();
                //posLineDisplay.DisplayText(text);
                //posLineDisplay.Release();
                //posLineDisplay.Close();
                #endregion

                serialPort.PortName = LoginManager.CustComPort;
                serialPort.BaudRate = 9600;
                serialPort.DataBits = 8;
                serialPort.Parity = Parity.None;
                serialPort.StopBits = StopBits.One;

                if (serialPort.IsOpen == true)
                {
                    serialPort.Close();
                }

                serialPort.Open();

                serialPort.Encoding = Encoding.Default;

                if(text1.Length>20)
                {
                    text1 = text1.Substring(0, 20);
                }

                if (text2.Length > 20)
                {
                    text2 = text2.Substring(0, 20);
                }

                serialPort.Write(Convert.ToString((char)12));
                
                serialPort.WriteLine(""+(char)31+(char)36+(char)1+(char)2);

                serialPort.WriteLine(text1.ToUpper());
                //serialPort.WriteLine((char)13 + text2);
                serialPort.WriteLine("" + (char)31 + (char)36 + (char)1 + (char)1);
                serialPort.WriteLine(text2.ToUpper());

            }
            
            catch (Exception ex)
            {
                //if (posLineDisplay!=null)
                //{
                //    posLineDisplay.Close();
                //}
                //posLineDisplay = null;

            }
            finally
            {
                if (serialPort.IsOpen)
                    serialPort.Close();
            }
        }
        public static void PrintWelcomeDisplay()
        {
            if (LoginManager.CustComPort == "")
            {
                return;
            }

            try
            {


                serialPort.PortName = LoginManager.CustComPort;
                serialPort.BaudRate = 9600;
                serialPort.DataBits = 8;
                serialPort.Parity = Parity.None;
                serialPort.StopBits = StopBits.One;

                if (serialPort.IsOpen == true)
                {
                    serialPort.Close();
                }

                serialPort.Open();

                serialPort.Encoding = Encoding.Default;

                serialPort.Write(Convert.ToString((char)12));

                string Text = "WELCOME!";
                string Text1 = new string(' ', ((20 - Text.Length) / 2)) + Text;

                serialPort.Write(Convert.ToString((char)12));
                serialPort.WriteLine(Text1);
                serialPort.WriteLine((char)13 + "");

            }
            catch (Exception ex)
            {
                //if (posLineDisplay!=null)
                //{
                //    posLineDisplay.Close();
                //}
                //posLineDisplay = null;

            }
            finally
            {
                if (serialPort.IsOpen)
                    serialPort.Close();
            }
        }
        public static void PrintCounterClosedDisplay()
        {
            if (LoginManager.CustComPort == "")
            {
                return;
            }
            try
            {
                serialPort.PortName = LoginManager.CustComPort;
                serialPort.BaudRate = 9600;
                serialPort.DataBits = 8;
                serialPort.Parity = Parity.None;
                serialPort.StopBits = StopBits.One;

                if (serialPort.IsOpen == true)
                {
                    serialPort.Close();
                }

                serialPort.Open();

                serialPort.Encoding = Encoding.Default;

                serialPort.Write(Convert.ToString((char)12));

                string Text = "COUNTER CLOSED!";
                string Text1 = new string(' ', ((20 - Text.Length) / 2)) + Text;

                serialPort.Write(Convert.ToString((char)12));
                serialPort.WriteLine(Text1);
                serialPort.WriteLine((char)13 + "");

            }
            catch (Exception ex)
            {
                //if (posLineDisplay!=null)
                //{
                //    posLineDisplay.Close();
                //}
                //posLineDisplay = null;

            }
            finally
            {
                if (serialPort.IsOpen)
                    serialPort.Close();
            }
        }
    }
}
