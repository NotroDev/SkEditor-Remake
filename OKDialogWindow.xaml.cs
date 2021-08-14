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
    /// Logika interakcji dla klasy OKDialogWindow.xaml
    /// </summary>
    public partial class OKDialogWindow : Window
    {
        public OKDialogWindow()
        {
            InitializeComponent();
        }

        public static bool showOKDialog(string text)
        {
            OKDialogWindow dialog = new OKDialogWindow();
            dialog.TextLabel.Text = text;
            return (bool)dialog.ShowDialog();
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
