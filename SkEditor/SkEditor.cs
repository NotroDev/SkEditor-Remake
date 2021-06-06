using FastColoredTextBoxNS;
using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SkEditor
{
    public partial class SkEditor : Form
    {
        public SkEditor()
        {
            InitializeComponent();
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

        private void SkEditor2_Load(object sender, EventArgs e)
        {
            menuStrip1.Renderer = new ToolStripProfessionalRenderer(new DarkBackColor());
            tabControl1.HorizontalLineColor = Color.FromArgb(50, 205, 50);
            Directory.CreateDirectory("C:\\ProgramData\\SkEditor\\");
            int fileCount = Directory.GetFiles(@"C:\ProgramData\SkEditor\").Length;
            string[] filePaths = Directory.GetFiles(@"C:\ProgramData\SkEditor\");
            if (fileCount != 0)
                foreach (string file in filePaths)
                {
                    TabPage tp1 = new TabPage(Path.GetFileName(file).Replace(".unknown", ""));
                    FastColoredTextBoxNS.FastColoredTextBox rtb1 = new FastColoredTextBoxNS.FastColoredTextBox();
                    rtb1.Dock = DockStyle.Fill;
                    rtb1.LineNumberColor = Color.Black;
                    rtb1.BorderStyle = BorderStyle.None;
                    rtb1.TabLength = 4;
                    rtb1.TextChanged += new EventHandler<TextChangedEventArgs>(this.TextChangedEvent);
                    rtb1.Text = File.ReadAllText(file);
                    rtb1.BackColor = Color.FromArgb(50, 50, 50);
                    rtb1.IndentBackColor = Color.FromArgb(45, 45, 45);
                    rtb1.LineNumberColor = Color.White;
                    rtb1.ForeColor = Color.White;
                    tp1.AllowDrop = true;
                    tp1.Controls.Add(rtb1);
                    tp1.ImageIndex = 0;
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
                rtb.BackColor = Color.FromArgb(50, 50, 50);
                rtb.IndentBackColor = Color.FromArgb(45, 45, 45);
                rtb.LineNumberColor = Color.White;
                rtb.ForeColor = Color.White;
                tp.Controls.Add(rtb);
                tp.ImageIndex = 0;
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
                    rtb2.BackColor = Color.FromArgb(50, 50, 50);
                    rtb2.IndentBackColor = Color.FromArgb(45, 45, 45);
                    rtb2.LineNumberColor = Color.White;
                    rtb2.ForeColor = Color.White;
                    tp2.Controls.Add(rtb2);
                    tp2.ImageIndex = 0;
                    tabControl1.TabPages.Add(tp2);
                    tabControl1.SelectTab(tp2);
                    GetFastColoredTextBox().SaveToFile("C:\\ProgramData\\SkEditor\\" + tabControl1.SelectedTab.Text.Replace("*", ""), Encoding.UTF8);
                }
            }
            GetFastColoredTextBox().Zoom = Int32.Parse(Properties.Settings.Default.Zoom);
        }

        Style red = new TextStyle(Brushes.IndianRed, null, FontStyle.Regular);
        Style blue = new TextStyle(Brushes.LightBlue, null, FontStyle.Regular);
        Style green = new TextStyle(Brushes.LightGreen, null, FontStyle.Regular);
        Style yellow = new TextStyle(Brushes.YellowGreen, null, FontStyle.Regular);
        Style gray = new TextStyle(Brushes.LightGray, null, FontStyle.Italic);
        static WebClient webClient = new WebClient();
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
                    GetFastColoredTextBox().SaveToFile("C:\\ProgramData\\SkEditor\\" + tabControl1.SelectedTab.Text.Replace("*", "") + ".unknown", Encoding.UTF8);
                }
                if (!tabControl1.SelectedTab.Text.Contains("*"))
                {
                    tabControl1.SelectedTab.Text = "*" + tabControl1.SelectedTab.Text;
                }
            }

            e.ChangedRange.ClearStyle(red, blue, green, yellow, gray);
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
            e.ChangedRange.SetStyle(green, "console");
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
            //gray
            e.ChangedRange.SetStyle(gray, "#.*$");
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
            rtb.TabLength = 4;
            rtb.TextChanged += new EventHandler<TextChangedEventArgs>(this.TextChangedEvent);
            rtb.BackColor = Color.FromArgb(50, 50, 50);
            rtb.IndentBackColor = Color.FromArgb(45, 45, 45);
            rtb.LineNumberColor = Color.White;
            rtb.ForeColor = Color.White;
            Font font = new Font("Courier New", rtb.Font.Size);
            rtb.Font = font;
            tp.Controls.Add(rtb);
            tabControl1.TabPages.Add(tp);
            tabControl1.SelectTab(tp);
            UpdateRPC("In Menu", "");
        }

        public void closeFile()
        {
            if (0 < tabControl1.TabPages.Count)
            {
                if (tabControl1.SelectedTab.Text.Contains("*"))
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
            if (0 == tabControl1.TabPages.Count)
            {
                newFile();
            }
        }

        public void closeAllFiles()
        {
            if (0 < tabControl1.TabPages.Count)
            {
                if (MessageBox.Show("Are you sure to close all files?", "SkEditor", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    Array.ForEach(Directory.GetFiles(@"C:\ProgramData\SkEditor\"), delegate (string path) { File.Delete(path); });
                    tabControl1.TabPages.Clear();
                }
                
            }
            if (tabControl1.TabPages.Count == 0)
            {
                newFile();
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
                    MessageBox.Show("The link has been copied to the clipboard", "SkEditor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        public static bool isNullOrEmpty(string s)
        {
            bool result;
            result = s == null || s == string.Empty;
            return result;
        }

        private void NewButton_Click(object sender, EventArgs e)
        {
            newFile();
        }

        private void OpenButton_Click(object sender, EventArgs e)
        {
            openFile();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            saveFile();
        }

        private void PrintButton_Click(object sender, EventArgs e)
        {
            PrintDocument p = new PrintDocument();
            p.DocumentName = tabControl1.SelectedTab.Text;
            p.PrintPage += delegate (object sender1, PrintPageEventArgs e1)
            {
                e1.Graphics.DrawString(GetFastColoredTextBox().Text, new Font("Arial", 12), new SolidBrush(Color.Black), new RectangleF(0, 0, p.DefaultPageSettings.PrintableArea.Width, p.DefaultPageSettings.PrintableArea.Height));
            };
            try
            {
                p.Print();
            }
            catch (Exception ex)
            {
                throw new Exception("Exception Occured While Printing", ex);
            }
        }

        private void PastebinButton_Click(object sender, EventArgs e)
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

        private void CloseButton_Click(object sender, EventArgs e)
        {
            closeFile();
        }

        private void CloseAllButton_Click(object sender, EventArgs e)
        {
            closeAllFiles();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void CutButton_Click(object sender, EventArgs e)
        {
            GetFastColoredTextBox().Cut();
        }

        private void CopyButton_Click(object sender, EventArgs e)
        {
            GetFastColoredTextBox().Copy();
        }

        private void PasteButton_Click(object sender, EventArgs e)
        {
            GetFastColoredTextBox().Paste();
        }

        private void UndoButton_Click(object sender, EventArgs e)
        {
            GetFastColoredTextBox().Undo();
        }

        private void RedoButton_Click(object sender, EventArgs e)
        {
            GetFastColoredTextBox().Redo();
        }

        private void FindButton_Click(object sender, EventArgs e)
        {
            FindForm fF = new FindForm(GetFastColoredTextBox());
            fF.Show();
        }

        private void FindAndReplaceButton_Click(object sender, EventArgs e)
        {
            ReplaceForm rF = new ReplaceForm(GetFastColoredTextBox());
            rF.Show();
        }
    }
}
