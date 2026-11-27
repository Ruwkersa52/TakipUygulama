namespace TakipUygulaması
{
    partial class TodoController
    {
        /// <summary> 
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Bileşen Tasarımcısı üretimi kod

        /// <summary> 
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            Todo_BitişTarihiDatePicker = new DateTimePicker();
            Todo_ÖnemYüksek = new RadioButton();
            Todo_ÖnemOrta = new RadioButton();
            Todo_ÖnemDüşük = new RadioButton();
            Todo_FlowPanel = new FlowLayoutPanel();
            Todo_İçerikTextButon = new Button();
            Todo_İçerikTextBox = new TextBox();
            Todo_BaşlıkTextBox = new TextBox();
            Todo_YapilacakOluşturButon = new Button();
            Todo_YapılacaklarLabel = new Label();
            Todo_BaşlıkTextButon = new Button();
            Todo_YapilacakEkleButon = new Button();
            Todo_AramaTextBox = new TextBox();
            Todo_BitişTarihiDatePickerController = new CheckBox();
            SuspendLayout();
            // 
            // Todo_BitişTarihiDatePicker
            // 
            Todo_BitişTarihiDatePicker.CalendarMonthBackground = Color.White;
            Todo_BitişTarihiDatePicker.Location = new Point(83, 620);
            Todo_BitişTarihiDatePicker.Name = "Todo_BitişTarihiDatePicker";
            Todo_BitişTarihiDatePicker.Size = new Size(182, 23);
            Todo_BitişTarihiDatePicker.TabIndex = 26;
            Todo_BitişTarihiDatePicker.ValueChanged += Todo_BitişTarihiDatePicker_ValueChanged;
            // 
            // Todo_ÖnemYüksek
            // 
            Todo_ÖnemYüksek.AutoSize = true;
            Todo_ÖnemYüksek.ForeColor = SystemColors.ControlLight;
            Todo_ÖnemYüksek.Location = new Point(19, 668);
            Todo_ÖnemYüksek.Name = "Todo_ÖnemYüksek";
            Todo_ÖnemYüksek.Size = new Size(62, 19);
            Todo_ÖnemYüksek.TabIndex = 25;
            Todo_ÖnemYüksek.TabStop = true;
            Todo_ÖnemYüksek.Text = "Yüksek";
            Todo_ÖnemYüksek.UseVisualStyleBackColor = true;
            Todo_ÖnemYüksek.Click += Todo_ÖnemYüksek_Click;
            // 
            // Todo_ÖnemOrta
            // 
            Todo_ÖnemOrta.AutoSize = true;
            Todo_ÖnemOrta.ForeColor = SystemColors.ControlLight;
            Todo_ÖnemOrta.Location = new Point(19, 643);
            Todo_ÖnemOrta.Name = "Todo_ÖnemOrta";
            Todo_ÖnemOrta.Size = new Size(48, 19);
            Todo_ÖnemOrta.TabIndex = 24;
            Todo_ÖnemOrta.TabStop = true;
            Todo_ÖnemOrta.Text = "Orta";
            Todo_ÖnemOrta.UseVisualStyleBackColor = true;
            Todo_ÖnemOrta.Click += Todo_ÖnemOrta_Click;
            // 
            // Todo_ÖnemDüşük
            // 
            Todo_ÖnemDüşük.AutoSize = true;
            Todo_ÖnemDüşük.ForeColor = SystemColors.ControlLight;
            Todo_ÖnemDüşük.Location = new Point(19, 621);
            Todo_ÖnemDüşük.Name = "Todo_ÖnemDüşük";
            Todo_ÖnemDüşük.Size = new Size(58, 19);
            Todo_ÖnemDüşük.TabIndex = 23;
            Todo_ÖnemDüşük.TabStop = true;
            Todo_ÖnemDüşük.Text = "Düşük";
            Todo_ÖnemDüşük.UseVisualStyleBackColor = true;
            Todo_ÖnemDüşük.Click += Todo_ÖnemDüşük_Click;
            // 
            // Todo_FlowPanel
            // 
            Todo_FlowPanel.AutoScroll = true;
            Todo_FlowPanel.BackColor = Color.DimGray;
            Todo_FlowPanel.FlowDirection = FlowDirection.BottomUp;
            Todo_FlowPanel.Location = new Point(11, 73);
            Todo_FlowPanel.Name = "Todo_FlowPanel";
            Todo_FlowPanel.Size = new Size(275, 300);
            Todo_FlowPanel.TabIndex = 17;
            Todo_FlowPanel.WrapContents = false;
            // 
            // Todo_İçerikTextButon
            // 
            Todo_İçerikTextButon.Location = new Point(114, 482);
            Todo_İçerikTextButon.Name = "Todo_İçerikTextButon";
            Todo_İçerikTextButon.Size = new Size(66, 24);
            Todo_İçerikTextButon.TabIndex = 22;
            Todo_İçerikTextButon.Text = "İçerik";
            Todo_İçerikTextButon.UseVisualStyleBackColor = true;
            Todo_İçerikTextButon.Click += Todo_İçerikTextButon_Click;
            // 
            // Todo_İçerikTextBox
            // 
            Todo_İçerikTextBox.Location = new Point(20, 512);
            Todo_İçerikTextBox.Multiline = true;
            Todo_İçerikTextBox.Name = "Todo_İçerikTextBox";
            Todo_İçerikTextBox.Size = new Size(261, 93);
            Todo_İçerikTextBox.TabIndex = 21;
            // 
            // Todo_BaşlıkTextBox
            // 
            Todo_BaşlıkTextBox.BackColor = Color.White;
            Todo_BaşlıkTextBox.Location = new Point(20, 442);
            Todo_BaşlıkTextBox.Name = "Todo_BaşlıkTextBox";
            Todo_BaşlıkTextBox.Size = new Size(261, 23);
            Todo_BaşlıkTextBox.TabIndex = 19;
            // 
            // Todo_YapilacakOluşturButon
            // 
            Todo_YapilacakOluşturButon.Location = new Point(11, 734);
            Todo_YapilacakOluşturButon.Name = "Todo_YapilacakOluşturButon";
            Todo_YapilacakOluşturButon.Size = new Size(66, 24);
            Todo_YapilacakOluşturButon.TabIndex = 18;
            Todo_YapilacakOluşturButon.Text = "Oluştur";
            Todo_YapilacakOluşturButon.UseVisualStyleBackColor = true;
            Todo_YapilacakOluşturButon.Click += Todo_YapilacakOluşturButon_Click;
            // 
            // Todo_YapılacaklarLabel
            // 
            Todo_YapılacaklarLabel.BackColor = Color.Black;
            Todo_YapılacaklarLabel.FlatStyle = FlatStyle.Flat;
            Todo_YapılacaklarLabel.Font = new Font("Arial", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 162);
            Todo_YapılacaklarLabel.ForeColor = Color.White;
            Todo_YapılacaklarLabel.Location = new Point(55, 0);
            Todo_YapılacaklarLabel.Name = "Todo_YapılacaklarLabel";
            Todo_YapılacaklarLabel.Size = new Size(175, 38);
            Todo_YapılacaklarLabel.TabIndex = 16;
            Todo_YapılacaklarLabel.Text = "Yapılacaklar";
            // 
            // Todo_BaşlıkTextButon
            // 
            Todo_BaşlıkTextButon.Location = new Point(114, 410);
            Todo_BaşlıkTextButon.Name = "Todo_BaşlıkTextButon";
            Todo_BaşlıkTextButon.Size = new Size(66, 24);
            Todo_BaşlıkTextButon.TabIndex = 20;
            Todo_BaşlıkTextButon.Text = "Başlık";
            Todo_BaşlıkTextButon.UseVisualStyleBackColor = true;
            Todo_BaşlıkTextButon.Click += Todo_BaşlıkTextButon_Click;
            // 
            // Todo_YapilacakEkleButon
            // 
            Todo_YapilacakEkleButon.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            Todo_YapilacakEkleButon.Location = new Point(11, 799);
            Todo_YapilacakEkleButon.Name = "Todo_YapilacakEkleButon";
            Todo_YapilacakEkleButon.Size = new Size(66, 24);
            Todo_YapilacakEkleButon.TabIndex = 28;
            Todo_YapilacakEkleButon.Text = "Ekle";
            Todo_YapilacakEkleButon.UseVisualStyleBackColor = true;
            Todo_YapilacakEkleButon.Click += Todo_YapilacakEkleButon_Click;
            // 
            // Todo_AramaTextBox
            // 
            Todo_AramaTextBox.Location = new Point(11, 53);
            Todo_AramaTextBox.Name = "Todo_AramaTextBox";
            Todo_AramaTextBox.PlaceholderText = "Arama yapmak için burayı kullanabilirsin";
            Todo_AramaTextBox.Size = new Size(275, 23);
            Todo_AramaTextBox.TabIndex = 29;
            Todo_AramaTextBox.TextChanged += Todo_AramaTextBox_TextChanged;
            // 
            // Todo_BitişTarihiDatePickerController
            // 
            Todo_BitişTarihiDatePickerController.AutoSize = true;
            Todo_BitişTarihiDatePickerController.Location = new Point(271, 624);
            Todo_BitişTarihiDatePickerController.Name = "Todo_BitişTarihiDatePickerController";
            Todo_BitişTarihiDatePickerController.Size = new Size(15, 14);
            Todo_BitişTarihiDatePickerController.TabIndex = 30;
            Todo_BitişTarihiDatePickerController.UseVisualStyleBackColor = true;
            // 
            // TodoController
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.Black;
            Controls.Add(Todo_YapılacaklarLabel);
            Controls.Add(Todo_AramaTextBox);
            Controls.Add(Todo_YapilacakEkleButon);
            Controls.Add(Todo_FlowPanel);
            Controls.Add(Todo_BitişTarihiDatePickerController);
            Controls.Add(Todo_BitişTarihiDatePicker);
            Controls.Add(Todo_ÖnemYüksek);
            Controls.Add(Todo_ÖnemOrta);
            Controls.Add(Todo_ÖnemDüşük);
            Controls.Add(Todo_İçerikTextButon);
            Controls.Add(Todo_İçerikTextBox);
            Controls.Add(Todo_BaşlıkTextBox);
            Controls.Add(Todo_YapilacakOluşturButon);
            Controls.Add(Todo_BaşlıkTextButon);
            Name = "TodoController";
            Size = new Size(300, 840);
            Load += TodoController_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DateTimePicker Todo_BitişTarihiDatePicker;
        private RadioButton Todo_ÖnemYüksek;
        private RadioButton Todo_ÖnemOrta;
        private RadioButton Todo_ÖnemDüşük;
        public FlowLayoutPanel Todo_FlowPanel;
        public Button Todo_İçerikTextButon;
        public TextBox Todo_İçerikTextBox;
        public TextBox Todo_BaşlıkTextBox;
        public Button Todo_YapilacakOluşturButon;
        public Label Todo_YapılacaklarLabel;
        public Button Todo_BaşlıkTextButon;
        public Button Todo_YapilacakEkleButon;
        private TextBox Todo_AramaTextBox;
        private CheckBox Todo_BitişTarihiDatePickerController;
    }
}
