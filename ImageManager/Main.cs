using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace ImageManager
{
    public partial class Main : Form
    {
        [DllImport("kernel32.dll", EntryPoint = "SetProcessWorkingSetSize", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        private static extern int SetProcessWorkingSetSize(IntPtr process, int minimumWorkingSetSize, int maximumWorkingSetSize);

        public string mainPath = @"";

        public string selectedPath;

        public Main()
        {
            InitializeComponent();
        }

        public static void alzheimer()
        {
            try
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
                SetProcessWorkingSetSize(System.Diagnostics.Process.GetCurrentProcess().Handle, -1, -1);
            }
            catch(Exception)
            {
                MessageBox.Show("Critical Error reading memory", "Oops", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
        }

        public void getTreeView()
        {
            if (Directory.Exists(mainPath) == true)
            {
                DirectoryInfo di = new DirectoryInfo(mainPath);
                foreach (DirectoryInfo d in di.GetDirectories())
                {
                    treeView1.Nodes.Clear();
                    string[] drives = Directory.GetDirectories(mainPath);

                    foreach (string drive in drives)
                    {
                        DirectoryInfo dir = new DirectoryInfo(drive);
                        if (((dir.Attributes & FileAttributes.System) != FileAttributes.System) || ((dir.Attributes & FileAttributes.Hidden) != FileAttributes.Hidden))
                        {
                            if (Regex.IsMatch(drive.Substring(drive.Length - 4, 4), "^(19|20)[0-9][0-9]"))
                            {
                                TreeNode node = new TreeNode(Path.GetFileName(drive))
                                {
                                    Tag = drive
                                };

                                node.Nodes.Add("...");
                                treeView1.Nodes.Add(node);
                            }
                        }
                    }
                }
            }
            else
            {
                treeView1.Nodes.Clear();
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            if (File.Exists(Application.StartupPath + "/config.ini"))
            {
                var ini = new INI(Application.StartupPath + "/config.ini");
                mainPath = ini.Read("mainPath");
                if (Directory.Exists(mainPath))
                {
                    getTreeView();
                }
                else
                {
                    MessageBox.Show("No se puede acceder a la ruta de guardado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Form frmConfig = new Config();
                    frmConfig.ShowDialog();
                }
            }
            else
            {
                string text = "[ImageManager]" + Environment.NewLine + "mainPath = C:";
                File.WriteAllText(Application.StartupPath + "/config.ini", text);
                Application.Restart();
            }
        }
        private void treeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node.Nodes.Count > 0)
            {
                if (e.Node.Nodes[0].Text == "..." && e.Node.Nodes[0].Tag == null)
                {
                    e.Node.Nodes.Clear();

                    //get the list of sub directories
                    string[] dirs = Directory.GetDirectories(e.Node.Tag.ToString());

                    foreach (string dir in dirs)
                    {
                        DirectoryInfo di = new DirectoryInfo(dir);
                        TreeNode node = new TreeNode(di.Name, 0, 1);

                        try
                        {
                            //keep the directory's full path in the tag for use later
                            node.Tag = dir;

                            //if the directory has sub directories add the place holder
                            if (di.GetDirectories().Count() > 0)
                                node.Nodes.Add(null, "...", 0, 0);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "DirectoryLister",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            e.Node.Nodes.Add(node);
                        }
                    }
                }
            }
        }

        static bool IfContains(string data, string type)
        {
            List<string> lstFormat_all = new List<string>(new string[] { ".jpg", ".bmp", ".png", ".jpeg", ".gif", ".webp", ".heif", ".ogg", ".webm", ".mp4", ".avi", ".flv" });
            List<string> lstFormat_images = new List<string>(new string[] { ".jpg", ".bmp", ".png", ".jpeg", ".gif", ".webp", ".heif", ".ogg", ".webm" });
            if(type == "all")
            {
                foreach (string item in lstFormat_all)
                {
                    if (data.Contains(item))
                    {
                        return true;
                    }
                }
            }else{
                foreach (string item in lstFormat_images)
                {
                    if (data.Contains(item))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private void bgWrk1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            string[] files = Directory.GetFiles(selectedPath);
            for (int i = 0; i < files.Length; i++)
            {
                if (bgWrk1.CancellationPending)
                {
                    break;
                }

                if (IfContains(files[i], "all"))
                {
                    try
                    {
                        Image myImage = Image.FromFile(files[i]);
                        PropertyItem propItem = myImage.GetPropertyItem(36867);

                        //Convert date taken metadata to a DateTime object
                        string sdate = Encoding.UTF8.GetString(propItem.Value).Trim();
                        string firsthalf = sdate.Substring(0, 10);
                        firsthalf = firsthalf.Replace(":", "-");

                        string[] date = firsthalf.ToString().Split('-');
                        string yearDir = mainPath + "/" + date[0];
                        string monthDir = yearDir + "/" + date[1];

                        switch (monthDir.Substring(Path.GetDirectoryName(monthDir).Length + 1, 2))
                        {
                            case "01":
                                monthDir = yearDir + "/" + date[1] + " (ene)";
                                break;
                            case "02":
                                monthDir = yearDir + "/" + date[1] + " (feb)";
                                break;
                            case "03":
                                monthDir = yearDir + "/" + date[1] + " (mar)";
                                break;
                            case "04":
                                monthDir = yearDir + "/" + date[1] + " (abr)";
                                break;
                            case "05":
                                monthDir = yearDir + "/" + date[1] + " (may)";
                                break;
                            case "06":
                                monthDir = yearDir + "/" + date[1] + " (jun)";
                                break;
                            case "07":
                                monthDir = yearDir + "/" + date[1] + " (jul)";
                                break;
                            case "08":
                                monthDir = yearDir + "/" + date[1] + " (ago)";
                                break;
                            case "09":
                                monthDir = yearDir + "/" + date[1] + " (sep)";
                                break;
                            case "10":
                                monthDir = yearDir + "/" + date[1] + " (oct)";
                                break;
                            case "11":
                                monthDir = yearDir + "/" + date[1] + " (nov)";
                                break;
                            case "12":
                                monthDir = yearDir + "/" + date[1] + " (dic)";
                                break;
                        }

                        Directory.CreateDirectory(yearDir);
                        Directory.CreateDirectory(monthDir);

                        if (File.Exists(monthDir + "/" + Path.GetFileName(files[i])) == false)
                        {
                            File.Copy(files[i], monthDir + "/" + Path.GetFileName(files[i]));
                        }
                        alzheimer();
                    }
                    catch (Exception)
                    {
                        try
                        {
                            FileInfo fileInfo = new FileInfo(files[i]);
                            DateTime lastWriteTime = fileInfo.LastWriteTime;

                            //Convert date taken metadata to a DateTime object
                            string sdate = lastWriteTime.ToString();
                            string firsthalf = sdate.Substring(0, 10);
                            firsthalf = firsthalf.Replace(":", "-");

                            string[] date = firsthalf.ToString().Split('/');
                            string yearDir = mainPath + "/" + date[2];
                            string monthDir = yearDir + "/" + date[1];



                            switch (monthDir.Substring(Path.GetDirectoryName(monthDir).Length + 1, 2))
                            {
                                case "01":
                                    monthDir = yearDir + "/" + date[1] + " (ene)";
                                    break;
                                case "02":
                                    monthDir = yearDir + "/" + date[1] + " (feb)";
                                    break;
                                case "03":
                                    monthDir = yearDir + "/" + date[1] + " (mar)";
                                    break;
                                case "04":
                                    monthDir = yearDir + "/" + date[1] + " (abr)";
                                    break;
                                case "05":
                                    monthDir = yearDir + "/" + date[1] + " (may)";
                                    break;
                                case "06":
                                    monthDir = yearDir + "/" + date[1] + " (jun)";
                                    break;
                                case "07":
                                    monthDir = yearDir + "/" + date[1] + " (jul)";
                                    break;
                                case "08":
                                    monthDir = yearDir + "/" + date[1] + " (ago)";
                                    break;
                                case "09":
                                    monthDir = yearDir + "/" + date[1] + " (sep)";
                                    break;
                                case "10":
                                    monthDir = yearDir + "/" + date[1] + " (oct)";
                                    break;
                                case "11":
                                    monthDir = yearDir + "/" + date[1] + " (nov)";
                                    break;
                                case "12":
                                    monthDir = yearDir + "/" + date[1] + " (dic)";
                                    break;
                            }

                            Directory.CreateDirectory(yearDir);
                            Directory.CreateDirectory(monthDir);
                            if (File.Exists(monthDir + "/" + Path.GetFileName(files[i])) == false)
                            {
                                File.Copy(files[i], monthDir + "/" + Path.GetFileName(files[i]));
                            }
                            alzheimer();
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Error con el archivo: " + files[i], "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            continue;
                        }
                        continue;
                    }
                    bgWrk1.ReportProgress(i);
                }

            }
        }

        private void bgWrk1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            button6.Visible = false;
            if (Directory.Exists(mainPath) == true)
            {
                treeView1.Nodes.Clear();
                string[] drives = Directory.GetDirectories(mainPath);

                foreach (string drive in drives)
                {
                    DirectoryInfo dir = new DirectoryInfo(drive);
                    if (((dir.Attributes & FileAttributes.System) != FileAttributes.System) || ((dir.Attributes & FileAttributes.Hidden) != FileAttributes.Hidden))
                    {
                        if(Regex.IsMatch(drive.Substring(drive.Length - 4, 4), "^(19|20)[0-9][0-9]"))
                        {
                            TreeNode node = new TreeNode(drive.Substring(drive.Length - 4, 4))
                            {
                                Tag = drive
                            };

                            node.Nodes.Add("...");
                            treeView1.Nodes.Add(node);
                        }
                    }
                }
            }
            else
            {
                treeView1.Nodes.Clear();
            }

            toolStripProgressBar1.Value = 0;
            toolStripStatusLabel1.Visible = false;
            toolStripProgressBar1.Visible = false;
            button1.Enabled = true;

            MessageBox.Show("Se han procesado todas las imágenes", "Procesamiento terminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void bgWrk1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            toolStripStatusLabel1.Visible = true;
            toolStripProgressBar1.Visible = true;
            string[] files = Directory.GetFiles(selectedPath);
            toolStripProgressBar1.Maximum = files.Length;
            toolStripProgressBar1.Value = e.ProgressPercentage;
            toolStripStatusLabel1.Text = "Cargando... " + "[" + e.ProgressPercentage + "/" + files.Length + "]";
        }

        public Control rm_lbl;

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (rm_lbl != null)
            {
                rm_lbl.Dispose();
            }

            Label charging = new Label();
            charging.Text = "Cargando...";
            charging.Font = new Font("Segoe UI", 32);
            charging.BackColor = Color.Transparent;
            charging.Size = new Size(247, 57);
            charging.Location = new Point((this.Width - charging.Width + treeView1.Width) / 2, (this.Height - charging.Height - groupBox1.Height) / 2);

            flowLayoutPanel1.Visible = false;
            flowLayoutPanel1.Controls.Clear();

            this.Controls.Add(charging);
            charging.BringToFront();

            string[] files = Directory.GetFiles(e.Node.Tag.ToString());

            if (files.Length > 0)
            {
                for (int i = 0; i < files.Length; i++)
                {
                    PictureBox imgCtrl = new PictureBox();
                    if (IfContains(files[i], "image"))
                    {
                        imgCtrl.Image = Image.FromFile(files[i]).GetThumbnailImage(640, 360, () => false, IntPtr.Zero);
                        imgCtrl.Size = new Size(200, 113);
                        imgCtrl.Tag = files[i];
                        imgCtrl.SizeMode = PictureBoxSizeMode.Zoom;
                        imgCtrl.Click += new EventHandler(SeeImg);
                        flowLayoutPanel1.Controls.Add(imgCtrl);
                    }
                    alzheimer();
                }
                charging.Dispose();
                flowLayoutPanel1.Visible = true;
            }
            else
            {
                charging.Dispose();

                Label empty = new Label();
                empty.Text = "Carpeta Vacía";
                empty.Font = new Font("Segoe UI", 32);
                empty.BackColor = Color.Transparent;
                empty.Size = new Size(290, 57);
                empty.Location = new Point((this.Width - empty.Width + treeView1.Width) / 2, (this.Height - empty.Height - groupBox1.Height) / 2);

                flowLayoutPanel1.Visible = false;
                flowLayoutPanel1.Controls.Clear();

                rm_lbl = empty;

                this.Controls.Add(empty);
                charging.BringToFront();
            }
        }

        private void SeeImg(object sender, EventArgs e)
        {
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = true;
            button4.Visible = true;
            button5.Visible = true;

            pictureBox1.Visible = true;
            PictureBox box = (PictureBox)sender;
            button5.Tag = box.Tag.ToString();
            pictureBox1.BringToFront();
            pictureBox1.Image = Image.FromFile(box.Tag.ToString());
        }

        public void hidePic()
        {
            pictureBox1.Image.Dispose();
            pictureBox1.Image = null;
            pictureBox1.SendToBack();
            pictureBox1.Visible = false;
            button5.Visible = false;
            button4.Visible = false;
            button3.Visible = false;
            button2.Visible = true;
            button1.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            hidePic();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog data = new FolderBrowserDialog();
            data.Description = "[!] Selecciona el dispositivo o carpeta que contiene todas las imágenes.";
            if (data.ShowDialog() == DialogResult.OK)
            {
                var ini = new INI(Application.StartupPath + "/config.ini");
                mainPath = ini.Read("mainPath");
                button1.Enabled = false;
                button6.Visible = true;
                selectedPath = data.SelectedPath;
                bgWrk1.WorkerReportsProgress = true;
                bgWrk1.RunWorkerAsync();
                data.Dispose();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(pictureBox1.Image != null)
            {
                Image pic = pictureBox1.Image;
                pic.RotateFlip(RotateFlipType.Rotate90FlipNone);
                pictureBox1.Image = pic;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Config fc = Application.OpenForms["Config"] != null ? (Config)Application.OpenForms["Config"] : null;
            if (fc == null)
            {
                Config frmConfig = new Config();
                frmConfig.Show();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            foreach(Control ctrl in flowLayoutPanel1.Controls)
            {
                if (ctrl.Tag.ToString() == button5.Tag.ToString())
                {
                    DialogResult dr = MessageBox.Show("¿Estas seguro que quieres eliminar esta imagen?", "Eliminar Imagen", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (dr == DialogResult.OK)
                    {
                        ctrl.Dispose();
                        hidePic();
                        if(File.Exists(ctrl.Tag.ToString()))
                        {
                            alzheimer();
                            File.Delete(ctrl.Tag.ToString());
                        }
                        alzheimer();
                    }
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("¿Estas seguro que quieres cancelar el proceso?\n No se eliminarán los datos creados hasta el momento", "Cancelar Proceso", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if(dr == DialogResult.OK)
            {
                bgWrk1.CancelAsync();
                button6.Visible = false;
                button1.Enabled = true;
            }
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(bgWrk1.IsBusy)
            {
                DialogResult dr = MessageBox.Show("Hay procesos ejecutandose, ¿estas seguro que quieres finalizar el proceso?", "Cerrar Programa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (dr == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
                else
                {
                    Environment.Exit(0);
                }
            }
        }

        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {
            treeView1.Nodes.Clear();
            getTreeView();
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(this.button1, "Seleccionar imágenes");
        }

        private void button6_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(this.button6, "Cancelar proceso");
        }

        private void button3_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(this.button3, "Volver");
        }

        private void button4_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(this.button4, "Rotar imagen");
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(this.button2, "Configuración");
        }

        private void button5_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(this.button5, "Eliminar imágen");
        }
    }
}
