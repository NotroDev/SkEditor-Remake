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
    public partial class InformationsWindow : Window
    {
        public InformationsWindow()
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

        private void ChangeLanguage()
        {
            if (Properties.Settings.Default.Language == "English")
            {
                GeneralInfoText.Text = "General info";
                GeneralInfoSubText.Text = "The program was created by Notro. The syntax highlighting is inspired by the highlighting from code.skript.pl site. The program is in an early version. Much will change for the better, and if I can access a few things, I'll be able to introduce some great features.";
                ContactText.Text = "Contact";
                ContactSubText.Text = "If you want to contact me, send me a Discord friend request - Notro#3737";
            }
            else if (Properties.Settings.Default.Language == "Polish")
            {
                GeneralInfoText.Text = "Podstawowe informacje";
                GeneralInfoSubText.Text = "Program został stworzony przez Notro. Podświetlanie składni jest inspirowane podświetlaniem ze strony code.skript.pl. Program jest we wczesnej wersji. Wiele zmieni się na lepsze, a jeśli uda mi się uzyskać dostęp do kilku rzeczy, będę mógł wprowadzić kilka fajnych funkcji.";
                ContactText.Text = "Kontakt";
                ContactSubText.Text = "Jeśli chcesz się ze mną skontaktować, wyślij mi zaproszenie do znajomych na Discordzie - Notro#3737";
            }
        }
        private void ChangeTheme()
        {
            
        }

        private void ChangelogText_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ChangelogWindow changelogWindow = new ChangelogWindow();
            changelogWindow.ShowDialog();
        }

        private void ChangelogText_MouseEnter(object sender, MouseEventArgs e)
        {
            ChangelogText.TextDecorations = TextDecorations.Underline;
        }

        private void ChangelogText_MouseLeave(object sender, MouseEventArgs e)
        {
            ChangelogText.TextDecorations = null;
        }
    }
}
