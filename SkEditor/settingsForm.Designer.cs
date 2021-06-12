namespace SkEditor
{
    partial class settingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(settingsForm));
            this.languageGroupBox = new System.Windows.Forms.GroupBox();
            this.panelCheckBox = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.languageComboBox = new System.Windows.Forms.ComboBox();
            this.themeGroupBox = new System.Windows.Forms.GroupBox();
            this.themeComboBox = new System.Windows.Forms.ComboBox();
            this.languageGroupBox.SuspendLayout();
            this.themeGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // languageGroupBox
            // 
            this.languageGroupBox.Controls.Add(this.languageComboBox);
            this.languageGroupBox.Location = new System.Drawing.Point(46, 28);
            this.languageGroupBox.Name = "languageGroupBox";
            this.languageGroupBox.Size = new System.Drawing.Size(133, 77);
            this.languageGroupBox.TabIndex = 0;
            this.languageGroupBox.TabStop = false;
            this.languageGroupBox.Text = "Język";
            // 
            // panelCheckBox
            // 
            this.panelCheckBox.AutoSize = true;
            this.panelCheckBox.Location = new System.Drawing.Point(234, 143);
            this.panelCheckBox.Name = "panelCheckBox";
            this.panelCheckBox.Size = new System.Drawing.Size(53, 17);
            this.panelCheckBox.TabIndex = 2;
            this.panelCheckBox.Text = "Panel";
            this.panelCheckBox.UseVisualStyleBackColor = true;
            this.panelCheckBox.CheckedChanged += new System.EventHandler(this.panelCheckBox_CheckedChanged);
            this.panelCheckBox.MouseHover += new System.EventHandler(this.checkBox1_MouseHover);
            // 
            // languageComboBox
            // 
            this.languageComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.languageComboBox.FormattingEnabled = true;
            this.languageComboBox.Items.AddRange(new object[] {
            "English",
            "Polski"});
            this.languageComboBox.Location = new System.Drawing.Point(6, 32);
            this.languageComboBox.Name = "languageComboBox";
            this.languageComboBox.Size = new System.Drawing.Size(121, 21);
            this.languageComboBox.TabIndex = 0;
            this.languageComboBox.SelectedIndexChanged += new System.EventHandler(this.languageComboBox_SelectedIndexChanged);
            // 
            // themeGroupBox
            // 
            this.themeGroupBox.Controls.Add(this.themeComboBox);
            this.themeGroupBox.Location = new System.Drawing.Point(342, 28);
            this.themeGroupBox.Name = "themeGroupBox";
            this.themeGroupBox.Size = new System.Drawing.Size(133, 77);
            this.themeGroupBox.TabIndex = 1;
            this.themeGroupBox.TabStop = false;
            this.themeGroupBox.Text = "Motyw";
            // 
            // themeComboBox
            // 
            this.themeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.themeComboBox.FormattingEnabled = true;
            this.themeComboBox.Items.AddRange(new object[] {
            "Jasny",
            "Ciemny"});
            this.themeComboBox.Location = new System.Drawing.Point(6, 32);
            this.themeComboBox.Name = "themeComboBox";
            this.themeComboBox.Size = new System.Drawing.Size(121, 21);
            this.themeComboBox.TabIndex = 0;
            this.themeComboBox.SelectedIndexChanged += new System.EventHandler(this.themeComboBox_SelectedIndexChanged);
            // 
            // settingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 255);
            this.Controls.Add(this.themeGroupBox);
            this.Controls.Add(this.panelCheckBox);
            this.Controls.Add(this.languageGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "settingsForm";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.settingsForm_Load);
            this.languageGroupBox.ResumeLayout(false);
            this.themeGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox languageGroupBox;
        private System.Windows.Forms.CheckBox panelCheckBox;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ComboBox languageComboBox;
        private System.Windows.Forms.GroupBox themeGroupBox;
        private System.Windows.Forms.ComboBox themeComboBox;
    }
}