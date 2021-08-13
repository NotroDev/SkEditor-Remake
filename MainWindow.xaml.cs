using ICSharpCode.AvalonEdit.CodeCompletion;
using ICSharpCode.AvalonEdit.Highlighting;
using ICSharpCode.AvalonEdit.Highlighting.Xshd;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Xml;
using YamlDotNet;
using YamlDotNet.Core;
using YamlDotNet.RepresentationModel;
using System.Drawing;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace SkEditorRemake
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string allExtensions = "All files|*.*|Skript|*.sk|YAML|*.yml; *.yaml|TXT|*.txt";

        public static Border _Border;
        public static TabControl _TabControl;
        public static Menu _MenuStrip;
        public static ContextMenu _ContextMenu;

        string closeText = "";

        public static readonly string applicationPath = new System.Uri(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase)).LocalPath;

        public MainWindow()
        {

            InitializeComponent();

            _Border = Border;
            _MenuStrip = MenuStrip;
            _ContextMenu = ContextMenu;
            _TabControl = tabControl1;

            if (getCustomLanguageText("enabled") == "true")
            {
                Properties.Settings.Default.Language = "Custom";
            }

            TabItem tp = new TabItem();
            ICSharpCode.AvalonEdit.TextEditor textBox = new ICSharpCode.AvalonEdit.TextEditor();
            tp.Content = textBox;
            switch (Properties.Settings.Default.Language)
            {
                case "English":
                    tp.Header = "New file";
                    break;
                case "Polish":
                    tp.Header = "Nowy plik";
                    break;
                case "Custom":
                    tp.Header = getCustomLanguageText("newFileTabName");
                    break;
            }
            tabControl1.Items.Add(tp);

            loadAddons();
        }

        void loadAddons()
        {
            try
            {
                var appdataFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                Directory.CreateDirectory(Path.Combine(appdataFolder, "SkEditorRemake", "Addons"));
                var addonFolder = Path.Combine(appdataFolder, "SkEditorRemake", "Addons");
                foreach (var dllFile in Directory.EnumerateFiles(addonFolder, "*.dll", SearchOption.AllDirectories))
                {
                    var assembly = Assembly.LoadFrom(dllFile);
                    var addonTypes = AppDomain.CurrentDomain.GetAssemblies()
                        .SelectMany(s => s.GetTypes())
                        .Where(p => typeof(ISkEditorRemakeAddon).IsAssignableFrom(p))
                        .Where(w => w.IsClass && !w.IsAbstract);
                    foreach (var addonType in addonTypes)
                    {
                        var addonInstance = (ISkEditorRemakeAddon)Activator.CreateInstance(addonType);
                        addonInstance.Run();
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        bool wantToContinue(string Message)
        {
            if (DialogWindow.showDialog(Message))
            {
                return true;
            }
            return false;
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
                try
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
                        if (Properties.Settings.Default.Language == "English")
                        {
                            OKDialogWindow.showOKDialog("Link has been copied to clipboard.");
                        }
                        else if (Properties.Settings.Default.Language == "Polish")
                        {
                            OKDialogWindow.showOKDialog("Link został skopiowany do schowka.");
                        }
                        else if (Properties.Settings.Default.Language == "Custom")
                        {
                            OKDialogWindow.showOKDialog(getCustomLanguageText("publishCodeLinkCopiedText"));
                        }

                    }
                }
                catch
                {
                    if (Properties.Settings.Default.Language == "English")
                    {
                        OKDialogWindow.showOKDialog("You don't have a internet connection.");
                    }
                    else if (Properties.Settings.Default.Language == "Polish")
                    {
                        OKDialogWindow.showOKDialog("Nie masz połączenia z internetem.");
                    }
                    else if(Properties.Settings.Default.Language == "Custom")
                    {
                        OKDialogWindow.showOKDialog(getCustomLanguageText("noInternetConnection"));
                    }
                }
            }
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            if (tabControl1.SelectedItem != null)
            {
                switch (Properties.Settings.Default.Language)
                {
                    case "English":
                        closeText = "Are you sure to close current file?";
                        break;
                    case "Polish":
                        closeText = "Jesteś pewny, że chcesz aktualny plik?";
                        break;
                    case "Custom":
                        closeText = getCustomLanguageText("closeAppWarning");
                        break;
                }

                if (wantToContinue(closeText))
                {
                    tabControl1.Items.Remove(tabControl1.SelectedItem);
                    GC.Collect();
                }
            }

        }

        private void maximizeButton_Click(object sender, MouseButtonEventArgs e)
        {
            if (MainWindow.GetWindow(this).WindowState == WindowState.Maximized)
            {
                MainWindow.GetWindow(this).WindowState = WindowState.Normal;
            }
            else
            {
                MainWindow.GetWindow(this).WindowState = WindowState.Maximized;
            }
        }
        
        private void minimizeButton_Click(object sender, MouseButtonEventArgs e)
        {
            var anim = new DoubleAnimation(0, (Duration)TimeSpan.FromSeconds(0.2));
            anim.Completed += (s, _) => { MainWindow.GetWindow(this).WindowState = WindowState.Minimized; this.BeginAnimation(UIElement.OpacityProperty, null); };
            this.BeginAnimation(UIElement.OpacityProperty, anim);
        }

        //File (MenuStrip)
        private void newButton_Click(object sender, RoutedEventArgs e)
        {
            newFile();
        }

        private void newFile()
        {
            if (tabControl1.Items.Count < 10)
            {


                TabItem tp = new TabItem();
                ICSharpCode.AvalonEdit.TextEditor textBox = new ICSharpCode.AvalonEdit.TextEditor();
                tp.Content = textBox;
                switch (Properties.Settings.Default.Language)
                {
                    case "English":
                        tp.Header = "New file";
                        break;
                    case "Polish":
                        tp.Header = "Nowy plik";
                        break;
                    case "Custom":
                        tp.Header = getCustomLanguageText("newFileTabName");
                        break;
                }
                tabControl1.Items.Add(tp);

                tabControl1.SelectedItem = tp;
            }
            else
            {
                switch (Properties.Settings.Default.Language)
                {
                    case "English":
                        OKDialogWindow.showOKDialog("Sorry, the program doesn't support opening more than 10 files at once for now.");
                        break;
                    case "Polish":
                        OKDialogWindow.showOKDialog("Przepraszamy, na razie program nie obsługuje otwierania więcej niż 10 plików na raz.");
                        break;
                    case "Custom":
                        OKDialogWindow.showOKDialog(getCustomLanguageText("fileLimitMessage"));
                        break;
                }
            }
        }

        private void openButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = allExtensions;

            if (openDialog.ShowDialog() == true)
            {
                TabItem tp = new TabItem();
                ICSharpCode.AvalonEdit.TextEditor textBox = new ICSharpCode.AvalonEdit.TextEditor();
                tp.Content = textBox;
                tp.Header = openDialog.SafeFileName;
                tp.ToolTip = openDialog.FileName;
                tabControl1.Items.Add(tp);

                tabControl1.SelectedItem = tp;
                GetCurrentTextBox().Load(openDialog.FileName);
            }
        }

        private void saveAsButton_Click(object sender, RoutedEventArgs e)
        {
            saveDialog();
        }

        private void publishCodeButton_Click(object sender, RoutedEventArgs e)
        {
            publishCode(GetCurrentTextBox().Text);
        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            switch (Properties.Settings.Default.Language)
            {
                case "English":
                    closeText = "Are you sure to close application?";
                    break;
                case "Polish":
                    closeText = "Jesteś pewny, że chcesz zamknąć program?";
                    break;
                case "Custom":
                    closeText = getCustomLanguageText("closeAppWarning");
                    break;
            }

            if (wantToContinue(closeText))
            {
                Close();
            }
        }

        //ContextMenu/Edit (MenuStrip)
        private void undoButton_Click(object sender, RoutedEventArgs e)
        {
            GetCurrentTextBox().Undo();
        }

        private void redoButton_Click(object sender, RoutedEventArgs e)
        {
            GetCurrentTextBox().Redo();
        }

        private void cutButton_Click(object sender, RoutedEventArgs e)
        {
            GetCurrentTextBox().Cut();
        }

        private void copyButton_Click(object sender, RoutedEventArgs e)
        {
            GetCurrentTextBox().Copy();
        }

        private void pasteButton_Click(object sender, RoutedEventArgs e)
        {
            GetCurrentTextBox().Paste();
        }

        private void selectAllButton_Click(object sender, RoutedEventArgs e)
        {
            GetCurrentTextBox().SelectAll();
        }
        
        //Shortcuts
        private void shortCutNewButton_Click(object sender, ExecutedRoutedEventArgs e)
        {
            newFile();
        }

        private void shortCutOpenButton_Click(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = allExtensions;

            if (openDialog.ShowDialog() == true)
            {
                TabItem tp = new TabItem();
                ICSharpCode.AvalonEdit.TextEditor textBox = new ICSharpCode.AvalonEdit.TextEditor();
                tp.Content = textBox;
                tp.Header = openDialog.SafeFileName;
                tp.ToolTip = openDialog.FileName;
                tabControl1.Items.Add(tp);

                tabControl1.SelectedItem = tp;
                GetCurrentTextBox().Load(openDialog.FileName);
            }
        }

        private void shortCutSaveAsButton_Click(object sender, ExecutedRoutedEventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = allExtensions;
            if (saveDialog.ShowDialog() == true)
                GetCurrentTextBox().Save(saveDialog.FileName);
        }
        private void shortCutSaveButton_Click(object sender, ExecutedRoutedEventArgs e)
        {
            save();
        }

        private void shortCutPublishCodeButton_Click(object sender, ExecutedRoutedEventArgs e)
        {
            publishCode(GetCurrentTextBox().Text);
        }

        private void shortCutCloseButton_Click(object sender, ExecutedRoutedEventArgs e)
        {
            if (tabControl1.SelectedItem != null)
            {
                switch (Properties.Settings.Default.Language)
                {
                    case "English":
                        closeText = "Are you sure to close current file?";
                        break;
                    case "Polish":
                        closeText = "Jesteś pewny, że chcesz aktualny plik?";
                        break;
                    case "Custom":
                        closeText = getCustomLanguageText("closeFileWarning");
                        break;
                }

                if (wantToContinue(closeText))
                {
                    tabControl1.Items.Remove(tabControl1.SelectedItem);
                }
            }
        }

        private void nameLabelMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void SkEditorImage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void SkEditorLogo_MouseEnter(object sender, MouseEventArgs e)
        {
            ToolTip toolTip = new ToolTip();

            string[] englishWords = { "Hi!", "Hey!", "Hello!", "Good morning!" };

            string[] polishWords = { "Cześć!", "Hej!", "Siemka!", "Witaj!" };

            Random Random = new Random();

            switch (Properties.Settings.Default.Language)
            {
                case "English":
                    toolTip.Content = RandomWord(Random, englishWords);
                    break;
                case "Polish":
                    toolTip.Content = RandomWord(Random, polishWords);
                    break;
                case "Custom":
                    toolTip.Content = "Custom language, huh? :)";
                    break;
            }

            string RandomWord(Random random, string[] lookup) => lookup[random.Next(lookup.Length)];

            SkEditorLogo.ToolTip = toolTip;
        }

        public string getCustomLanguageText(string value)
        {
            using (var reader = new StreamReader("customLanguage.yml"))
            {
                var yaml = new YamlStream();
                yaml.Load(reader);

                var mapping =
                (YamlMappingNode)yaml.Documents[0].RootNode;

                var item = (YamlScalarNode)mapping.Children[new YamlScalarNode(value)];

                return item.Value;
            }
        }

        private void Window_Activated(object sender, EventArgs e)
        {

            if (getCustomLanguageText("enabled") == "true")
            {
                Properties.Settings.Default.Language = "Custom";

                fileMenuStripItem.Header = getCustomLanguageText("fileMenuStripItem");
                editMenuStripItem.Header = getCustomLanguageText("editMenuStripItem");
                otherMenuStripItem.Header = getCustomLanguageText("otherMenuStripItem");

                newFileMenuItem.Header = getCustomLanguageText("newFileMenuItem");
                openFileMenuItem.Header = getCustomLanguageText("openFileMenuItem");
                saveMenuItem.Header = getCustomLanguageText("saveMenuItem");
                saveAsMenuItem.Header = getCustomLanguageText("saveAsMenuItem");
                publishMenuItem.Header = getCustomLanguageText("publishMenuItem");
                closeMenuItem.Header = getCustomLanguageText("closeMenuItem");
                exitMenuItem.Header = getCustomLanguageText("exitMenuItem");

                undoMenuItem.Header = getCustomLanguageText("undoMenuItem");
                redoMenuItem.Header = getCustomLanguageText("redoMenuItem");
                cutMenuItem.Header = getCustomLanguageText("cutMenuItem");
                copyMenuItem.Header = getCustomLanguageText("copyMenuItem");
                pasteMenuItem.Header = getCustomLanguageText("pasteMenuItem");
                selectAllMenuItem.Header = getCustomLanguageText("selectAllMenuItem");

                settingsMenuItem.Header = getCustomLanguageText("settingsMenuItem");
                informationsMenuItem.Header = getCustomLanguageText("informationsMenuItem");
            }

            else
            {
                if (Properties.Settings.Default.Language == "English")
                {
                    setLanguage("English");
                }
                else if (Properties.Settings.Default.Language == "Polish")
                {
                    setLanguage("Polish");
                }
            }
        }

        private void setLanguage(string language)
        {
            if (language == "English")
            {
                fileMenuStripItem.Header = "File";
                editMenuStripItem.Header = "Edit";
                otherMenuStripItem.Header = "Other";

                newFileMenuItem.Header = "New";
                openFileMenuItem.Header = "Open";
                saveMenuItem.Header = "Save";
                saveAsMenuItem.Header = "Save as";
                publishMenuItem.Header = "Publish code";
                closeMenuItem.Header = "Close";
                exitMenuItem.Header = "Exit";

                undoMenuItem.Header = "Undo";
                redoMenuItem.Header = "Redo";
                cutMenuItem.Header = "Cut";
                copyMenuItem.Header = "Copy";
                pasteMenuItem.Header = "Paste";
                selectAllMenuItem.Header = "Select all";

                settingsMenuItem.Header = "Settings";
                informationsMenuItem.Header = "Informations";
            }
            else if (language == "Polish")
            {
                fileMenuStripItem.Header = "Plik";
                editMenuStripItem.Header = "Edycja";
                otherMenuStripItem.Header = "Inne";

                newFileMenuItem.Header = "Nowy";
                openFileMenuItem.Header = "Otwórz";
                saveAsMenuItem.Header = "Zapisz jako";
                saveMenuItem.Header = "Zapisz";
                publishMenuItem.Header = "Opublikuj kod";
                closeMenuItem.Header = "Zamknij plik";
                exitMenuItem.Header = "Wyjdź";

                undoMenuItem.Header = "Cofnij";
                redoMenuItem.Header = "Ponów";
                cutMenuItem.Header = "Wytnij";
                copyMenuItem.Header = "Kopiuj";
                pasteMenuItem.Header = "Wklej";
                selectAllMenuItem.Header = "Zaznacz wszystko";

                settingsMenuItem.Header = "Ustawienia";
                informationsMenuItem.Header = "Informacje";
            }
        }

        private void settingsMenuItem_Click(object sender, RoutedEventArgs e)
        {
            SettingsWindow settingsWindow = new SettingsWindow();

            settingsWindow.ShowDialog();
        }

        private void informationsMenuItem_Click(object sender, RoutedEventArgs e)
        {
            InformationsWindow infoWindow = new InformationsWindow();

            infoWindow.ShowDialog();
        }

        ICSharpCode.AvalonEdit.TextEditor GetCurrentTextBox()
        {
            ICSharpCode.AvalonEdit.TextEditor textEditor = null;
            TabItem tp = tabControl1.SelectedItem as TabItem;
            if (tp != null)
            {
                textEditor = tp.Content as ICSharpCode.AvalonEdit.TextEditor;
            }
            return textEditor;
        }

        private void tabControl1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (tabControl1.SelectedItem != null)
            {
                GetCurrentTextBox().Options.EnableHyperlinks = false;

                using (StreamReader s = new StreamReader("SkriptHighlighting.xshd"))
                {
                    using (XmlTextReader reader = new XmlTextReader(s))
                    {
                        GetCurrentTextBox().SyntaxHighlighting =
                            ICSharpCode.AvalonEdit.Highlighting.Xshd.HighlightingLoader.Load(reader, HighlightingManager.Instance);
                    }
                }

                GetCurrentTextBox().Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(35, 39, 42));
                GetCurrentTextBox().Foreground = new SolidColorBrush(System.Windows.Media.Color.FromRgb(255, 255, 255));
                GetCurrentTextBox().FontFamily = new System.Windows.Media.FontFamily("/SkEditorRemake;component/Fonts/#Ubuntu Mono");
                GetCurrentTextBox().FontSize = 16;
                GetCurrentTextBox().VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
                GetCurrentTextBox().VerticalContentAlignment = VerticalAlignment.Stretch;
                GetCurrentTextBox().HorizontalContentAlignment = HorizontalAlignment.Stretch;
                GetCurrentTextBox().ShowLineNumbers = true;
                GetCurrentTextBox().WordWrap = true;
                GetCurrentTextBox().Cursor = Cursors.None;
                GetCurrentTextBox().LineNumbersForeground = new SolidColorBrush(System.Windows.Media.Color.FromRgb(140, 140, 140));
            }
        }

        void saveDialog()
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            if (saveFile.ShowDialog() == true)
            {
                GetCurrentTextBox().Save(saveFile.FileName);
                TabItem ti = tabControl1.SelectedItem as TabItem;
                ti.ToolTip = saveFile.FileName.ToString();
            }
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            save();
        }

        void save()
        {
            TabItem ti = tabControl1.SelectedItem as TabItem;
            if (ti.ToolTip != null)
            {
                if (ti.ToolTip.ToString() != null && ti.ToolTip.ToString() != "")
                {
                    GetCurrentTextBox().Save(ti.ToolTip.ToString());
                    return;
                }
                saveDialog();
            }
        }

        private void dragMove(object sender, MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            if (e.LeftButton.Equals(MouseButtonState.Pressed))
                DragMove();
        }

        private void maximizeButton_MouseEnter(object sender, MouseEventArgs e)
        {
            maximizeButton.Opacity = 0.7;
        }

        private void maximizeButton_MouseLeave(object sender, MouseEventArgs e)
        {
            maximizeButton.Opacity = 1;
        }

        private void closeButton_MouseEnter(object sender, MouseEventArgs e)
        {
            closeAppButton.Opacity = 0.7;
        }

        private void closeButton_MouseLeave(object sender, MouseEventArgs e)
        {
            closeAppButton.Opacity = 1;
        }

        private void minimizeButton_MouseEnter(object sender, MouseEventArgs e)
        {
            minimizeButton.Opacity = 0.7;
        }

        private void minimizeButton_MouseLeave(object sender, MouseEventArgs e)
        {
            minimizeButton.Opacity = 1;
        }

        private void closeAppButton_Click(object sender, MouseButtonEventArgs e)
        {
            switch (Properties.Settings.Default.Language)
            {
                case "English":
                    closeText = "Are you sure to close application?";
                    break;
                case "Polish":
                    closeText = "Jesteś pewny, że chcesz zamknąć program?";
                    break;
                case "Custom":
                    closeText = getCustomLanguageText("closeAppWarning");
                    break;
            }

            if (wantToContinue(closeText))
            {
                Close();
            }
        }
    }
}