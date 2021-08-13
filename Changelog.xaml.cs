using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;
using System.IO.Compression;
using System.Net;
using Xam;
using Xam.Animations;
using YamlDotNet.RepresentationModel;

namespace SkEditorRemake
{
    /// <summary>
    /// Logika interakcji dla klasy SettingsWindow.xaml
    /// </summary>
    public partial class ChangelogWindow : Window
    {
        public ChangelogWindow()
        {
            InitializeComponent();
        }

        private void nameLabelMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            if (e.LeftButton.Equals(MouseButtonState.Pressed))
                DragMove();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Closing -= Window_Closing;
            e.Cancel = true;
            var anim = new DoubleAnimation(0, (Duration)TimeSpan.FromSeconds(0.2));
            anim.Completed += (s, _) => this.Close();
            this.BeginAnimation(UIElement.OpacityProperty, anim);
        }

        private void closeButton_Click(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void changelogTextBlock_Loaded(object sender, RoutedEventArgs e)
        {
            switch (Properties.Settings.Default.Language)
            {
                case "English":
                    changelogTextblock.Text = "Nothing here...";
                    break;
                case "Polish":
                    changelogTextblock.Text = "Pustka...";
                    break;
                case "Custom":
                    changelogTextblock.Text = getCustomLanguageText("changelogNotLoaded");
                    break;
            }
        }

        private void ChangelogText_MouseEnter(object sender, MouseEventArgs e)
        {
            loadText.TextDecorations = TextDecorations.Underline;
        }

        private void ChangelogText_MouseLeave(object sender, MouseEventArgs e)
        {
            loadText.TextDecorations = null;
        }

        private void ChangelogText_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                WebClient webClient = new WebClient();
                string changelogText = webClient.DownloadString("https://drive.google.com/uc?export=download&id=1CrEFe5-aLZvBLiXLoBlgF0MAL9hB_zx0");
                changelogTextblock.Text = changelogText;
            }
            catch
            {
                OKDialogWindow.showOKDialog("Nie masz internetu, przez co nie\n można wyświetlić changelogu.");
            }
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

        private void loadText_Loaded(object sender, RoutedEventArgs e)
        {
            switch (Properties.Settings.Default.Language)
            {
                case "English":
                    loadText.Text = "Load";
                    break;
                case "Polish":
                    loadText.Text = "Załaduj";
                    break;
                case "Custom":
                    loadText.Text = getCustomLanguageText("loadChangelogLabel");
                    break;
            }
        }
    }
}