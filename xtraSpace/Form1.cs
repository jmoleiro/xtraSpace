using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using xtraSpace.Properties;

namespace xtraSpace
{
    public partial class frmMain : Form
    {

        frmCopy copyfrm;
        public string _in;
        public string _out;
        public string _nwid;
        public string _nwname;
        public bool allow_close = true;
        
        public frmMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //foreach (var drive in DriveInfo.GetDrives())
            //{
            //    textBox1.Text += String.Format("Drive Type: {0}", drive.DriveType) + Environment.NewLine;
            //    textBox1.Text += String.Format("Drive ?: {0}", drive.RootDirectory) + Environment.NewLine;
            //    //drive.DriveType == DriveType.Fixed
            //    //textBox1.Text += String.Format("Drive Free Space: {0}", drive.TotalFreeSpace);
            //}
            checkDrives();
            itmsFolders.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            webBrowser1.Navigate("about:blank");
            copyfrm = new frmCopy();
            /*itmsFolders.Items.Add("Slot 1\r\n\t32GB.");
            itmsFolders.Items.Add("Slot 2\r\n\t32GB.");*/
        }

        private void checkDrives()
        {
            foreach (var drive in DriveInfo.GetDrives())
            {
                if ((drive.DriveType == DriveType.Fixed) || (drive.DriveType == DriveType.Removable))
                {
                    if (Directory.Exists(drive.RootDirectory + "Xbox360"))
                    {
                        cbDrives.Items.Add(drive.RootDirectory);
                    }
                }
            }
            if (cbDrives.Items.Count > 0)
            {
                cbDrives.SelectedIndex = 0;
            }
        }

        private void itmsFolders_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            //e.ItemHeight = 13 * GetLinesNumber((string)itmsFolders.Items[e.Index]);
            e.ItemHeight = 14 * 2;
        }

        private int GetLinesNumber(string text)
        {
            int count = 1;
            int pos = 0;
            while ((pos = text.IndexOf("\r\n", pos)) != -1) { count++; pos += 2; }
            return count;
        }

        //DrawItem event handler for your ListBox
        private void itmsFolders_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index != -1)
            {
                Font fnt = e.Font;
                if (itmsFolders.Items[e.Index].ToString().IndexOf("Activ") != -1)
                {
                    fnt = new Font(e.Font.Name, e.Font.SizeInPoints, FontStyle.Bold);
                }
                e.DrawBackground();

                ///e.Font.Bold = (itmsFolders.Items[e.Index].ToString().IndexOf("Activ") != -1);
                e.Graphics.DrawString(itmsFolders.Items[e.Index].ToString(), fnt, new SolidBrush(e.ForeColor), e.Bounds);
            }
        }

        private void cbDrives_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbDrives.SelectedIndex != -1)
            {
                reloadList();
            }
        }

        private void reloadList()
        {
            loadDrive(cbDrives.SelectedItem.ToString());
        }

        private void loadDrive(string drive)
        {
            try
            {
                webBrowser1.Document.Body.InnerHtml = "";
            }
            catch { }
            itmsFolders.Items.Clear();
            btnActivate.Enabled = false;
            btnCopy.Enabled = false;
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
            string[] dirs = Directory.GetDirectories(drive);
            foreach (string dir in dirs)
            {
                string _display_name = "";
                string _display_state = "";
                string _path = dir;
                //Data0000
                if (File.Exists(dir + "\\Data0000"))
                {
                    //Encontramos un directorio
                    if (!File.Exists(dir + "\\_.content"))
                    {
                        //Creamos el file 
                        string _title = dir.Replace(drive, "");
                        string _uid = _title;
                        if (_title == "Xbox360")
                        {
                            _uid = _uid + "00_ori";
                        }
                        string _content = "";
                        WebUtil.IO.WriteToFile(dir + "\\_.content", write_content(_title, _uid, _content));
                        _display_name = _title;
                    }
                    else 
                    {
                        string[] _content = File.ReadAllText(dir + "\\_.content").Split('\t');
                        _display_name = _content[0];
                    }
                    if (dir.Replace(drive, "") == "Xbox360")
                    {
                        _display_state = Resources.active;
                    }
                    else
                    {
                        _display_state = Resources.inactive;
                    }
                    string item = _display_name + "\r\n" + _display_state + "\r\n" + _path;
                    itmsFolders.Items.Add(item);
                }
            }
        }

        private string write_content(string _title, string _uid, string _content)
        {
            return _title + "\t" + _uid + "\t" + _content;
        }

        private void itmsFolders_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (itmsFolders.SelectedIndex != -1)
            {
                //Mostramos el contenido en el lateral.
                btnActivate.Enabled = (itmsFolders.Items[itmsFolders.SelectedIndex].ToString().IndexOf("Activ") == -1);

                if (itmsFolders.Items[itmsFolders.SelectedIndex].ToString() != "")
                {
                    _in = itmsFolders.Items[itmsFolders.SelectedIndex].ToString().Replace("\r", "").Split('\n')[2];
                    //MessageBox.Show(_in);
                }

                btnCopy.Enabled = true;
                btnDelete.Enabled = btnActivate.Enabled;
                btnEdit.Enabled = true;
                displayContent();
            }
        }

        private void displayContent()
        {
            string[] _cnt = File.ReadAllText(itmsFolders.Items[itmsFolders.SelectedIndex].ToString().Replace("\r", "").Split('\n')[2] + "\\_.content").Split('\t');
            string _html = "";
            if (_cnt[2].Trim() != "")
            {
                _html = "<font face=Arial color=darkblue><b>" + Resources.content + "</b><br><br>" + _cnt[2].Replace("\r\n", "<br>");
            }
            else
            {
                _html = "<font face=Arial color=darkblue><b>" + Resources.no_content+ "</b><br><br>";
            }
            webBrowser1.Document.Body.InnerHtml = _html;
        }

        /*public static void CopyFolder(DirectoryInfo source, DirectoryInfo target)
        {
            foreach (DirectoryInfo dir in source.GetDirectories())
                CopyFilesRecursively(dir, target.CreateSubdirectory(dir.Name));
            foreach (FileInfo file in source.GetFiles())
                file.CopyTo(Path.Combine(target.FullName, file.Name));
        }*/

        public static void copy_folder(string SourcePath, string DestinationPath)
        {

            //Now Create all of the directories
            foreach (string dirPath in Directory.GetDirectories(SourcePath, "*",
                SearchOption.AllDirectories))
                Directory.CreateDirectory(dirPath.Replace(SourcePath, DestinationPath));

            //Copy all the files & Replaces any files with the same name
            foreach (string newPath in Directory.GetFiles(SourcePath, "*.*",
                SearchOption.AllDirectories))
                File.Copy(newPath, newPath.Replace(SourcePath, DestinationPath), true);
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (!driveHasSpace())
            {
                if (MessageBox.Show(Resources.space_alert, Resources.confirm, MessageBoxButtons.YesNo)==DialogResult.No)
                {
                    return;
                }
            }
            pbstat.Visible = true;
            frmName frmN = new frmName();
            frmN._name = "Slot ";
            if (frmN.ShowDialog() == DialogResult.OK)
            {
                _out = cbDrives.SelectedItem.ToString() + Regex.Replace(frmN._name, @"[^A-Za-z0-9_~]+", "");
                _nwid = Regex.Replace(frmN._name, @"[^A-Za-z0-9_~]+", "");
                _nwname = frmN._name;
                if (Directory.Exists(_out))
                {
                    _out = cbDrives.SelectedItem.ToString() + Regex.Replace(frmN._name, @"[^A-Za-z0-9_~]+", "") + "_X";
                    _nwid = Regex.Replace(frmN._name, @"[^A-Za-z0-9_~]+", "") + "_X";
                    _nwname = frmN._name + " X";
                }
                if (!Directory.Exists(_out))
                {
                    Directory.CreateDirectory(_out);
                }
                /*copyfrm._canclose = false;
                copyfrm.label1.Text = Resources.copy_slot;
                copyfrm.Show();*/
                showStatusWnd(Resources.copy_slot);
                bwCopy.RunWorkerAsync();
            }
        }

        private bool driveHasSpace()
        {
            DriveInfo drv = new DriveInfo(cbDrives.SelectedItem.ToString());
            //return drv.AvailableFreeSpace >= 35433480192;
            return drv.AvailableFreeSpace >= 34905129960;
        }

        private void bwCopy_DoWork(object sender, DoWorkEventArgs e)
        {
            //copy_folder(_in, _out);
            string SourcePath = _in;
            string DestinationPath = _out; 

            //Now Create all of the directories
            foreach (string dirPath in Directory.GetDirectories(SourcePath, "*",
                SearchOption.AllDirectories))
                Directory.CreateDirectory(dirPath.Replace(SourcePath, DestinationPath));


            int max = Directory.GetFiles(SourcePath, "*.*", SearchOption.AllDirectories).Length;
            int cnt = 0;
            double prc = 100 / max;


            //Copy all the files & Replaces any files with the same name
            foreach (string newPath in Directory.GetFiles(SourcePath, "*.*", SearchOption.AllDirectories))
            {
                cnt++;
                bwCopy.ReportProgress(Convert.ToInt32(Math.Round(prc * cnt)));
                File.Copy(newPath, newPath.Replace(SourcePath, DestinationPath), true);
            }
            var di = new DirectoryInfo(_out);
            di.Attributes |= FileAttributes.Hidden;
        }

        private void bwCopy_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            string[] _content = File.ReadAllText(_out + "\\_.content").Split('\t');
            _content[0] = _nwname;
            _content[1] = _nwid;
            WebUtil.IO.WriteToFile(_out + "\\_.content", String.Join("\t", _content));
            /*copyfrm._canclose = true;
            copyfrm.Close();
            this.Enabled = true;*/
            pbstat.Visible = false;
            hideStatusWnd();
            reloadList();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(Resources.confirm_delete, Resources.confirm, MessageBoxButtons.YesNo) == DialogResult.Yes)
            { 
                //Adios...
                /*copyfrm._canclose = false;
                copyfrm.label1.Text = Resources.deleting;
                copyfrm.Show();*/
                showStatusWnd(Resources.deleting);
                bwDeleter.RunWorkerAsync();
                /*copyfrm._canclose = true;
                copyfrm.Close();
                this.Enabled = true;*/
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            frmEditor edt = new frmEditor();
            string[] _cnt = File.ReadAllText(itmsFolders.Items[itmsFolders.SelectedIndex].ToString().Replace("\r", "").Split('\n')[2] + "\\_.content").Split('\t');
            edt._name = _cnt[0];
            edt._content = _cnt[2];
            edt.ShowDialog();
            WebUtil.IO.WriteToFile(itmsFolders.Items[itmsFolders.SelectedIndex].ToString().Replace("\r", "").Split('\n')[2] + "\\_.content", write_content(edt._name, _cnt[1], edt._content));
            reloadList();
        }

        private void btnActivate_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show(Resources.confirm_activate, Resources.confirm, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                //Primero desactivamos el slot actual
                string[] _cnt = File.ReadAllText(cbDrives.SelectedItem.ToString() + "Xbox360" + "\\_.content").Split('\t');
                string _now = cbDrives.SelectedItem.ToString() + "Xbox360";
                string _new = cbDrives.SelectedItem.ToString() + _cnt[1];
                Directory.Move(_now, _new);

                //Luego copiamos el nuevo
                _cnt = File.ReadAllText(itmsFolders.Items[itmsFolders.SelectedIndex].ToString().Replace("\r", "").Split('\n')[2] + "\\_.content").Split('\t');
                _new = cbDrives.SelectedItem.ToString() + "Xbox360";
                _now = cbDrives.SelectedItem.ToString() + _cnt[1];
                Directory.Move(_now, _new);

                reloadList();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("xtraSpace 1.1 for Xbox 360\r\n©2014 Jonatan Moleiro");
        }

        private void showStatusWnd(string message)
        {
            allow_close = false;
            pnlButtons.Enabled = false;
            pnlCopy.Visible = true;
            cbDrives.Enabled = false;
            itmsFolders.Enabled = false;
            lblCopyOperation.Text = message;        
        }

        private void hideStatusWnd()
        {
            pnlButtons.Enabled = true;
            pnlCopy.Visible = false;
            cbDrives.Enabled = true;
            itmsFolders.Enabled = true;
            allow_close = true;
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !allow_close;
        }

        private void bwCopy_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //
            pbstat.Value = e.ProgressPercentage;
        }

        private void bwDeleter_DoWork(object sender, DoWorkEventArgs e)
        {
            Directory.Delete(_in, true);
        }

        private void bwDeleter_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            hideStatusWnd();
            reloadList();
        }
    }
}
