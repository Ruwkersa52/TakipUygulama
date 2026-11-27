using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Firebase.Database;
using Firebase.Database.Query;

namespace TakipUygulaması
{
    public partial class TodoController : UserControl
    {
        private bool TodoEklenecekAlanAcikmi = false;
        private int TodoEklenecekAlanMaxHeight = 700;
        private int TodoEklenecekAlanMinHeight = 300;
        private int TodoEklenecekAlanChangeSpeed = 20;
        private Control? acikAksiyonMenusu = null;
        private Panel? acikKart = null;
        private CancellationTokenSource? animasyonIptal;
        private readonly FirebaseClient firebaseClient = new FirebaseClient(GizliAyarlar.FirebaseUrl);//Kendi Firebase URL'nizi buraya girin

        public TodoController()
        {
            InitializeComponent();
        }

        private async void TodoController_Load(object sender, EventArgs e)
        {
            DeğerleriSıfırlama();

            await VerileriGetirVeListele();
        }

        private void DeğerleriSıfırlama()
        {
            //Belki sonradan eklenebilir
            Todo_FlowPanel.Size = new Size(Todo_FlowPanel.Width, 700);
        }

        private void ekleDeğerleriniSıfırla()
        {
            Todo_BaşlıkTextBox.Text = string.Empty;
            Todo_İçerikTextBox.Text = string.Empty;
            Todo_BitişTarihiDatePicker.Value = DateTime.Now;
            Todo_ÖnemDüşük.Checked = true;
            Todo_ÖnemOrta.Checked = false;
            Todo_ÖnemYüksek.Checked = false;
            Todo_BaşlıkTextBox.BackColor = Color.White;
            Todo_İçerikTextBox.BackColor = Color.White;
            Todo_BitişTarihiDatePickerController.Checked = false;
        }

        private Yapilacak YapılacakObjeOluşturucu(string baslik, string? icerik, OnemDerecesi onem, DateTime? bitisTarihi)
        {
            return new Yapilacak
            {
                Baslik = baslik,
                Icerik = icerik,
                Onem = onem,
                TamamlandiMi = false,
                EklenmeTarihi = DateTime.Now,
                BitisTarihi = bitisTarihi
            };
        }

        private void Todo_FlowPanel_MouseEnter(object? sender, EventArgs e)
        {
            Todo_FlowPanel.Focus();
        }
        private async Task VerileriGetirVeListele()
        {
            try
            {
                var kayitlar = await firebaseClient
                    .Child("Yapilacaklar")
                    .OnceAsync<Yapilacak>();

                Todo_FlowPanel.Controls.Clear();

                // Önem derecesine göre sırala (Yüksek -> Orta -> Düşük)
                var siraliListe = kayitlar
                    .Select(item =>
                    {
                        item.Object.Id = item.Key;
                        return item.Object;
                    })
                    .OrderByDescending(x => x.Onem)
                    .ThenBy(x => x.EklenmeTarihi)
                    .ToList();

                foreach (var gorev in siraliListe)
                {
                    Panel kart = GorevKartiOlustur(gorev);
                    Todo_FlowPanel.Controls.Add(kart);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veriler çekilirken hata oluştu: " + ex.Message, "Bağlantı Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // DİNAMİK GÖREV KARTI OLUŞTURUCU
        private Panel GorevKartiOlustur(Yapilacak gorev)
        {
            int kartGenislik = Todo_FlowPanel.Width - 25;
            Color SelectedBackColor =Color.White;
            if(gorev.TamamlandiMi)
            {
                SelectedBackColor = Color.LightGreen;
            }
            else
            {
                SelectedBackColor = Color.LightGray;
            }
            Panel kart = new Panel
            {
                Width = kartGenislik,
                BackColor = SelectedBackColor,//FromArgb(210, 210, 210), // Senin mevcut rengin
                Margin = new Padding(5),
                Padding = new Padding(8)
            };
            EventHandler Tıklama = (sender, e) => 
            {
                Todo_GörevTamamlandi(kart,gorev);
                
            };
            kart.Click += Tıklama;
            
            // Sol tarafa önem derecesine göre renk şeridi
            Panel onemSeridi = new Panel
            {
                Dock = DockStyle.Left,
                Width = 5,
                BackColor = gorev.Onem switch
                {
                    OnemDerecesi.Yuksek => Color.Crimson,
                    OnemDerecesi.Orta => Color.Gold,
                    _ => Color.MediumSeaGreen
                }
            };

            Label lblBaslik = Todo_YapılacakBaşlıkLabelOluşturucu(gorev.Baslik);
            lblBaslik.ForeColor = Color.FromArgb(45, 45, 45);
            lblBaslik.Location = new Point(12, 6);
            lblBaslik.MaximumSize = new Size(kartGenislik - 95, 0); // Uzun başlıklar da alt satıra insin
            lblBaslik.AutoSize = true;

            kart.Controls.Add(onemSeridi);
            kart.Controls.Add(lblBaslik);

            if (gorev.BitisTarihi.HasValue)
            {
                Label lblTarih = new Label
                {
                    Text = gorev.BitisTarihi.Value.ToString("dd.MM.yyyy"),
                    Font = new Font("Arial", 7.5F, FontStyle.Italic),
                    ForeColor = Color.DimGray,
                    AutoSize = true,
                    Location = new Point(kartGenislik - 75, 8)
                };
                kart.Controls.Add(lblTarih);
            }

            int altSinir = lblBaslik.Bottom;

            if (!string.IsNullOrWhiteSpace(gorev.Icerik))
            {
                Label lblIcerik = Todo_YapılacakAçıklamaLabelOluşturucu(gorev.Icerik);
                lblIcerik.ForeColor = Color.FromArgb(70, 70, 70);
                lblIcerik.Location = new Point(12, lblBaslik.Bottom + 4);
                // Yükseklik sınırını 0 yapıyoruz ki metin uzadıkça aşağı doğru sınırsız büyüsün
                lblIcerik.MaximumSize = new Size(kartGenislik - 25, 0);
                lblIcerik.AutoSize = true;

                kart.Controls.Add(lblIcerik);
                altSinir = lblIcerik.Bottom;
            }

            // Kart yüksekliğini içindeki en alt yazıya + 10 piksel boşluğa göre ayarla
            kart.Height = altSinir + 10;
            foreach (Control ctrl in kart.Controls)
            {
                ctrl.Click += Tıklama;
            }
            return kart;
        }
        private async void Todo_GörevTamamlandi(Panel kart, Yapilacak gorev)
        {
            if(!gorev.TamamlandiMi)
            {
                kart.BackColor = Color.LightGreen;//PİNK?
                gorev.TamamlandiMi = true;
                
            }
            else
            {
                kart.BackColor = Color.LightGray;
                gorev.TamamlandiMi = false;
            }
            await firebaseClient.Child("Yapilacaklar").Child(gorev.Id).PutAsync(gorev);

        }
        #region Label Oluşturucular
        private Label Todo_YapılacakAçıklamaLabelOluşturucu(string yapılacakAdi)
        {
            Label label = new Label();
            label.Text = yapılacakAdi;
            label.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, 162);
            return label;
        }
        
        private Label Todo_YapılacakBaşlıkLabelOluşturucu(string yapılacakBaşlık)
        {
            Label label = new Label();
            label.Text = yapılacakBaşlık;
            label.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            return label;
        }
        private Label Todo_TableLayoutPanelLabelOluşturucu(string text, Color foreColor)
        {
            Label label = new Label();
            label.Text = text;
            label.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label.ForeColor = foreColor;
            label.AutoSize = true;
            return label;
        }
        #endregion 

        private TableLayoutPanel Todo_TableLayoutPanelOluşturucu()
        {
            TableLayoutPanel table = new TableLayoutPanel();
            table.Dock = DockStyle.Fill;
            table.ColumnCount = 3;
            table.RowCount = 1;
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.34F));
            table.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            return table;
        }

        #region EklenecekAlan Açma/Kapama Butonu
        private async void Todo_YapilacakEkleButon_Click(object sender, EventArgs e)
        {
            animasyonIptal?.Cancel();
            animasyonIptal = new CancellationTokenSource();

            //True-> Açma İşlemi, False-> Kapama İşlemi
            Todo_EklenecekAlanAçma(TodoEklenecekAlanAcikmi, animasyonIptal.Token);
            if (!TodoEklenecekAlanAcikmi)
            {
                ekleDeğerleriniSıfırla();
                await VerileriGetirVeListele();
            }

            TodoEklenecekAlanAcikmi = !TodoEklenecekAlanAcikmi;
        }
        #endregion

        #region EklenecekAlanAnimasyonu
        private async void Todo_EklenecekAlanAçma(bool durum, CancellationToken token)
        {
            try
            {
                if (durum)
                {
                    for (int i = Todo_FlowPanel.Height; i <= TodoEklenecekAlanMaxHeight; i += TodoEklenecekAlanChangeSpeed)
                    {
                        token.ThrowIfCancellationRequested();
                        Todo_FlowPanel.Height = i;
                        await Task.Delay(1, token);
                    }
                    Todo_FlowPanel.Height = TodoEklenecekAlanMaxHeight;
                }
                else
                {
                    for (int i = Todo_FlowPanel.Height; i >= TodoEklenecekAlanMinHeight; i -= TodoEklenecekAlanChangeSpeed)
                    {
                        token.ThrowIfCancellationRequested();
                        Todo_FlowPanel.Height = i;
                        await Task.Delay(1, token);
                    }
                    Todo_FlowPanel.Height = TodoEklenecekAlanMinHeight;
                }
            }
            catch (OperationCanceledException)
            {
                // Peş peşe basıldığında önceki animasyon iptal edilip buradan temizce çıkar
            }
        }
        #endregion

        #region Metin Kontrol Edici
        private string? MetinKontrolEdici(string metin)
        {
            metin = metin.Trim();
            char[] yasakli = { '.', '$', '#', '[', ']', '/' };
            foreach (char c in yasakli)
            {
                metin = metin.Replace(c.ToString(), "");
            }

            if (string.IsNullOrWhiteSpace(metin)) return null;

            return char.ToUpper(metin[0]) + metin.Substring(1);
        }
        #endregion
        
        #region Önem Derecesi Butonları
        private void Todo_ÖnemDüşük_Click(object sender, EventArgs e)
        {
            Todo_ÖnemDüşük.Checked = true;
            Todo_ÖnemOrta.Checked = false;
            Todo_ÖnemYüksek.Checked = false;
        }

        private void Todo_ÖnemOrta_Click(object sender, EventArgs e)
        {
            Todo_ÖnemDüşük.Checked = false;
            Todo_ÖnemOrta.Checked = true;
            Todo_ÖnemYüksek.Checked = false;
        }

        private void Todo_ÖnemYüksek_Click(object sender, EventArgs e)
        {
            Todo_ÖnemDüşük.Checked = false;
            Todo_ÖnemOrta.Checked = false;
            Todo_ÖnemYüksek.Checked = true;
        }
        #endregion
        private void Todo_İçerikTextButon_Click(object sender, EventArgs e)
        {
            if (MetinKontrolEdici(Todo_İçerikTextBox.Text) == null)
            {
                Todo_İçerikTextBox.BackColor = Color.Red;
                return;
            }
            else
            {
                Todo_İçerikTextBox.BackColor = Color.SpringGreen;
            }
        }
        private void Todo_BaşlıkTextButon_Click(object sender, EventArgs e)
        {
            if (MetinKontrolEdici(Todo_BaşlıkTextBox.Text) == null)
            {
                Todo_BaşlıkTextBox.BackColor = Color.Red;
                return;
            }
            else
            {
                Todo_BaşlıkTextBox.BackColor = Color.SpringGreen;
            }
        }
        private void Todo_BitişTarihiDatePicker_ValueChanged(object sender, EventArgs e)
        {
            Todo_BitişTarihiDatePickerController.Checked = true;
        }

        private async void Todo_YapilacakOluşturButon_Click(object sender, EventArgs e)
        {
            string? temizBaslik = MetinKontrolEdici(Todo_BaşlıkTextBox.Text);
            if (temizBaslik == null)
            {
                Todo_BaşlıkTextBox.BackColor = Color.Red;
                return;
            }
            Todo_BaşlıkTextBox.BackColor = Color.SpringGreen;

            string? temizIcerik = string.IsNullOrWhiteSpace(Todo_İçerikTextBox.Text)
                ? null
                : MetinKontrolEdici(Todo_İçerikTextBox.Text);

            OnemDerecesi secilenOnem = OnemDerecesi.Dusuk;
            if (Todo_ÖnemYüksek.Checked)
            {
                secilenOnem = OnemDerecesi.Yuksek;
            }
            else if (Todo_ÖnemOrta.Checked)
            {
                secilenOnem = OnemDerecesi.Orta;
            }

            DateTime? bitisTarihi = Todo_BitişTarihiDatePickerController.Checked
                ? Todo_BitişTarihiDatePicker.Value
                : null;

            Yapilacak yeniGorev = YapılacakObjeOluşturucu(temizBaslik, temizIcerik, secilenOnem, bitisTarihi);

            try
            {
                Todo_YapilacakOluşturButon.Enabled = false;
                Todo_YapilacakOluşturButon.Text = "Kaydediliyor...";

                await firebaseClient
                    .Child("Yapilacaklar")
                    .PostAsync(yeniGorev);

                ekleDeğerleriniSıfırla();
                MessageBox.Show("Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await VerileriGetirVeListele();
            }
            catch (Exception ex)
            {
                if(ex is HttpRequestException)
                {
                    MessageBox.Show("İnternet bağlantısı hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
                else if(ex is TaskCanceledException)
                {
                    MessageBox.Show("Zaman aşımına uğradı: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (ex is FirebaseException)
                {
                    MessageBox.Show("Firebase hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Kayıt hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            finally
            {
                Todo_YapilacakOluşturButon.Enabled = true;
                Todo_YapilacakOluşturButon.Text = "Oluştur";
            }
        }

        private void Todo_AramaTextBox_TextChanged(object sender, EventArgs e)
        {

        }
        //Eklenecekler
        //Uygulama içi bütün elemanlamrın rengini değiştirme ekle.
    }
}