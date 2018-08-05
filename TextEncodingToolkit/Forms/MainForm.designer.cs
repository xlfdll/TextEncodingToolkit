namespace TextEncodingToolkit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mainTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.intepreterButton = new System.Windows.Forms.Button();
            this.converterButton = new System.Windows.Forms.Button();
            this.mainTableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainTableLayoutPanel
            // 
            resources.ApplyResources(this.mainTableLayoutPanel, "mainTableLayoutPanel");
            this.mainTableLayoutPanel.Controls.Add(this.converterButton, 0, 0);
            this.mainTableLayoutPanel.Controls.Add(this.intepreterButton, 0, 1);
            this.mainTableLayoutPanel.Name = "mainTableLayoutPanel";
            // 
            // intepreterButton
            // 
            this.intepreterButton.AllowDrop = true;
            resources.ApplyResources(this.intepreterButton, "intepreterButton");
            this.intepreterButton.Image = global::TextEncodingToolkit.Properties.Resources.Handwriting;
            this.intepreterButton.Name = "intepreterButton";
            this.intepreterButton.UseVisualStyleBackColor = true;
            this.intepreterButton.Click += new System.EventHandler(this.textConvertButton_Click);
            // 
            // converterButton
            // 
            this.converterButton.AllowDrop = true;
            resources.ApplyResources(this.converterButton, "converterButton");
            this.converterButton.Image = global::TextEncodingToolkit.Properties.Resources.Gesture;
            this.converterButton.Name = "converterButton";
            this.converterButton.UseVisualStyleBackColor = true;
            this.converterButton.Click += new System.EventHandler(this.fileConvertButton_Click);
            this.converterButton.DragDrop += new System.Windows.Forms.DragEventHandler(this.mainFormButton_DragDrop);
            this.converterButton.DragEnter += new System.Windows.Forms.DragEventHandler(this.mainFormButton_DragEnter);
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel mainTableLayoutPanel;
        private System.Windows.Forms.Button converterButton;
        private System.Windows.Forms.Button intepreterButton;

    }
}