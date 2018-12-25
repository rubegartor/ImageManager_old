namespace ImageManager
{
    partial class Main
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.openBtn = new System.Windows.Forms.Button();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.refreshStatusBtn = new System.Windows.Forms.ToolStripDropDownButton();
            this.spaceStatusBarLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.loadStatusBarLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.progressStatusBar = new System.Windows.Forms.ToolStripProgressBar();
            this.treeView = new System.Windows.Forms.TreeView();
            this.forwardBtn = new System.Windows.Forms.Button();
            this.main_flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.bgWrk1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tools_flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.rotationBtn = new System.Windows.Forms.Button();
            this.configBtn = new System.Windows.Forms.Button();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.infoBtn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.statusBar.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tools_flowLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // openBtn
            // 
            this.openBtn.Image = ((System.Drawing.Image)(resources.GetObject("openBtn.Image")));
            this.openBtn.Location = new System.Drawing.Point(3, 3);
            this.openBtn.Name = "openBtn";
            this.openBtn.Size = new System.Drawing.Size(58, 48);
            this.openBtn.TabIndex = 0;
            this.openBtn.UseVisualStyleBackColor = true;
            this.openBtn.Click += new System.EventHandler(this.openBtn_Click);
            this.openBtn.MouseHover += new System.EventHandler(this.openBtn_MouseHover);
            // 
            // statusBar
            // 
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshStatusBtn,
            this.spaceStatusBarLabel,
            this.loadStatusBarLabel,
            this.progressStatusBar});
            this.statusBar.Location = new System.Drawing.Point(0, 513);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(895, 22);
            this.statusBar.SizingGrip = false;
            this.statusBar.TabIndex = 3;
            this.statusBar.Text = "statusStrip1";
            // 
            // refreshStatusBtn
            // 
            this.refreshStatusBtn.Image = ((System.Drawing.Image)(resources.GetObject("refreshStatusBtn.Image")));
            this.refreshStatusBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.refreshStatusBtn.Name = "refreshStatusBtn";
            this.refreshStatusBtn.ShowDropDownArrow = false;
            this.refreshStatusBtn.Size = new System.Drawing.Size(73, 20);
            this.refreshStatusBtn.Text = "Recargar";
            this.refreshStatusBtn.Click += new System.EventHandler(this.refreshStatusBtn_Click);
            // 
            // spaceStatusBarLabel
            // 
            this.spaceStatusBarLabel.Name = "spaceStatusBarLabel";
            this.spaceStatusBarLabel.Size = new System.Drawing.Size(807, 17);
            this.spaceStatusBarLabel.Spring = true;
            // 
            // loadStatusBarLabel
            // 
            this.loadStatusBarLabel.Name = "loadStatusBarLabel";
            this.loadStatusBarLabel.Size = new System.Drawing.Size(68, 17);
            this.loadStatusBarLabel.Text = "Cargando...";
            this.loadStatusBarLabel.Visible = false;
            // 
            // progressStatusBar
            // 
            this.progressStatusBar.Name = "progressStatusBar";
            this.progressStatusBar.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.progressStatusBar.Size = new System.Drawing.Size(100, 16);
            this.progressStatusBar.Visible = false;
            // 
            // treeView
            // 
            this.treeView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.treeView.Location = new System.Drawing.Point(12, 77);
            this.treeView.Name = "treeView";
            this.treeView.Size = new System.Drawing.Size(222, 433);
            this.treeView.TabIndex = 4;
            this.treeView.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeView_BeforeExpand);
            this.treeView.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView_NodeMouseDoubleClick);
            // 
            // forwardBtn
            // 
            this.forwardBtn.Image = ((System.Drawing.Image)(resources.GetObject("forwardBtn.Image")));
            this.forwardBtn.Location = new System.Drawing.Point(131, 3);
            this.forwardBtn.Name = "forwardBtn";
            this.forwardBtn.Size = new System.Drawing.Size(58, 48);
            this.forwardBtn.TabIndex = 2;
            this.forwardBtn.UseVisualStyleBackColor = true;
            this.forwardBtn.Visible = false;
            this.forwardBtn.Click += new System.EventHandler(this.forwardBtn_Click);
            this.forwardBtn.MouseHover += new System.EventHandler(this.forwardBtn_MouseHover);
            // 
            // main_flowLayoutPanel
            // 
            this.main_flowLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.main_flowLayoutPanel.AutoScroll = true;
            this.main_flowLayoutPanel.Location = new System.Drawing.Point(240, 77);
            this.main_flowLayoutPanel.Name = "main_flowLayoutPanel";
            this.main_flowLayoutPanel.Size = new System.Drawing.Size(643, 433);
            this.main_flowLayoutPanel.TabIndex = 6;
            // 
            // bgWrk1
            // 
            this.bgWrk1.WorkerSupportsCancellation = true;
            this.bgWrk1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWrk1_DoWork);
            this.bgWrk1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgWrk1_ProgressChanged);
            this.bgWrk1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWrk1_RunWorkerCompleted);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.tools_flowLayoutPanel);
            this.groupBox1.Location = new System.Drawing.Point(12, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(871, 69);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // tools_flowLayoutPanel
            // 
            this.tools_flowLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tools_flowLayoutPanel.Controls.Add(this.openBtn);
            this.tools_flowLayoutPanel.Controls.Add(this.cancelBtn);
            this.tools_flowLayoutPanel.Controls.Add(this.forwardBtn);
            this.tools_flowLayoutPanel.Controls.Add(this.rotationBtn);
            this.tools_flowLayoutPanel.Controls.Add(this.configBtn);
            this.tools_flowLayoutPanel.Controls.Add(this.deleteBtn);
            this.tools_flowLayoutPanel.Controls.Add(this.infoBtn);
            this.tools_flowLayoutPanel.Location = new System.Drawing.Point(6, 10);
            this.tools_flowLayoutPanel.Name = "tools_flowLayoutPanel";
            this.tools_flowLayoutPanel.Size = new System.Drawing.Size(859, 53);
            this.tools_flowLayoutPanel.TabIndex = 3;
            // 
            // cancelBtn
            // 
            this.cancelBtn.AccessibleDescription = "";
            this.cancelBtn.Image = ((System.Drawing.Image)(resources.GetObject("cancelBtn.Image")));
            this.cancelBtn.Location = new System.Drawing.Point(67, 3);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(58, 48);
            this.cancelBtn.TabIndex = 6;
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Visible = false;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            this.cancelBtn.MouseHover += new System.EventHandler(this.cancelBtn_MouseHover);
            // 
            // rotationBtn
            // 
            this.rotationBtn.Image = ((System.Drawing.Image)(resources.GetObject("rotationBtn.Image")));
            this.rotationBtn.Location = new System.Drawing.Point(195, 3);
            this.rotationBtn.Name = "rotationBtn";
            this.rotationBtn.Size = new System.Drawing.Size(58, 48);
            this.rotationBtn.TabIndex = 4;
            this.rotationBtn.UseVisualStyleBackColor = true;
            this.rotationBtn.Visible = false;
            this.rotationBtn.Click += new System.EventHandler(this.rotationBtn_Click);
            this.rotationBtn.MouseHover += new System.EventHandler(this.rotationBtn_MouseHover);
            // 
            // configBtn
            // 
            this.configBtn.Image = ((System.Drawing.Image)(resources.GetObject("configBtn.Image")));
            this.configBtn.Location = new System.Drawing.Point(259, 3);
            this.configBtn.Name = "configBtn";
            this.configBtn.Size = new System.Drawing.Size(58, 48);
            this.configBtn.TabIndex = 3;
            this.configBtn.UseVisualStyleBackColor = true;
            this.configBtn.Click += new System.EventHandler(this.configBtn_Click);
            this.configBtn.MouseHover += new System.EventHandler(this.configBtn_MouseHover);
            // 
            // deleteBtn
            // 
            this.deleteBtn.Image = ((System.Drawing.Image)(resources.GetObject("deleteBtn.Image")));
            this.deleteBtn.Location = new System.Drawing.Point(323, 3);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(58, 48);
            this.deleteBtn.TabIndex = 5;
            this.deleteBtn.UseVisualStyleBackColor = true;
            this.deleteBtn.Visible = false;
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            this.deleteBtn.MouseHover += new System.EventHandler(this.deleteBtn_MouseHover);
            // 
            // infoBtn
            // 
            this.infoBtn.Image = ((System.Drawing.Image)(resources.GetObject("infoBtn.Image")));
            this.infoBtn.Location = new System.Drawing.Point(387, 3);
            this.infoBtn.Name = "infoBtn";
            this.infoBtn.Size = new System.Drawing.Size(58, 48);
            this.infoBtn.TabIndex = 7;
            this.infoBtn.UseVisualStyleBackColor = true;
            this.infoBtn.Visible = false;
            this.infoBtn.Click += new System.EventHandler(this.infoBtn_Click);
            this.infoBtn.MouseHover += new System.EventHandler(this.infoBtn_MouseHover);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Location = new System.Drawing.Point(12, 77);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(871, 433);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(895, 535);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.main_flowLayoutPanel);
            this.Controls.Add(this.treeView);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.Text = "Image Manager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.tools_flowLayoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button openBtn;
        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.Button forwardBtn;
        private System.Windows.Forms.FlowLayoutPanel main_flowLayoutPanel;
        private System.ComponentModel.BackgroundWorker bgWrk1;
        private System.Windows.Forms.ToolStripProgressBar progressStatusBar;
        private System.Windows.Forms.ToolStripStatusLabel loadStatusBarLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.FlowLayoutPanel tools_flowLayoutPanel;
        private System.Windows.Forms.Button configBtn;
        private System.Windows.Forms.Button rotationBtn;
        private System.Windows.Forms.Button deleteBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.ToolStripStatusLabel spaceStatusBarLabel;
        private System.Windows.Forms.ToolStripDropDownButton refreshStatusBtn;
        private System.Windows.Forms.ToolTip toolTip1;
        public System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.Button infoBtn;
    }
}

