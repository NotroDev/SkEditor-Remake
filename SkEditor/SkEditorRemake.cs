using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using FastColoredTextBoxNS;
using System.Net;
using System.Diagnostics;
using System.Collections.Specialized;
using MessageBox = System.Windows.Forms.MessageBox;
using MessageBoxButtons = System.Windows.Forms.MessageBoxButtons;
using MessageBoxIcon = System.Windows.Forms.MessageBoxIcon;
using Style = FastColoredTextBoxNS.Style;
using FontStyle = System.Drawing.FontStyle;
using Clipboard = System.Windows.Clipboard;
using Application = System.Windows.Forms.Application;
using DialogResult = System.Windows.Forms.DialogResult;
using DiscordRPC;
using DiscordRPC.Logging;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.ServiceModel.Description;
using System.Net.Http.Headers;

namespace SkEditor
{
    public partial class SkEditorRemake : Form
    {
        public string version = "v0.2 Alpha";

        public static class Environment
        {

        }

        public SkEditorRemake()
        {
            InitializeComponent();
        }



        public static string ready = "false";

        private void SkEditor_Load(object sender, EventArgs e)
        {
            DiscordRpcClient client = new DiscordRpcClient("853260040663728135");
            client.Logger = new ConsoleLogger() { Level = LogLevel.Warning };
            client.Initialize();

            client.SetPresence(new DiscordRPC.RichPresence()
            {
                Details = "Test1",
                State = "Test2",
                Timestamps = Timestamps.Now,
                Buttons = new DiscordRPC.Button[]
                {
                    new DiscordRPC.Button() { Label = "Pobierz SkEditor Remake", Url = "https://github.com/NotroDev/SkEditor-Remake" }
                },
                Assets = new Assets()
                {
                    LargeImageKey = "skeditor_large",
                    LargeImageText = "SkEditor Remake"
                }
            });

            menuStrip1.Renderer = new CustomProfessionalRenderer();

            Directory.CreateDirectory("C:\\ProgramData\\SkEditor\\");
            versionLabel.Text = version;
            int fileCount = Directory.GetFiles(@"C:\ProgramData\SkEditor\").Length;
            string[] filePaths = Directory.GetFiles(@"C:\ProgramData\SkEditor\");
            Debug.Listeners.Add(new TextWriterTraceListener(Console.Out));
            Debug.AutoFlush = true;
            Debug.Indent();
            foreach (string file in filePaths) Debug.WriteLine(Path.GetFileName(file));
            Debug.WriteLine(fileCount);
            Debug.Unindent();
            if (fileCount != 0)
                foreach (string file in filePaths)
                {
                    TabPage tp1 = new TabPage(Path.GetFileName(file).Replace(".unknow", ""));
                    FastColoredTextBoxNS.FastColoredTextBox rtb1 = new FastColoredTextBoxNS.FastColoredTextBox();
                    rtb1.Dock = DockStyle.Fill;
                    rtb1.LineNumberColor = Color.Black;
                    rtb1.BorderStyle = BorderStyle.None;
                    rtb1.TabLength = 4;
                    rtb1.TextChanged += new EventHandler<TextChangedEventArgs>(this.TextChangedEvent);
                    rtb1.Text = File.ReadAllText(file);
                    Font font = new Font("Courier New", rtb1.Font.Size);
                    rtb1.Font = font;
                    tp1.Controls.Add(rtb1);
                    tabControl1.TabPages.Add(tp1);
                    ready = "true";
                }
            if (0 == tabControl1.TabPages.Count)
            {
                TabPage tp = new TabPage("New File " + (tabControl1.TabPages.Count + 1));
                FastColoredTextBoxNS.FastColoredTextBox rtb = new FastColoredTextBoxNS.FastColoredTextBox();
                rtb.Dock = DockStyle.Fill;
                rtb.LineNumberColor = Color.Black;
                rtb.BorderStyle = BorderStyle.None;
                rtb.TabLength = 4;
                rtb.TextChanged += new EventHandler<TextChangedEventArgs>(this.TextChangedEvent);
                Font font = new Font("Courier New", rtb.Font.Size);
                rtb.Font = font;
                tp.Controls.Add(rtb);
                tabControl1.TabPages.Add(tp);
                ready = "true";
            }
            string[] args = System.Environment.GetCommandLineArgs();
            string filePath = args[0];
            for (int i = 0; i <= args.Length - 1; i++)
            {
                if (!args[i].Contains(".exe"))
                {
                    TabPage tp2 = new TabPage(Path.GetFileName(args[i]));
                    FastColoredTextBoxNS.FastColoredTextBox rtb2 = new FastColoredTextBoxNS.FastColoredTextBox();
                    rtb2.Dock = DockStyle.Fill;
                    rtb2.LineNumberColor = Color.Black;
                    rtb2.BorderStyle = BorderStyle.None;
                    rtb2.TabLength = 4;
                    rtb2.TextChanged += new EventHandler<TextChangedEventArgs>(this.TextChangedEvent);
                    rtb2.Text = File.ReadAllText(args[i]);
                    Font font = new Font("Courier New", rtb2.Font.Size);
                    rtb2.Font = font;
                    tp2.Controls.Add(rtb2);
                    tabControl1.TabPages.Add(tp2);
                    tabControl1.SelectTab(tp2);
                    GetFastColoredTextBox().SaveToFile("C:\\ProgramData\\SkEditor\\" + tabControl1.SelectedTab.Text.Replace("*", ""), Encoding.UTF8);
                }
            }
            int z = Int32.Parse(Properties.Settings.Default.Zoom);
            GetFastColoredTextBox().Zoom = z;
        }

        public void setLang(string LangString)
        {
            if (LangString == "polish")
            {
                fileToolStripMenuItem.Text = "Plik";
                editToolStripMenuItem.Text = "Edycja";
                skriptDocumentationToolStripMenuItem.Text = "Dokumentacja Skripta";
                newToolStripMenuItem.Text = "Nowy";
                saveToolStripMenuItem.Text = "Zapisz";
                openToolStripMenuItem.Text = "Otwórz";
                closeToolStripMenuItem.Text = "Zamknij";
                closeAllToolStripMenuItem.Text = "Zamknij wszystko";
                exitToolStripMenuItem.Text = "Zakończ";
                cutToolStripMenuItem.Text = "Wytnij";
                copyToolStripMenuItem.Text = "Kopiuj";
                pasteToolStripMenuItem.Text = "Wklej";
                undoToolStripMenuItem.Text = "Cofnij";
                redoToolStripMenuItem.Text = "Ponów";
                newToolStripButton.Text = "Nowy";
                openToolStripButton.Text = "Otwórz";
                saveToolStripButton.Text = "Zapisz";
                closeToolStripButton.Text = "Zamknij";
                closeAllToolStripButton.Text = "Zamknij wszystko";
                cutToolStripButton.Text = "Wytnij";
                copyToolStripButton.Text = "Kopiuj";
                pasteToolStripButton.Text = "Wklej";
                undoToolStripButton.Text = "Cofnij";
                redoToolStripButton.Text = "Ponów";
                joinDiscordToolStripMenuItem.Text = "Dołącz na naszego discorda";
                ourWebsiteToolStripMenuItem.Text = "Nasza strona internetowa";
                aboutSkEditorToolStripMenuItem.Text = "O SkEditorze";
                homeButton.Text = "Strona Główna";
                editorButton.Text = "Edytor";
                welcomeLabel.Text = "Witaj w SkEditor Remake!";
                subWelcomeLabel.Text = "Jest to wersja testowa. W razie problemu możesz napisać do twórcy na Discord - Notro#3737";
                searchToolStripButton.Text = "Szukaj";
                replaceToolStripButton.Text = "Szukaj i zamień";
                findToolStripMenuItem.Text = "Szukaj";
                replaceToolStripMenuItem.Text = "Szukaj i zamień";
                zoomInToolStripButton.Text = "Przybliż";
                zoomOutToolStripButton.Text = "Oddal";
                otherToolStripMenuItem.Text = "Inne";
                settingsToolStripMenuItem1.Text = "Ustawienia";
            }
            else if (LangString == "english")
            {
                fileToolStripMenuItem.Text = "File";
                editToolStripMenuItem.Text = "Edit";
                skriptDocumentationToolStripMenuItem.Text = "Skript Documentation";
                newToolStripMenuItem.Text = "New";
                saveToolStripMenuItem.Text = "Save";
                openToolStripMenuItem.Text = "Open";
                closeToolStripMenuItem.Text = "Close";
                closeAllToolStripMenuItem.Text = "Close all";
                exitToolStripMenuItem.Text = "Exit";
                cutToolStripMenuItem.Text = "Cut";
                copyToolStripMenuItem.Text = "Copy";
                pasteToolStripMenuItem.Text = "Paste";
                undoToolStripMenuItem.Text = "Undo";
                redoToolStripMenuItem.Text = "Redo";
                newToolStripButton.Text = "New";
                openToolStripButton.Text = "Open";
                saveToolStripButton.Text = "Save";
                closeToolStripButton.Text = "Close";
                closeAllToolStripButton.Text = "Close all";
                cutToolStripButton.Text = "Cut";
                copyToolStripButton.Text = "Copy";
                pasteToolStripButton.Text = "Paste";
                undoToolStripButton.Text = "Undo";
                redoToolStripButton.Text = "Redo";
                joinDiscordToolStripMenuItem.Text = "Join Discord";
                ourWebsiteToolStripMenuItem.Text = "Our Website";
                aboutSkEditorToolStripMenuItem.Text = "About SkEditor";
                homeButton.Text = "Home";
                editorButton.Text = "Editor";
                welcomeLabel.Text = "Welcome to SkEditor Remake!";
                subWelcomeLabel.Text = "This is a test version. In case of bug or problem, you can write to author on Discord - Notro#3737";
                searchToolStripButton.Text = "Find";
                replaceToolStripButton.Text = "Find and replace";
                findToolStripMenuItem.Text = "Find";
                replaceToolStripMenuItem.Text = "Find and replace";
                zoomInToolStripButton.Text = "Zoom in";
                zoomOutToolStripButton.Text = "Zoom out";
                otherToolStripMenuItem.Text = "Other";
                settingsToolStripMenuItem1.Text = "Settings";
            }
        }

        public void openFile()
        {
            if (0 < tabControl1.TabPages.Count)
            {
                OpenFileDialog openFile1 = new OpenFileDialog();

                openFile1.DefaultExt = "*.sk";
                openFile1.Filter = "Skript File|*.sk|Txt file|*.txt|All files|*.*";

                if (openFile1.ShowDialog() == System.Windows.Forms.DialogResult.OK &&
                   openFile1.FileName.Length > 0)
                {
                    ready = "false";
                    GetFastColoredTextBox().OpenFile(openFile1.FileName);
                    tabControl1.SelectedTab.Text = openFile1.SafeFileName;
                    ready = "true";
                    GetFastColoredTextBox().SaveToFile("C:\\ProgramData\\SkEditor\\" + tabControl1.SelectedTab.Text.Replace("*", ""), Encoding.UTF8);
                }
            }
        }

        public void saveFile()
        {
            if (0 < tabControl1.TabPages.Count)
            {
                SaveFileDialog saveFile1 = new SaveFileDialog();

                saveFile1.FileName = tabControl1.SelectedTab.Text.Replace("*", "");
                saveFile1.DefaultExt = "*.sk";
                saveFile1.Filter = "Skript File|*.sk|Txt file|*.txt|All files|*.*";

                if (saveFile1.ShowDialog() == System.Windows.Forms.DialogResult.OK &&
                   saveFile1.FileName.Length > 0)
                {
                    if (tabControl1.SelectedTab.Text.Contains("."))
                    {
                        File.Delete(@"C:\ProgramData\SkEditor\" + tabControl1.SelectedTab.Text.Replace("*", ""));
                    }
                    else
                    {
                        File.Delete(@"C:\ProgramData\SkEditor\" + tabControl1.SelectedTab.Text.Replace("*", "") + ".unknow");
                    }
                    GetFastColoredTextBox().SaveToFile(saveFile1.FileName, Encoding.UTF8);
                    FileInfo FileName = new FileInfo(saveFile1.FileName);
                    string FileName1 = FileName.Name;
                    tabControl1.SelectedTab.Text = FileName1;
                    GetFastColoredTextBox().SaveToFile("C:\\ProgramData\\SkEditor\\" + tabControl1.SelectedTab.Text, Encoding.UTF8);
                }
            }
        }

        public void newFile()
        {
            TabPage tp = new TabPage("New File " + (tabControl1.TabPages.Count + 1));
            FastColoredTextBoxNS.FastColoredTextBox rtb = new FastColoredTextBoxNS.FastColoredTextBox();
            rtb.Dock = DockStyle.Fill;
            rtb.LineNumberColor = Color.Black;
            rtb.BorderStyle = BorderStyle.None;
            rtb.TextChanged += new EventHandler<TextChangedEventArgs>(this.TextChangedEvent);
            Font font = new Font("Courier New", rtb.Font.Size);
            rtb.Font = font;
            tp.Controls.Add(rtb);
            tabControl1.TabPages.Add(tp);
            tabControl1.SelectTab(tp);
            if (Properties.Settings.Default.Mode == "Dark")
            {
                GetFastColoredTextBox().BackColor = Color.FromArgb(50, 50, 50);
                GetFastColoredTextBox().IndentBackColor = Color.FromArgb(45, 45, 45);
                GetFastColoredTextBox().LineNumberColor = Color.White;
                GetFastColoredTextBox().ForeColor = Color.White;
            }
            else
            {
                GetFastColoredTextBox().BackColor = Color.White;
                GetFastColoredTextBox().IndentBackColor = Color.WhiteSmoke;
                GetFastColoredTextBox().LineNumberColor = Color.Black;
                GetFastColoredTextBox().ForeColor = Color.Black;
            }
        }

        public void closeFile()
        {
            if (0 < tabControl1.TabPages.Count)
            {
                if (tabControl1.SelectedTab.Text.Contains("*"))
                {
                    if (Properties.Settings.Default.Lang == "Polish")
                    {
                        if (MessageBox.Show("Jesteś pewien, że chcesz zamknąć niezapisany plik?", "SkEditor", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            if (tabControl1.SelectedTab.Text.Contains("."))
                            {
                                File.Delete(@"C:\ProgramData\SkEditor\" + tabControl1.SelectedTab.Text.Replace("*", ""));
                            }
                            else
                            {
                                File.Delete(@"C:\ProgramData\SkEditor\" + tabControl1.SelectedTab.Text.Replace("*", "") + ".unknow");
                            }
                            tabControl1.TabPages.Remove(tabControl1.SelectedTab);
                        }
                    }
                    else
                    {
                        if (MessageBox.Show("Are you sure to close unsaved file?", "SkEditor", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            if (tabControl1.SelectedTab.Text.Contains("."))
                            {
                                File.Delete(@"C:\ProgramData\SkEditor\" + tabControl1.SelectedTab.Text.Replace("*", ""));
                            }
                            else
                            {
                                File.Delete(@"C:\ProgramData\SkEditor\" + tabControl1.SelectedTab.Text.Replace("*", "") + ".unknow");
                            }
                            tabControl1.TabPages.Remove(tabControl1.SelectedTab);
                        }
                    }
                }
                else
                {
                    if (tabControl1.SelectedTab.Text.Contains("."))
                    {
                        File.Delete(@"C:\ProgramData\SkEditor\" + tabControl1.SelectedTab.Text.Replace("*", ""));
                    }
                    else
                    {
                        File.Delete(@"C:\ProgramData\SkEditor\" + tabControl1.SelectedTab.Text.Replace("*", "") + ".unknow");
                    }
                    tabControl1.TabPages.Remove(tabControl1.SelectedTab);
                }
            }
        }

        public void closeAllFiles()
        {
            if (0 < tabControl1.TabPages.Count)
            {
                if (Properties.Settings.Default.Lang == "Polish")
                {
                    if (MessageBox.Show("Jesteś pewien, że chcesz zamknąć wszystkie pliki?", "SkEditor", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        Array.ForEach(Directory.GetFiles(@"C:\ProgramData\SkEditor\"), delegate (string path) { File.Delete(path); });
                        tabControl1.TabPages.Clear();
                    }
                }
                else
                {
                    if (MessageBox.Show("Are you sure to close all files?", "SkEditor", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        Array.ForEach(Directory.GetFiles(@"C:\ProgramData\SkEditor\"), delegate (string path) { File.Delete(path); });
                        tabControl1.TabPages.Clear();
                    }
                }
            }
        }

        Style red = new TextStyle(Brushes.IndianRed, null, FontStyle.Regular);
        Style blue = new TextStyle(Brushes.LightBlue, null, FontStyle.Regular);
        Style green = new TextStyle(Brushes.LightGreen, null, FontStyle.Regular);
        Style yellow = new TextStyle(Brushes.YellowGreen, null, FontStyle.Regular);
        Style gray = new TextStyle(Brushes.LightGray, null, FontStyle.Italic);
        private void TextChangedEvent(object sender, TextChangedEventArgs e)
        {
            WebClient webClient = new WebClient();
            Directory.CreateDirectory("C:\\ProgramData\\SkEditor\\");
            if (ready == "true")
            {
                if (tabControl1.SelectedTab.Text.Contains(".sk"))
                {
                    GetFastColoredTextBox().SaveToFile("C:\\ProgramData\\SkEditor\\" + tabControl1.SelectedTab.Text.Replace("*", ""), Encoding.UTF8);
                }
                else
                {
                    GetFastColoredTextBox().SaveToFile("C:\\ProgramData\\SkEditor\\" + tabControl1.SelectedTab.Text.Replace("*", "") + ".unknow", Encoding.UTF8);
                }
                if (!tabControl1.SelectedTab.Text.Contains("*"))
                {
                    tabControl1.SelectedTab.Text = "*" + tabControl1.SelectedTab.Text;
                }
            }

            e.ChangedRange.ClearStyle(red, blue, green, yellow, gray);
            //red
            /*
            while (events.Read())
            {
                if (events.Value != null)
                {
                    e.ChangedRange.SetStyle(red, "on " + events.Value.ToString().ToLower());
                }
            }
            */
            e.ChangedRange.SetStyle(green, "console");
            //red
            e.ChangedRange.SetStyle(red, "command");
            e.ChangedRange.SetStyle(red, "trigger");
            e.ChangedRange.SetStyle(red, "if");
            e.ChangedRange.SetStyle(red, ":");
            e.ChangedRange.SetStyle(red, "else");
            e.ChangedRange.SetStyle(red, "stop");
            e.ChangedRange.SetStyle(red, "permission");
            e.ChangedRange.SetStyle(red, "cooldown");
            e.ChangedRange.SetStyle(red, "message");
            e.ChangedRange.SetStyle(red, "loop");
            e.ChangedRange.SetStyle(red, "every");
            e.ChangedRange.SetStyle(red, "set");
            e.ChangedRange.SetStyle(red, "wait");
            e.ChangedRange.SetStyle(red, "cancel event");
            e.ChangedRange.SetStyle(red, "on");
            e.ChangedRange.SetStyle(red, "execute");
            e.ChangedRange.SetStyle(red, "function");
            //green
            e.ChangedRange.SetStyle(green, "%");
            e.ChangedRange.SetStyle(green, "/");
            e.ChangedRange.SetStyle(green, "player");
            e.ChangedRange.SetStyle(green, "slot");
            e.ChangedRange.SetStyle(green, "offline");
            e.ChangedRange.SetStyle(green, "players");
            e.ChangedRange.SetStyle(green, "player's");
            e.ChangedRange.SetStyle(green, "clear");
            e.ChangedRange.SetStyle(green, "send");
            e.ChangedRange.SetStyle(green, "broadcast");
            e.ChangedRange.SetStyle(green, "inventory");
            e.ChangedRange.SetStyle(green, "text");
            e.ChangedRange.SetStyle(green, "number");
            e.ChangedRange.SetStyle(green, "integer");
            e.ChangedRange.SetStyle(green, "-");
            //blue
            e.ChangedRange.SetStyle(blue, "{");
            e.ChangedRange.SetStyle(blue, "}");
            e.ChangedRange.SetStyle(blue, "true");
            e.ChangedRange.SetStyle(blue, "false");
            e.ChangedRange.SetStyle(blue, "is");
            e.ChangedRange.SetStyle(blue, "of ");
            e.ChangedRange.SetStyle(blue, "all");
            e.ChangedRange.SetStyle(blue, "tick");
            e.ChangedRange.SetStyle(blue, "ticks");
            e.ChangedRange.SetStyle(blue, "second");
            e.ChangedRange.SetStyle(blue, "seconds");
            e.ChangedRange.SetStyle(blue, "month");
            e.ChangedRange.SetStyle(blue, "months");
            e.ChangedRange.SetStyle(blue, "minute");
            e.ChangedRange.SetStyle(blue, "minutes");
            e.ChangedRange.SetStyle(blue, "to");
            e.ChangedRange.SetStyle(blue, "week");
            e.ChangedRange.SetStyle(blue, "weeks");
            e.ChangedRange.SetStyle(blue, "year");
            e.ChangedRange.SetStyle(blue, "years");
            e.ChangedRange.SetStyle(blue, "\"");
            e.ChangedRange.SetStyle(blue, "kill");
            e.ChangedRange.SetStyle(blue, "current");
            e.ChangedRange.SetStyle(blue, @"<");
            e.ChangedRange.SetStyle(blue, @">");
            e.ChangedRange.SetStyle(blue, "arg");
            e.ChangedRange.SetStyle(blue, "clicked");
            //yellow
            /*
            while (conditions.Read())
            {
                if (conditions.Value != null)
                {
                    e.ChangedRange.SetStyle(yellow, conditions.Value.ToString().ToLower());
                }
            }
            //gray
            */
            e.ChangedRange.SetStyle(gray, "#.*$");
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

        private void Editor_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;
        }

        private void Home_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
        }

        private void polskiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Lang = "Polish";
            Properties.Settings.Default.Save();
            setLang("polish");
        }

        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Lang = "English";
            Properties.Settings.Default.Save();
            setLang("english");
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newFile();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            newFile();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFile();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            openFile();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFile();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            saveFile();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            closeFile();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            closeFile();
        }

        private void closeAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            closeAllFiles();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            closeAllFiles();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (0 < tabControl1.TabPages.Count)
            {
                GetFastColoredTextBox().Cut();
            }
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            if (0 < tabControl1.TabPages.Count)
            {
                GetFastColoredTextBox().Cut();
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (0 < tabControl1.TabPages.Count)
            {
                GetFastColoredTextBox().Copy();
            }
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            if (0 < tabControl1.TabPages.Count)
            {
                GetFastColoredTextBox().Copy();
            }
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (0 < tabControl1.TabPages.Count)
            {
                GetFastColoredTextBox().Paste();
            }
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            if (0 < tabControl1.TabPages.Count)
            {
                GetFastColoredTextBox().Paste();
            }
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (0 < tabControl1.TabPages.Count)
            {
                GetFastColoredTextBox().Undo();
            }
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            if (0 < tabControl1.TabPages.Count)
            {
                GetFastColoredTextBox().Undo();
            }
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (0 < tabControl1.TabPages.Count)
            {
                GetFastColoredTextBox().Redo();
            }
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            if (0 < tabControl1.TabPages.Count)
            {
                GetFastColoredTextBox().Redo();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void skriptDocumentationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://skripthub.net/docs/");
        }

        private void joinDiscordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://discord.gg/2dv42hZTC7");
        }

        private void ourWebsiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://michixyt.github.io/SkEditor/");
        }

        private void lightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Mode = "Light";
            Properties.Settings.Default.Save();
            if (0 < tabControl1.TabPages.Count)
            {
                GetFastColoredTextBox().BackColor = Color.White;
                GetFastColoredTextBox().IndentBackColor = Color.WhiteSmoke;
                GetFastColoredTextBox().LineNumberColor = Color.Black;
                GetFastColoredTextBox().ForeColor = Color.Black;
            }
        }

        private void darkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Mode = "Dark";
            Properties.Settings.Default.Save();
            if (0 < tabControl1.TabPages.Count)
            {
                GetFastColoredTextBox().BackColor = Color.FromArgb(50, 50, 50);
                GetFastColoredTextBox().IndentBackColor = Color.FromArgb(45, 45, 45);
                GetFastColoredTextBox().LineNumberColor = Color.White;
                GetFastColoredTextBox().ForeColor = Color.White;
            }
        }

        private void aboutSkEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutSkEditorRemake aboutSkEditorRemake = new AboutSkEditorRemake();

            aboutSkEditorRemake.ShowDialog();
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (0 < tabControl1.TabPages.Count)
            {
                if (Properties.Settings.Default.Mode == "Dark")
                {
                    GetFastColoredTextBox().BackColor = Color.FromArgb(50, 50, 50);
                    GetFastColoredTextBox().IndentBackColor = Color.FromArgb(45, 45, 45);
                    GetFastColoredTextBox().LineNumberColor = Color.White;
                    GetFastColoredTextBox().ForeColor = Color.White;
                }
                else
                {
                    GetFastColoredTextBox().BackColor = Color.White;
                    GetFastColoredTextBox().IndentBackColor = Color.WhiteSmoke;
                    GetFastColoredTextBox().LineNumberColor = Color.Black;
                    GetFastColoredTextBox().ForeColor = Color.Black;
                }
                int z = Int32.Parse(Properties.Settings.Default.Zoom);
                GetFastColoredTextBox().Zoom = z;
            }
        }

        public static bool isNullOrEmpty(string s)
        {
            bool result;
            result = s == null || s == string.Empty;
            return result;
        }

        private void toolStripButton12_Click(object sender, EventArgs e)
        {
            FastColoredTextBoxNS.FindForm findForm = new FastColoredTextBoxNS.FindForm(GetFastColoredTextBox());
            findForm.Show();
        }

        private void toolStripButton13_Click(object sender, EventArgs e)
        {
            FastColoredTextBoxNS.ReplaceForm replaceForm = new FastColoredTextBoxNS.ReplaceForm(GetFastColoredTextBox());
            replaceForm.Show();
        }

        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FastColoredTextBoxNS.FindForm findForm = new FastColoredTextBoxNS.FindForm(GetFastColoredTextBox());
            findForm.Show();
        }

        private void replaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FastColoredTextBoxNS.ReplaceForm replaceForm = new FastColoredTextBoxNS.ReplaceForm(GetFastColoredTextBox());
            replaceForm.Show();
        }

        private void toolStripButton14_Click(object sender, EventArgs e)
        {
            int z = GetFastColoredTextBox().Zoom + 5;
            GetFastColoredTextBox().Zoom = z;
            Properties.Settings.Default.Zoom = z.ToString();
            Properties.Settings.Default.Save();
        }

        private void toolStripButton15_Click(object sender, EventArgs e)
        {
            int z = GetFastColoredTextBox().Zoom - 5;
            GetFastColoredTextBox().Zoom = z;
            Properties.Settings.Default.Zoom = z.ToString();
            Properties.Settings.Default.Save();
        }

        public void createButton(string Name, Image Img, EventHandler ClickFunction)
        {
            ToolStripButton button = new ToolStripButton();
            button.Text = Name;
            button.Image = Img;
            button.Click += ClickFunction;
            button.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStrip1.Items.Add(button);
        }
        public void createButton(string Name, EventHandler ClickFunction)
        {
            ToolStripButton button = new ToolStripButton();
            button.Text = Name;
            button.Click += ClickFunction;
            button.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStrip1.Items.Add(button);
        }

        private void settingsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            settingsForm settingsForm = new settingsForm();

            settingsForm.ShowDialog();
        }

        private void SkEditorOld_Activated(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Lang == "Polish")
            {
                setLang("polish");
            }
            else
            {
                setLang("english");
            }

            if (Properties.Settings.Default.Panel == "Enabled")
            {
                panel3.Visible = true;
                panel1.Visible = true;
            }
            else
            {
                panel3.Visible = true;
                panel1.Visible = false;
            }

            if (Properties.Settings.Default.Mode == "Light")
            {
                setTheme("Light");
            }
            else if (Properties.Settings.Default.Mode == "Dark")
            {
                setTheme("Dark");
            }

            if (Properties.Settings.Default.IconSet == "Default")
            {
                setIcons("Default");
            }
            else if (Properties.Settings.Default.IconSet == "Old")
            {
                setIcons("Old");
            }
        }

        public void setTheme(string themeString)
        {
            if (themeString == "Light")
            {
                GetFastColoredTextBox().BackColor = Color.White;
                GetFastColoredTextBox().IndentBackColor = Color.WhiteSmoke;
                GetFastColoredTextBox().LineNumberColor = Color.Black;
                GetFastColoredTextBox().ForeColor = Color.Black;
            }

            else if (themeString == "Dark")
            {
                GetFastColoredTextBox().BackColor = Color.FromArgb(50, 50, 50);
                GetFastColoredTextBox().IndentBackColor = Color.FromArgb(45, 45, 45);
                GetFastColoredTextBox().LineNumberColor = Color.White;
                GetFastColoredTextBox().ForeColor = Color.White;
            }
        }

        public void setIcons(string iconsString)
        {
            if (iconsString == "Default")
            {
                newToolStripButton.Image = Properties.Resources.new_file;
                openToolStripButton.Image = Properties.Resources.open_file;
                saveToolStripButton.Image = Properties.Resources.save_file;
                closeToolStripButton.Image = Properties.Resources.close_file;
                closeAllToolStripButton.Image = Properties.Resources.close_all;
                cutToolStripButton.Image = Properties.Resources.cut;
                copyToolStripButton.Image = Properties.Resources.copy_file;
                pasteToolStripButton.Image = Properties.Resources.paste_file;
                undoToolStripButton.Image = Properties.Resources.undo_b;
                redoToolStripButton.Image = Properties.Resources.redo_b;
                searchToolStripButton.Image = Properties.Resources.search;
                replaceToolStripButton.Image = Properties.Resources.replace;
                zoomInToolStripButton.Image = Properties.Resources.zoom_in;
                zoomOutToolStripButton.Image = Properties.Resources.zoom_out;

                newToolStripMenuItem.Image = Properties.Resources.new_file;
                openToolStripMenuItem.Image = Properties.Resources.open_file;
                saveToolStripMenuItem.Image = Properties.Resources.save_file;
                closeToolStripMenuItem.Image = Properties.Resources.close_file;
                closeAllToolStripMenuItem.Image = Properties.Resources.close_all;
                cutToolStripMenuItem.Image = Properties.Resources.cut;
                copyToolStripMenuItem.Image = Properties.Resources.copy_file;
                pasteToolStripMenuItem.Image = Properties.Resources.paste_file;
                undoToolStripMenuItem.Image = Properties.Resources.undo_b;
                redoToolStripMenuItem.Image = Properties.Resources.redo_b;
                findToolStripMenuItem.Image = Properties.Resources.search;
                replaceToolStripMenuItem.Image = Properties.Resources.replace;
                exitToolStripMenuItem.Image = Properties.Resources.exit;
            }

            else if (iconsString == "Old")
            {
                newToolStripButton.Image = Properties.Resources.new_file_old;
                openToolStripButton.Image = Properties.Resources.open_old;
                saveToolStripButton.Image = Properties.Resources.save_old;
                closeToolStripButton.Image = Properties.Resources.close_file_old;
                closeAllToolStripButton.Image = Properties.Resources.close_all_old;
                cutToolStripButton.Image = Properties.Resources.cut_old;
                copyToolStripButton.Image = Properties.Resources.copy_old;
                pasteToolStripButton.Image = Properties.Resources.paste_old;
                undoToolStripButton.Image = Properties.Resources.undo_old;
                redoToolStripButton.Image = Properties.Resources.redo_old;
                searchToolStripButton.Image = Properties.Resources.search_old;
                replaceToolStripButton.Image = Properties.Resources.replace_old;
                zoomInToolStripButton.Image = Properties.Resources.zoom_in_old;
                zoomOutToolStripButton.Image = Properties.Resources.zoom_out_old;

                newToolStripMenuItem.Image = Properties.Resources.new_file_old;
                openToolStripMenuItem.Image = Properties.Resources.open_old;
                saveToolStripMenuItem.Image = Properties.Resources.save_old;
                closeToolStripMenuItem.Image = Properties.Resources.close_file_old;
                closeAllToolStripMenuItem.Image = Properties.Resources.close_all_old;
                cutToolStripMenuItem.Image = Properties.Resources.cut_old;
                copyToolStripMenuItem.Image = Properties.Resources.copy_old;
                pasteToolStripMenuItem.Image = Properties.Resources.paste_old;
                undoToolStripMenuItem.Image = Properties.Resources.undo_old;
                redoToolStripMenuItem.Image = Properties.Resources.redo_old;
                findToolStripMenuItem.Image = Properties.Resources.search_old;
                replaceToolStripMenuItem.Image = Properties.Resources.replace_old;
                exitToolStripMenuItem.Image = Properties.Resources.exit_old;
            }
        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            publishCode(GetFastColoredTextBox().Text);
        }

        async void publishCode(string Code)
        {
            if (string.IsNullOrWhiteSpace(Code))
                Code = " ";
            CookieContainer cookies = new CookieContainer();
            HttpClientHandler handler = new HttpClientHandler();
            handler.CookieContainer = cookies;
            using (HttpClient client = new HttpClient(handler))
            {
                using (HttpResponseMessage response = client.GetAsync("https://code.skript.pl").Result)
                {
                    HttpHeaders headers = response.Headers;
                    HttpContent content = response.Content;
                    string myContent = content.ReadAsStringAsync().Result;
                    Regex regex = new Regex("name='csrf-token' content='(.*)'");
                    var otherLang = regex.Match(myContent).Groups[1];
                    var values = new Dictionary<string, string>
                    {
                        { "lang", "text" },
                        { "content", Code },
                        { "_token", otherLang.ToString() }
                    };
                    var content2 = new FormUrlEncodedContent(values);
                    var response2 = await client.PostAsync("https://code.skript.pl/create", content2);
                    var responseString = response2.RequestMessage.RequestUri;
                    Clipboard.SetText(responseString.ToString());
                    MessageBox.Show("Link został skopiowany do schowka.", "Skopiowano link", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void skriptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            publishCode(GetFastColoredTextBox().Text);
        }
    }

}