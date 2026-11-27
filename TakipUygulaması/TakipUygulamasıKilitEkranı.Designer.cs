namespace TakipUygulaması
{
    partial class TakipUygulamasıKilitEkranı
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Kilit_ŞifreTextBox = new TextBox();
            Kilit_ŞifreLabel = new Label();
            Kilit_ÇıkışButon = new Button();
            SuspendLayout();
            // 
            // Kilit_ŞifreTextBox
            // 
            Kilit_ŞifreTextBox.Anchor = AnchorStyles.None;
            Kilit_ŞifreTextBox.Location = new Point(142, 128);
            Kilit_ŞifreTextBox.Name = "Kilit_ŞifreTextBox";
            Kilit_ŞifreTextBox.Size = new Size(125, 23);
            Kilit_ŞifreTextBox.TabIndex = 0;
            Kilit_ŞifreTextBox.TextChanged += Kilit_ŞifreTextBox_TextChanged;
            // 
            // Kilit_ŞifreLabel
            // 
            Kilit_ŞifreLabel.Anchor = AnchorStyles.None;
            Kilit_ŞifreLabel.AutoSize = true;
            Kilit_ŞifreLabel.BackColor = Color.Black;
            Kilit_ŞifreLabel.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 162);
            Kilit_ŞifreLabel.ForeColor = SystemColors.Control;
            Kilit_ŞifreLabel.Location = new Point(160, 72);
            Kilit_ŞifreLabel.Name = "Kilit_ŞifreLabel";
            Kilit_ŞifreLabel.Size = new Size(89, 45);
            Kilit_ŞifreLabel.TabIndex = 1;
            Kilit_ŞifreLabel.Text = "Şifre";
            // 
            // Kilit_ÇıkışButon
            // 
            Kilit_ÇıkışButon.Anchor = AnchorStyles.None;
            Kilit_ÇıkışButon.Location = new Point(169, 235);
            Kilit_ÇıkışButon.Name = "Kilit_ÇıkışButon";
            Kilit_ÇıkışButon.Size = new Size(75, 23);
            Kilit_ÇıkışButon.TabIndex = 2;
            Kilit_ÇıkışButon.Text = "KAPAT";
            Kilit_ÇıkışButon.UseVisualStyleBackColor = true;
            Kilit_ÇıkışButon.Click += Kilit_ÇıkışButon_Click;
            // 
            // TakipUygulamasıKilitEkranı
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = Color.Black;
            ClientSize = new Size(419, 283);
            ControlBox = false;
            Controls.Add(Kilit_ÇıkışButon);
            Controls.Add(Kilit_ŞifreLabel);
            Controls.Add(Kilit_ŞifreTextBox);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MinimumSize = new Size(419, 289);
            Name = "TakipUygulamasıKilitEkranı";
            Opacity = 0.75D;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "KilitEkranı";
            TransparencyKey = Color.LightSalmon;
            Load += TakipUygulamasıKilitEkranı_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox Kilit_ŞifreTextBox;
        private Label Kilit_ŞifreLabel;
        private Button Kilit_ÇıkışButon;
    }
}
