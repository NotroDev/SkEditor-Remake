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
            var anim = new DoubleAnimation(0, (Duration)TimeSpan.FromSeconds(0.5));
            anim.Completed += (s, _) => this.Close();
            this.BeginAnimation(UIElement.OpacityProperty, anim);
        }

        private void closeButton_Click(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void changelogTextBlock_Loaded(object sender, RoutedEventArgs e)
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
                changelogTextblock.Text = "Pustka...";
            }
        }
    }
}
