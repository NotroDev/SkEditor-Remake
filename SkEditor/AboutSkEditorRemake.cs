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
    public partial class AboutSkEditorRemake : Form
    {
        public AboutSkEditorRemake()
        {
            InitializeComponent();
        }

        private void AboutSkEditorRemake_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Lang == "Polish")
            {
                questionLabel.Text = "Co to jest SkEditor?";
                question2Label.Text = "Co to jest SkEditor Remake?";

                answerLabel.Text = "SkEditor to edytor skryptów tworzonych w pluginie Skript w grze Minecraft.\nStworzony został przez Michixa.\nProjekt został porzucony.";
                answer2Label.Text = "SkEditor Remake to przerobiona i ulepszona wersja SkEditora.\nProgram został stworzony ze względu na porzucenie oryginalnego.\nTworzony jest przez NotroDeva.";
            }
            else
            {
                questionLabel.Text = "What is SkEditor?";
                question2Label.Text = "What is SkEditor Remake?";

                answerLabel.Text = "SkEditor is an editor for scripts created in the Skript plugin in Minecraft.\nIt was created by Michix.\nProject was abandoned.";
                answer2Label.Text = "SkEditor Remake is a reworked and improved version of SkEditor.\nProgram was created due to the abandonment of the original.\nCreated by NotroDev.";
            }
        }
    }
}
