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
        public static ICSharpCode.AvalonEdit.TextEditor _TextEditor;
        public static Menu _MenuStrip;
        public static ContextMenu _ContextMenu;

        string closeText = "";


        public MainWindow()
        {

            InitializeComponent();

            _Border = Border;
            _TextEditor = AvalonEdit;
            _MenuStrip = MenuStrip;
            _ContextMenu = ContextMenu;
            AvalonEdit.Options.EnableHyperlinks = false;
            if (App.startupFile != null)
                AvalonEdit.Load(App.startupFile);

            using (StreamReader s = new StreamReader("SkriptHighlighting.xshd"))
            {
                using (XmlTextReader reader = new XmlTextReader(s))
                {
                    AvalonEdit.SyntaxHighlighting =
                        ICSharpCode.AvalonEdit.Highlighting.Xshd.HighlightingLoader.Load(reader, HighlightingManager.Instance);
                }
            }

            using (var reader = new StreamReader("test.yml"))
            {
                var yaml = new YamlStream();
                yaml.Load(reader);

                var mapping =
                (YamlMappingNode)yaml.Documents[0].RootNode;

                var item1 = (YamlScalarNode)mapping.Children[new YamlScalarNode("textBoxColor")];

                string textBoxColor = item1.Value;

                var converter = new System.Windows.Media.BrushConverter();
                var brush = (System.Windows.Media.Brush) converter.ConvertFromString(textBoxColor);

                //AvalonEdit.Background = brush;
            }



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

                }
            }
        }

        private void closeButton_Click(object sender, MouseButtonEventArgs e)
        {
            if (Properties.Settings.Default.Language == "English")
            {
                closeText = "Are you sure to close current file?";
            }
            else if (Properties.Settings.Default.Language == "Polish")
            {
                closeText = "Jesteś pewny, że chcesz zamknąć\naktualny plik?";
            }

            if (wantToContinue(closeText))
            {
                Close();
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
            var anim = new DoubleAnimation(0, (Duration)TimeSpan.FromSeconds(0.5));
            anim.Completed += (s, _) => { MainWindow.GetWindow(this).WindowState = WindowState.Minimized; this.BeginAnimation(UIElement.OpacityProperty, null); };
            this.BeginAnimation(UIElement.OpacityProperty, anim);
        }

        //File (MenuStrip)
        private void newButton_Click(object sender, RoutedEventArgs e)
        {
            if (Properties.Settings.Default.Language == "English")
            {
                closeText = "Are you sure to close current file?";
            }
            else if (Properties.Settings.Default.Language == "Polish")
            {
                closeText = "Jesteś pewny, że chcesz zamknąć\naktualny plik?";
            }

            if (wantToContinue(closeText))
                AvalonEdit.Text = "";
        }

        private void openButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = allExtensions;
            if (openDialog.ShowDialog() == true)
            {
                if (Properties.Settings.Default.Language == "English")
                {
                    closeText = "Are you sure to close current file?";
                }
                else if (Properties.Settings.Default.Language == "Polish")
                {
                    closeText = "Jesteś pewny, że chcesz zamknąć\naktualny plik?";
                }

                if (wantToContinue(closeText))
                    AvalonEdit.Load(openDialog.FileName);
            }
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = allExtensions;
            if (saveDialog.ShowDialog() == true)
                AvalonEdit.Save(saveDialog.FileName);
        }

        private void publishCodeButton_Click(object sender, RoutedEventArgs e)
        {
            publishCode(AvalonEdit.Text);
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            if (Properties.Settings.Default.Language == "English")
            {
                closeText = "Are you sure to close current file?";
            }
            else if (Properties.Settings.Default.Language == "Polish")
            {
                closeText = "Jesteś pewny, że chcesz zamknąć\naktualny plik?";
            }

            if (wantToContinue(closeText))
                AvalonEdit.Text = "";
        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            if (Properties.Settings.Default.Language == "English")
            {
                closeText = "Are you sure to close current file?";
            }
            else if (Properties.Settings.Default.Language == "Polish")
            {
                closeText = "Jesteś pewny, że chcesz zamknąć\naktualny plik?";
            }

            if (wantToContinue(closeText))
                Close();
        }

        //ContextMenu/Edit (MenuStrip)
        private void undoButton_Click(object sender, RoutedEventArgs e)
        {
            AvalonEdit.Undo();
        }

        private void redoButton_Click(object sender, RoutedEventArgs e)
        {
            AvalonEdit.Redo();
        }

        private void cutButton_Click(object sender, RoutedEventArgs e)
        {
            AvalonEdit.Cut();
        }

        private void copyButton_Click(object sender, RoutedEventArgs e)
        {
            AvalonEdit.Copy();
        }

        private void pasteButton_Click(object sender, RoutedEventArgs e)
        {
            AvalonEdit.Paste();
        }

        private void selectAllButton_Click(object sender, RoutedEventArgs e)
        {
            AvalonEdit.SelectAll();
        }
        
        //Shortcuts
        private void shortCutNewButton_Click(object sender, ExecutedRoutedEventArgs e)
        {
            if (Properties.Settings.Default.Language == "English")
            {
                closeText = "Are you sure to close current file?";
            }
            else if (Properties.Settings.Default.Language == "Polish")
            {
                closeText = "Jesteś pewny, że chcesz zamknąć\naktualny plik?";
            }

            if (wantToContinue(closeText))
                AvalonEdit.Text = "";
        }

        private void shortCutOpenButton_Click(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = allExtensions;
            if (openDialog.ShowDialog() == true)
            {
                if (Properties.Settings.Default.Language == "English")
                {
                    closeText = "Are you sure to close current file?";
                }
                else if (Properties.Settings.Default.Language == "Polish")
                {
                    closeText = "Jesteś pewny, że chcesz zamknąć\naktualny plik?";
                }

                if (wantToContinue(closeText))
                    AvalonEdit.Load(openDialog.FileName);
            }
        }

        private void shortCutSaveButton_Click(object sender, ExecutedRoutedEventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = allExtensions;
            if (saveDialog.ShowDialog() == true)
                AvalonEdit.Save(saveDialog.FileName);
        }

        private void shortCutPublishCodeButton_Click(object sender, ExecutedRoutedEventArgs e)
        {
            publishCode(AvalonEdit.Text);
        }

        private void shortCutCloseButton_Click(object sender, ExecutedRoutedEventArgs e)
        {
            if (Properties.Settings.Default.Language == "English")
            {
                closeText = "Are you sure to close current file?";
            }
            else if (Properties.Settings.Default.Language == "Polish")
            {
                closeText = "Jesteś pewny, że chcesz zamknąć\naktualny plik?";
            }

            if (wantToContinue(closeText))
                AvalonEdit.Text = "";
        }

        private void nameLabelMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            if (e.LeftButton.Equals(MouseButtonState.Pressed))
                DragMove();
        }

        private void SkEditorImage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void SkEditorLogo_MouseEnter(object sender, MouseEventArgs e)
        {
            ToolTip toolTip = new ToolTip();

            Random rnd = new Random();
            int random = rnd.Next(1, 5);

            if (Properties.Settings.Default.Language == "English")
            {
                if (random == 1)
                {
                    toolTip.Content = "Hi!";
                }
                else if (random == 2)
                {
                    toolTip.Content = "Hey!";
                }
                else if (random == 3)
                {
                    toolTip.Content = "Hello!";
                }
                else if (random == 3)
                {
                    toolTip.Content = "Hello!";
                }
                else if (random == 4)
                {
                    toolTip.Content = "Good morning!";
                }
            }
            else if (Properties.Settings.Default.Language == "Polish")
            {
                if (random == 1)
                {
                    toolTip.Content = "Cześć!";
                }
                else if (random == 2)
                {
                    toolTip.Content = "Hej!";
                }
                else if (random == 3)
                {
                    toolTip.Content = "Siemka!";
                }
                else if (random == 4)
                {
                    toolTip.Content = "Witam!";
                }
            }

            SkEditorLogo.ToolTip = toolTip;
        }

        private void Window_Activated(object sender, EventArgs e)
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
    }
}