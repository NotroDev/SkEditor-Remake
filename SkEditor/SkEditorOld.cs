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

namespace SkEditor
{
    public partial class SkEditorOld : Form
    {
        public string version = "1.6.3 Hotfix-3";

        public static class Environment
        {

        }

        public SkEditorOld()
        {
            InitializeComponent();
            WebClient webclient = new WebClient();
            if (!webclient.DownloadString("https://pastebin.com/raw/nYdZUkvT").Equals(version))
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
                        System.Diagnostics.Process.Start("https://github.com/MichixYT/SkEditor/releases/latest/");
                    }
                }
            }
        }



        public static string ready = "false";

        DiscordRPC.DiscordRpcClient client = new DiscordRPC.DiscordRpcClient("787430361742311424");
        DiscordRPC.RichPresence richPresence = new DiscordRPC.RichPresence()
        {
            Assets = new DiscordRPC.Assets()
            {
                LargeImageKey = "large_image",
                LargeImageText = "Skript",
                SmallImageKey = "small_image",
                SmallImageText = "SkEditor"
            }
        };
        public void UpdateRPC(string Details, string State)
        {
            if (!client.IsInitialized)
            {
                client.Initialize();
            }
            client.SetPresence(richPresence);
            richPresence.Details = Details;
            richPresence.State = State;
        }

        private void SkEditor_Load(object sender, EventArgs e)
        {
            Directory.CreateDirectory("C:\\ProgramData\\SkEditor\\");
            label3.Text = version;
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
            if (Properties.Settings.Default.Mode == "Dark")
            {
                darkToolStripMenuItem.Image = Properties.Resources.checkmark_16;
                lightToolStripMenuItem.Image = Properties.Resources.x_mark_16;
                GetFastColoredTextBox().BackColor = Color.FromArgb(50, 50, 50);
                GetFastColoredTextBox().IndentBackColor = Color.FromArgb(45, 45, 45);
                GetFastColoredTextBox().LineNumberColor = Color.White;
                GetFastColoredTextBox().ForeColor = Color.White;
            }
            else
            {
                darkToolStripMenuItem.Image = Properties.Resources.x_mark_16;
                lightToolStripMenuItem.Image = Properties.Resources.checkmark_16;
                GetFastColoredTextBox().BackColor = Color.White;
                GetFastColoredTextBox().IndentBackColor = Color.WhiteSmoke;
                GetFastColoredTextBox().LineNumberColor = Color.Black;
                GetFastColoredTextBox().ForeColor = Color.Black;
            }
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
                panel3.Visible = false;
                panel1.Visible = true;
                enabledToolStripMenuItem.Image = Properties.Resources.checkmark_16;
                disabledToolStripMenuItem.Image = Properties.Resources.x_mark_16;
            }
            else
            {
                panel3.Visible = true;
                panel1.Visible = false;
                disabledToolStripMenuItem.Image = Properties.Resources.checkmark_16;
                enabledToolStripMenuItem.Image = Properties.Resources.x_mark_16;
            }
            int z = Int32.Parse(Properties.Settings.Default.Zoom);
            GetFastColoredTextBox().Zoom = z;
        }

        public void setLang(string LangString)
        {
            if (LangString == "polish")
            {
                polskiToolStripMenuItem.Image = Properties.Resources.checkmark_16;
                englishToolStripMenuItem.Image = Properties.Resources.x_mark_16;
                fileToolStripMenuItem.Text = "Plik";
                editToolStripMenuItem.Text = "Edycja";
                settingsToolStripMenuItem.Text = "Ustawienia";
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
                modeToolStripMenuItem.Text = "Tryb";
                languageToolStripMenuItem.Text = "Język";
                toolStripButton1.Text = "Nowy";
                toolStripButton2.Text = "Otwórz";
                toolStripButton3.Text = "Zapisz";
                toolStripButton4.Text = "Zamknij";
                toolStripButton5.Text = "Zamknij wszystko";
                toolStripButton6.Text = "Wytnij";
                toolStripButton7.Text = "Kopiuj";
                toolStripButton8.Text = "Wklej";
                toolStripButton9.Text = "Cofnij";
                toolStripButton10.Text = "Ponów";
                lightToolStripMenuItem.Text = "Jasny";
                darkToolStripMenuItem.Text = "Ciemny";
                enabledToolStripMenuItem.Text = "Włączony";
                disabledToolStripMenuItem.Text = "Wyłączony";
                joinDiscordToolStripMenuItem.Text = "Dołącz na naszego discorda";
                ourWebsiteToolStripMenuItem.Text = "Nasza strona internetowa";
                aboutSkEditorToolStripMenuItem.Text = "O SkEditorze";
                Home.Text = "Dom";
                Editor.Text = "Edytor";
                label2.Text = "Witaj w SkEditorze!";
                toolStripButton12.Text = "Szukaj";
                toolStripButton13.Text = "Szukaj i zamień";
                findToolStripMenuItem.Text = "Szukaj";
                replaceToolStripMenuItem.Text = "Szukaj i zamień";
                toolStripButton14.Text = "Przybliż";
                toolStripButton15.Text = "Oddal";
            }
            else if (LangString == "english")
            {
                polskiToolStripMenuItem.Image = Properties.Resources.x_mark_16;
                englishToolStripMenuItem.Image = Properties.Resources.checkmark_16;
                fileToolStripMenuItem.Text = "File";
                editToolStripMenuItem.Text = "Edit";
                settingsToolStripMenuItem.Text = "Settings";
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
                modeToolStripMenuItem.Text = "Mode";
                languageToolStripMenuItem.Text = "Language";
                toolStripButton1.Text = "New";
                toolStripButton2.Text = "Open";
                toolStripButton3.Text = "Save";
                toolStripButton4.Text = "Close";
                toolStripButton5.Text = "Close all";
                toolStripButton6.Text = "Cut";
                toolStripButton7.Text = "Copy";
                toolStripButton8.Text = "Paste";
                toolStripButton9.Text = "Undo";
                toolStripButton10.Text = "Redo";
                lightToolStripMenuItem.Text = "Light";
                darkToolStripMenuItem.Text = "Dark";
                enabledToolStripMenuItem.Text = "Enabled";
                disabledToolStripMenuItem.Text = "Disabled";
                joinDiscordToolStripMenuItem.Text = "Join Discord";
                ourWebsiteToolStripMenuItem.Text = "Our Website";
                aboutSkEditorToolStripMenuItem.Text = "About SkEditor";
                Home.Text = "Home";
                Editor.Text = "Editor";
                label2.Text = "Welcome to SkEditor!";
                toolStripButton12.Text = "Find";
                toolStripButton13.Text = "Find and replace";
                findToolStripMenuItem.Text = "Find";
                replaceToolStripMenuItem.Text = "Find and replace";
                toolStripButton14.Text = "Zoom in";
                toolStripButton15.Text = "Zoom out";
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
                darkToolStripMenuItem.Image = Properties.Resources.checkmark_16;
                lightToolStripMenuItem.Image = Properties.Resources.x_mark_16;
                GetFastColoredTextBox().BackColor = Color.FromArgb(50, 50, 50);
                GetFastColoredTextBox().IndentBackColor = Color.FromArgb(45, 45, 45);
                GetFastColoredTextBox().LineNumberColor = Color.White;
                GetFastColoredTextBox().ForeColor = Color.White;
            }
            else
            {
                darkToolStripMenuItem.Image = Properties.Resources.x_mark_16;
                lightToolStripMenuItem.Image = Properties.Resources.checkmark_16;
                GetFastColoredTextBox().BackColor = Color.White;
                GetFastColoredTextBox().IndentBackColor = Color.WhiteSmoke;
                GetFastColoredTextBox().LineNumberColor = Color.Black;
                GetFastColoredTextBox().ForeColor = Color.Black;
            }
            UpdateRPC("In Menu", "");
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
        static WebClient webClient = new WebClient();
        //Newtonsoft.Json.JsonTextReader events = new Newtonsoft.Json.JsonTextReader(new StringReader(webClient.DownloadString("http://gameclub.gameclan.pl/api/apis-12d21hd289gc9gsfgh49gf9wg4789fgwc9g4wg79f4g79ftg@/f3gq078fg7804g84v3v2d2df76wd32vfocv7f3g5dg36wfd3gfd9rffr3wadf383wd6r9fwd3f8d3wf6d683f673cwv34cdf73wcvc4wf7c3wov.json")));
        //Newtonsoft.Json.JsonTextReader conditions = new Newtonsoft.Json.JsonTextReader(new StringReader(webClient.DownloadString("http://gameclub.gameclan.pl/api/apis-12d21hd289gc9gsfgh49gf9wg4789fgwc9g4wg79f4g79ftg@/f3gq078fg7804g814v3v2d2df76wd32vfocv7f3gdg36wfd3gfd9rffr3wadf383wd6r9fwd3f8d2536342642356ov.json")));
        private void TextChangedEvent(object sender, TextChangedEventArgs e)
        {
            WebClient webClient = new WebClient();
            Directory.CreateDirectory("C:\\ProgramData\\SkEditor\\");
            if (ready == "true")
            {
                UpdateRPC("Editing", tabControl1.SelectedTab.Text.Replace("*", ""));
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
            darkToolStripMenuItem.Image = Properties.Resources.x_mark_16;
            lightToolStripMenuItem.Image = Properties.Resources.checkmark_16;
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
            darkToolStripMenuItem.Image = Properties.Resources.checkmark_16;
            lightToolStripMenuItem.Image = Properties.Resources.x_mark_16;
            if (0 < tabControl1.TabPages.Count)
            {
                GetFastColoredTextBox().BackColor = Color.FromArgb(50, 50, 50);
                GetFastColoredTextBox().IndentBackColor = Color.FromArgb(45, 45, 45);
                GetFastColoredTextBox().LineNumberColor = Color.White;
                GetFastColoredTextBox().ForeColor = Color.White;
            }
        }

        private void enabledToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Panel = "Enabled";
            Properties.Settings.Default.Save();
            panel3.Visible = false;
            panel1.Visible = true;
            enabledToolStripMenuItem.Image = Properties.Resources.checkmark_16;
            disabledToolStripMenuItem.Image = Properties.Resources.x_mark_16;
        }

        private void disabledToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Panel = "Disabled";
            Properties.Settings.Default.Save();
            panel3.Visible = true;
            panel1.Visible = false;
            disabledToolStripMenuItem.Image = Properties.Resources.checkmark_16;
            enabledToolStripMenuItem.Image = Properties.Resources.x_mark_16;
        }

        private void aboutSkEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WebClient webclient = new WebClient();
            if (!webclient.DownloadString("https://pastebin.com/raw/nYdZUkvT").Contains(version))
            {
                if (Properties.Settings.Default.Lang == "Polish")
                {
                    MessageBox.Show("Wersja: " + version + "\n" + "Dostępna aktualizacja: Tak" + "\n" + "Wersja aktualizacji: " + webclient.DownloadString("https://pastebin.com/raw/nYdZUkvT"), "SkEditor", MessageBoxButtons.OK, MessageBoxIcon.Information); //
                }
                else
                {
                    MessageBox.Show("Version: " + version + "\n" + "Avaible update: Yes" + "\n" + "Update version: " + webclient.DownloadString("https://pastebin.com/raw/nYdZUkvT"), "SkEditor", MessageBoxButtons.OK, MessageBoxIcon.Information); //
                }
            }
            else
            {
                if (Properties.Settings.Default.Lang == "Polish")
                {
                    MessageBox.Show("Wersja: " + version + "\n" + "Dostępna aktualizacja: Nie", "SkEditor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Version: " + version + "\n" + "Avaible update: No", "SkEditor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (0 < tabControl1.TabPages.Count)
            {
                if (Properties.Settings.Default.Mode == "Dark")
                {
                    darkToolStripMenuItem.Image = Properties.Resources.checkmark_16;
                    lightToolStripMenuItem.Image = Properties.Resources.x_mark_16;
                    GetFastColoredTextBox().BackColor = Color.FromArgb(50, 50, 50);
                    GetFastColoredTextBox().IndentBackColor = Color.FromArgb(45, 45, 45);
                    GetFastColoredTextBox().LineNumberColor = Color.White;
                    GetFastColoredTextBox().ForeColor = Color.White;
                }
                else
                {
                    darkToolStripMenuItem.Image = Properties.Resources.x_mark_16;
                    lightToolStripMenuItem.Image = Properties.Resources.checkmark_16;
                    GetFastColoredTextBox().BackColor = Color.White;
                    GetFastColoredTextBox().IndentBackColor = Color.WhiteSmoke;
                    GetFastColoredTextBox().LineNumberColor = Color.Black;
                    GetFastColoredTextBox().ForeColor = Color.Black;
                }
                int z = Int32.Parse(Properties.Settings.Default.Zoom);
                GetFastColoredTextBox().Zoom = z;
            }
        }

        public void createPastebin(string Code)
        {
            if (string.IsNullOrEmpty(Code.Trim())) { return; }

            NameValueCollection IQuery = new NameValueCollection();

            IQuery.Add("api_dev_key", "3a26130ae7db1bf8aca1a069b31d4e37");
            IQuery.Add("api_option", "paste");
            IQuery.Add("api_paste_code", Code);
            IQuery.Add("api_paste_name", tabControl1.SelectedTab.Text);

            using (WebClient IClient = new WebClient())
            {
                string IResponse = Encoding.UTF8.GetString(IClient.UploadValues("https://pastebin.com/api/api_post.php", IQuery));

                Uri isValid = null;
                if (!Uri.TryCreate(IResponse, UriKind.Absolute, out isValid))
                {
                    throw new WebException("Paste Error", WebExceptionStatus.SendFailure);
                }
                else
                {
                    Clipboard.SetText(IResponse);
                    if (Properties.Settings.Default.Lang == "Polish")
                    {
                        MessageBox.Show("Link został skopiowany do schowka", "SkEditor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("The link has been copied to the clipboard", "SkEditor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void toolStripButton11_Click(object sender, EventArgs e)
        {
            if (!isNullOrEmpty(GetFastColoredTextBox().Selection.Text))
            {
                createPastebin(GetFastColoredTextBox().Selection.Text);
            }
            else 
            {
                createPastebin(GetFastColoredTextBox().Text);
            }
        }

        private void pastebinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!isNullOrEmpty(GetFastColoredTextBox().Selection.Text))
            {
                createPastebin(GetFastColoredTextBox().Selection.Text);
            }
            else
            {
                createPastebin(GetFastColoredTextBox().Text);
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
    }

}
