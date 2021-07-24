using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Microsoft.VisualBasic;
using FastColoredTextBoxNS;
using System.Net;
using System.Diagnostics;

namespace SkEditor
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();

            WebClient webclient = new WebClient();
            if (!webclient.DownloadString("https://pastebin.com/raw/nYdZUkvT").Contains("1.3.3"))
            {
                if (Properties.Settings.Default.Lang == "Polish")
                {
                    if (MessageBox.Show("Jest dostępna aktualizacja! Czy chcesz ją pobrać?", "SkEditor", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start(webclient.DownloadString("https://pastebin.com/raw/jexXDzjM"));
                    }
                }
                else
                {
                    if (MessageBox.Show("An update is available! Do you want to download it?", "SkEditor", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start(webclient.DownloadString("https://pastebin.com/raw/jexXDzjM"));
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TabPage tp = new TabPage("New File");
            FastColoredTextBoxNS.FastColoredTextBox rtb = new FastColoredTextBoxNS.FastColoredTextBox();
            rtb.Dock = DockStyle.Fill;
            rtb.LineNumberColor = Color.Black;
            rtb.BorderStyle = BorderStyle.None;
            tp.Controls.Add(rtb);
            tabControl1.TabPages.Add(tp);
            if (Properties.Settings.Default.Lang == "Polish")
            {
                fileToolStripMenuItem.Text = "Plik";
                editToolStripMenuItem.Text = "Edycja";
                settingsToolStripMenuItem.Text = "Ustawienia";
                skriptDocumentationToolStripMenuItem.Text = "Dokumentacja Skripta";
                newToolStripMenuItem.Text = "Nowy";
                saveToolStripMenuItem.Text = "Zapisz";
                openToolStripMenuItem.Text = "Otwórz";
                closeCurrentTabToolStripMenuItem.Text = "Zamknij";
                closeAllToolStripMenuItem.Text = "Zamknij wszystko";
                exitToolStripMenuItem.Text = "Zakończ";
                cutToolStripMenuItem.Text = "Wytnij";
                copyToolStripMenuItem.Text = "Kopiuj";
                pasteToolStripMenuItem.Text = "Wklej";
                undoToolStripMenuItem.Text = "Cofnij";
                redoToolStripMenuItem.Text = "Ponów";
                modeToolStripMenuItem.Text = "Tryb";
                lightToolStripMenuItem.Text = "Jasny";
                darkToolStripMenuItem.Text = "Ciemny";
                languageToolStripMenuItem.Text = "Język";
                toolStripButton1.Text = "Nowy";
                toolStripButton2.Text = "Otwórz";
                toolStripButton3.Text = "Zapisz";
                toolStripButton4.Text = "Zamknij";
                toolStripButton10.Text = "Zamknij wszystko";
                toolStripButton5.Text = "Wytnij";
                toolStripButton6.Text = "Kopiuj";
                toolStripButton7.Text = "Wklej";
                toolStripButton8.Text = "Cofnij";
                toolStripButton9.Text = "Ponów";
                joinDiscordToolStripMenuItem.Text = "Dołącz na naszego discorda";
                ourWebSiteToolStripMenuItem.Text = "Nasza strona internetowa";
            }
            if (Properties.Settings.Default.Mode == "Dark")
            {
                this.BackColor = Color.DimGray;
                GetFastColoredTextBox().BackColor = Color.DarkGray;
                GetFastColoredTextBox().IndentBackColor = Color.Gray;
                menuStrip1.BackColor = Color.Gray;
                //tabPage1.BackColor = Color.Gray;
                fileToolStripMenuItem.BackColor = Color.Gray;
                editToolStripMenuItem.BackColor = Color.Gray;
                settingsToolStripMenuItem.BackColor = Color.Gray;

            }
        }

        //private void GetFastColoredTextBox_TextChanged(object sender, EventArgs e) 
        //protected override void OnTextChanged (EventArgs e)
        //{
        //    tabControl1.SelectedTab.Text = "* " + tabControl1.SelectedTab.Text; 
        //}

        private void saveFileDialog2_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private FastColoredTextBoxNS.FastColoredTextBox GetFastColoredTextBox()
        {
            FastColoredTextBoxNS.FastColoredTextBox rtb = null;
            TabPage tp = tabControl1.SelectedTab;
            if (tp != null)
            {
                rtb = tp.Controls[0] as FastColoredTextBoxNS.FastColoredTextBox;
            }
            return rtb;
        }

        private void lightToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Properties.Settings.Default.Mode = "Light";
            Properties.Settings.Default.Save();
            GetFastColoredTextBox().BackColor = Color.White;
            GetFastColoredTextBox().IndentBackColor = Color.WhiteSmoke;
            GetFastColoredTextBox().ForeColor = Color.Black;
        }

        private void darkToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Properties.Settings.Default.Mode = "Dark";
            Properties.Settings.Default.Save();
            GetFastColoredTextBox().BackColor = Color.FromArgb(45, 45, 45);
            GetFastColoredTextBox().IndentBackColor = Color.FromArgb(72, 72, 72);
            GetFastColoredTextBox().ForeColor = Color.White;
        }

        private void fastColoredTextBox1_Load(object sender, EventArgs e)
        {

        }

        private void skriptDocumentationToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://skripthub.net/docs/");
        }

        private void exitToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void newToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            //fastColoredTextBox1.Text = "";
            //this.Text = "New File - SkEditor";
            TabPage tp = new TabPage("New File");
            FastColoredTextBoxNS.FastColoredTextBox rtb = new FastColoredTextBoxNS.FastColoredTextBox();
            rtb.Dock = DockStyle.Fill;
            rtb.LineNumberColor = Color.Black;
            rtb.BorderStyle = BorderStyle.None;
            //rtb.MinimumSize = MinimumSize.Height
            tp.Controls.Add(rtb);
            tabControl1.TabPages.Add(tp);
            
        }

        private void openToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            // Create an OpenFileDialog to request a file to open.
            OpenFileDialog openFile1 = new OpenFileDialog();

            // Initialize the OpenFileDialog to look for RTF files.
            openFile1.DefaultExt = "*.sk";
            openFile1.Filter = "SKRIPT File|*.sk";

            // Determine whether the user selected a file from the OpenFileDialog.
            if (openFile1.ShowDialog() == System.Windows.Forms.DialogResult.OK &&
               openFile1.FileName.Length > 0)
            {
                // Load the contents of the file into the RichTextBox.
                TabPage tp = new TabPage("New File");
                FastColoredTextBoxNS.FastColoredTextBox rtb = new FastColoredTextBoxNS.FastColoredTextBox();
                rtb.Dock = DockStyle.Fill;
                rtb.LineNumberColor = Color.Black;
                rtb.BorderStyle = BorderStyle.None;
                //rtb.MinimumSize = MinimumSize.Height
                tp.Controls.Add(rtb);
                tabControl1.TabPages.Add(tp);
                GetFastColoredTextBox().OpenFile(openFile1.FileName);
                //this.Text = openFile1.FileName + " - SkEditor";
                tabControl1.SelectedTab.Text = openFile1.SafeFileName;
            }
        }

        private void undoToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            GetFastColoredTextBox().Undo();
        }

        private void redoToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            GetFastColoredTextBox().Redo();
        }

        private void modeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Form2 settingsForm = new Form2();
            //settingsForm.Show();
        }

        private void closeCurrentTabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab.Text == "New File")
            {
                if (Properties.Settings.Default.Lang == "Polish")
                {
                    if (MessageBox.Show("Jesteś pewien, że chcesz wyłączyć niezapisany plik?", "SkEditor", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        tabControl1.TabPages.Remove(tabControl1.SelectedTab);
                    }
                }
                else
                {
                    if (MessageBox.Show("Are you sure to close unsaved file?", "SkEditor", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        tabControl1.TabPages.Remove(tabControl1.SelectedTab);
                    }
                }
            }
        }

        private void polskiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Lang = "Polish";
            Properties.Settings.Default.Save();
            fileToolStripMenuItem.Text = "Plik";
            editToolStripMenuItem.Text = "Edycja";
            settingsToolStripMenuItem.Text = "Ustawienia";
            skriptDocumentationToolStripMenuItem.Text = "Dokumentacja Skripta";
            newToolStripMenuItem.Text = "Nowy";
            saveToolStripMenuItem.Text = "Zapisz";
            openToolStripMenuItem.Text = "Otwórz";
            closeCurrentTabToolStripMenuItem.Text = "Zamknij";
            closeAllToolStripMenuItem.Text = "Zamknij wszystko";
            exitToolStripMenuItem.Text = "Zakończ";
            cutToolStripMenuItem.Text = "Wytnij";
            copyToolStripMenuItem.Text = "Kopiuj";
            pasteToolStripMenuItem.Text = "Wklej";
            undoToolStripMenuItem.Text = "Cofnij";
            redoToolStripMenuItem.Text = "Ponów";
            modeToolStripMenuItem.Text = "Tryb";
            lightToolStripMenuItem.Text = "Jasny";
            darkToolStripMenuItem.Text = "Ciemny";
            languageToolStripMenuItem.Text = "Język";
            toolStripButton1.Text = "Nowy";
            toolStripButton2.Text = "Otwórz";
            toolStripButton3.Text = "Zapisz";
            toolStripButton4.Text = "Zamknij";
            toolStripButton10.Text = "Zamknij wszystko";
            toolStripButton5.Text = "Wytnij";
            toolStripButton6.Text = "Kopiuj";
            toolStripButton7.Text = "Wklej";
            toolStripButton8.Text = "Cofnij";
            toolStripButton9.Text = "Ponów";
            joinDiscordToolStripMenuItem.Text = "Dołącz na naszego discorda";
            ourWebSiteToolStripMenuItem.Text = "Nasza strona internetowa";
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Lang = "English";
            Properties.Settings.Default.Save();
            fileToolStripMenuItem.Text = "File";
            editToolStripMenuItem.Text = "Edit";
            settingsToolStripMenuItem.Text = "Settings";
            skriptDocumentationToolStripMenuItem.Text = "Skript Documentation";
            newToolStripMenuItem.Text = "New";
            saveToolStripMenuItem.Text = "Save";
            openToolStripMenuItem.Text = "Open";
            closeCurrentTabToolStripMenuItem.Text = "Close";
            closeAllToolStripMenuItem.Text = "Close all";
            exitToolStripMenuItem.Text = "Exit";
            cutToolStripMenuItem.Text = "Cut";
            copyToolStripMenuItem.Text = "Copy";
            pasteToolStripMenuItem.Text = "Paste";
            undoToolStripMenuItem.Text = "Undo";
            redoToolStripMenuItem.Text = "Redo";
            modeToolStripMenuItem.Text = "Mode";
            lightToolStripMenuItem.Text = "Light";
            darkToolStripMenuItem.Text = "Dark";
            languageToolStripMenuItem.Text = "Language";
            toolStripButton1.Text = "New";
            toolStripButton2.Text = "Open";
            toolStripButton3.Text = "Save";
            toolStripButton4.Text = "Close";
            toolStripButton10.Text = "Close all";
            toolStripButton5.Text = "Cut";
            toolStripButton6.Text = "Copy";
            toolStripButton7.Text = "Paste";
            toolStripButton8.Text = "Undo";
            toolStripButton9.Text = "Redo";
            joinDiscordToolStripMenuItem.Text = "Join Discord";
            ourWebSiteToolStripMenuItem.Text = "Our WebSite";
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            TabPage tp = new TabPage("New File");
            FastColoredTextBoxNS.FastColoredTextBox rtb = new FastColoredTextBoxNS.FastColoredTextBox();
            rtb.Dock = DockStyle.Fill;
            rtb.LineNumberColor = Color.Black;
            rtb.BorderStyle = BorderStyle.None;
            //rtb.MinimumSize = MinimumSize.Height
            tp.Controls.Add(rtb);
            tabControl1.TabPages.Add(tp);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile1 = new OpenFileDialog();

            // Initialize the OpenFileDialog to look for RTF files.
            openFile1.DefaultExt = "*.sk";
            openFile1.Filter = "SKRIPT File|*.sk";

            // Determine whether the user selected a file from the OpenFileDialog.
            if (openFile1.ShowDialog() == System.Windows.Forms.DialogResult.OK &&
               openFile1.FileName.Length > 0)
            {
                // Load the contents of the file into the RichTextBox.
                TabPage tp = new TabPage("New File");
                FastColoredTextBoxNS.FastColoredTextBox rtb = new FastColoredTextBoxNS.FastColoredTextBox();
                rtb.Dock = DockStyle.Fill;
                rtb.LineNumberColor = Color.Black;
                rtb.BorderStyle = BorderStyle.None;
                //rtb.MinimumSize = MinimumSize.Height
                tp.Controls.Add(rtb);
                tabControl1.TabPages.Add(tp);
                GetFastColoredTextBox().OpenFile(openFile1.FileName);
                //this.Text = openFile1.FileName + " - SkEditor";
                tabControl1.SelectedTab.Text = openFile1.SafeFileName;
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            /// Create a SaveFileDialog to request a path and file name to save to.
            SaveFileDialog saveFile1 = new SaveFileDialog();

            // Initialize the SaveFileDialog to specify the RTF extension for the file.
            saveFile1.DefaultExt = "*.sk";
            saveFile1.Filter = "SKRIPT File|*.sk";

            // Determine if the user selected a file name from the saveFileDialog.
            if (saveFile1.ShowDialog() == System.Windows.Forms.DialogResult.OK &&
               saveFile1.FileName.Length > 0)
            {
                // Save the contents of the RichTextBox into the file.
                GetFastColoredTextBox().SaveToFile(saveFile1.FileName, Encoding.UTF8);
                //this.Text = saveFile1.FileName + " - SkEditor";
                FileInfo FileName = new FileInfo(saveFile1.FileName);
                string FileName1 = FileName.Name;
                tabControl1.SelectedTab.Text = FileName1;
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab.Text == "New File")
            {
                if (Properties.Settings.Default.Lang == "Polish")
                {
                    if (MessageBox.Show("Jesteś pewien, że chcesz wyłączyć niezapisany plik?", "SkEditor", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        tabControl1.TabPages.Remove(tabControl1.SelectedTab);
                    }
                }
                else
                {
                    if (MessageBox.Show("Are you sure to close unsaved file?", "SkEditor", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        tabControl1.TabPages.Remove(tabControl1.SelectedTab);
                    }
                }
            }
            else
            {
                tabControl1.TabPages.Remove(tabControl1.SelectedTab);
            }
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            GetFastColoredTextBox().Redo();
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            GetFastColoredTextBox().Undo();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            GetFastColoredTextBox().Cut();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            GetFastColoredTextBox().Copy();
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            GetFastColoredTextBox().Paste();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetFastColoredTextBox().Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetFastColoredTextBox().Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetFastColoredTextBox().Paste();
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Lang == "Polish")
            {
                if (MessageBox.Show("Jesteś pewien, że chcesz wyłączyć wszystkie pliki?", "SkEditor", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    tabControl1.TabPages.Clear();
                }
            }
            else
            {
                if (MessageBox.Show("Are you sure to close all files?", "SkEditor", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    tabControl1.TabPages.Clear();
                }
            }
        }

        private void closeAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Lang == "Polish")
            {
                if (MessageBox.Show("Jesteś pewien, że chcesz wyłączyć wszystkie pliki?", "SkEditor", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    tabControl1.TabPages.Clear();
                }
            }
            else
            {
                if (MessageBox.Show("Are you sure to close all files?", "SkEditor", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    tabControl1.TabPages.Clear();
                }
            }
        }

        public void saveToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            // Create a SaveFileDialog to request a path and file name to save to.
            SaveFileDialog saveFile1 = new SaveFileDialog();

            // Initialize the SaveFileDialog to specify the RTF extension for the file.
            saveFile1.DefaultExt = "*.sk";
            saveFile1.Filter = "SKRIPT File|*.sk";

            // Determine if the user selected a file name from the saveFileDialog.
            if (saveFile1.ShowDialog() == System.Windows.Forms.DialogResult.OK &&
               saveFile1.FileName.Length > 0)
            {
                // Save the contents of the RichTextBox into the file.
                GetFastColoredTextBox().SaveToFile(saveFile1.FileName, Encoding.UTF8);
                //this.Text = saveFile1.FileName + " - SkEditor";
                FileInfo FileName = new FileInfo(saveFile1.FileName);
                string FileName1 = FileName.Name;
                tabControl1.SelectedTab.Text = FileName1;
            }
        }

        private void joinDiscordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://discord.gg/cYcHfas");
        }

        private void ourWebSiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://michixyt.github.io/SkEditor/");
        }
    }
}
