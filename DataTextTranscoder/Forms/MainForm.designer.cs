namespace DataTextTranscoder
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mainTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.fileConvertButton = new System.Windows.Forms.Button();
            this.textConvertButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.base64ConvertButton = new System.Windows.Forms.Button();
            this.base64ModeContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.encodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.decodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainTableLayoutPanel.SuspendLayout();
            this.base64ModeContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainTableLayoutPanel
            // 
            resources.ApplyResources(this.mainTableLayoutPanel, "mainTableLayoutPanel");
            this.mainTableLayoutPanel.Controls.Add(this.fileConvertButton, 0, 0);
            this.mainTableLayoutPanel.Controls.Add(this.textConvertButton, 0, 1);
            this.mainTableLayoutPanel.Controls.Add(this.exitButton, 0, 3);
            this.mainTableLayoutPanel.Controls.Add(this.base64ConvertButton, 0, 2);
            this.mainTableLayoutPanel.Name = "mainTableLayoutPanel";
            // 
            // fileConvertButton
            // 
            this.fileConvertButton.AllowDrop = true;
            resources.ApplyResources(this.fileConvertButton, "fileConvertButton");
            this.fileConvertButton.Name = "fileConvertButton";
            this.fileConvertButton.UseVisualStyleBackColor = true;
            this.fileConvertButton.Click += new System.EventHandler(this.fileConvertButton_Click);
            this.fileConvertButton.DragDrop += new System.Windows.Forms.DragEventHandler(this.mainFormButton_DragDrop);
            this.fileConvertButton.DragEnter += new System.Windows.Forms.DragEventHandler(this.mainFormButton_DragEnter);
            // 
            // textConvertButton
            // 
            this.textConvertButton.AllowDrop = true;
            resources.ApplyResources(this.textConvertButton, "textConvertButton");
            this.textConvertButton.Image = global::DataTextTranscoder.Properties.Resources.Letter;
            this.textConvertButton.Name = "textConvertButton";
            this.textConvertButton.UseVisualStyleBackColor = true;
            this.textConvertButton.Click += new System.EventHandler(this.textConvertButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.AllowDrop = true;
            resources.ApplyResources(this.exitButton, "exitButton");
            this.exitButton.Image = global::DataTextTranscoder.Properties.Resources.OK;
            this.exitButton.Name = "exitButton";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // base64ConvertButton
            // 
            this.base64ConvertButton.AllowDrop = true;
            resources.ApplyResources(this.base64ConvertButton, "base64ConvertButton");
            this.base64ConvertButton.Name = "base64ConvertButton";
            this.base64ConvertButton.UseVisualStyleBackColor = true;
            this.base64ConvertButton.Click += new System.EventHandler(this.base64ConvertButton_Click);
            this.base64ConvertButton.DragDrop += new System.Windows.Forms.DragEventHandler(this.mainFormButton_DragDrop);
            this.base64ConvertButton.DragEnter += new System.Windows.Forms.DragEventHandler(this.mainFormButton_DragEnter);
            // 
            // base64ModeContextMenuStrip
            // 
            this.base64ModeContextMenuStrip.AllowDrop = true;
            this.base64ModeContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.encodeToolStripMenuItem,
            this.decodeToolStripMenuItem});
            this.base64ModeContextMenuStrip.Name = "base64ModeContextMenuStrip";
            resources.ApplyResources(this.base64ModeContextMenuStrip, "base64ModeContextMenuStrip");
            this.base64ModeContextMenuStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.base64ModeContextMenuStrip_ItemClicked);
            // 
            // encodeToolStripMenuItem
            // 
            this.encodeToolStripMenuItem.Image = global::DataTextTranscoder.Properties.Resources.CycleRed;
            this.encodeToolStripMenuItem.Name = "encodeToolStripMenuItem";
            resources.ApplyResources(this.encodeToolStripMenuItem, "encodeToolStripMenuItem");
            this.encodeToolStripMenuItem.Tag = "0";
            // 
            // decodeToolStripMenuItem
            // 
            this.decodeToolStripMenuItem.Image = global::DataTextTranscoder.Properties.Resources.CycleGreen;
            this.decodeToolStripMenuItem.Name = "decodeToolStripMenuItem";
            resources.ApplyResources(this.decodeToolStripMenuItem, "decodeToolStripMenuItem");
            this.decodeToolStripMenuItem.Tag = "1";
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mainTableLayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            this.mainTableLayoutPanel.ResumeLayout(false);
            this.base64ModeContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel mainTableLayoutPanel;
        private System.Windows.Forms.Button fileConvertButton;
        private System.Windows.Forms.Button textConvertButton;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button base64ConvertButton;
        private System.Windows.Forms.ContextMenuStrip base64ModeContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem encodeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem decodeToolStripMenuItem;

    }
}