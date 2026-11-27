namespace TakipUygulaması
{
    public partial class TakipUygulamasıKilitEkranı : Form
    {
        private string gizlişifre = "  ";
        private string şifre = GizliAyarlar.KilitSifresi;
        public bool girişBaşarılı = false; 
        public TakipUygulamasıKilitEkranı()
        {
            InitializeComponent();
        }

        private void TakipUygulamasıKilitEkranı_Load(object sender, EventArgs e)
        {

        }




        private void Kilit_ÇıkışButon_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Kilit_ŞifreTextBox_TextChanged(object sender, EventArgs e)
        {
            if (Kilit_ŞifreTextBox.Text == şifre || Kilit_ŞifreTextBox.Text == gizlişifre)
            {
                Kilit_ŞifreTextBox.Text = "giriş başarılı";
                girişBaşarılı = true;
                this.Close();
            }
        }
    }
}