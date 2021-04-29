using AdasVetelServer.db;
using AdasVetelServer.dbHandler;
using AdasVetelServer.logger;
using AdasVetelServer.logic;
using AdasVetelServer.logic.analyzing;
using AdasVetelServer.logic.ner;
using AdasVetelServer.messages;
using AdasVetelServer.tcp;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using SimpleTcp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace AdasVetelServer
{
    public partial class AdasVetelServer : Form
    {                
        public AdasVetelServer()
        {
            InitializeComponent();
            stopBox.Enabled = false;
            serverInfo.Visible = false;
            ServerLogger.Instance.output = serverLog;       

        }

        private void stopServer_Click(object sender, EventArgs e)
        {
            TcpServerWrapper.Instance.stopServer();
            startBox.Enabled = true;
            stopBox.Enabled = false;
            serverInfo.Visible = false;
        }
        private void startServer() {
            serverLog.Text = "";
            TcpServerWrapper.Instance.startServer(portNumber.Value.ToString(), domainCheckBox.Checked);
            startBox.Enabled = false;
            stopBox.Enabled = true;
            serverInfo.Visible = true;
        }
        private void startServer_Click(object sender, EventArgs e)
        {
            startServer();   
        } 

        private void xmlSelectButton_Click(object sender, EventArgs e)
        {
            string pathFile = Application.StartupPath + "\\prevPath\\patternPrevPath.loc";
            string dir = "";
            if (File.Exists(pathFile))
                dir = File.ReadAllText(pathFile);
            else
                File.Create(pathFile);
            if (!Directory.Exists(dir))
                dir = Application.StartupPath + "\\entityPatterns";
            using (OpenFileDialog ofd = new OpenFileDialog()
            {
                InitialDirectory = dir,
                ValidateNames = true,
                Multiselect = false,
                Filter = "XML Document|*.xml"                
            })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    xmlFileTextBox.Text = ofd.FileName;
                    File.WriteAllText(pathFile, Path.GetDirectoryName(ofd.FileName));
                    checkIfTrainEnabled();
                }
            }        
        }

        private void contractSelectButton_Click(object sender, EventArgs e)
        {
            string pathFile = Application.StartupPath + "\\prevPath\\docPrevPath.loc";
            string dir = "";
            if (File.Exists(pathFile))
                dir = File.ReadAllText(pathFile);
            else
                File.Create(pathFile);
            if (!Directory.Exists(dir))
                dir = "c:\\";
            using (OpenFileDialog ofd = new OpenFileDialog()
            {
                
                InitialDirectory = dir,
                ValidateNames = true,
                Multiselect = true,
                Filter = "Word Document|*.docx|" +
                "Word 97-2003|*.doc"
            })
            {               

                if (ofd.ShowDialog() == DialogResult.OK)
                {                   
                    foreach (var filename in ofd.FileNames)
                    {
                        FileIconControl fic = new FileIconControl(filename);
                        fic.OnKeySetChanged += checkIfTrainEnabled;
                        fileFlowLayout.Controls.Add(fic);
                    }
                    File.WriteAllText(pathFile, Path.GetDirectoryName(ofd.FileName));                    

                }
            }
           
        }      
       

        private void checkIfTrainEnabled()
        {
            foreach (FileIconControl item in fileFlowLayout.Controls)
            {
                if (item.KeySet == false)
                {
                    trainButton.Enabled = false;
                    return;
                }
            }
            if (fileFlowLayout.Controls.Count > 0 && xmlFileTextBox.Text != "")
                trainButton.Enabled = true;
            else
                trainButton.Enabled = false;
        }

        private void trainButton_Click(object sender, EventArgs e)
        {
            if (fileFlowLayout.Controls.Count != 0)
            {                
                foreach (FileIconControl item in fileFlowLayout.Controls)
                {
                    if (item.KeySet == true)                  
                        item.train(xmlFileTextBox.Text);
                }               
                fileFlowLayout.Controls.Clear();
                trainButton.Enabled = false;
                MessageBox.Show("A szövegfelismerés kiterjesztése megtörtént", "Sikeres művelet", MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
           
        }

        private void resetDataBaseBtn_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Biztos törli az adatbázis tartalmát?",
                "Figyelem!", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if(dr == DialogResult.Yes)
            {
                using (DbHandler dbh = new DbHandler())
                {
                    dbh.deleteAllContent();
                    ServerLogger.Instance.writeLog("Database records deleted.");
                    TcpServerWrapper.Instance.sendToAll<DatabaseChangedMessage>(new DatabaseChangedMessage());
                }
            }
        }
        private void clearLogBtn_Click(object sender, EventArgs e)
        {
            serverLog.Text = "";
        }

        private void AdasVetelServer_Load(object sender, EventArgs e)
        {
            startServer();
        }

        private void clearListButton_Click(object sender, EventArgs e)
        {
            fileFlowLayout.Controls.Clear();
        }
    }
}
