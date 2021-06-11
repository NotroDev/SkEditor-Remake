namespace SkEditor
{
    partial class AboutSkEditorRemake
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutSkEditorRemake));
            this.questionLabel = new System.Windows.Forms.Label();
            this.answerLabel = new System.Windows.Forms.Label();
            this.question2Label = new System.Windows.Forms.Label();
            this.answer2Label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // questionLabel
            // 
            this.questionLabel.AutoSize = true;
            this.questionLabel.Font = new System.Drawing.Font("Comic Sans MS", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.questionLabel.Location = new System.Drawing.Point(12, 10);
            this.questionLabel.Name = "questionLabel";
            this.questionLabel.Size = new System.Drawing.Size(204, 28);
            this.questionLabel.TabIndex = 0;
            this.questionLabel.Text = "Co to jest SkEditor?";
            // 
            // answerLabel
            // 
            this.answerLabel.AutoSize = true;
            this.answerLabel.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.answerLabel.Location = new System.Drawing.Point(16, 43);
            this.answerLabel.Name = "answerLabel";
            this.answerLabel.Size = new System.Drawing.Size(457, 39);
            this.answerLabel.TabIndex = 1;
            this.answerLabel.Text = "SkEditor to edytor skryptów tworzonych w pluginie Skript w grze Minecraft. \r\nStwo" +
    "rzony został przez Glitcztrapa (Kiedyś: Michix).\r\nProjekt został porzucony.\r\n";
            // 
            // question2Label
            // 
            this.question2Label.AutoSize = true;
            this.question2Label.Font = new System.Drawing.Font("Comic Sans MS", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.question2Label.Location = new System.Drawing.Point(14, 105);
            this.question2Label.Name = "question2Label";
            this.question2Label.Size = new System.Drawing.Size(281, 28);
            this.question2Label.TabIndex = 2;
            this.question2Label.Text = "Co to jest SkEditor Remake?";
            // 
            // answer2Label
            // 
            this.answer2Label.AutoSize = true;
            this.answer2Label.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.answer2Label.Location = new System.Drawing.Point(16, 142);
            this.answer2Label.Name = "answer2Label";
            this.answer2Label.Size = new System.Drawing.Size(385, 39);
            this.answer2Label.TabIndex = 3;
            this.answer2Label.Text = "SkEditor Remake to przerobiona i ulepszona wersja SkEditora.\r\nProgram został stwo" +
    "rzony ze względu na porzucenie oryginalnego.\r\nTworzony jest przez NotroDeva.";
            // 
            // AboutSkEditorRemake
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 205);
            this.Controls.Add(this.answer2Label);
            this.Controls.Add(this.question2Label);
            this.Controls.Add(this.answerLabel);
            this.Controls.Add(this.questionLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutSkEditorRemake";
            this.Text = "About SkEditor Remake";
            this.Load += new System.EventHandler(this.AboutSkEditorRemake_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label questionLabel;
        private System.Windows.Forms.Label answerLabel;
        private System.Windows.Forms.Label question2Label;
        private System.Windows.Forms.Label answer2Label;
    }
}