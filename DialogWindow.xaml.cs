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
    /// Logika interakcji dla klasy Window1.xaml
    /// </summary>
    public partial class DialogWindow : Window
    {
        public DialogWindow()
        {
            InitializeComponent();
        }

        private void closeButton_Click(object sender, MouseButtonEventArgs e)
        {
            this.DialogResult = false;
            Close();
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            if (e.LeftButton.Equals(MouseButtonState.Pressed))
                DragMove();
        }

        private void nameLabelMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            if (e.LeftButton.Equals(MouseButtonState.Pressed))
                DragMove();
        }

        private void yesButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        public static bool showDialog(string text)
        {
            DialogWindow dialog = new DialogWindow();
            dialog.TextLabel.Text = text;
            return (bool)dialog.ShowDialog();
        }

        private void DialogWindow_Loaded(object sender, RoutedEventArgs e)
        {
            if (Properties.Settings.Default.Language == "Polish")
            {
                yesButton.Content = "Tak";
                noButton.Content = "Nie";
            }
            else if (Properties.Settings.Default.Language == "English")
            {
                yesButton.Content = "Yes";
                noButton.Content = "No";
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if ((bool) this.DialogResult == false)
            {
                Closing -= Window_Closing;
                e.Cancel = true;
                var anim = new DoubleAnimation(0, (Duration)TimeSpan.FromSeconds(0.2));
                anim.Completed += (s, _) => this.Close();
                this.BeginAnimation(UIElement.OpacityProperty, anim);
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
