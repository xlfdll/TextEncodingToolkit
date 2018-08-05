namespace TextEncodingToolkit
{
    partial class TextEncodingConverterForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TextEncodingConverterForm));
            this.mainTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.destinationHexRichTextBox = new System.Windows.Forms.RichTextBox();
            this.textContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textToolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deselectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sourceHexRichTextBox = new System.Windows.Forms.RichTextBox();
            this.destinationEncodingComboBox = new System.Windows.Forms.ComboBox();
            this.sourceEncodingLabel = new System.Windows.Forms.Label();
            this.sourceEncodingComboBox = new System.Windows.Forms.ComboBox();
            this.encodingTargetLabel = new System.Windows.Forms.Label();
            this.destinationEncodingLabel = new System.Windows.Forms.Label();
            this.textTargetLabel = new System.Windows.Forms.Label();
            this.sourceRichTextBox = new System.Windows.Forms.RichTextBox();
            this.destinationRichTextBox = new System.Windows.Forms.RichTextBox();
            this.loadButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.hexTargetLabel = new System.Windows.Forms.Label();
            this.mainToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.mainTableLayoutPanel.SuspendLayout();
            this.textContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainTableLayoutPanel
            // 
            resources.ApplyResources(this.mainTableLayoutPanel, "mainTableLayoutPanel");
            this.mainTableLayoutPanel.Controls.Add(this.destinationHexRichTextBox, 4, 2);
            this.mainTableLayoutPanel.Controls.Add(this.sourceHexRichTextBox, 0, 2);
            this.mainTableLayoutPanel.Controls.Add(this.destinationEncodingComboBox, 5, 0);
            this.mainTableLayoutPanel.Controls.Add(this.sourceEncodingLabel, 0, 0);
            this.mainTableLayoutPanel.Controls.Add(this.sourceEncodingComboBox, 1, 0);
            this.mainTableLayoutPanel.Controls.Add(this.encodingTargetLabel, 3, 0);
            this.mainTableLayoutPanel.Controls.Add(this.destinationEncodingLabel, 4, 0);
            this.mainTableLayoutPanel.Controls.Add(this.textTargetLabel, 3, 1);
            this.mainTableLayoutPanel.Controls.Add(this.sourceRichTextBox, 0, 1);
            this.mainTableLayoutPanel.Controls.Add(this.destinationRichTextBox, 4, 1);
            this.mainTableLayoutPanel.Controls.Add(this.loadButton, 2, 0);
            this.mainTableLayoutPanel.Controls.Add(this.saveButton, 6, 0);
            this.mainTableLayoutPanel.Controls.Add(this.hexTargetLabel, 3, 2);
            this.mainTableLayoutPanel.Name = "mainTableLayoutPanel";
            // 
            // destinationHexRichTextBox
            // 
            this.mainTableLayoutPanel.SetColumnSpan(this.destinationHexRichTextBox, 3);
            this.destinationHexRichTextBox.ContextMenuStrip = this.textContextMenuStrip;
            this.destinationHexRichTextBox.DetectUrls = false;
            resources.ApplyResources(this.destinationHexRichTextBox, "destinationHexRichTextBox");
            this.destinationHexRichTextBox.HideSelection = false;
            this.destinationHexRichTextBox.Name = "destinationHexRichTextBox";
            this.destinationHexRichTextBox.ReadOnly = true;
            this.mainTableLayoutPanel.SetRowSpan(this.destinationHexRichTextBox, 2);
            this.mainToolTip.SetToolTip(this.destinationHexRichTextBox, resources.GetString("destinationHexRichTextBox.ToolTip"));
            // 
            // textContextMenuStrip
            // 
            this.textContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.textToolStripSeparator,
            this.selectAllToolStripMenuItem,
            this.deselectAllToolStripMenuItem});
            this.textContextMenuStrip.Name = "textContextMenuStrip";
            resources.ApplyResources(this.textContextMenuStrip, "textContextMenuStrip");
            this.textContextMenuStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.textContextMenuStrip_ItemClicked);
            this.textContextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.textContextMenuStrip_Opening);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Image = global::TextEncodingToolkit.Properties.Resources.Copy;
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            resources.ApplyResources(this.copyToolStripMenuItem, "copyToolStripMenuItem");
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Image = global::TextEncodingToolkit.Properties.Resources.Paste;
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            resources.ApplyResources(this.pasteToolStripMenuItem, "pasteToolStripMenuItem");
            // 
            // textToolStripSeparator
            // 
            this.textToolStripSeparator.Name = "textToolStripSeparator";
            resources.ApplyResources(this.textToolStripSeparator, "textToolStripSeparator");
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Image = global::TextEncodingToolkit.Properties.Resources.Select;
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            resources.ApplyResources(this.selectAllToolStripMenuItem, "selectAllToolStripMenuItem");
            // 
            // deselectAllToolStripMenuItem
            // 
            this.deselectAllToolStripMenuItem.Name = "deselectAllToolStripMenuItem";
            resources.ApplyResources(this.deselectAllToolStripMenuItem, "deselectAllToolStripMenuItem");
            // 
            // sourceHexRichTextBox
            // 
            this.mainTableLayoutPanel.SetColumnSpan(this.sourceHexRichTextBox, 3);
            this.sourceHexRichTextBox.ContextMenuStrip = this.textContextMenuStrip;
            this.sourceHexRichTextBox.DetectUrls = false;
            resources.ApplyResources(this.sourceHexRichTextBox, "sourceHexRichTextBox");
            this.sourceHexRichTextBox.HideSelection = false;
            this.sourceHexRichTextBox.Name = "sourceHexRichTextBox";
            this.sourceHexRichTextBox.ReadOnly = true;
            this.mainTableLayoutPanel.SetRowSpan(this.sourceHexRichTextBox, 2);
            this.mainToolTip.SetToolTip(this.sourceHexRichTextBox, resources.GetString("sourceHexRichTextBox.ToolTip"));
            // 
            // destinationEncodingComboBox
            // 
            resources.ApplyResources(this.destinationEncodingComboBox, "destinationEncodingComboBox");
            this.destinationEncodingComboBox.DropDownHeight = 212;
            this.destinationEncodingComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.destinationEncodingComboBox.DropDownWidth = 350;
            this.destinationEncodingComboBox.FormattingEnabled = true;
            this.destinationEncodingComboBox.Name = "destinationEncodingComboBox";
            this.destinationEncodingComboBox.SelectedIndexChanged += new System.EventHandler(this.encodingComboBox_SelectedIndexChanged);
            // 
            // sourceEncodingLabel
            // 
            resources.ApplyResources(this.sourceEncodingLabel, "sourceEncodingLabel");
            this.sourceEncodingLabel.Name = "sourceEncodingLabel";
            // 
            // sourceEncodingComboBox
            // 
            resources.ApplyResources(this.sourceEncodingComboBox, "sourceEncodingComboBox");
            this.sourceEncodingComboBox.DropDownHeight = 212;
            this.sourceEncodingComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sourceEncodingComboBox.DropDownWidth = 350;
            this.sourceEncodingComboBox.FormattingEnabled = true;
            this.sourceEncodingComboBox.Name = "sourceEncodingComboBox";
            this.sourceEncodingComboBox.SelectedIndexChanged += new System.EventHandler(this.encodingComboBox_SelectedIndexChanged);
            // 
            // encodingTargetLabel
            // 
            resources.ApplyResources(this.encodingTargetLabel, "encodingTargetLabel");
            this.encodingTargetLabel.Name = "encodingTargetLabel";
            // 
            // destinationEncodingLabel
            // 
            resources.ApplyResources(this.destinationEncodingLabel, "destinationEncodingLabel");
            this.destinationEncodingLabel.Name = "destinationEncodingLabel";
            // 
            // textTargetLabel
            // 
            resources.ApplyResources(this.textTargetLabel, "textTargetLabel");
            this.textTargetLabel.Name = "textTargetLabel";
            // 
            // sourceRichTextBox
            // 
            this.mainTableLayoutPanel.SetColumnSpan(this.sourceRichTextBox, 3);
            this.sourceRichTextBox.ContextMenuStrip = this.textContextMenuStrip;
            this.sourceRichTextBox.DetectUrls = false;
            resources.ApplyResources(this.sourceRichTextBox, "sourceRichTextBox");
            this.sourceRichTextBox.HideSelection = false;
            this.sourceRichTextBox.Name = "sourceRichTextBox";
            this.sourceRichTextBox.ReadOnly = true;
            // 
            // destinationRichTextBox
            // 
            this.mainTableLayoutPanel.SetColumnSpan(this.destinationRichTextBox, 3);
            this.destinationRichTextBox.ContextMenuStrip = this.textContextMenuStrip;
            this.destinationRichTextBox.DetectUrls = false;
            resources.ApplyResources(this.destinationRichTextBox, "destinationRichTextBox");
            this.destinationRichTextBox.HideSelection = false;
            this.destinationRichTextBox.Name = "destinationRichTextBox";
            this.destinationRichTextBox.ReadOnly = true;
            // 
            // loadButton
            // 
            resources.ApplyResources(this.loadButton, "loadButton");
            this.loadButton.Image = global::TextEncodingToolkit.Properties.Resources.Load;
            this.loadButton.Name = "loadButton";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // saveButton
            // 
            resources.ApplyResources(this.saveButton, "saveButton");
            this.saveButton.Image = global::TextEncodingToolkit.Properties.Resources.Save;
            this.saveButton.Name = "saveButton";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // hexTargetLabel
            // 
            resources.ApplyResources(this.hexTargetLabel, "hexTargetLabel");
            this.hexTargetLabel.Name = "hexTargetLabel";
            this.mainTableLayoutPanel.SetRowSpan(this.hexTargetLabel, 2);
            // 
            // TextEncodingConverterForm
            // 
            this.AllowDrop = true;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mainTableLayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TextEncodingConverterForm";
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.TextFileConverterForm_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.TextFileConverterForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.TextFileConverterForm_DragEnter);
            this.mainTableLayoutPanel.ResumeLayout(false);
            this.mainTableLayoutPanel.PerformLayout();
            this.textContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel mainTableLayoutPanel;
        private System.Windows.Forms.Label sourceEncodingLabel;
        private System.Windows.Forms.ComboBox sourceEncodingComboBox;
        private System.Windows.Forms.Label encodingTargetLabel;
        private System.Windows.Forms.Label destinationEncodingLabel;
        private System.Windows.Forms.ComboBox destinationEncodingComboBox;
        private System.Windows.Forms.Label textTargetLabel;
        private System.Windows.Forms.RichTextBox sourceRichTextBox;
        private System.Windows.Forms.RichTextBox destinationRichTextBox;
        private System.Windows.Forms.ToolTip mainToolTip;
        private System.Windows.Forms.ContextMenuStrip textContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator textToolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deselectAllToolStripMenuItem;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.RichTextBox destinationHexRichTextBox;
        private System.Windows.Forms.RichTextBox sourceHexRichTextBox;
        private System.Windows.Forms.Label hexTargetLabel;
    }
}