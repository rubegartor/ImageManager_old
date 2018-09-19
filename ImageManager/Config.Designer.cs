namespace ImageManager
{
    partial class Config
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Config));
            this.configGroupBox = new System.Windows.Forms.GroupBox();
            this.alertLbl = new System.Windows.Forms.Label();
            this.selectMainPathBtn = new System.Windows.Forms.Button();
            this.mainPathLbl = new System.Windows.Forms.Label();
            this.mainPathTxt = new System.Windows.Forms.TextBox();
            this.labelAnim = new System.Windows.Forms.Timer(this.components);
            this.contentPanel = new System.Windows.Forms.Panel();
            this.alertPanel = new System.Windows.Forms.Panel();
            this.configGroupBox.SuspendLayout();
            this.contentPanel.SuspendLayout();
            this.alertPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // configGroupBox
            // 
            this.configGroupBox.Controls.Add(this.selectMainPathBtn);
            this.configGroupBox.Controls.Add(this.mainPathLbl);
            this.configGroupBox.Controls.Add(this.mainPathTxt);
            this.configGroupBox.Location = new System.Drawing.Point(3, 3);
            this.configGroupBox.Name = "configGroupBox";
            this.configGroupBox.Size = new System.Drawing.Size(350, 88);
            this.configGroupBox.TabIndex = 1;
            this.configGroupBox.TabStop = false;
            this.configGroupBox.Text = "Tu Configuración";
            // 
            // alertLbl
            // 
            this.alertLbl.AutoSize = true;
            this.alertLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.alertLbl.ForeColor = System.Drawing.Color.White;
            this.alertLbl.Location = new System.Drawing.Point(3, 15);
            this.alertLbl.Name = "alertLbl";
            this.alertLbl.Size = new System.Drawing.Size(62, 18);
            this.alertLbl.TabIndex = 3;
            this.alertLbl.Text = "%data%";
            this.alertLbl.Visible = false;
            // 
            // selectMainPathBtn
            // 
            this.selectMainPathBtn.Location = new System.Drawing.Point(311, 42);
            this.selectMainPathBtn.Name = "selectMainPathBtn";
            this.selectMainPathBtn.Size = new System.Drawing.Size(29, 23);
            this.selectMainPathBtn.TabIndex = 2;
            this.selectMainPathBtn.Text = "...";
            this.selectMainPathBtn.UseVisualStyleBackColor = true;
            this.selectMainPathBtn.Click += new System.EventHandler(this.button2_Click);
            // 
            // mainPathLbl
            // 
            this.mainPathLbl.AutoSize = true;
            this.mainPathLbl.Location = new System.Drawing.Point(23, 28);
            this.mainPathLbl.Name = "mainPathLbl";
            this.mainPathLbl.Size = new System.Drawing.Size(96, 13);
            this.mainPathLbl.TabIndex = 1;
            this.mainPathLbl.Text = "Ruta de guardado:";
            // 
            // mainPathTxt
            // 
            this.mainPathTxt.Enabled = false;
            this.mainPathTxt.Location = new System.Drawing.Point(26, 44);
            this.mainPathTxt.Name = "mainPathTxt";
            this.mainPathTxt.Size = new System.Drawing.Size(279, 20);
            this.mainPathTxt.TabIndex = 0;
            // 
            // labelAnim
            // 
            this.labelAnim.Interval = 6000;
            this.labelAnim.Tick += new System.EventHandler(this.labelAnim_Tick);
            // 
            // contentPanel
            // 
            this.contentPanel.Controls.Add(this.configGroupBox);
            this.contentPanel.Location = new System.Drawing.Point(12, 12);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Size = new System.Drawing.Size(356, 94);
            this.contentPanel.TabIndex = 2;
            // 
            // alertPanel
            // 
            this.alertPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.alertPanel.Controls.Add(this.alertLbl);
            this.alertPanel.Location = new System.Drawing.Point(12, 12);
            this.alertPanel.Name = "alertPanel";
            this.alertPanel.Size = new System.Drawing.Size(356, 48);
            this.alertPanel.TabIndex = 4;
            // 
            // Config
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(380, 122);
            this.Controls.Add(this.contentPanel);
            this.Controls.Add(this.alertPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Config";
            this.Text = "Configuración";
            this.Load += new System.EventHandler(this.Config_Load);
            this.configGroupBox.ResumeLayout(false);
            this.configGroupBox.PerformLayout();
            this.contentPanel.ResumeLayout(false);
            this.alertPanel.ResumeLayout(false);
            this.alertPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox configGroupBox;
        private System.Windows.Forms.Button selectMainPathBtn;
        private System.Windows.Forms.Label mainPathLbl;
        private System.Windows.Forms.TextBox mainPathTxt;
        private System.Windows.Forms.Label alertLbl;
        private System.Windows.Forms.Timer labelAnim;
        private System.Windows.Forms.Panel contentPanel;
        private System.Windows.Forms.Panel alertPanel;
    }
}