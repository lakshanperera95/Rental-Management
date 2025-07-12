using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;
using System.IO;
using System.Data.SqlClient;
using Inventory.Properties;
using clsLibrary;
using System.Threading;
using System.IO.Compression;

namespace Inventory
{
    public partial class frmBackupRestore : Form
    {
        private static Server srvSql;

        

        public frmBackupRestore()
        {
            InitializeComponent();
        }
        clsUserProfile objUser = new clsUserProfile();
        private static frmBackupRestore BackupRestore;

        public static frmBackupRestore GetBackupRestore
        {
            get { return BackupRestore; }
            set { BackupRestore = value; }
        }
        string strcmbdatabase;
        int progress = 1;

        //private void Form1_Load(object sender, EventArgs e)
        //{
        //    DataTable dtServers = SmoApplication.EnumAvailableSqlServers(true);
        //    if (dtServers.Rows.Count > 0)
        //    {
        //        foreach (DataRow drServer in dtServers.Rows)
        //        {
        //            cmbServer.Items.Add(drServer["Name"]);
        //        }
        //    }
        //}

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (cmbServer.SelectedItem != null && cmbServer.SelectedItem.ToString() != "")
            {
               ServerConnection srvConn = new ServerConnection(cmbServer.SelectedItem.ToString());
                //SqlConnection srvConn = new SqlConnection(Inventory.Properties.Settings.Default.AllianceConnectionString1); 
                srvConn.LoginSecure = false;
                srvConn.Login = txtUsername.Text;
                srvConn.Password = txtPassword.Text;
                srvSql = new Server(srvConn);
                  
                //sqlcmd = new SqlCommand("backup database" + databaseName.BKSDatabaseName + "to disk='" + path + "\\" + saveFileName + ".Bak'", con);
                //sqlcmd.ExecuteNonQuery();
                //con.Close();

                foreach (Database dbServer in srvSql.Databases)
                {

                    cmbDatabase.Items.Add(dbServer.Name);
                }
            }
            else
            {
                MessageBox.Show("Please select a server first", "Server Not Selected", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
            
        private void DeleteOldFiles(string sPath, string sPattern, int OlderThanDays)
        {
            foreach (string myfile in Directory.GetFiles(sPath, sPattern))
            {
                System.IO.FileInfo fi = new System.IO.FileInfo(myfile);
                if (fi.CreationTime < DateTime.Now.AddDays(0 - OlderThanDays))
                {
                    fi.Delete();
                }
            }

        }

        private void Zip(string zipFileName, string sourceFile, string directory)
        {
            //java.io.FileOutputStream fos = new java.io.FileOutputStream(zipFileName);
            //java.util.zip.ZipOutputStream zos = new java.util.zip.ZipOutputStream(fos); 

            //java.io.FileInputStream fis = new java.io.FileInputStream(/*directory*/Inventory.Properties.Settings.Default.BackupPath+ sourceFile);
            //java.util.zip.ZipEntry ze = new java.util.zip.ZipEntry(Inventory.Properties.Settings.Default.BackupPath  + sourceFile);
            //zos.putNextEntry(ze);
            //sbyte []buffer = new sbyte[1024];
            //lblCurrentProc.Text = "Compresing the backup file.....";
            //this.Refresh();
            //int len;
            //while ((len = fis.read(buffer)) >= 0)
            //{
            //    zos.write(buffer, 0, len);
            //}
            //zos.closeEntry();
            //fis.close();
            //zos.close();
            //fos.close();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {

            ServerConnection srvConn = new ServerConnection(cmbServer.SelectedItem.ToString());
            
            srvConn.LoginSecure = false;
            srvConn.Login = txtUsername.Text;
            srvConn.Password = txtPassword.Text;
            srvSql = new Server(srvConn);

            SqlConnection srvConn1 = new SqlConnection("Data Source="+cmbServer.Text.Trim()+";Initial Catalog="+cmbDatabase.Text.Trim()+";User ID=sa;Password="+txtPassword.Text+""); 

            try
            {
                if (srvSql != null)
                {
                    //Thread thread = new Thread();
                    if (cmbDatabase.Text == "")
                    {
                        MessageBox.Show("Select Database", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        cmbDatabase.Focus();
                        return;
                    }
                    btnCreate.Enabled = false;
                    panel1.Visible = true;
                    this.Refresh();
                    DateTime dtCurrentDate = DateTime.Now;
                    saveBackupDialog.InitialDirectory = Inventory.Properties.Settings.Default.BackupPath.ToString();
                    saveBackupDialog.FileName = cmbDatabase.Text.Trim()+"_"+string.Format("{0: dd_MM_yyyy}", dtCurrentDate).Trim() + ".bak";

                    //if (saveBackupDialog.ShowDialog() == DialogResult.OK)
                    //{
                    Backup bkpDatabase = new Backup();
                    bkpDatabase.Action = BackupActionType.Database;
                    bkpDatabase.Database = cmbDatabase.SelectedItem.ToString();  

                    //-----------------------------     


                    //BackupDeviceItem bkpDevice = new BackupDeviceItem(/*saveBackupDialog.InitialDirectory*/Inventory.Properties.Settings.Default.BackupPath + saveBackupDialog.FileName, DeviceType.File);
                    string Cm = "BACKUP DATABASE[" + LoginManager.DatabaseName + "] TO DISK = '" + saveBackupDialog.InitialDirectory + "\\" + saveBackupDialog.FileName + "' ";
                    using (SqlCommand Command = new SqlCommand(Cm, srvConn1))
                    {
                        if (srvConn1.State!= ConnectionState.Open)
                        {
                            srvConn1.Open();                            
                        }
                        Command.CommandTimeout = 0;
                        Command.ExecuteNonQuery();


                        CompressFile(saveBackupDialog.InitialDirectory + "\\" + saveBackupDialog.FileName);

                        Zip(saveBackupDialog.InitialDirectory +"\\" +saveBackupDialog.FileName.Replace(".bak", ".zip"), saveBackupDialog.FileName, saveBackupDialog.InitialDirectory);

                      //  Zip(saveBackupDialog.InitialDirectory + "\\" + saveBackupDialog.FileName, saveBackupDialog.FileName, saveBackupDialog.InitialDirectory);


                        lblCurrentProc.Text = "Deleting temparary file.....";
                        this.Refresh();
                        File.Delete(Inventory.Properties.Settings.Default.BackupPath + saveBackupDialog.FileName);
                        this.Refresh();

                        string BkZipFileName= cmbDatabase.Text.Trim() + "_" + string.Format("{0: dd_MM_yyyy}", dtCurrentDate).Trim() + ".zip";
                        string BkPath = Inventory.Properties.Settings.Default.BackupPath +BkZipFileName ;
                       
                        if (File.Exists(BkPath) == true)
                        {
                            MessageBox.Show("Backup Success.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Backup Failed.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        srvConn1.Close();

                        if (txtPath.Text.Trim() != string.Empty)
                        {
                            File.Copy(BkPath, txtPath.Text +BkZipFileName);
                            if (File.Exists(txtPath.Text + BkZipFileName) == true)
                            {
                                MessageBox.Show("Copy Success.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Copy Failed.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        
                        }
                        
                        this.Close();
                    }

                    //---------------------------

                    BackupDeviceItem bkpDevice = new BackupDeviceItem(/*saveBackupDialog.InitialDirectory*/Inventory.Properties.Settings.Default.BackupPath + saveBackupDialog.FileName, DeviceType.File);
                    
                }
                else
                {
                    MessageBox.Show("A connection to a SQL server was not established.", "Not Connected to Server", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Backup operation Stoped", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Dispose();
                BackupRestore = null;

            }
            
        }

        public   void CompressFile(string path)
        {
            FileStream sourceFile = File.OpenRead(path);
            FileStream destinationFile = File.Create(path + ".gz");

            byte[] buffer = new byte[sourceFile.Length];
            sourceFile.Read(buffer, 0, buffer.Length);

            using (GZipStream output = new GZipStream(destinationFile,CompressionMode.Compress))
            {
                 output.Write(buffer, 0, buffer.Length);
            }

          
            sourceFile.Close();
            destinationFile.Close();
        }


        //public void Zip()
        //{
        //    var zipFilePath = "c:\\myfile.zip";
        //    var tempFolderPath = "c:\\unzipped";

        //    using (Package package = ZipPackage.Open(zipFilePath, FileMode.Open, FileAccess.Read))
        //    {
        //        foreach (PackagePart part in package.GetParts())
        //        {
        //            var target = Path.GetFullPath(Path.Combine(tempFolderPath, part.Uri.OriginalString.TrimStart('/')));
        //            var targetDir = target.Remove(target.LastIndexOf('\\'));

        //            if (!Directory.Exists(targetDir))
        //                Directory.CreateDirectory(targetDir);

        //            using (Stream source = part.GetStream(FileMode.Open, FileAccess.Read))
        //            {
        //                source.CopyTo(File.OpenWrite(target));
        //            }
        //        }
        //    }
        //}

        private void btnRestore_Click(object sender, EventArgs e)
        {
            try
            {
                if (srvSql != null)
                {
                    if (cmbDatabase.Text == "")
                    {
                        MessageBox.Show("Select Database", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        cmbDatabase.Focus();
                        return;
                    }

                    if (File.Exists(@"..\DatabaseKill.sql"))
                    {
                        File.Delete(@"..\DatabaseKill.sql");
                    }
                    FileStream fileStream = new FileStream(@"..\DatabaseKill.sql", FileMode.Create);
                    StreamWriter m_streamWriter = new StreamWriter(fileStream);
                    try
                    {
                        m_streamWriter.WriteLine("USE master");
                        m_streamWriter.WriteLine("GO");
                        m_streamWriter.WriteLine("SET NOCOUNT ON");
                        m_streamWriter.WriteLine("DECLARE @DBName varchar(50)");
                        m_streamWriter.WriteLine("DECLARE @spidstr varchar(8000)");
                        m_streamWriter.WriteLine("DECLARE @ConnKilled smallint");
                        m_streamWriter.WriteLine("SET @ConnKilled=0");
                        m_streamWriter.WriteLine("SET @spidstr = ''");
                        m_streamWriter.WriteLine("Set @DBName = '" + cmbDatabase.SelectedItem.ToString() + "'");
                        m_streamWriter.WriteLine("IF db_id(@DBName) < 4");
                        m_streamWriter.WriteLine("BEGIN");
                        m_streamWriter.WriteLine("PRINT 'Connections to system databases cannot be clear'");
                        m_streamWriter.WriteLine("RETURN");
                        m_streamWriter.WriteLine("END");
                        m_streamWriter.WriteLine("SELECT @spidstr=coalesce(@spidstr,',' )+'kill '+convert(varchar, spid)+ ';'");
                        m_streamWriter.WriteLine("FROM master..sysprocesses WHERE dbid=db_id(@DBName)");
                        m_streamWriter.WriteLine("IF LEN(@spidstr) > 0");
                        m_streamWriter.WriteLine("BEGIN");
                        m_streamWriter.WriteLine("EXEC(@spidstr)");
                        m_streamWriter.WriteLine("SELECT @ConnKilled = COUNT(1)FROM master..sysprocesses WHERE dbid=db_id(@DBName)");
                        m_streamWriter.WriteLine("END");

                    }
                    finally
                    {
                        m_streamWriter.Close();
                        fileStream.Close();
                    }

                    string sqlConnectionString = "Data Source='" + LoginManager.ServerName + "';Initial Catalog=master;User ID=sa; password='" + LoginManager.Password + "'";
                    FileInfo file = new FileInfo(@"..\DatabaseKill.sql");
                    string script = file.OpenText().ReadToEnd();
                    SqlConnection conn = new SqlConnection(sqlConnectionString);
                    Server server = new Server(new ServerConnection(conn));
                    server.ConnectionContext.ExecuteNonQuery(script);

                    //"DatabaseKill.sql"
                    if (openBackupDialog.ShowDialog() == DialogResult.OK)
                    {
                        Restore rstDatabase = new Restore();
                        rstDatabase.Action = RestoreActionType.Database;
                        rstDatabase.Database = cmbDatabase.SelectedItem.ToString();
                        panel1.Visible = true;
                        this.Refresh();
                        BackupDeviceItem bkpDevice = new BackupDeviceItem(openBackupDialog.FileName, DeviceType.File);
                        rstDatabase.Devices.Add(bkpDevice);
                        rstDatabase.ReplaceDatabase = true;
                        rstDatabase.SqlRestore(srvSql);

                        //if (MessageBox.Show("Restart Application", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.OK)
                        this.Refresh();
                        clsSplash.ApplicationReset();
                        panel1.Visible = false;
                        this.Refresh();
                        MessageBox.Show("Restore Complete!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
                else
                {
                    MessageBox.Show("A connection to a SQL server was not established.", "Not Connected to Server", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Restore operation Stoped", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Dispose();
                BackupRestore = null;
            }

        }

        private void frmBackupRestore_Load(object sender, EventArgs e)
        { 
            if (LoginManager.UserName.ToUpper()=="ONIMTA")
            {
                btnRestore.Enabled = true;
            }
            else
            {
                btnRestore.Enabled = false;
            }
            cmbServer.Items.Add(LoginManager.ServerName);
            cmbServer.Text = LoginManager.ServerName;
            txtUsername.Text = LoginManager.User.ToString();
            txtPassword.Text = LoginManager.Password.ToString();

            if (cmbServer.SelectedItem != null && cmbServer.SelectedItem.ToString() != "")
            {
                ServerConnection srvConn = new ServerConnection(cmbServer.SelectedItem.ToString());
                srvConn.LoginSecure = false;
                srvConn.Login = txtUsername.Text;
                srvConn.Password = txtPassword.Text;
                srvSql = new Server(srvConn); 

              cmbDatabase.Items.Add(LoginManager.DatabaseName);

              cmbDatabase.SelectedIndex = 0;
             

            }
            else
            {
                MessageBox.Show("Please select a server first", "Server Not Selected", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void frmBackupRestore_FormClosing(object sender, FormClosingEventArgs e)
        {
            BackupRestore = null;
            
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void btnCopy_Click(object sender, EventArgs e)
        {


            try
            {
                string fileName = saveBackupDialog.FileName.Replace(".bak", ".zip");
                string sourcePath = saveBackupDialog.InitialDirectory;
                string targetPath = txtPath.Text;

                // Use Path class to manipulate file and directory paths.
                string sourceFile = System.IO.Path.Combine(sourcePath, fileName);
                string destFile = System.IO.Path.Combine(targetPath, fileName);

                // To copy a folder's contents to a new location:
                // Create a new target folder, if necessary.
                if (!System.IO.Directory.Exists(targetPath))
                {
                    System.IO.Directory.CreateDirectory(targetPath);
                }

                if (System.IO.File.Exists(destFile))
                {
                    if (MessageBox.Show("There is already a file with the same name. Do you want to Overwrite ?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        return;
                    }
                }

                // To copy a file to another location and 
                // overwrite the destination file if it already exists.
                lblCurrentProc.Text = "copying Backup file.....";
                panel1.Visible = true;
                this.Refresh();
                System.IO.File.Copy(sourceFile, destFile, true);

                // To copy all the files in one directory to another directory.
                /*
                if (System.IO.Directory.Exists(sourcePath))
                {
                    string[] files = System.IO.Directory.GetFiles(sourcePath);

                    // Copy the files and overwrite destination files if they already exist.
                    foreach (string s in files)
                    {
                        // Use static Path methods to extract only the file name from the path.
                        fileName = System.IO.Path.GetFileName(s);
                        destFile = System.IO.Path.Combine(targetPath, fileName);
                        System.IO.File.Copy(s, destFile, true);
                    }
                }
                else
                {
                    MessageBox.Show("Source path does not exist!");
                }
                 * */
                MessageBox.Show("File Copied successfully, To " + targetPath + " ");
                lblCurrentProc.Text = "File Copied successfully.....";
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Backup operation Stoped", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Dispose();
                BackupRestore = null;

            }
                   

        }

        private void btnpathSerch_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txtPath.Text = folderBrowserDialog1.SelectedPath + "\\";
            }
        }

        
    }
}