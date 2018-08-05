namespace DataTextTranscoder
{
    partial class Base64CoderForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Base64CoderForm));
            this.mainTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.sourceLabel = new System.Windows.Forms.Label();
            this.modeComboBox = new System.Windows.Forms.ComboBox();
            this.modeLabel = new System.Windows.Forms.Label();
            this.sourceComboBox = new System.Windows.Forms.ComboBox();
            this.helpLabel = new System.Windows.Forms.Label();
            this.executeButton = new System.Windows.Forms.Button();
            this.encodingLabel = new System.Windows.Forms.Label();
            this.encodingComboBox = new System.Windows.Forms.ComboBox();
            this.mainToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.fileProcessBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.mainProgressBar = new System.Windows.Forms.ProgressBar();
            this.mainTableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainTableLayoutPanel
            // 
            resources.ApplyResources(this.mainTableLayoutPanel, "mainTableLayoutPanel");
            this.mainTableLayoutPanel.Controls.Add(this.sourceLabel, 2, 0);
            this.mainTableLayoutPanel.Controls.Add(this.modeComboBox, 1, 0);
            this.mainTableLayoutPanel.Controls.Add(this.modeLabel, 0, 0);
            this.mainTableLayoutPanel.Controls.Add(this.sourceComboBox, 3, 0);
            this.mainTableLayoutPanel.Controls.Add(this.helpLabel, 0, 2);
            this.mainTableLayoutPanel.Controls.Add(this.executeButton, 3, 2);
            this.mainTableLayoutPanel.Controls.Add(this.encodingLabel, 0, 1);
            this.mainTableLayoutPanel.Controls.Add(this.encodingComboBox, 1, 1);
            this.mainTableLayoutPanel.Controls.Add(this.mainProgressBar, 0, 3);
            this.mainTableLayoutPanel.Name = "mainTableLayoutPanel";
            // 
            // sourceLabel
            // 
            resources.ApplyResources(this.sourceLabel, "sourceLabel");
            this.sourceLabel.Name = "sourceLabel";
            // 
            // modeComboBox
            // 
            resources.ApplyResources(this.modeComboBox, "modeComboBox");
            this.modeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.modeComboBox.FormattingEnabled = true;
            this.modeComboBox.Items.AddRange(new object[] {
            resources.GetString("modeComboBox.Items"),
            resources.GetString("modeComboBox.Items1")});
            this.modeComboBox.Name = "modeComboBox";
            this.modeComboBox.SelectedIndexChanged += new System.EventHandler(this.base64ComboBox_SelectedIndexChanged);
            // 
            // modeLabel
            // 
            resources.ApplyResources(this.modeLabel, "modeLabel");
            this.modeLabel.Name = "modeLabel";
            // 
            // sourceComboBox
            // 
            resources.ApplyResources(this.sourceComboBox, "sourceComboBox");
            this.sourceComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sourceComboBox.FormattingEnabled = true;
            this.sourceComboBox.Items.AddRange(new object[] {
            resources.GetString("sourceComboBox.Items"),
            resources.GetString("sourceComboBox.Items1")});
            this.sourceComboBox.Name = "sourceComboBox";
            this.sourceComboBox.SelectedIndexChanged += new System.EventHandler(this.base64ComboBox_SelectedIndexChanged);
            // 
            // helpLabel
            // 
            resources.ApplyResources(this.helpLabel, "helpLabel");
            this.mainTableLayoutPanel.SetColumnSpan(this.helpLabel, 3);
            this.helpLabel.Name = "helpLabel";
            // 
            // executeButton
            // 
            resources.ApplyResources(this.executeButton, "executeButton");
            this.executeButton.Name = "executeButton";
            this.executeButton.UseVisualStyleBackColor = true;
            this.executeButton.Click += new System.EventHandler(this.executeButton_Click);
            // 
            // encodingLabel
            // 
            resources.ApplyResources(this.encodingLabel, "encodingLabel");
            this.encodingLabel.Name = "encodingLabel";
            // 
            // encodingComboBox
            // 
            this.mainTableLayoutPanel.SetColumnSpan(this.encodingComboBox, 3);
            resources.ApplyResources(this.encodingComboBox, "encodingComboBox");
            this.encodingComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.encodingComboBox.FormattingEnabled = true;
            this.encodingComboBox.Name = "encodingComboBox";
            this.encodingComboBox.SelectedIndexChanged += new System.EventHandler(this.encodingComboBox_SelectedIndexChanged);
            // 
            // fileProcessBackgroundWorker
            // 
            this.fileProcessBackgroundWorker.WorkerReportsProgress = true;
            this.fileProcessBackgroundWorker.WorkerSupportsCancellation = true;
            this.fileProcessBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.fileProcessBackgroundWorker_DoWork);
            this.fileProcessBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.fileProcessBackgroundWorker_RunWorkerCompleted);
            this.fileProcessBackgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.fileProcessBackgroundWorker_ProgressChanged);
            // 
            // mainProgressBar
            // 
            this.mainTableLayoutPanel.SetColumnSpan(this.mainProgressBar, 4);
            resources.ApplyResources(this.mainProgressBar, "mainProgressBar");
            this.mainProgressBar.Name = "mainProgressBar";
            this.mainProgressBar.Step = 1;
            // 
            // Base64CoderForm
            // 
            this.AllowDrop = true;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mainTableLayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Base64CoderForm";
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.Base64CoderForm_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Base64CoderForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Base64CoderForm_DragEnter);
            this.mainTableLayoutPanel.ResumeLayout(false);
            this.mainTableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel mainTableLayoutPanel;
        private System.Windows.Forms.Label sourceLabel;
        private System.Windows.Forms.ComboBox modeComboBox;
        private System.Windows.Forms.Label modeLabel;
        private System.Windows.Forms.ComboBox sourceComboBox;
        private System.Windows.Forms.Label helpLabel;
        private System.Windows.Forms.Button executeButton;
        private System.Windows.Forms.Label encodingLabel;
        private System.Windows.Forms.ComboBox encodingComboBox;
        private System.Windows.Forms.ToolTip mainToolTip;
        private System.ComponentModel.BackgroundWorker fileProcessBackgroundWorker;
        private System.Windows.Forms.ProgressBar mainProgressBar;
    }
}