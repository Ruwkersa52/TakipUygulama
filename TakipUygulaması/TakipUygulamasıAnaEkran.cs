using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Forms;
using Firebase.Database;
using Firebase.Database.Query;

namespace TakipUygulaması
{
    public partial class Todo_ArkaPlan : Form
    {
        TakipUygulamasıKilitEkranı kilitEkranı = new TakipUygulamasıKilitEkranı();
        TakiplerinElementListeleri takiplerinElementListeleri;
        TodoController todoSayfasi = new TodoController();

        //Ekran boyutları ve kaydırma hızı
        private int EkranSizeX = 10;
        private int EkranSizeXMax = 300;
        private int EkranSizeXChangeSpeed = 30;
        private bool EkranSizeChangeable = true;
        private int EkranSizeY = 840;
        //*************************************************//

        private bool formSabitli = false;
        private FirebaseClient firebaseClient;
        public Todo_ArkaPlan()
        {
            InitializeComponent();
            firebaseClient = new FirebaseClient("https://console.firebase.google.com/project/uygulamamfirebase/database/uygulamamfirebase-default-rtdb/data/~2F");
            takiplerinElementListeleri = new TakiplerinElementListeleri(this);
        }
        private void TumKontrollereFareOlayiBagla(Control anaKontrol)
        {
            foreach (Control altKontrol in anaKontrol.Controls)
            {
                altKontrol.MouseEnter -= AnaEkran_MouseTetiklenmeGiriş;
                altKontrol.MouseLeave -= AnaEkran_MouseTetiklenmeÇıkış;

                altKontrol.MouseEnter += AnaEkran_MouseTetiklenmeGiriş;
                altKontrol.MouseLeave += AnaEkran_MouseTetiklenmeÇıkış;

                if (altKontrol.HasChildren)
                {
                    TumKontrollereFareOlayiBagla(altKontrol);
                }
            }
        }
        private void TakipUygulamasıAnaEkran_Load(object sender, EventArgs e)
        {
            //Kilit açılmadan önce arayüzü gizler açılmassa program kapanır. Kilit açılırsa arayüzü tekrar görünür yapar.
            TumKontrollereFareOlayiBagla(this);
            ObjeleriKapatmaAçma(takiplerinElementListeleri.AnaEkranDefaultElementlerListeGetir(), false);
            this.Width = EkranSizeX;

            kilitEkranı.ShowDialog();
            if (!kilitEkranı.girişBaşarılı)
            {
                this.Close();
                return;
            }
            ObjeleriKapatmaAçma(takiplerinElementListeleri.AnaEkranDefaultElementlerListeGetir(), true);

            this.Paint += CerceveCiz;
            AnaEkranIcerikPaneli.Paint += CerceveCiz;
            todoSayfasi.Paint += CerceveCiz;
            //*************************************************//
        }

        #region Objelerini gizle ve göster
        public void ObjeleriKapatmaAçma(List<Control>? AnaEkranControl = null, bool durum = true)
        {
            //Adı üstünde ekrandki TÜM objeleri açıp kapatır

            //Eğer child da kontrol etmek istiyorsan uğraşma.
            //Çünkü zaten childlar parent görünür ve aktif ise otomatik olarak görünür ve aktif olur.

            foreach (Control control in AnaEkranControl ?? new List<Control>())
            {
                control.Visible = durum;
                control.Enabled = durum;
            }
            //*************************************************//
        }
        #endregion

        #region Form gösterme
        private async void AnaEkran_MouseTetiklenmeGiriş(object sender, EventArgs e)
        {
            // Ekran kaydırmayı ileri alma işlemi burda yapılır

            if (this.Width >= EkranSizeXMax) return;

            for (int i = this.Width; i <= EkranSizeXMax; i += EkranSizeXChangeSpeed)
            {
                this.Width = i;
                this.Refresh();
                await Task.Delay(1);
            }
            this.Width = EkranSizeXMax;

            //*************************************************//
        }
        #endregion

        #region Form gizleme
        private async void AnaEkran_MouseTetiklenmeÇıkış(object sender, EventArgs e)
        {
            // Ekran kaydırmayı geri alma işlemi burda yapılır

            if (!EkranSizeChangeable) return;

            await Task.Delay(10);

            bool fareFormunIcindeMi = this.ClientRectangle.Contains(this.PointToClient(Cursor.Position));

            if (fareFormunIcindeMi)
            {
                return;
            }

            for (int i = this.Width; i >= EkranSizeX; i -= EkranSizeXChangeSpeed)
            {
                this.Width = i;
                this.Refresh();
                await Task.Delay(1);
            }
            this.Width = EkranSizeX;

            //*************************************************//
        }
        #endregion

        private void AnaEkran_SabitleButon_Click(object sender, EventArgs e)
        {
            // Ekran kyadırmayı durdurur ve sabitler. Sabitle butonuna tekrar basılırsa kaydırma tekrar aktif olur.

            EkranSizeChangeable = !EkranSizeChangeable;

            if (!EkranSizeChangeable) // Sabitlendi
            {
                AnaEkran_SabitleButon.Text = "Sabitlendi";
            }
            else // Serbest
            {
                AnaEkran_SabitleButon.Text = "Sabitle";
            }

            // Hem formu hem de üzerindeki modül panelini yeniden çizdir
            this.Invalidate();
            AnaEkranIcerikPaneli.Invalidate();
            todoSayfasi.Invalidate();

            //*************************************************//
        }

        private void AnaEkran_todoButon_Click(object sender, EventArgs e)
        {
            AnaEkranIcerikPaneli.Controls.Clear();
            todoSayfasi.Dock = DockStyle.Fill;
            AnaEkranIcerikPaneli.Controls.Add(todoSayfasi);
            TumKontrollereFareOlayiBagla(AnaEkranIcerikPaneli);
            AnaEkranIcerikPaneli.Visible = true;
            Todo_AnaEkranGeri.Visible = true;
            Todo_AnaEkranGeri.BringToFront();
            AnaEkran_SabitleButon.BringToFront();
        }

        private void Todo_AnaEkranGeri_Click(object sender, EventArgs e)
        {
            AnaEkranIcerikPaneli.Visible = false;
            Todo_AnaEkranGeri.Visible = false;
        }

        private void CerceveCiz(object? sender, PaintEventArgs e)
        {
            if (!EkranSizeChangeable && sender is Control kontrol)
            {
                using (Pen kalem = new Pen(Color.White, 2)) // 2 piksel kalınlığında çerçeve
                {
                    e.Graphics.DrawRectangle(kalem, 0, 0, kontrol.Width - 1, kontrol.Height - 1);
                }
            }
        }
        // Eklenecekler:

        // Ekle butonuna basıldığında yukarı aşağı gitmesinde sorun var peş peşe basılınca takılıyor
        // Sabitle yaptığında belli et çerçeve rengini falan değiştir
        // Treewiew ile firebase  verileri kontrol etme
    }
}