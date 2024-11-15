using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Kargo_Uygulaması
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static long DogruTC;

        // SQL Bağlantısı
        SqlConnection baglanti = new SqlConnection("Data Source=.;Initial Catalog=GorselKargoUygulamasıDB;Integrated Security=True;");

        public long TCno;

        //////////// Personel Ekleme Fonksiyonu \\\\\\\\\\\\\
        void PersonelEkle(string TcNumarasi, string Ad, string Soyad, string Telefon, string Sifre, string Eposta)
        {
            try
            {
                baglanti.Open();

                // Sicil No'yu Rastgele versin
                Random r = new Random();

                string kayit = "insert into Personel (TCnumara, Ad, Soyad, Telefon, Eposta, Sifre, SicilNo, Statü) values (@TCNo, @Ad, @Soyad, @Telefon, @Eposta, @Sifre, @SicilNo, 'Personel')";
                SqlCommand ekle = new SqlCommand(kayit, baglanti);

                ekle.Parameters.AddWithValue("@TCNo", TcNumarasi);
                ekle.Parameters.AddWithValue("@Ad", Ad);
                ekle.Parameters.AddWithValue("@Soyad", Soyad);
                ekle.Parameters.AddWithValue("@Telefon", Telefon);
                ekle.Parameters.AddWithValue("@Eposta", Eposta);
                ekle.Parameters.AddWithValue("@Sifre", Sifre);
                ekle.Parameters.AddWithValue("@SicilNo", r.Next(100000, 1000000));
                ekle.ExecuteNonQuery();
                baglanti.Close();

                MessageBox.Show("Kayıt Başarıyla Eklenmiştir", "BAŞARILI", MessageBoxButtons.OK, MessageBoxIcon.Information);

                baglanti.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Giriş Kontrol Fonksiyonu

        void GirisKontrol(string Sifre, long TCnumarasi)
        {
            try
            {
                // Girilen TC ve Şifrede Personel var mı ?

                baglanti.Open();
                string PersonelSorgu = "select * from Personel where TCnumara = @TC and Sifre = @Sifre and Statü = 'Personel'";
                SqlCommand PersonelKontrol = new SqlCommand(PersonelSorgu, baglanti);
                PersonelKontrol.Parameters.AddWithValue("@TC", TCnumarasi);
                PersonelKontrol.Parameters.AddWithValue("@Sifre", Sifre);
                PersonelKontrol.ExecuteNonQuery();
                SqlDataReader dr = PersonelKontrol.ExecuteReader();

                // Sorgu Çalışırsa Personel Girdi demektir -> AnaSayfaya Yönlendir
                if (dr.Read())
                {
                    DogruTC = TCnumarasi;
                    AnaSayfa anaSayfa = new AnaSayfa();


                    anaSayfa.Show();
                    this.Hide();

                    baglanti.Close();
                    dr.Close();
                }
                // Sorgu Çalışmazsa Müdür mü diye kontrol et
                else
                {
                    // önceki datareader'ı kapat
                    dr.Close();

                    string MüdürSorgu = "select * from Personel where TCnumara = @TC and Sifre = @Sifre and Statü = 'Müdür'";
                    SqlCommand MüdürKontrol = new SqlCommand(MüdürSorgu, baglanti);
                    MüdürKontrol.Parameters.AddWithValue("@TC", TCnumarasi);
                    MüdürKontrol.Parameters.AddWithValue("@Sifre", Sifre);
                    MüdürKontrol.ExecuteNonQuery();
                    SqlDataReader drr = MüdürKontrol.ExecuteReader();

                    // Müdür Sorgusu Çalışırsa Müdür Sayfasına aktar
                    if (drr.Read())
                    {
                        DogruTC = TCnumarasi;
                        YoneticiEkrani f = new YoneticiEkrani();
                        f.Show();
                        this.Hide();

                        baglanti.Close();
                        drr.Close();
                    }

                    // Müdür Sorgusu da Çalışmazsa Hatalı Bilgi Uyarısı ver
                    else
                        MessageBox.Show("Giriş Bilgileri Hatalı \n Tekrar Deneyiniz", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    baglanti.Close();
                    drr.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        //////////////////// TAB Index'leri UNUTMA !!! \\\\\\\\\\\\\\\\\\\\\\\\\
        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Left = 0; pictureBox1.Top = 0;
            pnl_SifreYenileme.Top = 0;
            pnl_SifreYenileme.Left = 530;
            pnl_SifreYenileme.Visible = false;
        }

        // Giriş Ekranı ve Kayıt Ekranı arasında geçiş
        private void ResmiKaydir_Tick(object sender, EventArgs e)
        {
            pictureBox1.BringToFront();

            if (pictureBox1.Left <= 10)
            {
                for (int i = pictureBox1.Left; i <= 500; i += 100)
                    pictureBox1.Left = i;

                ResmiKaydir.Enabled = false;
            }
            else
            {
                for (int i = pictureBox1.Left; i >= 0; i -= 100)
                    pictureBox1.Left = i;

                ResmiKaydir.Enabled = false;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            TChatasi.Clear();
            TCBasamakHatasi.Clear();

            txtGirisTC.Enabled = true;
            txt_GirisSifre.Enabled = true;
            btn_GirisYap.Enabled = true;

            txt_KayitAd.Enabled = false;
            txt_KayitSoyad.Enabled = false;
            txt_KayitTC.Enabled = false;
            txt_KayitTelefon.Enabled = false;
            txt_KayitSifre.Enabled = false;
            txt_KayitSifreTekrar.Enabled = false;
            btn_KaydiTamamla.Enabled = false;

            txtGirisTC.TabIndex = 1;
            txt_GirisSifre.TabIndex = 2;
            btn_GirisYap.TabIndex = 3;

            ResmiKaydir.Enabled = true;

            this.AcceptButton = btn_GirisYap;
        }
        private void link_PersonelKaydi_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            TCBasamakHatasi.Clear();
            TChatasi.Clear();

            txtGirisTC.Enabled = false;
            txt_GirisSifre.Enabled = false;
            btn_GirisYap.Enabled = false;

            txt_KayitAd.Enabled = true;
            txt_KayitSoyad.Enabled = true;
            txt_KayitTC.Enabled = true;
            txt_KayitTelefon.Enabled = true;
            txt_KayitEposta.Enabled = true;
            txt_KayitSifre.Enabled = true;
            txt_KayitSifreTekrar.Enabled = true;
            btn_KaydiTamamla.Enabled = true;

            txt_KayitAd.TabIndex = 0;
            txt_KayitSoyad.TabIndex = 1;
            txt_KayitTelefon.TabIndex = 2;
            txt_KayitEposta.TabIndex = 3;
            txt_KayitTC.TabIndex = 4;
            txt_KayitSifre.TabIndex = 5;
            txt_KayitSifreTekrar.TabIndex = 6;
            btn_KaydiTamamla.TabIndex = 7;

            ResmiKaydir.Enabled = true;

            this.AcceptButton = btn_KaydiTamamla;
        }


        // Giriş Ekranındaki Şifreyi Görme ve Gizleme
        private void picture_SifreGizle_Click(object sender, EventArgs e)
        {
            picture_SifreGizle.SendToBack();
            pictur_SifreGor.BringToFront();

            pictur_SifreGor.Left = 873;
            pictur_SifreGor.Top = 268;

            txt_GirisSifre.PasswordChar = '*';
        }

        private void pictur_SifreGor_Click(object sender, EventArgs e)
        {
            pictur_SifreGor.SendToBack();
            picture_SifreGizle.BringToFront();

            picture_SifreGizle.Left = 873;
            picture_SifreGizle.Top = 268;

            txt_GirisSifre.PasswordChar = '\0';
        }


        // TC ve Telefon Numara kısımlarında sadece rakam girilsin
        private void txt_KayitTC_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtGirisTC_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txt_KayitTelefon_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }



        ////// Buttonların Tıklanma Olayları \\\\\\\

        // Kayıt ve Giriş için gerekli değişkenler

        string Ad, Soyad, Telefon, Sifre, Eposta;
        long TC;
        private void btn_KaydiTamamla_Click(object sender, EventArgs e)
        {
            try
            {
                Ad = txt_KayitAd.Text;
                Soyad = txt_KayitSoyad.Text;
                Telefon = txt_KayitTelefon.Text;
                Sifre = txt_KayitSifre.Text;
                Eposta = txt_KayitEposta.Text;

                int SifreRakamSayac = 0;
                bool SifreBoslukSayac = false;
                char[] rakamlar = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

                // Telefon Numarası 10 haneli mi ?
                if (long.Parse(txt_KayitTelefon.Text) / 1000000000 < 1)
                {
                    MessageBox.Show("Girilen Telefon Numarası Eksik \n ya da Hatalı", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                // Numarada eksik yoksa
                else
                {
                    // Şifre alanlarındaki Kontroller \\

                    // Şifre Kontrolü için gerekli Sayaçlar
                    for (int i = 0; i < Sifre.Length; i++)
                    {
                        for (int j = 0; j < rakamlar.Length; j++)
                        {
                            if (Sifre[i] == rakamlar[j])
                                SifreRakamSayac++;
                        }
                        if (Sifre[i] == ' ')
                            SifreBoslukSayac = true;
                    }

                    // Eğer Şifre Hiç Rakam İçermiyorsa Geçersiz Say

                    if (SifreRakamSayac == 0)
                    {
                        MessageBox.Show("Şifre En Az Bir Rakam İçermelidir \n Tekrar Deneyiniz", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    // Eğer Şifre Sadece Rakamlardan Oluşuyorsa Geçersiz Say

                    else if (SifreRakamSayac == Sifre.Length)
                    {
                        MessageBox.Show("Şifre En Az Bir Harf veya Özel Karakter İçermelidir \n Tekrar Deneyiniz", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    // Eğer Şifrede Boşluk Varsa Geçersiz Say

                    else if (SifreBoslukSayac == true)
                    {
                        MessageBox.Show("Şifre Boşluk Karakteri İçeremez \n Tekrar Deneyiniz", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    // Eğer Şifreler Uyuşmuyorsa Geçersiz Say

                    else if (Sifre != txt_KayitSifreTekrar.Text)
                    {
                        MessageBox.Show("Şifreler Uyuşmuyor", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    // Her şey doğruysa Kayıt başarıyla veri tabanına eklensin
                    else
                    {
                        string TcNumarasi = txt_KayitTC.Text;
                        PersonelEkle(TcNumarasi, Ad, Soyad, Telefon, Sifre, Eposta);

                        baglanti.Close();
                    }
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_GirisYap_Click(object sender, EventArgs e)
        {
            TChatasi.Clear();

            try
            {
                TC = long.Parse(txtGirisTC.Text);

                Sifre = txt_GirisSifre.Text;

                // VeriTabanındaki TC ile Şifre Uyuşuyor mu ??

                GirisKontrol(Sifre, TC);

            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //////////// TC Girişindeki Kontroller ve Fonksiyonlar \\\\\\\\\\\\\

        private void txt_KayitTC_TextChanged(object sender, EventArgs e)
        {
            TChatasi.Clear();
            if (txt_KayitTC.Text != "")
                KayitTCkontrolü();
        }

        private void txtGirisTC_TextChanged(object sender, EventArgs e)
        {
            TChatasi.Clear();
            if (txtGirisTC.Text != "") // TC kutusu boş değilse işlem yap
            {
                GirisTCkontrolü();
            }
        }


        void GirisTCkontrolü()
        {
            string TCmetin = txtGirisTC.Text;

            if (TCmetin == "0")
                txtGirisTC.Text = "";

            // İlk rakam 0 değilse uzunluk 10 olunca 10. rakamı kontrol et
            else
            {
                if (TCmetin.Length == 10)
                {
                    long TCsayisi = long.Parse(TCmetin);
                    int[] TCrakamlar = new int[10];
                    long BasDeger = 10, SayDeger = 1;
                    int TeklerToplami = 0, CiftlerToplami = 0;

                    // Rakamlar dizisini doldur ve tek çift toplamını hesapla
                    for (int i = TCrakamlar.Length - 1; i >= 0; i--)
                    {
                        TCrakamlar[i] = Convert.ToInt16(TCsayisi % BasDeger / SayDeger);
                        BasDeger *= 10;
                        SayDeger *= 10;

                        // Tek ve Çift basamakları topla 10. Rakamı Dahil etme
                        if (i < TCrakamlar.Length - 1)
                        {
                            if (i % 2 == 0)
                                TeklerToplami += TCrakamlar[i];
                            else
                                CiftlerToplami += TCrakamlar[i];
                        }
                    }

                    // 10. Rakam Kontrolü
                    if (TCrakamlar[9] != (TeklerToplami * 7 - CiftlerToplami) % 10)
                        TChatasi.SetError(txtGirisTC, "10.Rakam Hatası");
                }

                // TC uzunluğu 11 olursa önce 10. rakamı sonra da 11. Rakamı Kontrol Et
                else if (TCmetin.Length == 11)
                {
                    long TCsayisi = long.Parse(TCmetin);
                    int[] TCrakamlar = new int[11];
                    long BasDeger = 10, SayDeger = 1;
                    int TeklerToplami = 0, CiftlerToplami = 0;

                    // Rakamlar dizisini oluştur ve tek çift basamak toplamını hesapla
                    for (int i = TCrakamlar.Length - 1; i >= 0; i--)
                    {
                        TCrakamlar[i] = Convert.ToInt16(TCsayisi % BasDeger / SayDeger);
                        BasDeger *= 10;
                        SayDeger *= 10;

                        // tek çift basamakları topla
                        if (i < TCrakamlar.Length - 2)
                        {
                            if (i % 2 == 0)
                                TeklerToplami += TCrakamlar[i];
                            else
                                CiftlerToplami += TCrakamlar[i];
                        }
                    }

                    if (TCrakamlar[9] != (TeklerToplami * 7 - CiftlerToplami) % 10)
                        TChatasi.SetError(txtGirisTC, "10.Rakam Hatalı");

                    // 10. Rakam Doğruysa 11. Rakam Kontrolü
                    else
                    {
                        if (TCrakamlar[10] != (TeklerToplami + CiftlerToplami + TCrakamlar[9]) % 10)
                            TChatasi.SetError(txtGirisTC, "11. Rakam Hatası");
                        else
                            btn_GirisYap.Enabled = true;
                    }
                }
            }
        }

        void KayitTCkontrolü()
        {
            string TCmetin = txt_KayitTC.Text;

            if (TCmetin == "0")
                txt_KayitTC.Text = "";

            // İlk rakam 0 değilse uzunluk 10 olunca 10. rakamı kontrol et
            else
            {
                if (TCmetin.Length == 10)
                {
                    long TCsayisi = long.Parse(TCmetin);
                    int[] TCrakamlar = new int[10];
                    long BasDeger = 10, SayDeger = 1;
                    int TeklerToplami = 0, CiftlerToplami = 0;

                    // Rakamlar dizisini doldur ve tek çift toplamını hesapla
                    for (int i = TCrakamlar.Length - 1; i >= 0; i--)
                    {
                        TCrakamlar[i] = Convert.ToInt16(TCsayisi % BasDeger / SayDeger);
                        BasDeger *= 10;
                        SayDeger *= 10;

                        // Tek ve Çift basamakları topla 10. Rakamı Dahil etme
                        if (i < TCrakamlar.Length - 1)
                        {
                            if (i % 2 == 0)
                                TeklerToplami += TCrakamlar[i];
                            else
                                CiftlerToplami += TCrakamlar[i];
                        }
                    }

                    // 10. Rakam Kontrolü
                    if (TCrakamlar[9] != (TeklerToplami * 7 - CiftlerToplami) % 10)
                        TChatasi.SetError(txt_KayitTC, "10.Rakam Hatası");
                }

                // TC uzunluğu 11 olursa önce 10. rakamı sonra da 11. Rakamı Kontrol Et
                else if (TCmetin.Length == 11)
                {
                    long TCsayisi = long.Parse(TCmetin);
                    int[] TCrakamlar = new int[11];
                    long BasDeger = 10, SayDeger = 1;
                    int TeklerToplami = 0, CiftlerToplami = 0;

                    // Rakamlar dizisini oluştur ve tek çift basamak toplamını hesapla
                    for (int i = TCrakamlar.Length - 1; i >= 0; i--)
                    {
                        TCrakamlar[i] = Convert.ToInt16(TCsayisi % BasDeger / SayDeger);
                        BasDeger *= 10;
                        SayDeger *= 10;

                        // tek çift basamakları topla
                        if (i < TCrakamlar.Length - 2)
                        {
                            if (i % 2 == 0)
                                TeklerToplami += TCrakamlar[i];
                            else
                                CiftlerToplami += TCrakamlar[i];
                        }
                    }

                    if (TCrakamlar[9] != (TeklerToplami * 7 - CiftlerToplami) % 10)
                        TChatasi.SetError(txt_KayitTC, "10.Rakam Hatalı");

                    // 10. Rakam Doğruysa 11. Rakam Kontrolü
                    else
                    {
                        if (TCrakamlar[10] != (TeklerToplami + CiftlerToplami + TCrakamlar[9]) % 10)
                            TChatasi.SetError(txt_KayitTC, "11. Rakam Hatası");
                        else
                            btn_KaydiTamamla.Enabled = true;
                    }
                }
            }
        }


        // Girilen TC'ler 11 Haneli mi ?
        private void txtGirisTC_Leave(object sender, EventArgs e)
        {
            if (txtGirisTC.Text.Length != 11)
                TCBasamakHatasi.SetError(txtGirisTC, "TC 11 Haneli Olmalıdır");
        }

        private void txt_KayitTC_Leave(object sender, EventArgs e)
        {
            if (txt_KayitTC.Text.Length != 11)
                TCBasamakHatasi.SetError(txt_KayitTC, "TC 11 Haneli Olmalıdır");
        }

        private void txt_KayitTC_Enter(object sender, EventArgs e)
        {
            TCBasamakHatasi.Clear();
        }

        private void txtGirisTC_Enter(object sender, EventArgs e)
        {
            TCBasamakHatasi.Clear();
        }

        ///////////////////  ŞİFRE YENİLEME PANELİ KONTROLLERİ  \\\\\\\\\\\\\\\\\\\

        // Şifremi Unuttum Tıklanırsa
        private void linklbl_SifremiUnuttum_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            TChatasi.Clear();
            TCBasamakHatasi.Clear();
            pnl_SifreYenileme.Visible = true;
            pnl_SifreYenileme.BringToFront();
        }

        // TC Kontrolü
        private void txt_SifreYenileTC_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txt_SifreYenileTC.Text != "")
                {
                    string TC = txt_SifreYenileTC.Text;

                    // İlk Rakam 0 mı
                    if (TC[0] == '0')
                    {
                        txt_SifreYenileTC.Text = "";
                    }
                    // İlk Rakam 0 değilse
                    else
                    {
                        TChatasi.Clear();

                        // TC uzunluğu 10 olduysa kontrol et
                        if (TC.Length == 10)
                        {
                            int[] TCrakamlar = new int[10];
                            long saydeger = 1, basdeger = 10;
                            long TCsayi = long.Parse(TC);
                            int teklertoplami = 0, ciftlertoplami = 0;

                            for (int i = 0; i < 10; i++)
                            {
                                TCrakamlar[i] = Convert.ToInt16(TCsayi % basdeger / saydeger);

                                saydeger *= 10;
                                basdeger *= 10;

                                if (i != 0 && i % 2 == 0)
                                    ciftlertoplami += TCrakamlar[i];

                                else if (i != 0 && i % 2 != 0)
                                    teklertoplami += TCrakamlar[i];
                            }

                            // 10. Rakam Hesaplamanın Dışındaysa
                            if (TCrakamlar[0] != (teklertoplami * 7 - ciftlertoplami) % 10)
                            {
                                TChatasi.SetError(txt_SifreYenileTC, "10. Rakam Hatalı");
                            }
                        }

                        // TC uzunluğu 11 olursa önce 10. Rakamı sonra 11. Rakamı kontrol et
                        else if (TC.Length == 11)
                        {
                            TChatasi.Clear();

                            int[] TCrakamlar = new int[11];
                            long saydeger = 1, basdeger = 10;
                            long TCsayi = long.Parse(TC);
                            int teklertoplami = 0, ciftlertoplami = 0;

                            for (int i = 0; i < 11; i++)
                            {
                                TCrakamlar[i] = Convert.ToInt16(TCsayi % basdeger / saydeger);

                                saydeger *= 10;
                                basdeger *= 10;

                                if (i > 1 && i % 2 == 0)
                                    teklertoplami += TCrakamlar[i];

                                else if (i > 1 && i % 2 != 0)
                                    ciftlertoplami += TCrakamlar[i];
                            }

                            // 10. Rakam Yanlışsa
                            if (TCrakamlar[1] != (teklertoplami * 7 - ciftlertoplami) % 10)
                                TChatasi.SetError(txt_SifreYenileTC, "10. Rakam Hatalı");

                            // 10. Rakam Doğruysa 11. Rakamı Kontrol Et
                            else
                            {
                                if (TCrakamlar[0] != (teklertoplami + ciftlertoplami + TCrakamlar[1]) % 10)
                                {
                                    TChatasi.SetError(txt_SifreYenileTC, "11. Rakam Hatalı");
                                }

                                // Her şey doğruysa buttonu aktifleştir
                                else
                                    btn_SifreYenile.Enabled = true;
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "HATA");
            }
        }

        // Şifreyi yenile tuşuna basılırsa
        private void btn_SifreYenile_Click(object sender, EventArgs e)
        {
            try
            {

                string YeniSifre = txt_SifreYenile_YeniSifre.Text;
                string YeniSifreTekrar = txt_YeniSifreTekrar.Text;

                // Şifre 5 karakterden azsa geçersiz say
                if (YeniSifre.Length < 5)
                {
                    MessageBox.Show("Girilen şifre en az 5 karakterli olmalıdır \n Tekrar Deneyiniz", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                // Şifre 5 karakterden Fazlaysa diğer Kontroller
                else
                {
                    // Şifrede en az 1 rakam olmazsa ya da hepsi rakam olursa şifreyi geçersiz say
                    char[] rakamlar = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
                    int rakamSayac = 0;
                    bool sifredeBoslukVarmi = false;

                    for (int i = 0; i < YeniSifre.Length; i++)
                    {
                        for (int j = 0; j < rakamlar.Length; j++)
                        {
                            if (YeniSifre[i] == rakamlar[j])
                                rakamSayac++;
                            else if (YeniSifre[i] == ' ')
                                sifredeBoslukVarmi = true;
                        }
                    }

                    // Hiç rakam yoksa
                    if (rakamSayac == 0)
                    {
                        MessageBox.Show("Şifre en az bir rakam içermelidir \n Tekrar Deneyiniz", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    // Hepsi Rakamsa
                    else if (rakamSayac == YeniSifre.Length)
                    {
                        MessageBox.Show("Şifre en az bir harf ya da özel karakter içermelidir \n Tekrar Deneyiniz", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    // Şifrede Boşluk varsa
                    else if (sifredeBoslukVarmi == true)
                    {
                        MessageBox.Show("Şifrede boşluk karakteri olamaz \n Tekrar Deneyiniz", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    // Girilen Şifreler uyuşuyor mu
                    else if (YeniSifre != YeniSifreTekrar)
                    {
                        MessageBox.Show("Girilen Şifreler Uyuşmuyor \n Tekrar Deneyiniz", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    // Şifre Tüm Kurallara uyuyorsa veritabanında şifreyi güncelle
                    else
                    {
                        baglanti.Open();

                        string sorgu = "select * from Personel where TCnumara = @TCno";
                        SqlCommand cmd = new SqlCommand(sorgu, baglanti);
                        cmd.Parameters.AddWithValue("@TCno", txt_SifreYenileTC.Text);
                        cmd.ExecuteNonQuery();
                        SqlDataReader dr = cmd.ExecuteReader();

                        if (dr.Read())
                        {
                            baglanti.Close();

                            baglanti.Open();

                            string guncelle = "update Personel set Sifre = @Sifre where TCnumara = @TCno";
                            SqlCommand update = new SqlCommand(guncelle, baglanti);
                            update.Parameters.AddWithValue("@Sifre", txt_SifreYenile_YeniSifre.Text);
                            update.Parameters.AddWithValue("@TCno", txt_SifreYenileTC.Text);
                            update.ExecuteNonQuery();

                            MessageBox.Show("Şifre Başarıyla Güncellenmiştir \n Giriş Sayfasına Yönlendiriliyorsunuz", "BAŞARILI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            pnl_SifreYenileme.Visible = false;
                        }
                        else
                        {
                            DialogResult yanit = MessageBox.Show("Girilen TC sistemde bulunamadı \n Personel Ekleme Sayfasına Gitmek İster Misiniz", "UYARI", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                            if (yanit == DialogResult.Yes)
                            {
                                pnl_SifreYenileme.Visible = false;
                                ResmiKaydir.Enabled = true;
                            }
                        }

                        baglanti.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "HATA");
            }
        }

        // Şifre Yenileme işlemi Tamamlanırsa
        private void linklbl_GirisEkraninaDon_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pnl_SifreYenileme.Visible = false;
        }



        ////////////////// BUTTONLARIN HOVER - LEAVE EFEKTLERİ \\\\\\\\\\\\\\\\\\\\\\

        private void btn_GirisYap_MouseHover(object sender, EventArgs e)
        {
            btn_GirisYap.BackColor = Color.Maroon;
            btn_GirisYap.ForeColor = Color.White;
        }

        private void btn_GirisYap_MouseLeave(object sender, EventArgs e)
        {
            btn_GirisYap.BackColor = Color.White;
            btn_GirisYap.ForeColor = Color.Black;
        }


        private void btn_KaydiTamamla_MouseHover(object sender, EventArgs e)
        {
            btn_KaydiTamamla.BackColor = Color.Maroon;
            btn_KaydiTamamla.ForeColor = Color.White;
        }

        private void btn_KaydiTamamla_MouseLeave(object sender, EventArgs e)
        {
            btn_KaydiTamamla.BackColor = Color.White;
            btn_KaydiTamamla.ForeColor = Color.Black;
        }

    }
}
