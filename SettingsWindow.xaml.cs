using System;
using System.Collections.Generic;
using System.IO;
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
using YamlDotNet.RepresentationModel;

namespace SkEditorRemake
{
    /// <summary>
    /// Logika interakcji dla klasy SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        public SettingsWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ChangeLanguage();
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
            Close();
        }

        private void languageComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (languageComboBox.SelectedIndex == 0)
            {
                Properties.Settings.Default.Language = "English";
                Properties.Settings.Default.Save();
            }
            else if (languageComboBox.SelectedIndex == 1)
            {
                Properties.Settings.Default.Language = "Polish";
                Properties.Settings.Default.Save();
            }
            ChangeLanguage();
        }

        private void ChangeLanguage()
        {
            if (Properties.Settings.Default.Language == "English")
            {
                languageComboBox.SelectedIndex = 0;
                languageText.Text = "Language";
            }
            else if (Properties.Settings.Default.Language == "Polish")
            {
                languageComboBox.SelectedIndex = 1;
                languageText.Text = "Język";
            }
            else if (Properties.Settings.Default.Language == "Custom")
            {
                ToolTip toolTip = new ToolTip();
                switch (Properties.Settings.Default.Language)
                {
                    case "English":
                        toolTip.Content = "To ustawienie nie może być zmienione, ponieważ wybrany jest język własny.";
                        break;
                    case "Polish":
                        toolTip.Content = "This setting can't be changed, because selected is custom language.";
                        break;
                    case "Custom":
                        toolTip.Content = getCustomLanguageText("customLangSelected");
                        break;
                }

                languageText.ToolTip = toolTip;

                ComboBoxItem customItem = new ComboBoxItem();
                customItem.Content = "Custom";

                languageComboBox.Items.Add(customItem);
                languageComboBox.SelectedIndex = 2;
                languageComboBox.IsEnabled = false;

                languageText.Text = getCustomLanguageText("languageLabel");
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

        private void closeButton_MouseEnter(object sender, MouseEventArgs e)
        {
            closeButton.Opacity = 0.7;
        }

        private void closeButton_MouseLeave(object sender, MouseEventArgs e)
        {
            closeButton.Opacity = 1;
        }
    }
}
