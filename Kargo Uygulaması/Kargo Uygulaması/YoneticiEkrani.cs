using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Kargo_Uygulaması
{
    public partial class YoneticiEkrani : Form
    {
        public YoneticiEkrani()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=.;Initial Catalog=GorselKargoUygulamasıDB;Integrated Security=True;");

        struct Müdür
        {
            public string Isim;
            public string Soyisim;
            public string SicilNo;
        }

        long TC;
        private void YoneticiEkrani_Load(object sender, System.EventArgs e)
        {
            try
            {
                // Labellerin arka plan rengini kaldır
                lbl_Marka.Parent = picture_üst;
                lbl_AdSoyad.Parent = picture_üst;
                lbl_SicilNo.Parent = picture_üst;
                lbl_SubeAdres.Parent = picture_üst;

                TC = Form1.DogruTC;

                // Giriş Yapan Müdür Bilgilerini Veritabanından Çekme
                baglanti.Open();
                string sorgu = "select * from Personel where TCnumara = @TC";
                SqlCommand cmd = new SqlCommand(sorgu, baglanti);
                cmd.Parameters.AddWithValue("@TC", TC);
                SqlDataReader dr = cmd.ExecuteReader();

                Müdür M1 = new Müdür();

                if (dr.Read())
                {
                    M1.Isim = dr["Ad"].ToString();
                    M1.Soyisim = dr["Soyad"].ToString();
                    M1.SicilNo = dr["SicilNo"].ToString();
                }

                lbl_AdSoyad.Text = "Müdür Ad : " + M1.Isim.ToString() + " " + M1.Soyisim.ToString();
                lbl_SicilNo.Text = "Sicil No : " + M1.SicilNo;

                baglanti.Close();


                ///////// PANELLER İÇİN GEREKLİ AYARLAR \\\\\\\\\\\

                pnl_PersonelEkle.Top = 124;
                pnl_PersonelEkle.Left = 4;
                pnl_PersonelEkle.Width = 1272;
                pnl_PersonelEkle.Height = 605;

                pnl_PersonelSil.Top = 124;
                pnl_PersonelSil.Left = 4;
                pnl_PersonelSil.Width = 1272;
                pnl_PersonelSil.Height = 605;

                pnl_PersonelBilgisiGuncelle.Top = 124;
                pnl_PersonelBilgisiGuncelle.Left = 4;
                pnl_PersonelBilgisiGuncelle.Width = 1272;
                pnl_PersonelBilgisiGuncelle.Height = 605;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "HATA");
            }
        }

        /////////////// ANA SAYFA BUTON KONTROLLERİ \\\\\\\\\\\\\\\
        private void btn_PersonelEkle_Click(object sender, EventArgs e)
        {
            try
            {
                // Panel kapalıyken buton tıklanırsa
                if (pnl_PersonelEkle.Visible == false)
                {
                    // Butonların renk ayarları
                    btn_PersonelEkle.BackColor = Color.DarkRed;

                    btn_PersonelSil.BackColor = Color.MidnightBlue;
                    btn_PersonelGuncelle.BackColor = Color.MidnightBlue;
                    btn_SubeGuncelle.BackColor = Color.MidnightBlue;
                    btn_Raporlar.BackColor = Color.MidnightBlue;

                    // Geçerli paneli aç ve diğerlerini kapat
                    pnl_PersonelEkle.Visible = true;
                    pnl_PersonelSil.Visible = false;
                    pnl_PersonelBilgisiGuncelle.Visible = false;
                }

                // Panel açıkken buton tıklanırsa
                else
                {
                    // Geçerli butonun renk ayarı
                    btn_PersonelEkle.BackColor = Color.MidnightBlue;

                    // Geçerli Paneli Kapat
                    pnl_PersonelEkle.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "HATA");
            }
        }

        private void btn_PersonelSil_Click(object sender, EventArgs e)
        {
            try
            {
                // Geçerli Panel Kapalıyken Tıklanırsa
                if (pnl_PersonelSil.Visible == false)
                {
                    // Butonların renk ayarı
                    btn_PersonelSil.BackColor = Color.DarkRed;

                    btn_PersonelEkle.BackColor = Color.MidnightBlue;
                    btn_PersonelGuncelle.BackColor = Color.MidnightBlue;
                    btn_SubeGuncelle.BackColor = Color.MidnightBlue;
                    btn_Raporlar.BackColor = Color.MidnightBlue;

                    // Geçerli Paneli Aç ve Diğerlerini Kapat
                    pnl_PersonelSil.Visible = true;
                    pnl_PersonelEkle.Visible = false;
                    pnl_PersonelBilgisiGuncelle.Visible = false;
                }

                // Geçerli Panel Açıkken Tıklanırsa
                else
                {
                    btn_PersonelSil.BackColor = Color.MidnightBlue;
                    pnl_PersonelSil.Visible = false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "HATA");
            }
        }

        private void btn_PersonelGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                // Geçerli Panel Kapalıyken Tıklanırsa
                if (pnl_PersonelBilgisiGuncelle.Visible == false)
                {
                    // Butonların renk ayarı
                    btn_PersonelGuncelle.BackColor = Color.DarkRed;

                    btn_PersonelEkle.BackColor = Color.MidnightBlue;
                    btn_PersonelSil.BackColor = Color.MidnightBlue;
                    btn_SubeGuncelle.BackColor = Color.MidnightBlue;
                    btn_Raporlar.BackColor = Color.MidnightBlue;

                    // Geçerli Paneli Aç ve Diğerlerini Kapat
                    pnl_PersonelBilgisiGuncelle.Visible = true;
                    pnl_PersonelEkle.Visible = false;
                    pnl_PersonelSil.Visible = false;
                }

                // Geçerli Panel Açıkken Tıklanırsa
                else
                {
                    btn_PersonelGuncelle.BackColor = Color.MidnightBlue;
                    pnl_PersonelBilgisiGuncelle.Visible = false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "HATA");
            }
        }

        private void btn_SubeGuncelle_Click(object sender, EventArgs e)
        {

        }

        private void btn_Raporlar_Click(object sender, EventArgs e)
        {

        }

        private void btn_CikisYap_Click(object sender, EventArgs e)
        {

        }


        ///////// PERSONEL EKLEME KONTROLÜ \\\\\\\\\


        // TC Kontrolü
        private void txt_KayitTC_TextChanged(object sender, EventArgs e)
        {
            TChatasi.Clear();

            if (txt_KayitTC.Text != "")
            {
                KayitTCkontrolü(txt_KayitTC.Text);
            }
        }

        public void KayitTCkontrolü(string TC)
        {
            // İlk rakam 0'sa metin kutusunu temizle
            if (TC.Length == 1 && TC == "0")
                txt_KayitTC.Text = "";

            // İlk rakam 0 değilse diğer kontroller
            else
            {
                // TC 10 Basamak olunca 10. Rakamı kontrol et
                if (TC.Length == 10)
                {
                    long TCsayisi = long.Parse(TC);

                    int[] TCrakamlar = new int[10];

                    long basdeger = 10, saydeger = 1;

                    // Rakamlar dizisi oluştur
                    for (int i = 0; i < TCrakamlar.Length; i++)
                    {
                        TCrakamlar[i] = Convert.ToInt16((TCsayisi % basdeger) / saydeger);
                        basdeger *= 10;
                        saydeger *= 10;
                    }

                    // tek ve çift basamakları topla 10. Rakamı dahil etme !!
                    int TekToplam = 0, CiftToplam = 0;
                    for (int i = 1; i < TCrakamlar.Length; i++)
                    {
                        if (i % 2 == 0)
                            CiftToplam += TCrakamlar[i];
                        else
                            TekToplam += TCrakamlar[i];
                    }

                    // 10. Rakam hesaplamanın dışındaysa hata ver
                    if (TCrakamlar[0] != (TekToplam * 7 - CiftToplam) % 10)
                        TChatasi.SetError(txt_KayitTC, "10. Rakam Hatalı");
                }

                // TC 11 Basamak olunca önce 10. sonra 11. rakam kontrolü yap
                else if (TC.Length == 11)
                {
                    long TCsayisi = long.Parse(TC);

                    int[] rakamlar = new int[11];

                    long BasDeger = 10, SayDeger = 1;
                    // Rakamlar dizisi oluştur
                    for (int i = 0; i < rakamlar.Length; i++)
                    {
                        rakamlar[i] = Convert.ToInt16(TCsayisi % BasDeger / SayDeger);

                        BasDeger *= 10;
                        SayDeger *= 10;
                    }

                    // Tek ve Çift Basamakları Topla
                    int TeklerToplami = 0, CiftlerToplami = 0;

                    for (int i = 2; i < rakamlar.Length; i++)
                    {
                        if (i % 2 == 0)
                            TeklerToplami += rakamlar[i];
                        else
                            CiftlerToplami += rakamlar[i];
                    }
                    // 10. Rakam Kontrolü
                    if (rakamlar[1] != (TeklerToplami * 7 - CiftlerToplami) % 10)
                        TChatasi.SetError(txt_KayitTC, "10. Rakam Hatalı");

                    // 10. Rakam Doğruysa 11. Rakam Kontrolü
                    else
                    {
                        if (rakamlar[0] != (TeklerToplami + CiftlerToplami + rakamlar[1]) % 10)
                            TChatasi.SetError(txt_KayitTC, "11. Rakam Hatalı");

                        // Her şey doğruysa butonu aktifleştir
                        else
                            btn_KaydiTamamla.Enabled = true;
                    }
                }
            }
        }


        // Kaydı Tamamla Butonu Tıkanırsa
        private void btn_KaydiTamamla_Click(object sender, EventArgs e)
        {
            try
            {
                string Ad = txt_KayitAd.Text;
                string Soyad = txt_KayitSoyad.Text;
                string Telefon = txt_KayitTelefon.Text;
                string Sifre = txt_KayitSifre.Text;
                string Eposta = txt_KayitEposta.Text;

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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "HATA");
            }
        }

        // Personel Ekleme Fonksiyonu

        void PersonelEkle(string TC, string Ad, string Soyad, string Telefon, string Sifre, string Eposta)
        {
            try
            {
                baglanti.Open();

                // Sicil No'yu Rastgele versin
                Random r = new Random();

                string kayit = "insert into Personel (TCnumara, Ad, Soyad, Telefon, Eposta, Sifre, SicilNo, Statü) values (@TCNo, @Ad, @Soyad, @Telefon, @Eposta, @Sifre, @SicilNo, 'Personel')";
                SqlCommand ekle = new SqlCommand(kayit, baglanti);

                ekle.Parameters.AddWithValue("@TCNo", TC);
                ekle.Parameters.AddWithValue("@Ad", Ad);
                ekle.Parameters.AddWithValue("@Soyad", Soyad);
                ekle.Parameters.AddWithValue("@Telefon", Telefon);
                ekle.Parameters.AddWithValue("@Eposta", Eposta);
                ekle.Parameters.AddWithValue("@Sifre", Sifre);
                ekle.Parameters.AddWithValue("@SicilNo", r.Next(100000, 1000000));
                ekle.ExecuteNonQuery();
                baglanti.Close();

                MessageBox.Show("Kayıt Başarıyla Eklenmiştir", "BAŞARILI", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /////////// PERSONEL SİLME KONTROLÜ \\\\\\\\\\

        private void btn_SilmeyiTamamla_Click(object sender, EventArgs e)
        {
            try
            {
                // Silme için gerekli değişkenler
                string Ad = txt_PersonelSilAd.Text;
                string Soyad = txt_PersonelSilSoyad.Text;
                string SicilNo = txt_PersonelSilSicilNo.Text;

                baglanti.Open();

                string SilmeKomutu = "select * from Personel where Ad = @Ad and Soyad = @Soyad and SicilNo = @SicilNo";
                SqlCommand cmd = new SqlCommand(SilmeKomutu, baglanti);
                cmd.Parameters.AddWithValue("@Ad", Ad);
                cmd.Parameters.AddWithValue("@Soyad", Soyad);
                cmd.Parameters.AddWithValue("@SicilNo", SicilNo);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    baglanti.Close();
                    baglanti.Open();
                    string sil = "delete from Personel where SicilNo = @Sicil";
                    SqlCommand komut = new SqlCommand(sil, baglanti);
                    komut.Parameters.AddWithValue("@Sicil", SicilNo);
                    SqlDataReader dataread = komut.ExecuteReader();
                    MessageBox.Show("Personel Silinmiştir", "Silme İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    baglanti.Close();

                    // Silme işlemi tamamlanırsa textboxları temizle
                    txt_PersonelSilAd.Text = "";
                    txt_PersonelSilSoyad.Text = "";
                    txt_PersonelSilSicilNo.Text = "";
                }
                else
                {
                    MessageBox.Show("Girilen bilgilere ait personel bulunamadı", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    baglanti.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        ///////// PERSONEL BİLGİSİ GÜNCELLEME \\\\\\\\\\\

        // TC Kontrolü
        private void txt_PersonelGuncelleTC_TextChanged(object sender, EventArgs e)
        {
            TChatasi.Clear();

            if (txt_PersonelGuncelleTC.Text != "")
                PersonelGuncelleTCkontrolü(txt_PersonelGuncelleTC.Text);
        }

        void PersonelGuncelleTCkontrolü(string TCmetni)
        {
            // İlk Rakam 0 girilirse sil
            if (TCmetni == "0")
            {
                txt_PersonelGuncelleTC.Text = "";
            }

            else
            {
                // Metin uzunluğu 10 olursa 10. Rakamı Kontrol et
                if (TCmetni.Length == 10)
                {
                    long TC = long.Parse(TCmetni);
                    long BasDeger = 10, SayDeger = 1;
                    int[] TCrakamlar = new int[10];
                    int TekToplam = 0, CiftToplam = 0;

                    // rakamlar dizisini doldur
                    for (int i = TCrakamlar.Length - 1; i >= 0; i--)
                    {
                        TCrakamlar[i] = Convert.ToInt16(TC % BasDeger / SayDeger);
                        BasDeger *= 10;
                        SayDeger *= 10;

                        // tekler ve çiftleri topla 10. rakamı dahil etme
                        if (i < TCrakamlar.Length - 1)
                        {
                            if (i % 2 == 0)
                                TekToplam += TCrakamlar[i];
                            else
                                CiftToplam += TCrakamlar[i];
                        }
                    }
                    if (TCrakamlar[9] != (TekToplam * 7 - CiftToplam) % 10)
                        TChatasi.SetError(txt_PersonelGuncelleTC, "10.Rakam Hatalı");
                }

                // Metin uzunluğu 11 olursa önce 10. rakam sonra 11. rakam kontrolü yap
                else if (TCmetni.Length == 11)
                {
                    long TC = long.Parse(TCmetni);
                    long BasDeger = 10, SayDeger = 1;
                    int[] TCrakamlar = new int[11];
                    int TekToplam = 0, CiftToplam = 0;

                    // Rakamlar dizisini oluştur
                    for (int i = TCrakamlar.Length - 1; i >= 0; i--)
                    {
                        TCrakamlar[i] = Convert.ToInt16(TC % BasDeger / SayDeger);
                        BasDeger *= 10;
                        SayDeger *= 10;

                        // Tekler ve çiftler yopla 10. ve 11. rakamları dahil etme
                        if (i < TCrakamlar.Length - 2)
                        {
                            if (i % 2 == 0)
                                TekToplam += TCrakamlar[i];
                            else
                                CiftToplam += TCrakamlar[i];
                        }
                    }

                    if (TCrakamlar[9] != (TekToplam * 7 - CiftToplam) % 10)
                        TChatasi.SetError(txt_PersonelGuncelleTC, "10. Rakam Hatası");

                    // 10. rakam Doğruysa 11. Rakam Kontrolü
                    else
                    {
                        if (TCrakamlar[10] != (TekToplam + CiftToplam + TCrakamlar[9]) % 10)
                            TChatasi.SetError(txt_PersonelGuncelleTC, "11. Rakam Hatası");
                        else
                            btn_PersonelGuncelleSorgula.Enabled = true;
                    }
                }
            }
        }

        // Sorgula butonu tıklanırsa veritabanından kayıtlar gelsin
        private void btn_PersonelGuncelleSorgula_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();

                string sorgu = "select Ad, Soyad, Eposta, Telefon, SicilNo from Personel where TCnumara = @TC";
                SqlCommand cmd = new SqlCommand(sorgu, baglanti);
                cmd.Parameters.AddWithValue("@TC", txt_PersonelGuncelleTC.Text);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    lbl_GuncelleAd.Text = "Ad : " + dr["Ad"].ToString();
                    lbl_GuncelleSoyad.Text = "Soyad : " + dr["Soyad"].ToString();
                    lbl_GuncelleEposta.Text = "E-posta : " + dr["Eposta"].ToString();
                    lbl_GuncelleTelefon.Text = "Telefon : " + dr["Telefon"].ToString();
                    lbl_guncelleSicilNo.Text = "Sicil No : " + dr["SicilNo"].ToString();

                    btn_PersonelGuncellemeIslemi.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Girilen TC ile eşleşen kayıt bulunamadı", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                baglanti.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        // Güncelle butonu tıklanırsa gerekli işlemler /* HATALI ALAN */
        private void btn_PersonelGuncellemeIslemi_Click(object sender, EventArgs e)
        {
            try
            {

                /*--- Güncelleme Kısmında HATA VAR ---*/

                /*
                string DegisecekAlan = cmbBox_GuncellenecekAlan.Text;

                string DegistirmeSorgusu = "update Personel set @Alan = @yenideger where TCnumara = @TC";
                baglanti.Open();
                SqlCommand update = new SqlCommand(DegistirmeSorgusu, baglanti);
                update.Parameters.AddWithValue("@Alan", DegisecekAlan);
                update.Parameters.AddWithValue("@yenideger", txt_PersonelGuncelleYeniDeger.Text);
                update.Parameters.AddWithValue("@TC", txt_PersonelGuncelleTC.Text);
                SqlDataReader DR = update.ExecuteReader();

                if (DR.Read())
                {
                    MessageBox.Show("Bilgi Güncellenmiştir", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                */
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
