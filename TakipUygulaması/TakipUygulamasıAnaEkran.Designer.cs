namespace TakipUygulaması
{
    partial class Todo_ArkaPlan
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
            AnaEkran_SabitleButon = new Button();
            AnaEkran_todoButon = new Button();
            Todo_AnaEkranGeri = new Button();
            AnaEkranIcerikPaneli = new Panel();
            SuspendLayout();
            // 
            // AnaEkran_SabitleButon
            // 
            AnaEkran_SabitleButon.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            AnaEkran_SabitleButon.Location = new Point(201, 805);
            AnaEkran_SabitleButon.Name = "AnaEkran_SabitleButon";
            AnaEkran_SabitleButon.Size = new Size(87, 24);
            AnaEkran_SabitleButon.TabIndex = 0;
            AnaEkran_SabitleButon.Text = "Sabitle";
            AnaEkran_SabitleButon.UseVisualStyleBackColor = true;
            AnaEkran_SabitleButon.Click += AnaEkran_SabitleButon_Click;
            AnaEkran_SabitleButon.MouseEnter += AnaEkran_MouseTetiklenmeGiriş;
            AnaEkran_SabitleButon.MouseLeave += AnaEkran_MouseTetiklenmeÇıkış;
            // 
            // AnaEkran_todoButon
            // 
            AnaEkran_todoButon.Location = new Point(12, 12);
            AnaEkran_todoButon.Name = "AnaEkran_todoButon";
            AnaEkran_todoButon.Size = new Size(80, 35);
            AnaEkran_todoButon.TabIndex = 1;
            AnaEkran_todoButon.Text = "Yapılacaklar";
            AnaEkran_todoButon.UseVisualStyleBackColor = true;
            AnaEkran_todoButon.Click += AnaEkran_todoButon_Click;
            // 
            // Todo_AnaEkranGeri
            // 
            Todo_AnaEkranGeri.Location = new Point(252, 12);
            Todo_AnaEkranGeri.Name = "Todo_AnaEkranGeri";
            Todo_AnaEkranGeri.Size = new Size(36, 35);
            Todo_AnaEkranGeri.TabIndex = 5;
            Todo_AnaEkranGeri.Text = "Geri";
            Todo_AnaEkranGeri.UseVisualStyleBackColor = true;
            Todo_AnaEkranGeri.Visible = false;
            Todo_AnaEkranGeri.Click += Todo_AnaEkranGeri_Click;
            // 
            // AnaEkranIcerikPaneli
            // 
            AnaEkranIcerikPaneli.Location = new Point(0, 0);
            AnaEkranIcerikPaneli.Name = "AnaEkranIcerikPaneli";
            AnaEkranIcerikPaneli.Size = new Size(300, 840);
            AnaEkranIcerikPaneli.TabIndex = 6;
            AnaEkranIcerikPaneli.Visible = false;
            // 
            // Todo_ArkaPlan
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(300, 840);
            Controls.Add(AnaEkran_SabitleButon);
            Controls.Add(Todo_AnaEkranGeri);
            Controls.Add(AnaEkranIcerikPaneli);
            Controls.Add(AnaEkran_todoButon);
            FormBorderStyle = FormBorderStyle.None;
            Location = new Point(-8, 0);
            Name = "Todo_ArkaPlan";
            Opacity = 0.75D;
            StartPosition = FormStartPosition.Manual;
            Text = "TakipUygulamasıAnaEkran";
            Deactivate += AnaEkran_MouseTetiklenmeÇıkış;
            Load += TakipUygulamasıAnaEkran_Load;
            MouseEnter += AnaEkran_MouseTetiklenmeGiriş;
            MouseLeave += AnaEkran_MouseTetiklenmeÇıkış;
            ResumeLayout(false);
        }

        #endregion

        public Button AnaEkran_SabitleButon;
        public Button AnaEkran_todoButon;
        public Button Todo_AnaEkranGeri;
        private Panel AnaEkranIcerikPaneli;
    }
}