using System.Windows.Forms;
using System.IO;
using System;
using System.Drawing;

namespace ImageManager
{
    public partial class fInfo : Form
    {
        PictureBox pic;

        public fInfo(PictureBox pic)
        {
            this.pic = pic;
            InitializeComponent();
        }

        static double ConvertBytesToMegabytes(long bytes)
        {
            return (bytes / 1024f) / 1024f;
        }

        public Tuple<int, int> getSizes(string path)
        {
            using (Stream stream = File.OpenRead(path))
            {
                using (Image sourceImage = Image.FromStream(stream, false, false))
                {
                    var tuple = new Tuple<int, int>(sourceImage.Width, sourceImage.Height);
                    return tuple;
                }
            }
        }

        private void fInfo_Load(object sender, EventArgs e)
        {
            long length = new FileInfo(pic.Tag.ToString()).Length;
            string size = Math.Round(ConvertBytesToMegabytes(length), 2).ToString();
            string ext = Path.GetExtension(pic.Tag.ToString());
            fileName.Text = Path.GetFileName(pic.Tag.ToString());
            fileSize.Text = "Tamaño del archivo: " + size + " MB";
            fileDimensions.Text = "Dimensiones: " + getSizes(pic.Tag.ToString()).Item1 + "x" + getSizes(pic.Tag.ToString()).Item2;
            fileExt.Text = "Extensión del archivo: " + ext;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
