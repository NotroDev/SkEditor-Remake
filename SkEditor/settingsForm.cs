using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SkEditor
{
    public partial class settingsForm : Form
    {
        public settingsForm()
        {
            InitializeComponent();
        }

        private void settingsForm_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Panel == "Enabled")
            {
                panelCheckBox.Checked = true;
            }
            else
            {
                panelCheckBox.Checked = false;
            }

            if (Properties.Settings.Default.Lang == "Polish")
            {
                this.Text = "Ustawienia";
                languageGroupBox.Text = "Język";
                themeGroupBox.Text = "Motyw";
                languageComboBox.SelectedIndex = 1;
                themeComboBox.Items[0] = "Jasny";
                themeComboBox.Items[1] = "Ciemny";
            }
            else if (Properties.Settings.Default.Lang == "English")
            {
                this.Text = "Settings";
                languageGroupBox.Text = "Language";
                themeGroupBox.Text = "Theme";
                languageComboBox.SelectedIndex = 0;
                themeComboBox.Items[0] = "Light";
                themeComboBox.Items[1] = "Dark";
            }
            
            if (Properties.Settings.Default.Mode == "Light")
            {
                themeComboBox.SelectedIndex = 0;
            }
            else if (Properties.Settings.Default.Mode == "Dark")
            {
                themeComboBox.SelectedIndex = 1;
            }
        }

        private void checkBox1_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Panel po lewej stronie edytora.", panelCheckBox);
        }

        private void panelCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (panelCheckBox.Checked)
            {
                Properties.Settings.Default.Panel = "Enabled";
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.Panel = "Disabled";
                Properties.Settings.Default.Save();
            }
        }

        private void themeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (themeComboBox.SelectedIndex == 0)
            {
                Properties.Settings.Default.Mode = "Light";
                Properties.Settings.Default.Save();
            }
            else if (themeComboBox.SelectedIndex == 1)
            {
                Properties.Settings.Default.Mode = "Dark";
                Properties.Settings.Default.Save();
            }
        }

        private void languageComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (languageComboBox.SelectedIndex == 0)
            {
                Properties.Settings.Default.Lang = "English";
                Properties.Settings.Default.Save();
            }
            else if (languageComboBox.SelectedIndex == 1)
            {
                Properties.Settings.Default.Lang = "Polish";
                Properties.Settings.Default.Save();
            }
        }
    }
}
