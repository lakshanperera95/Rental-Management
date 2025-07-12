using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography ;
using clsLibrary;
namespace Inventory
{
    public partial class frmJurnal : Form
    {
        private static frmJurnal Jurnal;

        clsPosTerminal objPosTerminal = new clsPosTerminal();

        public static frmJurnal GetJurnal
        {
            get { return Jurnal; }
            set { Jurnal = value; }
        }

        public frmJurnal()
        {
            InitializeComponent();
        }

        private void frmJurnal_Load(object sender, EventArgs e)
        {
            try
            {
                cmbUnit.Items.Add("01");
                cmbUnit.Items.Add("02");
                cmbUnit.Items.Add("03");
                cmbUnit.Items.Add("04");
                cmbUnit.Items.Add("05");
                cmbUnit.Items.Add("06");
                cmbUnit.Items.Add("07");
                cmbUnit.Items.Add("08");
                cmbUnit.Items.Add("09");
                cmbUnit.Items.Add("10");
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmSupplierPayment 001. Error Description " + ex.Message + "");
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

        private void frmJurnal_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                Jurnal = null;
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmBrand 005. Error Description " + ex.Message + " ");
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

        private void frmJurnal_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                // Hide the form...
                this.Hide();

                // Cancel the close...
                e.Cancel = true;
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmBarcode 002. Error Description " + ex.Message + " ");
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

        private void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                StreamReader myStreamReader;
                String strJournalName;
                String strSourcePath;

                strSourcePath = "";
                strJournalName = "";
                if (!Directory.Exists(@"..\Journal"))
                {
                    Directory.CreateDirectory(@"..\Journal");
                }
                //// Try to create the directory.
                //DirectoryInfo di = Directory.CreateDirectory(path);
                //Console.WriteLine("The directory was created successfully at {0}.", Directory.GetCreationTime(path));

                //// Delete the directory.
                //di.Delete();
                //Console.WriteLine("The directory was deleted successfully.");
                strJournalName = dtDate.Text.Substring(0, 2) + dtDate.Text.Substring(3, 2) + dtDate.Text.Substring(6, 4) + ".txt";

                objPosTerminal.Terminal = cmbUnit.Text.Trim();
                objPosTerminal.ReadPosTerminalJournalPath();
                if (objPosTerminal.RecordFound)
                {
                    strSourcePath = objPosTerminal.JournalPath + strJournalName;
                }
                else
                {
                    MessageBox.Show("Pos Terminal Setting Not Found.", "Error Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                File.Copy(@strSourcePath, @"..\Journal\Journal.txt",true );

                myStreamReader = File.OpenText(strSourcePath);

                txtJurnal.Text = string.Empty;
                string strDecryptString;
                string myInputString;
                int rowCount   = 0;
                myInputString = myStreamReader.ReadLine();
                while ( myInputString != string.Empty )
                {
                    //' Output the text with a line number
                    strDecryptString  = Decrypt(myInputString.Trim());
                    txtJurnal.Text += strDecryptString + "\n";
                    rowCount += 1;
                    //' Read the next line.
                    myInputString = myStreamReader.ReadLine();
                }

                txtJurnal.ReadOnly = true;
                myStreamReader.Close();


                //If ComboBox1.Text = "1" Then
                //    My.Computer.FileSystem.CopyFile("\\OITPOS01\D$\RAYAN\" & Mid(Format(DateTimePicker1.Value, "dd/MM/yyyy"), 1, 2) & Mid(Format(DateTimePicker1.Value, "dd/MM/yyyy"), 4, 2) & Mid(Format(DateTimePicker1.Value, "dd/MM/yyyy"), 7, 4) & ".txt", Path & Mid(Format(DateTimePicker1.Value, "dd/MM/yyyy"), 1, 2) & Mid(Format(DateTimePicker1.Value, "dd/MM/yyyy"), 4, 2) & Mid(Format(DateTimePicker1.Value, "dd/MM/yyyy"), 7, 4) & ".txt", FileIO.UIOption.AllDialogs)

                //    srrs = "C:\Rayan\" & Mid(Format(DateTimePicker1.Value, "dd/MM/yyyy"), 1, 2) & Mid(Format(DateTimePicker1.Value, "dd/MM/yyyy"), 4, 2) & Mid(Format(DateTimePicker1.Value, "dd/MM/yyyy"), 7, 4) & ".txt"

                //ElseIf ComboBox1.Text = "2" Then
                //    My.Computer.FileSystem.CopyFile("\\OITPOS02\D$\RAYAN\" & Mid(Format(DateTimePicker1.Value, "dd/MM/yyyy"), 1, 2) & Mid(Format(DateTimePicker1.Value, "dd/MM/yyyy"), 4, 2) & Mid(Format(DateTimePicker1.Value, "dd/MM/yyyy"), 7, 4) & ".txt", Path & Mid(Format(DateTimePicker1.Value, "dd/MM/yyyy"), 1, 2) & Mid(Format(DateTimePicker1.Value, "dd/MM/yyyy"), 4, 2) & Mid(Format(DateTimePicker1.Value, "dd/MM/yyyy"), 7, 4) & ".txt", FileIO.UIOption.AllDialogs)
                //    srrs = "C:\Rayan\" & Mid(Format(DateTimePicker1.Value, "dd/MM/yyyy"), 1, 2) & Mid(Format(DateTimePicker1.Value, "dd/MM/yyyy"), 4, 2) & Mid(Format(DateTimePicker1.Value, "dd/MM/yyyy"), 7, 4) & ".txt"
                //End If

                //myStreamReader = File.OpenText(srrs)

                //TextBox2.Text = ""
                //Dim myInputString As String
                //Dim rowCount As Integer = 0
                //myInputString = myStreamReader.ReadLine()
                //While Not myInputString Is Nothing
                //    //' Output the text with a line number
                //    TextBox2.Text += Decrypt(Trim(myInputString)) + vbCrLf
                //    rowCount += 1
                //    //' Read the next line.
                //    myInputString = myStreamReader.ReadLine()
                //End While

                //TextBox2.ReadOnly = True
                //myStreamReader.Close()
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmBarcode 002. Error Description " + ex.Message + " ");
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

         private static string Decrypt(string srcValue )
         {
        //'  Dim Key64() As Byte = New Byte() {165, 15, 146, 156, 78, 16, 218, 59}
        //'  Dim IV64() As Byte = New Byte() {55, 20, 246, 80, 239, 81, 167, 19}
        //' Dim Key64() As Byte = New Byte() {165, 15, 146, 156, 78, 16, 218, 59}
        //' Dim IV64() As Byte = New Byte() {55, 23, 246, 79, 239, 81, 167, 18}
        Byte [] Key64   = {165, 15, 140, 156, 78, 16, 218, 55};
        Byte [] IV64 = { 40, 23, 246, 85, 230, 81, 167, 18 };

        string retVal = "";
        Boolean EndOfStream = false;
        Byte bByte;
        DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
             Byte buffer ;
             //buffer = Convert.FromBase64String(srcValue);
        //Dim buffer() As Byte = Convert.FromBase64String(srcValue)
        //Dim ms As New IO.MemoryStream(buffer)
        //Dim cs As New Security.Cryptography.CryptoStream(ms, cryptoProvider.CreateDecryptor(Key64, IV64), Security.Cryptography.CryptoStreamMode.Read)
        //Do Until EndOfStream
        //    Try
        //        bByte = cs.ReadByte
        //    Catch ex As Exception
        //        EndOfStream = True
        //    End Try
        //    If Not EndOfStream Then
        //        retVal = retVal & Chr(bByte)
        //    End If
        //Loop
        return retVal;
         }
    }
}