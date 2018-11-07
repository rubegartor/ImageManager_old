namespace ImageManager
{
    partial class fInfo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fInfo));
            this.fileName = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.fileSize = new System.Windows.Forms.Label();
            this.fileDimensions = new System.Windows.Forms.Label();
            this.fileExt = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // fileName
            // 
            this.fileName.AutoSize = true;
            this.fileName.Location = new System.Drawing.Point(79, 18);
            this.fileName.Name = "fileName";
            this.fileName.Size = new System.Drawing.Size(35, 13);
            this.fileName.TabIndex = 0;
            this.fileName.Text = "label1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 48);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // fileSize
            // 
            this.fileSize.AutoSize = true;
            this.fileSize.Location = new System.Drawing.Point(79, 37);
            this.fileSize.Name = "fileSize";
            this.fileSize.Size = new System.Drawing.Size(35, 13);
            this.fileSize.TabIndex = 2;
            this.fileSize.Text = "label1";
            // 
            // fileDimensions
            // 
            this.fileDimensions.AutoSize = true;
            this.fileDimensions.Location = new System.Drawing.Point(79, 57);
            this.fileDimensions.Name = "fileDimensions";
            this.fileDimensions.Size = new System.Drawing.Size(35, 13);
            this.fileDimensions.TabIndex = 3;
            this.fileDimensions.Text = "label1";
            // 
            // fileExt
            // 
            this.fileExt.AutoSize = true;
            this.fileExt.Location = new System.Drawing.Point(79, 79);
            this.fileExt.Name = "fileExt";
            this.fileExt.Size = new System.Drawing.Size(35, 13);
            this.fileExt.TabIndex = 4;
            this.fileExt.Text = "label1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(218, 106);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Cerrar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // fInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(305, 141);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.fileExt);
            this.Controls.Add(this.fileDimensions);
            this.Controls.Add(this.fileSize);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.fileName);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fInfo";
            this.Text = "Información";
            this.Load += new System.EventHandler(this.fInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label fileName;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label fileSize;
        private System.Windows.Forms.Label fileDimensions;
        private System.Windows.Forms.Label fileExt;
        private System.Windows.Forms.Button button1;
    }
}