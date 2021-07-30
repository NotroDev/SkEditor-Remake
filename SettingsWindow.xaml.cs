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
            ChangeTheme();
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
            var anim = new DoubleAnimation(0, (Duration)TimeSpan.FromSeconds(0.5));
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
                themeText.Text = "Theme (?)";
                themeComboBox.Items[0] = "Light";
                themeComboBox.Items[1] = "Dark";
            }
            else if (Properties.Settings.Default.Language == "Polish")
            {
                languageComboBox.SelectedIndex = 1;
                languageText.Text = "Język";
                themeText.Text = "Motyw (?)";
                themeComboBox.Items[0] = "Jasny";
                themeComboBox.Items[1] = "Ciemny";
            }
        }
        private void ChangeTheme()
        {
            //Theme changing isn't avaible in this version - setting theme to Dark.

            /*if (Properties.Settings.Default.Theme == "Light")
            {
                themeComboBox.SelectedIndex = 0;
            }
            else if (Properties.Settings.Default.Theme == "Dark")
            {
                themeComboBox.SelectedIndex = 1;
            }*/
            themeComboBox.SelectedIndex = 1;
        }

        private void themeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (themeComboBox.SelectedIndex == 0)
            {
                Properties.Settings.Default.Theme = "Light";
                Properties.Settings.Default.Save();
            }
            else if (themeComboBox.SelectedIndex == 1)
            {
                Properties.Settings.Default.Theme = "Dark";
                Properties.Settings.Default.Save();
            }
            ChangeTheme();
        }

        private void themeText_MouseEnter(object sender, MouseEventArgs e)
        {
            ToolTip toolTip = new ToolTip();

            if (Properties.Settings.Default.Language == "English")
            {
                toolTip.Content = "Theme changing isn't avaible yet.";
            }
            else if (Properties.Settings.Default.Language == "Polish")
            {
                toolTip.Content = "Zmiana motywu nie jest jeszcze dostępna.";
            }

            themeText.ToolTip = toolTip;
        }
    }
}
