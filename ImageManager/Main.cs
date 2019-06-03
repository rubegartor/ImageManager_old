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
using System.Threading;

namespace ImageManager
{
    public partial class Main : Form
    {
        [DllImport("kernel32.dll", EntryPoint = "SetProcessWorkingSetSize", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        private static extern int SetProcessWorkingSetSize(IntPtr process, int minimumWorkingSetSize, int maximumWorkingSetSize);

        public string mainPath = @"";
        public string selectedPath;
        private Control rm_lbl;

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

        static string getMainPath()
        {
            string mainPath = Properties.Settings.Default.mainPath;
            return mainPath;
        }

        public void getTreeView()
        {
            mainPath = getMainPath();
            if (Directory.Exists(mainPath))
            {
                DirectoryInfo di = new DirectoryInfo(mainPath);
                foreach (DirectoryInfo d in di.GetDirectories())
                {
                    treeView.Nodes.Clear();
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
                                treeView.Nodes.Add(node);
                            }
                        }
                    }
                }
            }
            else
            {
                treeView.Nodes.Clear();
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            mainPath = getMainPath();
            if (Directory.Exists(mainPath))
            {
                getTreeView();
            }
            else
            {
                MessageBox.Show("No se puede acceder a la ruta de guardado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Form frmConfig = new Config(this);
                frmConfig.ShowDialog();
            }
        }
        private void treeView_BeforeExpand(object sender, TreeViewCancelEventArgs e)
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

        public void setFlowLayoutPanelVisible(bool visible) {
            if (InvokeRequired) {
                this.Invoke((MethodInvoker)delegate () { setFlowLayoutPanelVisible(visible); });
                return;
            }
            main_flowLayoutPanel.Visible = visible;
            if (!visible) {
                main_flowLayoutPanel.Controls.Clear();
            }
        }

        public void addMainControl(Control ctrl) {
            if (InvokeRequired) {
                this.Invoke((MethodInvoker)delegate () { addMainControl(ctrl); });
                return;
            }
            this.Controls.Add(ctrl);
            ctrl.BringToFront();
        }

        public void removeControl(Control ctrl) {
            if (InvokeRequired) {
                this.Invoke((MethodInvoker)delegate () { removeControl(ctrl); });
                return;
            }
            ctrl.Dispose();
        }

        public void addFlowLayoutPanelImage(Control ctrl) {
            if (InvokeRequired) {
                this.Invoke((MethodInvoker)delegate () { addFlowLayoutPanelImage(ctrl); });
                return;
            }
            main_flowLayoutPanel.Controls.Add(ctrl);
        }

        private void treeView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;

                if (rm_lbl != null) {
                    rm_lbl.Dispose();
                }

                Label charging = new Label();
                charging.Text = "Cargando...";
                charging.Font = new Font("Segoe UI", 32);
                charging.BackColor = Color.Transparent;
                charging.Size = new Size(247, 57);
                charging.Location = new Point((this.Width - charging.Width + treeView.Width) / 2, (this.Height - charging.Height - groupBox1.Height) / 2);

                setFlowLayoutPanelVisible(false);

                addMainControl(charging);
                string[] files = Directory.GetFiles(e.Node.Tag.ToString());

                if (files.Length > 0) {
                    for (int i = 0; i < files.Length; i++) {
                        if (new FileInfo(files[i]).Length > 0) {
                            PictureBox imgCtrl = new PictureBox();
                            if (IfContains(files[i], "image")) {
                                imgCtrl.Image = Image.FromFile(files[i]).GetThumbnailImage(640, 360, null, IntPtr.Zero);
                                imgCtrl.Size = new Size(200, 113);
                                imgCtrl.Tag = files[i];
                                imgCtrl.SizeMode = PictureBoxSizeMode.Zoom;
                                imgCtrl.Click += new EventHandler(SeeImg);
                                addFlowLayoutPanelImage(imgCtrl);
                            }
                            alzheimer();
                        }
                    }
                    removeControl(charging);
                    setFlowLayoutPanelVisible(true);
                } else {
                    charging.Dispose();

                    Label empty = new Label();
                    empty.Text = "Carpeta Vacía";
                    empty.Font = new Font("Segoe UI", 32);
                    empty.BackColor = Color.Transparent;
                    empty.Size = new Size(290, 57);
                    empty.Location = new Point((this.Width - empty.Width + treeView.Width) / 2, (this.Height - empty.Height - groupBox1.Height) / 2);

                    setFlowLayoutPanelVisible(false);

                    rm_lbl = empty;

                    addMainControl(empty);
                }
            }).Start();
        }

        static bool IfContains(string data, string type)
        {
            List<string> lstFormat_all = new List<string>(new string[] { ".jpg", ".bmp", ".png", ".jpeg", ".gif", ".webp", ".tiff", ".tif", ".heif", ".webm", ".mp4", ".avi", ".flv" });
            List<string> lstFormat_images = new List<string>(new string[] { ".jpg", ".bmp", ".png", ".jpeg", ".gif", ".webp", ".tiff", ".tif", ".heif" });
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

        public static string parseDate(string monthDir, string yearDir)
        {
            string res = "";
            switch (monthDir)
            {
                case "01":
                    res = yearDir + "/" + monthDir + " (ene)";
                    break;
                case "02":
                    res = yearDir + "/" + monthDir + " (feb)";
                    break;
                case "03":
                    res = yearDir + "/" + monthDir + " (mar)";
                    break;
                case "04":
                    res = yearDir + "/" + monthDir + " (abr)";
                    break;
                case "05":
                    res = yearDir + "/" + monthDir + " (may)";
                    break;
                case "06":
                    res = yearDir + "/" + monthDir + " (jun)";
                    break;
                case "07":
                    res = yearDir + "/" + monthDir + " (jul)";
                    break;
                case "08":
                    res = yearDir + "/" + monthDir + " (ago)";
                    break;
                case "09":
                    res = yearDir + "/" + monthDir + " (sep)";
                    break;
                case "10":
                    res = yearDir + "/" + monthDir + " (oct)";
                    break;
                case "11":
                    res = yearDir + "/" + monthDir + " (nov)";
                    break;
                case "12":
                    res = yearDir + "/" + monthDir + " (dic)";
                    break;
            }

            return res;
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
                        PropertyItem propItem = myImage.GetPropertyItem(36867); //Date taken 

                        //Convert date taken metadata to a DateTime object
                        string sdate = Encoding.UTF8.GetString(propItem.Value).Trim();
                        string firsthalf = sdate.Substring(0, 10);
                        firsthalf = firsthalf.Replace(":", "-");

                        string[] date = firsthalf.ToString().Split('-');
                        string yearDir = mainPath + "/" + date[0];
                        string monthDir = yearDir + "/" + date[1];

                        monthDir = mainPath  + "/" + parseDate(monthDir.Substring(Path.GetDirectoryName(monthDir).Length + 1, 2), date[0]);

                        Directory.CreateDirectory(yearDir);
                        Directory.CreateDirectory(monthDir);

                        if (!File.Exists(monthDir + "/" + Path.GetFileName(files[i])))
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

                            monthDir = mainPath + "/" + parseDate(monthDir.Substring(Path.GetDirectoryName(monthDir).Length + 1, 2), date[2]);

                            Directory.CreateDirectory(yearDir);
                            Directory.CreateDirectory(monthDir);
                            if (!File.Exists(monthDir + "/" + Path.GetFileName(files[i])))
                            {
                                File.Copy(files[i], monthDir + "/" + Path.GetFileName(files[i]));
                            }
                            alzheimer();
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("No se ha podido obtener la fecha del siguiente archivo: " + files[i], "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            cancelBtn.Visible = false;
            if (Directory.Exists(mainPath))
            {
                treeView.Nodes.Clear();
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
                            treeView.Nodes.Add(node);
                        }
                    }
                }
            }
            else
            {
                treeView.Nodes.Clear();
            }

            progressStatusBar.Value = 0;
            loadStatusBarLabel.Visible = false;
            progressStatusBar.Visible = false;
            openBtn.Enabled = true;

            MessageBox.Show("Se han procesado todas las imágenes", "Procesamiento terminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void bgWrk1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            loadStatusBarLabel.Visible = true;
            progressStatusBar.Visible = true;
            string[] files = Directory.GetFiles(selectedPath);
            progressStatusBar.Maximum = files.Length;
            progressStatusBar.Value = e.ProgressPercentage;
            loadStatusBarLabel.Text = "Cargando... " + "[" + e.ProgressPercentage + "/" + files.Length + "]";
        }

        private void SeeImg(object sender, EventArgs e)
        {
            openBtn.Visible = false;
            configBtn.Visible = false;
            forwardBtn.Visible = true;
            rotationBtn.Visible = true;
            deleteBtn.Visible = true;
            infoBtn.Visible = true;

            pictureBox1.Visible = true;
            PictureBox box = (PictureBox)sender;
            deleteBtn.Tag = box.Tag.ToString();
            pictureBox1.Tag = box.Tag.ToString();
            pictureBox1.BringToFront();
            pictureBox1.Image = Image.FromFile(box.Tag.ToString());
        }

        public void hidePic()
        {
            pictureBox1.Image.Dispose();
            pictureBox1.Image = null;
            pictureBox1.SendToBack();
            pictureBox1.Visible = false;
            deleteBtn.Visible = false;
            rotationBtn.Visible = false;
            forwardBtn.Visible = false;
            configBtn.Visible = true;
            openBtn.Visible = true;
            infoBtn.Visible = false;
        }

        private void forwardBtn_Click(object sender, EventArgs e)
        {
            hidePic();
        }

        private void openBtn_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog data = new FolderBrowserDialog();
            data.Description = "[!] Selecciona el dispositivo o carpeta que contiene todas las imágenes.";
            if (data.ShowDialog() == DialogResult.OK)
            {
                mainPath = Properties.Settings.Default.mainPath;
                openBtn.Enabled = false;
                cancelBtn.Visible = true;
                selectedPath = data.SelectedPath;
                bgWrk1.WorkerReportsProgress = true;
                bgWrk1.RunWorkerAsync();
                data.Dispose();
            }
        }

        private void rotationBtn_Click(object sender, EventArgs e)
        {
            if(pictureBox1.Image != null)
            {
                Image pic = pictureBox1.Image;
                pic.RotateFlip(RotateFlipType.Rotate90FlipNone);
                pictureBox1.Image = pic;
            }
        }

        private void configBtn_Click(object sender, EventArgs e)
        {
            Config fc = Application.OpenForms["Config"] != null ? (Config)Application.OpenForms["Config"] : null;
            if (fc == null)
            {
                Config frmConfig = new Config(this);
                frmConfig.Show();
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            foreach(Control ctrl in main_flowLayoutPanel.Controls)
            {
                if (ctrl.Tag.ToString() == deleteBtn.Tag.ToString())
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

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("¿Estas seguro que quieres cancelar el proceso?\n No se eliminarán los datos creados hasta el momento", "Cancelar Proceso", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if(dr == DialogResult.OK)
            {
                bgWrk1.CancelAsync();
                cancelBtn.Visible = false;
                openBtn.Enabled = true;
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

        private void refreshStatusBtn_Click(object sender, EventArgs e)
        {
            treeView.Nodes.Clear();
            getTreeView();
        }

        private void infoBtn_Click(object sender, EventArgs e)
        {
            fInfo frmInfo = new fInfo(pictureBox1);
            frmInfo.Show();
        }

        private void openBtn_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(this.openBtn, "Seleccionar imágenes");
        }

        private void cancelBtn_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(this.cancelBtn, "Cancelar proceso");
        }

        private void forwardBtn_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(this.forwardBtn, "Volver");
        }

        private void rotationBtn_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(this.rotationBtn, "Rotar imagen");
        }

        private void configBtn_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(this.configBtn, "Configuración");
        }

        private void deleteBtn_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(this.deleteBtn, "Eliminar imagen");
        }

        private void infoBtn_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(this.infoBtn, "Información");
        }
    }
}
