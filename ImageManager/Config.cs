using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Text.RegularExpressions;

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
                textBox1.Text = ini.Read("mainPath");
            }
            else
            {
                MessageBox.Show("No se ha podido encontrar el fichero de configuración", "File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void setLabel(string msg, Color color)
        {
            label2.Text = msg;
            label2.Location = new Point((groupBox1.Width - label2.Width) / 2, label2.Location.Y);
            label2.ForeColor = color;
            label2.Visible = true;
            labelAnim.Start();
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
                        textBox1.Text = toWrite;

                        setLabel("Ruta guardada con éxito", Color.Green);

                        frmMain.getTreeView();
                    } else {
                        string toWrite = data.SelectedPath;

                        var ini = new INI(Application.StartupPath + "/config.ini");
                        ini.Write("mainPath", toWrite);
                        textBox1.Text = toWrite;

                        setLabel("Ruta guardada con éxito", Color.Green);

                        frmMain.getTreeView();
                    }
                }
            }
        }

        private void labelAnim_Tick(object sender, EventArgs e)
        {
            label2.Visible = false;
            labelAnim.Stop();
        }
    }
}
