using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;

namespace ImageManager
{
    public partial class Config : Form
    {
        Form _frm;

        public Config(Form frm)
        {
            _frm = frm;
            InitializeComponent();
        }

        private void Config_Load(object sender, EventArgs e)
        {
            if (File.Exists(Application.StartupPath + "/config.ini"))
            {
                var ini = new INI(Application.StartupPath + "/config.ini");
                mainPathTxt.Text = ini.Read("mainPath");
            }
            else
            {
                MessageBox.Show("No se ha podido encontrar el fichero de configuración", "File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void showAlert(string msg, Color color)
        {
            alertLbl.Text = msg;
            this.Size = new Size(this.Size.Width, (contentPanel.Height + alertPanel.Height + 75));
            contentPanel.Location = new Point(contentPanel.Location.X, (alertPanel.Height + 20));
            alertLbl.Location = new Point((alertPanel.Width - alertLbl.Width) / 2, (alertPanel.Height - alertLbl.Height) / 2);
            alertLbl.BackColor = color;
            alertLbl.Visible = true;
            labelAnim.Start();
        }

        public void hideAlert()
        {
            contentPanel.Location = new Point(contentPanel.Location.X, (alertPanel.Height - 40));
            this.Size = new Size(this.Size.Width, (contentPanel.Height + alertPanel.Height + 15));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog data = new FolderBrowserDialog();
            if (data.ShowDialog() == DialogResult.OK)
            {
                if(Directory.Exists(data.SelectedPath))
                {
                    Main frmMain = (Main)_frm;
                    if (data.SelectedPath.Length <= 3)
                    {
                        string toWrite = data.SelectedPath.Substring(0, 2);

                        var ini = new INI(Application.StartupPath + "/config.ini");
                        ini.Write("mainPath", toWrite);
                        mainPathTxt.Text = toWrite;

                        showAlert("Ruta guardada con éxito", ColorTranslator.FromHtml("#27ae60"));

                        frmMain.getTreeView();
                    } else {
                        string toWrite = data.SelectedPath;

                        var ini = new INI(Application.StartupPath + "/config.ini");
                        ini.Write("mainPath", toWrite);
                        mainPathTxt.Text = toWrite;

                        showAlert("Ruta guardada con éxito", ColorTranslator.FromHtml("#27ae60"));

                        frmMain.getTreeView();
                    }
                }
            }
        }

        private void labelAnim_Tick(object sender, EventArgs e)
        {
            alertLbl.Visible = false;
            labelAnim.Stop();
            hideAlert();
        }
    }
}
