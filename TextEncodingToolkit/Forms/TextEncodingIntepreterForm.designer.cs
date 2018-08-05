namespace TextEncodingToolkit
{
    partial class TextTranscoderForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TextTranscoderForm));
            this.mainTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.binLabel = new System.Windows.Forms.Label();
            this.hexLabel = new System.Windows.Forms.Label();
            this.binTextBox = new System.Windows.Forms.TextBox();
            this.hexTextBox = new System.Windows.Forms.TextBox();
            this.encodingComboBox = new System.Windows.Forms.ComboBox();
            this.modeComboBox = new System.Windows.Forms.ComboBox();
            this.contentTextBox = new System.Windows.Forms.TextBox();
            this.spaceCheckBox = new System.Windows.Forms.CheckBox();
            this.contentLabel = new System.Windows.Forms.Label();
            this.mainToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.mainTableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainTableLayoutPanel
            // 
            resources.ApplyResources(this.mainTableLayoutPanel, "mainTableLayoutPanel");
            this.mainTableLayoutPanel.Controls.Add(this.binLabel, 0, 3);
            this.mainTableLayoutPanel.Controls.Add(this.hexLabel, 0, 2);
            this.mainTableLayoutPanel.Controls.Add(this.binTextBox, 1, 3);
            this.mainTableLayoutPanel.Controls.Add(this.hexTextBox, 1, 2);
            this.mainTableLayoutPanel.Controls.Add(this.encodingComboBox, 1, 0);
            this.mainTableLayoutPanel.Controls.Add(this.modeComboBox, 0, 0);
            this.mainTableLayoutPanel.Controls.Add(this.contentTextBox, 1, 1);
            this.mainTableLayoutPanel.Controls.Add(this.spaceCheckBox, 2, 0);
            this.mainTableLayoutPanel.Controls.Add(this.contentLabel, 0, 1);
            this.mainTableLayoutPanel.Name = "mainTableLayoutPanel";
            // 
            // binLabel
            // 
            resources.ApplyResources(this.binLabel, "binLabel");
            this.binLabel.Name = "binLabel";
            // 
            // hexLabel
            // 
            resources.ApplyResources(this.hexLabel, "hexLabel");
            this.hexLabel.Name = "hexLabel";
            // 
            // binTextBox
            // 
            this.mainTableLayoutPanel.SetColumnSpan(this.binTextBox, 2);
            resources.ApplyResources(this.binTextBox, "binTextBox");
            this.binTextBox.Name = "binTextBox";
            this.binTextBox.ReadOnly = true;
            // 
            // hexTextBox
            // 
            this.mainTableLayoutPanel.SetColumnSpan(this.hexTextBox, 2);
            resources.ApplyResources(this.hexTextBox, "hexTextBox");
            this.hexTextBox.Name = "hexTextBox";
            this.hexTextBox.ReadOnly = true;
            this.hexTextBox.TextChanged += new System.EventHandler(this.inputTextBox_TextChanged);
            // 
            // encodingComboBox
            // 
            resources.ApplyResources(this.encodingComboBox, "encodingComboBox");
            this.encodingComboBox.DropDownHeight = 212;
            this.encodingComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.encodingComboBox.DropDownWidth = 350;
            this.encodingComboBox.FormattingEnabled = true;
            this.encodingComboBox.Name = "encodingComboBox";
            this.encodingComboBox.SelectedIndexChanged += new System.EventHandler(this.encodingComboBox_SelectedIndexChanged);
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
            this.modeComboBox.SelectedIndexChanged += new System.EventHandler(this.modeComboBox_SelectedIndexChanged);
            // 
            // contentTextBox
            // 
            this.mainTableLayoutPanel.SetColumnSpan(this.contentTextBox, 2);
            resources.ApplyResources(this.contentTextBox, "contentTextBox");
            this.contentTextBox.Name = "contentTextBox";
            this.contentTextBox.TextChanged += new System.EventHandler(this.inputTextBox_TextChanged);
            // 
            // spaceCheckBox
            // 
            resources.ApplyResources(this.spaceCheckBox, "spaceCheckBox");
            this.spaceCheckBox.Checked = true;
            this.spaceCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.spaceCheckBox.Name = "spaceCheckBox";
            this.spaceCheckBox.UseVisualStyleBackColor = true;
            this.spaceCheckBox.CheckedChanged += new System.EventHandler(this.inputTextBox_TextChanged);
            // 
            // contentLabel
            // 
            resources.ApplyResources(this.contentLabel, "contentLabel");
            this.contentLabel.Name = "contentLabel";
            // 
            // TextTranscoderForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mainTableLayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TextTranscoderForm";
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.TextTranscoderForm_Load);
            this.mainTableLayoutPanel.ResumeLayout(false);
            this.mainTableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel mainTableLayoutPanel;
        private System.Windows.Forms.ComboBox encodingComboBox;
        private System.Windows.Forms.ComboBox modeComboBox;
        private System.Windows.Forms.TextBox binTextBox;
        private System.Windows.Forms.TextBox hexTextBox;
        private System.Windows.Forms.TextBox contentTextBox;
        private System.Windows.Forms.CheckBox spaceCheckBox;
        private System.Windows.Forms.ToolTip mainToolTip;
        private System.Windows.Forms.Label contentLabel;
        private System.Windows.Forms.Label binLabel;
        private System.Windows.Forms.Label hexLabel;
    }
}