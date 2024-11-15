using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Kargo_Uygulaması
{
    public partial class AnaSayfa : Form
    {
        public AnaSayfa()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=.;Initial Catalog=GorselKargoUygulamasıDB;Integrated Security=True;");

        long TC;

        public struct Personel
        {
            public string Ad;
            public string Soyad;
            public string SicilNo;
        }


        private void AnaSayfa_Load(object sender, EventArgs e)
        {
            try
            {
                // Metinlerin arka planını kaldır
                lbl_Marka.Parent = picture_Sol;
                lbl_PerBilgisi.Parent = picture_Sol;
                lbl_AdSoyad.Parent = picture_Sol;
                lbl_SicilNo.Parent = picture_Sol;
                lbl_SubeAdres.Parent = picture_Sol;

                // Giriş yapan personelin bilgilerini göster
                TC = Form1.DogruTC;

                Personel personel = new Personel();

                // Giriş Yapan Personelin Adı
                baglanti.Open();
                string sorgu = "select Ad from Personel where TCnumara = " + TC;
                SqlCommand AdKomutu = new SqlCommand(sorgu, baglanti);

                AdKomutu.ExecuteNonQuery();
                SqlDataReader isimbul = AdKomutu.ExecuteReader();

                if (isimbul.Read())
                {
                    personel.Ad = isimbul["Ad"].ToString();
                }
                isimbul.Close();

                // Giriş Yapan Personelin Soyadı
                sorgu = "select Soyad from Personel where TCnumara = " + TC;
                SqlCommand SoyadBul = new SqlCommand(sorgu, baglanti);
                SoyadBul.ExecuteNonQuery();
                SqlDataReader soyisimbul = SoyadBul.ExecuteReader();

                if (soyisimbul.Read())
                {
                    personel.Soyad = soyisimbul["Soyad"].ToString();
                }
                soyisimbul.Close();

                // Giriş Yapan Personelin Sicil No'su
                sorgu = "select SicilNo from Personel where TCnumara = " + TC;
                SqlCommand sicilNoBul = new SqlCommand(sorgu, baglanti);
                sicilNoBul.ExecuteNonQuery();
                SqlDataReader sicilNo = sicilNoBul.ExecuteReader();

                if (sicilNo.Read())
                {
                    personel.SicilNo = sicilNo["SicilNo"].ToString();
                }

                baglanti.Close();

                // Personelin adını, soyadını ve sicil numarasını yazdır
                lbl_AdSoyad.Text = personel.Ad + " " + personel.Soyad;
                lbl_SicilNo.Text = "Sicil No :" + personel.SicilNo;


                // Panelleri Gizle
                pnl_GonderiOlustur.Visible = false;
                pnl_PaketBilgileri.Visible = false;


                // Form Yüklenirken Gönderi ekranındaki iller veritabanından gelsin

                Illeri_getir();


                // Panelleri Yerleştir

                pnl_GonderiOlustur.Left = 0;
                pnl_GonderiOlustur.Top = 113;

                pnl_PaketBilgileri.Left = 0;
                pnl_PaketBilgileri.Top = 113;

                pnl_KargoSorgula.Left = 0;
                pnl_KargoSorgula.Top = 113;

                pnl_FiyatBilgisi.Left = 0;
                pnl_FiyatBilgisi.Top = 113;

                pnl_Raporlar.Left = 0;
                pnl_Raporlar.Top = 113;

                pnl_TahminOyunu.Left = -300;
                pnl_TahminOyunu.Top = 147;

                btn_TahminEtGosterGizle.Left = 35;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }



        //////////// Ana Sayfa Buton Kontrolleri \\\\\\\\\\\\\

        private void btn_GonderiOlustur_Click(object sender, EventArgs e)
        {
            try
            {
                // Gönderi Oluştur Paneli Kapalıysa Aç
                if (pnl_GonderiOlustur.Visible == false && pnl_PaketBilgileri.Visible == false)
                {
                    pnl_GonderiOlustur.Top = 113;
                    pnl_GonderiOlustur.Left = 0;
                    pnl_GonderiOlustur.Visible = true;
                    pnl_GonderiOlustur.BringToFront();

                    pnl_PaketBilgileri.Left = 0;
                    pnl_PaketBilgileri.Top = 113;
                    pnl_PaketBilgileri.BringToFront();

                    // Açıktaki Diğer Panelleri Kapat
                    pnl_KargoSorgula.Visible = false;
                    pnl_FiyatBilgisi.Visible = false;
                    pnl_Raporlar.Visible = false;

                    // Gönderi Oluştur butonun rengini Kırmızı Yap Diğerlerini Mavi Yap
                    btn_GonderiOlustur.BackColor = Color.DarkRed;
                    btn_KargoSorgula.BackColor = Color.MidnightBlue;
                    btn_Raporlar.BackColor = Color.MidnightBlue;
                    btn_FiyatBilgisi.BackColor = Color.MidnightBlue;
                }

                // Gönderi Oluşturma Paneli Aktifken Butona Tıklanırsa
                else
                {
                    btn_GonderiOlustur.BackColor = Color.MidnightBlue;

                    pnl_PaketBilgileri.Visible = false;
                    pnl_GonderiOlustur.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "HATA");
            }

        }
        private void btn_KargoSorgula_Click(object sender, EventArgs e)
        {
            try
            {
                // Kargo sorgulama panelini aç ve açıkta olan panelleri kapat
                if (pnl_KargoSorgula.Visible == false)
                {
                    btn_KargoSorgula.BackColor = Color.DarkRed;
                    pnl_KargoSorgula.Top = 113;
                    pnl_KargoSorgula.Left = 0;
                    pnl_KargoSorgula.Visible = true;
                    pnl_KargoSorgula.BringToFront();

                    btn_GonderiOlustur.BackColor = Color.MidnightBlue;
                    pnl_GonderiOlustur.Visible = false;
                    pnl_PaketBilgileri.Visible = false;
                    btn_FiyatBilgisi.BackColor = Color.MidnightBlue;
                    pnl_FiyatBilgisi.Visible = false;
                    btn_Raporlar.BackColor = Color.MidnightBlue;
                    pnl_Raporlar.Visible = false;
                }
                // Kargo Sorgulama Paneli Açıkken Butona Tıklanırsa
                else
                {
                    pnl_KargoSorgula.Visible = false;
                    btn_KargoSorgula.BackColor = Color.MidnightBlue;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "HATA");
            }
        }
        private void btn_FiyatBilgisi_Click(object sender, EventArgs e)
        {
            try
            {
                // fiyat Bilgisi Panelini Aç ve Diğerlerini Kapat
                if (pnl_FiyatBilgisi.Visible == false)
                {
                    pnl_FiyatBilgisi.Left = 0;
                    pnl_FiyatBilgisi.Top = 113;
                    pnl_FiyatBilgisi.Visible = true;
                    btn_FiyatBilgisi.BackColor = Color.DarkRed;
                    pnl_FiyatBilgisi.BringToFront();

                    btn_GonderiOlustur.BackColor = Color.MidnightBlue;
                    pnl_GonderiOlustur.Visible = false;
                    pnl_PaketBilgileri.Visible = false;

                    btn_KargoSorgula.BackColor = Color.MidnightBlue;
                    pnl_KargoSorgula.Visible = false;

                    btn_Raporlar.BackColor = Color.MidnightBlue;
                    pnl_Raporlar.Visible = false;

                }
                // Fiyat Bilgisi Paneli Açıkken Buton Tıklanırsa
                else
                {
                    pnl_FiyatBilgisi.Visible = false;
                    btn_FiyatBilgisi.BackColor = Color.MidnightBlue;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "HATA");
            }

        }
        private void btn_Raporlar_Click(object sender, EventArgs e)
        {
            try
            {
                // Panel Kapalıyken buton tıklanırsa
                if (pnl_Raporlar.Visible == false)
                {
                    // Önceki butonların arka rengini mavi bu butonunkini kırmızı yap
                    btn_GonderiOlustur.BackColor = Color.MidnightBlue;
                    btn_KargoSorgula.BackColor = Color.MidnightBlue;
                    btn_FiyatBilgisi.BackColor = Color.MidnightBlue;
                    btn_CikisYap.BackColor = Color.MidnightBlue;

                    btn_Raporlar.BackColor = Color.DarkRed;

                    // Açıkta Panel varsa kapat
                    pnl_GonderiOlustur.Visible = false;
                    pnl_PaketBilgileri.Visible = false;
                    pnl_FiyatBilgisi.Visible = false;
                    pnl_KargoSorgula.Visible = false;

                    // Geçerli Paneli Aç
                    pnl_Raporlar.Visible = true;
                    pnl_Raporlar.BringToFront();

                }
                // Panel açıkken buton tıklanırsa
                else
                {
                    pnl_Raporlar.Visible = false;

                    btn_Raporlar.BackColor = Color.MidnightBlue;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "HATA");
            }
        }
        private void btn_CikisYap_Click(object sender, EventArgs e)
        {
            if (pnl_PaketBilgileri.Visible == true || pnl_GonderiOlustur.Visible == true)
            {
                DialogResult yanit = MessageBox.Show("Devam eden bir işlem mevcut \n Çıkış yapmak istediğinize emin misiniz ?", "Çıkış", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (yanit == DialogResult.OK)
                {
                    Form1 form = new Form1();
                    form.Show();
                    this.Close();
                }

            }
            else
            {
                DialogResult yanit = MessageBox.Show("Çıkış yapmak istediğinize \n Emin misiniz ?", "ÇIKIŞ", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (yanit == DialogResult.OK)
                {
                    Form1 form = new Form1();
                    form.Show();
                    this.Close();
                }
            }
        }



        // TC ve Telefon kutularına sadece rakam girilsin

        private void txt_GonderenTCno_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txt_GonderenTelefon_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txt_AliciTelefon_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }


        // Bireysel - Kurumsal Kontrolü
        private void radio_Kurumsal_CheckedChanged(object sender, EventArgs e)
        {
            txt_GonderenVergiNo.BackColor = Color.White;
            txt_GonderenVergiNo.Enabled = true;
            txt_GonderenKurumAd.BackColor = Color.White;
            txt_GonderenKurumAd.Enabled = true;
            txt_AnlasmaKodu.BackColor = Color.White;
            txt_AnlasmaKodu.Enabled = true;

            txt_GonderenTCno.BackColor = Color.DarkGray;
            txt_GonderenTCno.Enabled = false;
            txt_GonderenBireyselAd.BackColor = Color.DarkGray;
            txt_GonderenBireyselAd.Enabled = false;
            txt_GonderenSoyad.BackColor = Color.DarkGray;
            txt_GonderenSoyad.Enabled = false;

            TChatasi.Clear();
            TCbasamakHatasi.Clear();
        }

        private void radio_Bireysel_CheckedChanged(object sender, EventArgs e)
        {
            txt_GonderenTCno.BackColor = Color.White;
            txt_GonderenTCno.Enabled = true;
            txt_GonderenBireyselAd.BackColor = Color.White;
            txt_GonderenBireyselAd.Enabled = true;
            txt_GonderenSoyad.BackColor = Color.White;
            txt_GonderenSoyad.Enabled = true;

            txt_GonderenVergiNo.BackColor = Color.DarkGray;
            txt_GonderenVergiNo.Enabled = false;
            txt_GonderenKurumAd.BackColor = Color.DarkGray;
            txt_GonderenKurumAd.Enabled = false;
            txt_AnlasmaKodu.BackColor = Color.DarkGray;
            txt_AnlasmaKodu.Enabled = false;
        }

        // TC Kontrolü
        private void txt_GonderenTCno_TextChanged(object sender, EventArgs e)
        {
            if (txt_GonderenTCno.Text != "")
                TCkontrolü();
        }

        int hatasayac = 0;
        void TCkontrolü()
        {
            string TCtext = txt_GonderenTCno.Text;
            long TC;
            int[] rakamlar = new int[10];
            int tektoplam = 0, cifttoplam = 0;

            btn_PaketBilgileri.Enabled = false;

            // İlk rakam 0 mı ?
            if (TCtext[0] == '0')
            {
                TChatasi.SetError(txt_GonderenTCno, "İlk Rakam 0 Olamaz");
            }

            // İlk rakam 0 değilse gerekli işlemleri yap
            else
            {
                TChatasi.Clear();

                // TC'nin 10. karakteri girildiğinde
                if (TCtext.Length == 10)
                {
                    TC = long.Parse(TCtext);

                    long BasDeger = 10, SayDeger = 1;

                    for (int i = TCtext.Length - 1; i >= 0; i--) // İlk 10 rakamı rakamlar[] dizisine aktar
                    {
                        rakamlar[i] = Convert.ToUInt16((TC % BasDeger) / SayDeger);
                        BasDeger *= 10;
                        SayDeger *= 10;
                    }

                    // Tek ve çift basamakaları topla --> 10.rakam hariç!!
                    for (int i = 0; i < rakamlar.Length - 1; i++)
                    {
                        if (i % 2 == 0)
                            tektoplam += rakamlar[i];
                        else
                            cifttoplam += rakamlar[i];
                    }

                    // Eğer 10. rakam hesaplananın dışındaysa hata ver
                    if (rakamlar[9] != ((tektoplam * 7) - cifttoplam) % 10)
                    {
                        // 10. Rakam yanlışsa 11. Rakam girişine izin verme
                        TChatasi.SetError(txt_GonderenTCno, "10. Rakam Hatası");
                        txt_GonderenTCno.MaxLength = 10;
                    }
                    else
                    {
                        // 10. rakam doğruysa 11. rakam girişine izin ver
                        txt_GonderenTCno.MaxLength = 11;
                        TChatasi.Clear();
                    }
                }

                // TC'nin 11. basamağı girildiğinde
                else if (TCtext.Length == 11)
                {
                    TChatasi.Clear();
                    hatasayac--;

                    TC = long.Parse(TCtext);
                    long BasDeger = 10, SayDeger = 1;
                    int ilk10toplami = 0;

                    // rakamlar[] dizisinin eleman sayını arttır
                    int[] yenirakamlar = new int[rakamlar.Length + 1];

                    // İlk 11 rakamı rakamlar[] dizisine aktar
                    for (int i = TCtext.Length - 1; i >= 0; i--)
                    {
                        yenirakamlar[i] = Convert.ToUInt16((TC % BasDeger) / SayDeger);
                        BasDeger *= 10;
                        SayDeger *= 10;
                    }

                    // İlk 10 rakamı topla --> 11. Rakam Hariç!!
                    for (int i = 0; i < rakamlar.Length; i++)
                    {
                        ilk10toplami += yenirakamlar[i];
                    }


                    // 11. rakam hesaplamanın dışındaysa hata ver
                    if (yenirakamlar[10] != ilk10toplami % 10)
                    {
                        TChatasi.SetError(txt_GonderenTCno, "11. Rakam Hatası");
                        hatasayac--;
                    }
                    else
                        btn_PaketBilgileri.Enabled = true;
                }
            }
        }

        private void txt_GonderenTCno_Leave(object sender, EventArgs e)
        {
            if (txt_GonderenTCno.Text.Length < 11)
            {
                TCbasamakHatasi.SetError(txt_GonderenTCno, "TC 11 Haneli Olmalıdır");
            }
        }

        private void txt_GonderenTCno_Enter(object sender, EventArgs e)
        {
            TCbasamakHatasi.Clear();
        }

        // Mersis No Kontrolü
        private void txt_GonderenVergiNo_TextChanged(object sender, EventArgs e)
        {
            btn_PaketBilgileri.Enabled = false;
            TChatasi.Clear();
            string VergiNo = txt_GonderenVergiNo.Text;

            // Girilen Vergi No Doğru Mu
            if (VergiNo.Length == 10)
            {
                int VergiSayisi = Convert.ToInt32(VergiNo);
                int BasDeger = 10, SayDeger = 1;
                int[] VergiRakamlar = new int[10];
                int toplam = 0;

                for (int i = VergiRakamlar.Length - 1; i >= 0; i--)
                {
                    VergiRakamlar[i] = VergiSayisi % BasDeger / SayDeger;
                    BasDeger *= 10;
                    SayDeger *= 10;

                    if (i < VergiRakamlar.Length - 1)
                        toplam += VergiRakamlar[i];
                }
                if (VergiRakamlar[9] != toplam % 10)
                    TChatasi.SetError(txt_GonderenVergiNo, "Vergi No Hatalı");
                else
                    btn_PaketBilgileri.Enabled = true;
            }
        }

        // İl - İlçe Comboboxlarının kontrolü
        private void cmbBox_Gonderen_il_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbBox_Gonderen_ilce.Text = "";
            cmbBox_Gonderen_mahalle.Text = "";

            cmbBox_Gonderen_ilce.Items.Clear();
            cmbBox_Gonderen_mahalle.Items.Clear();

            Gonderen_Ilce_getir();
        }

        private void cmbBox_Gonderen_ilce_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbBox_Gonderen_mahalle.Text = "";
            cmbBox_Gonderen_mahalle.Items.Clear();

            Gonderen_Mahalle_Getir();
        }

        private void cmbBox_Alici_il_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbBox_Alici_ilce.Text = "";
            cmbBox_Alici_Mahalle.Text = "";

            cmbBox_Alici_ilce.Items.Clear();
            cmbBox_Alici_Mahalle.Items.Clear();

            Alici_Ilce_Getir();
        }

        private void cmbBox_Alici_ilce_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbBox_Alici_Mahalle.Text = "";
            cmbBox_Alici_Mahalle.Items.Clear();

            Alici_Mahalle_Getir();
        }

        // İl - ilçe - mahalle Kontrolleri
        void Illeri_getir()
        {
            try
            {
                baglanti.Open();

                string komut = "select * from sehir";

                SqlCommand cmd = new SqlCommand(komut, baglanti);
                cmd.ExecuteNonQuery();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    cmbBox_Alici_il.Items.Add(dr["sehir_title"]);
                    cmbBox_Gonderen_il.Items.Add(dr["sehir_title"]);
                }

                baglanti.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "HATA");
            }
        }
        void Gonderen_Ilce_getir()
        {
            try
            {
                baglanti.Open();

                string komut = "select ilce.ilce_title from ilce inner join sehir on ilce.ilce_sehirkey = sehir.sehir_key where sehir_title = @sehirAd";
                SqlCommand cmd = new SqlCommand(komut, baglanti);
                cmd.Parameters.AddWithValue("@sehirAd", cmbBox_Gonderen_il.Text);
                cmd.ExecuteNonQuery();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    cmbBox_Gonderen_ilce.Items.Add(dr["ilce_title"]);
                }

                baglanti.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "HATA");
            }
        }
        void Alici_Ilce_Getir()
        {
            try
            {
                baglanti.Open();

                string komut = "select ilce.ilce_title from ilce inner join sehir on ilce.ilce_sehirkey = sehir.sehir_key where sehir_title = @sehirAd";
                SqlCommand cmd = new SqlCommand(komut, baglanti);
                cmd.Parameters.AddWithValue("@sehirAd", cmbBox_Alici_il.Text);
                cmd.ExecuteNonQuery();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    cmbBox_Alici_ilce.Items.Add(dr["ilce_title"]);
                }

                baglanti.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "HATA");
            }
        }
        void Gonderen_Mahalle_Getir()
        {
            try
            {
                baglanti.Open();

                string komut = "select mahalle.mahalle_title from mahalle inner join ilce on mahalle.mahalle_ilcekey = ilce.ilce_key where ilce.ilce_title = @ilceAd";
                SqlCommand cmd = new SqlCommand(komut, baglanti);
                cmd.Parameters.AddWithValue("@ilceAd", cmbBox_Gonderen_ilce.Text);
                cmd.ExecuteNonQuery();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    cmbBox_Gonderen_mahalle.Items.Add(dr["mahalle_title"]);
                }

                baglanti.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "HATA");
            }
        }
        void Alici_Mahalle_Getir()
        {
            try
            {
                baglanti.Open();

                string komut = "select mahalle.mahalle_title from mahalle inner join ilce on mahalle.mahalle_ilcekey = ilce.ilce_key where ilce.ilce_title = @ilceAd";
                SqlCommand cmd = new SqlCommand(komut, baglanti);
                cmd.Parameters.AddWithValue("@ilceAd", cmbBox_Alici_ilce.Text);
                cmd.ExecuteNonQuery();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    cmbBox_Alici_Mahalle.Items.Add(dr["mahalle_title"]);
                }

                baglanti.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "HATA");
            }
        }


        ////// Paket Bilgilerine Geçiş \\\\\\
        private void btn_PaketBilgileri_Click(object sender, EventArgs e)
        {
            pnl_PaketBilgileri.Visible = true;
            pnl_GonderiOlustur.Visible = true;
        }

        ///////// Paket Bilgileri Paneli \\\\\\\\\\

        // Button Kontrolleri
        private void btn_GeriGit_Click(object sender, EventArgs e)
        {
            pnl_GonderiOlustur.Visible = true;
            pnl_PaketBilgileri.Visible = false;
        }

        // Ağırlık - Desi Kontrolleri ve Hesaplamaları
        private void radio_Agirlik_CheckedChanged(object sender, EventArgs e)
        {
            txt_Agirlik.Enabled = true;
            txt_Agirlik.BackColor = Color.White;

            txt_En.BackColor = Color.DarkGray;
            txt_En.Enabled = false;
            txt_Boy.BackColor = Color.DarkGray;
            txt_Boy.Enabled = false;
            txt_Yukseklik.BackColor = Color.DarkGray;
            txt_Yukseklik.Enabled = false;
            txt_Desi.Text = "";
            txt_En.Text = "";
            txt_Boy.Text = "";
            txt_Yukseklik.Text = "";
        }

        private void radio_Desi_CheckedChanged(object sender, EventArgs e)
        {
            txt_Agirlik.BackColor = Color.DarkGray;
            txt_Agirlik.Enabled = false;
            txt_Agirlik.Text = "";

            txt_En.Enabled = true;
            txt_En.BackColor = Color.White;
            txt_Boy.Enabled = true;
            txt_Boy.BackColor = Color.White;
            txt_Yukseklik.Enabled = true;
            txt_Yukseklik.BackColor = Color.White;
        }

        //-> Desi Hesabı

        double En = 1, Boy = 1, Yukseklik = 1, EBY = 1, Agirlik = 1, Desi;

        private void txt_Agirlik_TextChanged(object sender, EventArgs e)
        {
            if (txt_Agirlik.Text != "")
            {
                try
                {
                    Agirlik = Convert.ToDouble(txt_Agirlik.Text);

                    if (Agirlik / 1000 > EBY)
                        Desi = Agirlik / 1000;
                    else
                        Desi = EBY;

                    txt_Desi.Text = Desi.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void txt_Yukseklik_TextChanged(object sender, EventArgs e)
        {
            if (txt_Yukseklik.Text != "")
            {
                try
                {
                    Yukseklik = Convert.ToDouble(txt_Yukseklik.Text);

                    EBY = En * Boy * Yukseklik / 3000;

                    if (EBY > Agirlik / 1000)
                        Desi = EBY;
                    else
                        Desi = Agirlik / 1000;

                    txt_Desi.Text = Desi.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "HATA");
                }
            }
        }

        private void txt_Boy_TextChanged(object sender, EventArgs e)
        {
            if (txt_Boy.Text != "")
            {
                try
                {
                    Boy = Convert.ToDouble(txt_Boy.Text);

                    EBY = En * Boy * Yukseklik / 3000;

                    if (EBY > Agirlik / 1000)
                        Desi = EBY;
                    else
                        Desi = Agirlik / 1000;

                    txt_Desi.Text = Desi.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "HATA");
                }
            }
        }

        private void txt_En_TextChanged(object sender, EventArgs e)
        {
            if (txt_En.Text != "")
            {
                try
                {
                    En = Convert.ToDouble(txt_En.Text);

                    EBY = En * Boy * Yukseklik / 3000;

                    if (EBY > Agirlik / 1000)
                        Desi = EBY;
                    else
                        Desi = Agirlik / 1000;

                    txt_Desi.Text = Desi.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "HATA");
                }
            }
        }

        // Ağırlık ve Hacim Kutularına Yalnızca Sayı Girilsin
        private void txt_Agirlik_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txt_En_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txt_Boy_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        private void txt_Yukseklik_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }


        //////////// PAKETİ OLUŞTUR TIKLANIRSA VERİTABANINA KAYIT EKLE \\\\\\\\\\\\\

        public class Gonderen
        {
            public string TCno;
            public string VergiNo;
            public string Ad;
            public string Soyad;
            public string Telefon;
            public string Eposta;
            public string KurumAd;
            public string AnlasmaKodu;
            public string Il;
            public string Ilce;
            public string Mahalle;
            public string TamAdres;
        }
        public class Alici
        {
            public string Ad;
            public string Soyad;
            public string Telefon;
            public string Eposta;
            public string Il;
            public string Ilce;
            public string Mahalle;
            public string TamAdres;
        }



        /*--- Müşteri Ekleme Kısmı HATALI ---*/
        private void btn_PaketiOlustur_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Close();
                Gonderen YeniGonderen = new Gonderen();
                Alici YeniAlici = new Alici();

                bool GonderenOnayi = false;

                // Müşteri ekranında bireysel - kurumsal işlemine göre atama yap

                // Kurumsal
                if (radio_Kurumsal.Checked == true)
                {
                    YeniGonderen.VergiNo = txt_GonderenVergiNo.Text;
                    YeniGonderen.KurumAd = txt_GonderenKurumAd.Text;
                    YeniGonderen.Telefon = txt_GonderenTelefon.Text;
                    YeniGonderen.Eposta = txt_GonderenEposta.Text;
                    YeniGonderen.AnlasmaKodu = txt_AnlasmaKodu.Text;
                    YeniGonderen.Il = cmbBox_Gonderen_il.Text;
                    YeniGonderen.Ilce = cmbBox_Gonderen_ilce.Text;
                    YeniGonderen.Mahalle = cmbBox_Gonderen_mahalle.Text;
                    YeniGonderen.TamAdres = txt_GonderenTamAdres.Text;
                }

                // Bireysel
                else
                {
                    YeniGonderen.TCno = txt_GonderenTCno.Text;
                    YeniGonderen.Ad = txt_GonderenBireyselAd.Text;
                    YeniGonderen.Soyad = txt_GonderenSoyad.Text;
                    YeniGonderen.Telefon = txt_GonderenTelefon.Text;
                    YeniGonderen.Eposta = txt_GonderenEposta.Text;
                    YeniGonderen.Il = cmbBox_Gonderen_il.Text;
                    YeniGonderen.Ilce = cmbBox_Gonderen_ilce.Text;
                    YeniGonderen.Mahalle = cmbBox_Gonderen_mahalle.Text;
                    YeniGonderen.TamAdres = txt_GonderenTamAdres.Text;
                }

                // Alıcı atamaları
                YeniAlici.Ad = txt_AliciAd.Text;
                YeniAlici.Soyad = txt_AliciSoyad.Text;
                YeniAlici.Telefon = txt_AliciTelefon.Text;
                YeniAlici.Eposta = txt_AliciEposta.Text;
                YeniAlici.Il = cmbBox_Alici_il.Text;
                YeniAlici.Ilce = cmbBox_Alici_ilce.Text;
                YeniAlici.Mahalle = cmbBox_Alici_Mahalle.Text;
                YeniAlici.TamAdres = txt_AliciTamAdres.Text;
                /* ATAMALAR BİTİŞ */


                ////// Gonderen ve Alıcı bilgisini veri tabanına ekle \\\\\\\

                // İl ilce mahalle keylerine ulaşma
                string SehirKeySorgu = "select * from sehir where sehir_title = @SehirAd";
                baglanti.Open();
                int SehirKey = 0;
                SqlCommand SehirID = new SqlCommand(SehirKeySorgu, baglanti);
                SehirID.Parameters.AddWithValue("@SehirAd", YeniGonderen.Il);
                SqlDataReader SehirDR = SehirID.ExecuteReader();
                if (SehirDR.Read())
                {
                    SehirKey = Convert.ToInt32(SehirDR["sehir_key"]);
                }
                baglanti.Close();

                string IlceKeySorgu = "select * from ilce where ilce_title = @IlceAd";
                baglanti.Open();
                int IlceKey = 0;
                SqlCommand IlceID = new SqlCommand(IlceKeySorgu, baglanti);
                IlceID.Parameters.AddWithValue("@IlceAd", YeniGonderen.Ilce);
                SqlDataReader IlceDR = IlceID.ExecuteReader();
                if (IlceDR.Read())
                {
                    IlceKey = Convert.ToInt32(IlceDR["ilce_key"]);
                }
                baglanti.Close();

                string MahalleKeySorgu = "select * from mahalle where mahalle_title = @MahalleAd";
                baglanti.Open();
                int MahalleKey = 0;
                SqlCommand MahalleID = new SqlCommand(MahalleKeySorgu, baglanti);
                MahalleID.Parameters.AddWithValue("@MahalleAd", YeniGonderen.Mahalle);
                SqlDataReader MahalleDR = MahalleID.ExecuteReader();
                if (MahalleDR.Read())
                {
                    MahalleKey = Convert.ToInt32(MahalleDR["mahalle_key"]);
                }
                baglanti.Close();

                /*-------------*/

                baglanti.Open();

                //-> Gönderen Bireyselse

                if (YeniGonderen.TCno != null)
                {
                    string sorgu = "insert into Musteri(Musteri_TCno, Musteri_Ad, Musteri_Soyad, Musteri_TelefonNo, Musteri_Eposta, Musteri_Statü, Musteri_TamAdres, Musteri_SehirKey, Musteri_IlceKey, Musteri_MahalleKey) values (@TC, @Ad, @Soyad, @Telefon, @Eposta, 'Gonderici', @TamAdres, @IlKey, @IlceKey, @MahalleKey)";
                    SqlCommand Gonderenekle = new SqlCommand(sorgu, baglanti);
                    Gonderenekle.Parameters.AddWithValue("@TC", YeniGonderen.TCno);
                    Gonderenekle.Parameters.AddWithValue("@Ad", YeniGonderen.Ad);
                    Gonderenekle.Parameters.AddWithValue("@Soyad", YeniGonderen.Soyad);
                    Gonderenekle.Parameters.AddWithValue("@Telefon", YeniGonderen.Telefon);
                    Gonderenekle.Parameters.AddWithValue("@Eposta", YeniGonderen.Eposta);
                    Gonderenekle.Parameters.AddWithValue("@TamAdres", YeniGonderen.TamAdres);
                    Gonderenekle.Parameters.AddWithValue("@IlKey", SehirKey);
                    Gonderenekle.Parameters.AddWithValue("@IlceKey", IlceKey);
                    Gonderenekle.Parameters.AddWithValue("@MahalleKey", MahalleKey);
                    SqlDataReader EkleRead = Gonderenekle.ExecuteReader();

                    if (!EkleRead.Read())
                    {
                        GonderenOnayi = true;
                    }
                    EkleRead.Close();
                }
                //-> Gönderen Kurumsalsa
                else
                {
                    string sorgu = "insert into Musteri(Musteri_VergiNo, Musteri_TelefonNo, Musteri_Eposta, Musteri_KurumAd, Musteri_Statü, Musteri_TamAdres, Musteri_SehirKey, Musteri_IlceKey, Musteri_MahalleKey) values (@VergiNo, @Telefon, @Eposta, @KurumAd, 'Gonderici', @TamAdres, @IlKey, @IlceKey, @MahalleKey)";
                    SqlCommand Gonderenekle = new SqlCommand(sorgu, baglanti);
                    Gonderenekle.Parameters.AddWithValue("@VergiNo", YeniGonderen.VergiNo);
                    Gonderenekle.Parameters.AddWithValue("@Telefon", YeniGonderen.Telefon);
                    Gonderenekle.Parameters.AddWithValue("@Eposta", YeniGonderen.Eposta);
                    Gonderenekle.Parameters.AddWithValue("@KurumAd", YeniGonderen.KurumAd);
                    Gonderenekle.Parameters.AddWithValue("@TamAdres", YeniGonderen.TamAdres);
                    Gonderenekle.Parameters.AddWithValue("@IlKey", SehirKey);
                    Gonderenekle.Parameters.AddWithValue("@IlceKey", IlceKey);
                    Gonderenekle.Parameters.AddWithValue("@MahalleKey", MahalleKey);
                    SqlDataReader EkleRead = Gonderenekle.ExecuteReader();

                    if (!EkleRead.Read())
                    {
                        GonderenOnayi = true;
                    }

                    EkleRead.Close();
                }

                baglanti.Close();

                /*---------------*/

                //-> Alıcı Bilgisini VeriTabanına Ekleme

                // Alıcının İl-İlçe-Mahalle Keylerine Ulaşma
                // İl ilce mahalle keylerine ulaşma
                string AliciSehirKeySorgu = "select * from sehir where sehir_title = @AliciSehirAd";
                baglanti.Open();
                int AliciSehirKey = 0;
                SqlCommand AliciSehirID = new SqlCommand(AliciSehirKeySorgu, baglanti);
                SehirID.Parameters.AddWithValue("@AliciSehirAd", YeniAlici.Il);
                SqlDataReader AliciSehirDR = SehirID.ExecuteReader();
                if (SehirDR.Read())
                {
                    AliciSehirKey = Convert.ToInt32(AliciSehirDR["sehir_key"]);
                }
                baglanti.Close();

                string AliciIlceKeySorgu = "select * from ilce where ilce_title = @AliciIlceAd";
                baglanti.Open();
                int AliciIlceKey = 0;
                SqlCommand AliciIlceID = new SqlCommand(AliciIlceKeySorgu, baglanti);
                IlceID.Parameters.AddWithValue("@AliciIlceAd", YeniAlici.Ilce);
                SqlDataReader AliciIlceDR = IlceID.ExecuteReader();
                if (IlceDR.Read())
                {
                    AliciIlceKey = Convert.ToInt32(AliciIlceDR["ilce_key"]);
                }
                baglanti.Close();

                string AliciMahalleKeySorgu = "select * from mahalle where mahalle_title = @AliciMahalleAd";
                baglanti.Open();
                int AliciMahalleKey = 0;
                SqlCommand AliciMahalleID = new SqlCommand(AliciMahalleKeySorgu, baglanti);
                MahalleID.Parameters.AddWithValue("@AliciMahalleAd", YeniAlici.Mahalle);
                SqlDataReader AliciMahalleDR = MahalleID.ExecuteReader();
                if (MahalleDR.Read())
                {
                    AliciMahalleKey = Convert.ToInt32(AliciMahalleDR["mahalle_key"]);
                }
                baglanti.Close();

                /*------*/

                //-> Alıcı ekle
                /*
                                baglanti.Open();

                                string AliciEkle = "insert into from Musteri(Musteri_Ad, Musteri_Soyad, Museri_TelefonNo, Musteri_Eposta, Musteri_Statü, Musteri_TamAdres, Musteri_SehirKey, Musteri_IlceKey, Musteri_MahalleKey) values (@Ad, @Soyad, @Telefon, @Eposta, 'Alıcı', @TamAdres, @SehirKey, @IlceKey, @MahalleKey)";
                                SqlCommand ekle = new SqlCommand(AliciEkle, baglanti);
                                ekle.Parameters.AddWithValue("@Ad", YeniAlici.Ad);
                                ekle.Parameters.AddWithValue("@Soyad", YeniAlici.Soyad);
                                ekle.Parameters.AddWithValue("@Telefon", YeniAlici.Telefon);
                                ekle.Parameters.AddWithValue("@Eposta", YeniAlici.Eposta);
                                ekle.Parameters.AddWithValue("@TamAdres", YeniAlici.TamAdres);
                                ekle.Parameters.AddWithValue("@SehirKey", AliciSehirKey);
                                ekle.Parameters.AddWithValue("@IlceKey", AliciIlceKey);
                                ekle.Parameters.AddWithValue("@MahalleKey", AliciMahalleKey);
                                SqlDataReader AliciekleDR = ekle.ExecuteReader();

                                if (AliciekleDR.Read() && GonderenOnayi == true)
                                {
                                    MessageBox.Show("Gönderici ve Alıcı Bilgisi Sisteme Eklenmiştir");
                                }

                                baglanti.Close();*/
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /* HATALI ALAN Finish */

        //////////////// TAHMİN OYUNU \\\\\\\\\\\\\\\\

        bool TahminOyunuAcikMi = false;
        int DogruCevap;

        Random r = new Random();
        private void btn_TahminEtGosteGizle_Click(object sender, EventArgs e)
        {
            if (TahminOyunuAcikMi == false)
            {
                TahminOyunuAcikMi = true;
                TahminOyunuGetir.Enabled = true;
                Tahmin_ProgBar.Visible = true;

                Tahmin_Baslik.Visible = false;
            }

            else
            {
                TahminOyunuAcikMi = false;
                TahminOyunuGötür.Enabled = true;
            }

        }


        // Her Soruda Butona Basılırsa
        private void Tahmin_btn_TahminET_Click(object sender, EventArgs e)
        {
            if (Tahmin_btn_TahminET.Text != "YENİLE")
            {
                int yanit = Convert.ToInt32(Tahmin_nmrcUpDown.Value);

                // Yanıt Doğru Cevabın 5 altındaysa ya da üstündeyse doğru say
                if (yanit >= DogruCevap - 3 && yanit <= DogruCevap + 3)
                {
                    Tahmin_lbl_Sonuc.ForeColor = Color.Green;
                    Tahmin_lbl_Sonuc.Text = DogruCevap.ToString();

                    Tahmin_btn_TahminET.Text = "YENİLE";
                }

                // Yanlışsa
                else
                {
                    Tahmin_lbl_Sonuc.ForeColor = Color.Red;
                    Tahmin_lbl_Sonuc.Text = DogruCevap.ToString();

                    Tahmin_btn_TahminET.Text = "YENİLE";
                }
            }

            // Soru Yanıtlanmışsa Yeni Soru Gelsin
            else
            {
                Tahmin_btn_TahminET.Text = "TAHMİN ET";

                DogruCevap = r.Next(1, 100);

                Tahmin_ProgBar.Value = DogruCevap;
            }
        }

        // Paneli Açma Kapatma Fonksiyonları
        private void TahminOyunuGetir_Tick(object sender, EventArgs e)
        {
            // Panel Gizliyken Butona Basılırsa
            btn_TahminEtGosterGizle.Text = "←";

            if (pnl_TahminOyunu.Left < 0)
            {
                pnl_TahminOyunu.Left += 5;
                btn_TahminEtGosterGizle.Left += 5;
            }
            else
            {
                TahminOyunuGetir.Enabled = false;

                // İlk Soru
                DogruCevap = r.Next(1, 100);
                Tahmin_ProgBar.Value = DogruCevap;
            }
        }

        private void TahminOyunuGötür_Tick(object sender, EventArgs e)
        {
            // Panel Açıkken Buton Basılırsa
            btn_TahminEtGosterGizle.Text = "→";

            if (pnl_TahminOyunu.Left > -290)
            {
                pnl_TahminOyunu.Left -= 5;
                btn_TahminEtGosterGizle.Left -= 5;

                // Açık Ekrandakileri Sıfırla
                Tahmin_ProgBar.Value = 0;
                Tahmin_lbl_Sonuc.Text = "00";
                Tahmin_nmrcUpDown.Value = 0;
            }
            else
            {
                Tahmin_Baslik.Visible = true;
                Tahmin_ProgBar.Visible = false;

                TahminOyunuGötür.Enabled = false;
            }
        }

    }
}
