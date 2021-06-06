
namespace SkEditor
{
    partial class SkEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SkEditor));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NewButton = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenButton = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveButton = new System.Windows.Forms.ToolStripMenuItem();
            this.Line1 = new System.Windows.Forms.ToolStripSeparator();
            this.PrintButton = new System.Windows.Forms.ToolStripMenuItem();
            this.PastebinButton = new System.Windows.Forms.ToolStripMenuItem();
            this.Line2 = new System.Windows.Forms.ToolStripSeparator();
            this.CloseButton = new System.Windows.Forms.ToolStripMenuItem();
            this.CloseAllButton = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitButton = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CutButton = new System.Windows.Forms.ToolStripMenuItem();
            this.CopyButton = new System.Windows.Forms.ToolStripMenuItem();
            this.PasteButton = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripSeparator();
            this.UndoButton = new System.Windows.Forms.ToolStripMenuItem();
            this.RedoButton = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripSeparator();
            this.FindButton = new System.Windows.Forms.ToolStripMenuItem();
            this.FindAndReplaceButton = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabControl1 = new VisualStudioTabControl.VisualStudioTabControl();
            this.menuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewButton,
            this.OpenButton,
            this.SaveButton,
            this.Line1,
            this.PrintButton,
            this.PastebinButton,
            this.Line2,
            this.CloseButton,
            this.CloseAllButton,
            this.ExitButton});
            this.fileToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.fileToolStripMenuItem.ImageTransparentColor = System.Drawing.SystemColors.ControlDarkDark;
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // NewButton
            // 
            this.NewButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.NewButton.ForeColor = System.Drawing.SystemColors.Control;
            this.NewButton.Image = global::SkEditor.Properties.Resources.plus_3_161;
            this.NewButton.Name = "NewButton";
            this.NewButton.ShortcutKeyDisplayString = "";
            this.NewButton.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.NewButton.Size = new System.Drawing.Size(195, 22);
            this.NewButton.Text = "New";
            this.NewButton.Click += new System.EventHandler(this.NewButton_Click);
            // 
            // OpenButton
            // 
            this.OpenButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.OpenButton.ForeColor = System.Drawing.SystemColors.Control;
            this.OpenButton.Image = global::SkEditor.Properties.Resources.folder_8_161;
            this.OpenButton.Name = "OpenButton";
            this.OpenButton.ShortcutKeyDisplayString = "";
            this.OpenButton.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.OpenButton.Size = new System.Drawing.Size(195, 22);
            this.OpenButton.Text = "Open";
            this.OpenButton.Click += new System.EventHandler(this.OpenButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.SaveButton.ForeColor = System.Drawing.SystemColors.Control;
            this.SaveButton.Image = global::SkEditor.Properties.Resources.save_161;
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.ShortcutKeyDisplayString = "";
            this.SaveButton.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.SaveButton.Size = new System.Drawing.Size(195, 22);
            this.SaveButton.Text = "Save";
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // Line1
            // 
            this.Line1.Name = "Line1";
            this.Line1.Size = new System.Drawing.Size(192, 6);
            // 
            // PrintButton
            // 
            this.PrintButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.PrintButton.ForeColor = System.Drawing.SystemColors.Control;
            this.PrintButton.Image = global::SkEditor.Properties.Resources.printer_16;
            this.PrintButton.Name = "PrintButton";
            this.PrintButton.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.PrintButton.Size = new System.Drawing.Size(195, 22);
            this.PrintButton.Text = "Print";
            this.PrintButton.Click += new System.EventHandler(this.PrintButton_Click);
            // 
            // PastebinButton
            // 
            this.PastebinButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.PastebinButton.ForeColor = System.Drawing.SystemColors.Control;
            this.PastebinButton.Image = global::SkEditor.Properties.Resources.favicon;
            this.PastebinButton.Name = "PastebinButton";
            this.PastebinButton.ShortcutKeyDisplayString = "";
            this.PastebinButton.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.P)));
            this.PastebinButton.Size = new System.Drawing.Size(195, 22);
            this.PastebinButton.Text = "Pastebin";
            this.PastebinButton.Click += new System.EventHandler(this.PastebinButton_Click);
            // 
            // Line2
            // 
            this.Line2.Name = "Line2";
            this.Line2.Size = new System.Drawing.Size(192, 6);
            // 
            // CloseButton
            // 
            this.CloseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.CloseButton.ForeColor = System.Drawing.SystemColors.Control;
            this.CloseButton.Image = global::SkEditor.Properties.Resources.x_mark_2_161;
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.ShortcutKeyDisplayString = "";
            this.CloseButton.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.CloseButton.Size = new System.Drawing.Size(195, 22);
            this.CloseButton.Text = "Close";
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // CloseAllButton
            // 
            this.CloseAllButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.CloseAllButton.ForeColor = System.Drawing.SystemColors.Control;
            this.CloseAllButton.Image = global::SkEditor.Properties.Resources.x_mark_5_161;
            this.CloseAllButton.Name = "CloseAllButton";
            this.CloseAllButton.ShortcutKeyDisplayString = "";
            this.CloseAllButton.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.W)));
            this.CloseAllButton.Size = new System.Drawing.Size(195, 22);
            this.CloseAllButton.Text = "Close all";
            this.CloseAllButton.Click += new System.EventHandler(this.CloseAllButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.ExitButton.ForeColor = System.Drawing.SystemColors.Control;
            this.ExitButton.Image = global::SkEditor.Properties.Resources.exit_161;
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.ShortcutKeyDisplayString = "Alt+F4";
            this.ExitButton.Size = new System.Drawing.Size(195, 22);
            this.ExitButton.Text = "Exit";
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CutButton,
            this.CopyButton,
            this.PasteButton,
            this.toolStripMenuItem9,
            this.UndoButton,
            this.RedoButton,
            this.toolStripMenuItem8,
            this.FindButton,
            this.FindAndReplaceButton});
            this.editToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // CutButton
            // 
            this.CutButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.CutButton.ForeColor = System.Drawing.SystemColors.Control;
            this.CutButton.Image = global::SkEditor.Properties.Resources.scissors_7_161;
            this.CutButton.Name = "CutButton";
            this.CutButton.ShortcutKeyDisplayString = "";
            this.CutButton.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.CutButton.Size = new System.Drawing.Size(207, 22);
            this.CutButton.Text = "Cut";
            this.CutButton.Click += new System.EventHandler(this.CutButton_Click);
            // 
            // CopyButton
            // 
            this.CopyButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.CopyButton.ForeColor = System.Drawing.SystemColors.Control;
            this.CopyButton.Image = global::SkEditor.Properties.Resources.copy_161;
            this.CopyButton.Name = "CopyButton";
            this.CopyButton.ShortcutKeyDisplayString = "";
            this.CopyButton.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.CopyButton.Size = new System.Drawing.Size(207, 22);
            this.CopyButton.Text = "Copy";
            this.CopyButton.Click += new System.EventHandler(this.CopyButton_Click);
            // 
            // PasteButton
            // 
            this.PasteButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.PasteButton.ForeColor = System.Drawing.SystemColors.Control;
            this.PasteButton.Image = global::SkEditor.Properties.Resources.clipboard_4_161;
            this.PasteButton.Name = "PasteButton";
            this.PasteButton.ShortcutKeyDisplayString = "";
            this.PasteButton.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.PasteButton.Size = new System.Drawing.Size(207, 22);
            this.PasteButton.Text = "Paste";
            this.PasteButton.Click += new System.EventHandler(this.PasteButton_Click);
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            this.toolStripMenuItem9.Size = new System.Drawing.Size(204, 6);
            // 
            // UndoButton
            // 
            this.UndoButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.UndoButton.ForeColor = System.Drawing.SystemColors.Control;
            this.UndoButton.Image = global::SkEditor.Properties.Resources.undo_161;
            this.UndoButton.Name = "UndoButton";
            this.UndoButton.ShortcutKeyDisplayString = "";
            this.UndoButton.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.UndoButton.Size = new System.Drawing.Size(207, 22);
            this.UndoButton.Text = "Undo";
            this.UndoButton.Click += new System.EventHandler(this.UndoButton_Click);
            // 
            // RedoButton
            // 
            this.RedoButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.RedoButton.ForeColor = System.Drawing.SystemColors.Control;
            this.RedoButton.Image = global::SkEditor.Properties.Resources.redo_161;
            this.RedoButton.Name = "RedoButton";
            this.RedoButton.ShortcutKeyDisplayString = "";
            this.RedoButton.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.RedoButton.Size = new System.Drawing.Size(207, 22);
            this.RedoButton.Text = "Redo";
            this.RedoButton.Click += new System.EventHandler(this.RedoButton_Click);
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(204, 6);
            // 
            // FindButton
            // 
            this.FindButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.FindButton.ForeColor = System.Drawing.SystemColors.Control;
            this.FindButton.Image = global::SkEditor.Properties.Resources.search_15_161;
            this.FindButton.Name = "FindButton";
            this.FindButton.ShortcutKeyDisplayString = "";
            this.FindButton.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.FindButton.Size = new System.Drawing.Size(207, 22);
            this.FindButton.Text = "Find";
            this.FindButton.Click += new System.EventHandler(this.FindButton_Click);
            // 
            // FindAndReplaceButton
            // 
            this.FindAndReplaceButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.FindAndReplaceButton.ForeColor = System.Drawing.SystemColors.Control;
            this.FindAndReplaceButton.Image = global::SkEditor.Properties.Resources.repeat_161;
            this.FindAndReplaceButton.Name = "FindAndReplaceButton";
            this.FindAndReplaceButton.ShortcutKeyDisplayString = "";
            this.FindAndReplaceButton.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
            this.FindAndReplaceButton.Size = new System.Drawing.Size(207, 22);
            this.FindAndReplaceButton.Text = "Find and Replace";
            this.FindAndReplaceButton.Click += new System.EventHandler(this.FindAndReplaceButton_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(49, 426);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tabControl1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(49, 24);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(751, 426);
            this.panel2.TabIndex = 2;
            // 
            // tabControl1
            // 
            this.tabControl1.ActiveColor = System.Drawing.Color.LimeGreen;
            this.tabControl1.AllowDrop = true;
            this.tabControl1.BackTabColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.tabControl1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.tabControl1.ClosingButtonColor = System.Drawing.Color.DimGray;
            this.tabControl1.ClosingMessage = null;
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tabControl1.HeaderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.tabControl1.HorizontalLineColor = System.Drawing.Color.LimeGreen;
            this.tabControl1.ItemSize = new System.Drawing.Size(240, 16);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.SelectedTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.tabControl1.ShowClosingButton = false;
            this.tabControl1.ShowClosingMessage = false;
            this.tabControl1.Size = new System.Drawing.Size(751, 426);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            // 
            // SkEditor2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(816, 489);
            this.Name = "SkEditor2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SkEditor";
            this.Load += new System.EventHandler(this.SkEditor2_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStripMenuItem SaveButton;
        private VisualStudioTabControl.VisualStudioTabControl tabControl1;
        private System.Windows.Forms.ToolStripMenuItem NewButton;
        private System.Windows.Forms.ToolStripMenuItem OpenButton;
        private System.Windows.Forms.ToolStripMenuItem PastebinButton;
        private System.Windows.Forms.ToolStripMenuItem CloseButton;
        private System.Windows.Forms.ToolStripMenuItem CloseAllButton;
        private System.Windows.Forms.ToolStripMenuItem ExitButton;
        private System.Windows.Forms.ToolStripSeparator Line1;
        private System.Windows.Forms.ToolStripSeparator Line2;
        private System.Windows.Forms.ToolStripMenuItem PrintButton;
        private System.Windows.Forms.ToolStripMenuItem CutButton;
        private System.Windows.Forms.ToolStripMenuItem CopyButton;
        private System.Windows.Forms.ToolStripMenuItem PasteButton;
        private System.Windows.Forms.ToolStripMenuItem UndoButton;
        private System.Windows.Forms.ToolStripMenuItem RedoButton;
        private System.Windows.Forms.ToolStripMenuItem FindButton;
        private System.Windows.Forms.ToolStripMenuItem FindAndReplaceButton;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem8;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem9;
    }
}