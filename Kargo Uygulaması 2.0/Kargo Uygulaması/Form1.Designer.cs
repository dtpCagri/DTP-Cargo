namespace Kargo_Uygulaması
{
    partial class Form1
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

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_GirisYap = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_GirisSifre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtGirisTC = new System.Windows.Forms.TextBox();
            this.btn_KaydiTamamla = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_KayitSifreTekrar = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_KayitSoyad = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_KayitTelefon = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_KayitTC = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_KayitSifre = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_KayitAd = new System.Windows.Forms.TextBox();
            this.ResmiKaydir = new System.Windows.Forms.Timer(this.components);
            this.link_PersonelGirisi = new System.Windows.Forms.LinkLabel();
            this.link_PersonelKaydi = new System.Windows.Forms.LinkLabel();
            this.picture_SifreGizle = new System.Windows.Forms.PictureBox();
            this.pictur_SifreGor = new System.Windows.Forms.PictureBox();
            this.TChatasi = new System.Windows.Forms.ErrorProvider(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.txt_KayitEposta = new System.Windows.Forms.TextBox();
            this.TCBasamakHatasi = new System.Windows.Forms.ErrorProvider(this.components);
            this.linklbl_SifremiUnuttum = new System.Windows.Forms.LinkLabel();
            this.pnl_SifreYenileme = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_YeniSifreTekrar = new System.Windows.Forms.TextBox();
            this.txt_SifreYenileTC = new System.Windows.Forms.TextBox();
            this.btn_SifreYenile = new System.Windows.Forms.Button();
            this.lbl_TC = new System.Windows.Forms.Label();
            this.lbl_Sifre = new System.Windows.Forms.Label();
            this.txt_SifreYenile_YeniSifre = new System.Windows.Forms.TextBox();
            this.linklbl_GirisEkraninaDon = new System.Windows.Forms.LinkLabel();
            this.lblSifreYenilemeBaslik = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_SifreGizle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictur_SifreGor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TChatasi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TCBasamakHatasi)).BeginInit();
            this.pnl_SifreYenileme.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(989, -1);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(526, 588);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btn_GirisYap
            // 
            this.btn_GirisYap.Enabled = false;
            this.btn_GirisYap.Font = new System.Drawing.Font("Century Schoolbook", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_GirisYap.ForeColor = System.Drawing.Color.Black;
            this.btn_GirisYap.Location = new System.Drawing.Point(658, 335);
            this.btn_GirisYap.Margin = new System.Windows.Forms.Padding(4);
            this.btn_GirisYap.Name = "btn_GirisYap";
            this.btn_GirisYap.Size = new System.Drawing.Size(256, 60);
            this.btn_GirisYap.TabIndex = 3;
            this.btn_GirisYap.Text = "Giriş Yap";
            this.btn_GirisYap.UseVisualStyleBackColor = true;
            this.btn_GirisYap.Click += new System.EventHandler(this.btn_GirisYap_Click);
            this.btn_GirisYap.MouseLeave += new System.EventHandler(this.btn_GirisYap_MouseLeave);
            this.btn_GirisYap.MouseHover += new System.EventHandler(this.btn_GirisYap_MouseHover);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Schoolbook", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(588, 268);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 28);
            this.label2.TabIndex = 26;
            this.label2.Text = "Şifre";
            // 
            // txt_GirisSifre
            // 
            this.txt_GirisSifre.Font = new System.Drawing.Font("Century Schoolbook", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txt_GirisSifre.ForeColor = System.Drawing.Color.Black;
            this.txt_GirisSifre.Location = new System.Drawing.Point(675, 269);
            this.txt_GirisSifre.Margin = new System.Windows.Forms.Padding(4);
            this.txt_GirisSifre.MaxLength = 15;
            this.txt_GirisSifre.Name = "txt_GirisSifre";
            this.txt_GirisSifre.PasswordChar = '*';
            this.txt_GirisSifre.Size = new System.Drawing.Size(239, 32);
            this.txt_GirisSifre.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Schoolbook", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(607, 198);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 28);
            this.label1.TabIndex = 24;
            this.label1.Text = "TC";
            // 
            // txtGirisTC
            // 
            this.txtGirisTC.Font = new System.Drawing.Font("Century Schoolbook", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtGirisTC.ForeColor = System.Drawing.Color.Black;
            this.txtGirisTC.Location = new System.Drawing.Point(675, 199);
            this.txtGirisTC.Margin = new System.Windows.Forms.Padding(4);
            this.txtGirisTC.MaxLength = 11;
            this.txtGirisTC.Name = "txtGirisTC";
            this.txtGirisTC.Size = new System.Drawing.Size(239, 32);
            this.txtGirisTC.TabIndex = 1;
            this.txtGirisTC.TextChanged += new System.EventHandler(this.txtGirisTC_TextChanged);
            this.txtGirisTC.Enter += new System.EventHandler(this.txtGirisTC_Enter);
            this.txtGirisTC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtGirisTC_KeyPress);
            this.txtGirisTC.Leave += new System.EventHandler(this.txtGirisTC_Leave);
            // 
            // btn_KaydiTamamla
            // 
            this.btn_KaydiTamamla.Enabled = false;
            this.btn_KaydiTamamla.ForeColor = System.Drawing.Color.Black;
            this.btn_KaydiTamamla.Location = new System.Drawing.Point(66, 444);
            this.btn_KaydiTamamla.Name = "btn_KaydiTamamla";
            this.btn_KaydiTamamla.Size = new System.Drawing.Size(331, 53);
            this.btn_KaydiTamamla.TabIndex = 26;
            this.btn_KaydiTamamla.Text = "Kaydı Tamamla";
            this.btn_KaydiTamamla.UseVisualStyleBackColor = true;
            this.btn_KaydiTamamla.Click += new System.EventHandler(this.btn_KaydiTamamla_Click);
            this.btn_KaydiTamamla.MouseLeave += new System.EventHandler(this.btn_KaydiTamamla_MouseLeave);
            this.btn_KaydiTamamla.MouseHover += new System.EventHandler(this.btn_KaydiTamamla_MouseHover);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Schoolbook", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label8.Location = new System.Drawing.Point(100, 351);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 28);
            this.label8.TabIndex = 41;
            this.label8.Text = "Şifre";
            // 
            // txt_KayitSifreTekrar
            // 
            this.txt_KayitSifreTekrar.Enabled = false;
            this.txt_KayitSifreTekrar.Font = new System.Drawing.Font("Century Schoolbook", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txt_KayitSifreTekrar.Location = new System.Drawing.Point(175, 347);
            this.txt_KayitSifreTekrar.MaxLength = 15;
            this.txt_KayitSifreTekrar.Name = "txt_KayitSifreTekrar";
            this.txt_KayitSifreTekrar.Size = new System.Drawing.Size(222, 32);
            this.txt_KayitSifreTekrar.TabIndex = 25;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Schoolbook", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.Location = new System.Drawing.Point(87, 100);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 28);
            this.label7.TabIndex = 39;
            this.label7.Text = "Soyad";
            // 
            // txt_KayitSoyad
            // 
            this.txt_KayitSoyad.Enabled = false;
            this.txt_KayitSoyad.Font = new System.Drawing.Font("Century Schoolbook", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txt_KayitSoyad.Location = new System.Drawing.Point(175, 99);
            this.txt_KayitSoyad.MaxLength = 25;
            this.txt_KayitSoyad.Name = "txt_KayitSoyad";
            this.txt_KayitSoyad.Size = new System.Drawing.Size(222, 32);
            this.txt_KayitSoyad.TabIndex = 21;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Schoolbook", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(71, 150);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 28);
            this.label6.TabIndex = 37;
            this.label6.Text = "Telefon";
            // 
            // txt_KayitTelefon
            // 
            this.txt_KayitTelefon.Enabled = false;
            this.txt_KayitTelefon.Font = new System.Drawing.Font("Century Schoolbook", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txt_KayitTelefon.Location = new System.Drawing.Point(175, 148);
            this.txt_KayitTelefon.MaxLength = 10;
            this.txt_KayitTelefon.Name = "txt_KayitTelefon";
            this.txt_KayitTelefon.Size = new System.Drawing.Size(222, 32);
            this.txt_KayitTelefon.TabIndex = 22;
            this.txt_KayitTelefon.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KayitTelefon_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Schoolbook", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(119, 247);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 28);
            this.label5.TabIndex = 35;
            this.label5.Text = "TC";
            // 
            // txt_KayitTC
            // 
            this.txt_KayitTC.Enabled = false;
            this.txt_KayitTC.Font = new System.Drawing.Font("Century Schoolbook", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txt_KayitTC.Location = new System.Drawing.Point(175, 246);
            this.txt_KayitTC.MaxLength = 11;
            this.txt_KayitTC.Name = "txt_KayitTC";
            this.txt_KayitTC.Size = new System.Drawing.Size(222, 32);
            this.txt_KayitTC.TabIndex = 23;
            this.txt_KayitTC.TextChanged += new System.EventHandler(this.txt_KayitTC_TextChanged);
            this.txt_KayitTC.Enter += new System.EventHandler(this.txt_KayitTC_Enter);
            this.txt_KayitTC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KayitTC_KeyPress);
            this.txt_KayitTC.Leave += new System.EventHandler(this.txt_KayitTC_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Schoolbook", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(100, 302);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 28);
            this.label4.TabIndex = 33;
            this.label4.Text = "Şifre";
            // 
            // txt_KayitSifre
            // 
            this.txt_KayitSifre.Enabled = false;
            this.txt_KayitSifre.Font = new System.Drawing.Font("Century Schoolbook", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txt_KayitSifre.Location = new System.Drawing.Point(175, 299);
            this.txt_KayitSifre.MaxLength = 15;
            this.txt_KayitSifre.Name = "txt_KayitSifre";
            this.txt_KayitSifre.Size = new System.Drawing.Size(222, 32);
            this.txt_KayitSifre.TabIndex = 24;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Schoolbook", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(121, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 28);
            this.label3.TabIndex = 31;
            this.label3.Text = "Ad";
            // 
            // txt_KayitAd
            // 
            this.txt_KayitAd.Enabled = false;
            this.txt_KayitAd.Font = new System.Drawing.Font("Century Schoolbook", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txt_KayitAd.Location = new System.Drawing.Point(175, 48);
            this.txt_KayitAd.MaxLength = 30;
            this.txt_KayitAd.Name = "txt_KayitAd";
            this.txt_KayitAd.Size = new System.Drawing.Size(222, 32);
            this.txt_KayitAd.TabIndex = 20;
            // 
            // ResmiKaydir
            // 
            this.ResmiKaydir.Interval = 1;
            this.ResmiKaydir.Tick += new System.EventHandler(this.ResmiKaydir_Tick);
            // 
            // link_PersonelGirisi
            // 
            this.link_PersonelGirisi.AutoSize = true;
            this.link_PersonelGirisi.Font = new System.Drawing.Font("Century Schoolbook", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.link_PersonelGirisi.LinkColor = System.Drawing.Color.White;
            this.link_PersonelGirisi.Location = new System.Drawing.Point(118, 526);
            this.link_PersonelGirisi.Name = "link_PersonelGirisi";
            this.link_PersonelGirisi.Size = new System.Drawing.Size(257, 35);
            this.link_PersonelGirisi.TabIndex = 45;
            this.link_PersonelGirisi.TabStop = true;
            this.link_PersonelGirisi.Text = "Personel Girişi →";
            this.link_PersonelGirisi.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // link_PersonelKaydi
            // 
            this.link_PersonelKaydi.AutoSize = true;
            this.link_PersonelKaydi.Font = new System.Drawing.Font("Century Schoolbook", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.link_PersonelKaydi.LinkColor = System.Drawing.Color.White;
            this.link_PersonelKaydi.Location = new System.Drawing.Point(652, 526);
            this.link_PersonelKaydi.Name = "link_PersonelKaydi";
            this.link_PersonelKaydi.Size = new System.Drawing.Size(262, 35);
            this.link_PersonelKaydi.TabIndex = 46;
            this.link_PersonelKaydi.TabStop = true;
            this.link_PersonelKaydi.Text = "← Personel Kaydı";
            this.link_PersonelKaydi.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.link_PersonelKaydi_LinkClicked);
            // 
            // picture_SifreGizle
            // 
            this.picture_SifreGizle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picture_SifreGizle.Image = ((System.Drawing.Image)(resources.GetObject("picture_SifreGizle.Image")));
            this.picture_SifreGizle.Location = new System.Drawing.Point(813, 271);
            this.picture_SifreGizle.Name = "picture_SifreGizle";
            this.picture_SifreGizle.Size = new System.Drawing.Size(41, 25);
            this.picture_SifreGizle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picture_SifreGizle.TabIndex = 47;
            this.picture_SifreGizle.TabStop = false;
            this.picture_SifreGizle.Click += new System.EventHandler(this.picture_SifreGizle_Click);
            // 
            // pictur_SifreGor
            // 
            this.pictur_SifreGor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictur_SifreGor.Image = ((System.Drawing.Image)(resources.GetObject("pictur_SifreGor.Image")));
            this.pictur_SifreGor.Location = new System.Drawing.Point(873, 269);
            this.pictur_SifreGor.Name = "pictur_SifreGor";
            this.pictur_SifreGor.Size = new System.Drawing.Size(26, 25);
            this.pictur_SifreGor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictur_SifreGor.TabIndex = 48;
            this.pictur_SifreGor.TabStop = false;
            this.pictur_SifreGor.Click += new System.EventHandler(this.pictur_SifreGor_Click);
            // 
            // TChatasi
            // 
            this.TChatasi.ContainerControl = this;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Century Schoolbook", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label9.Location = new System.Drawing.Point(71, 199);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(93, 28);
            this.label9.TabIndex = 52;
            this.label9.Text = "E posta";
            // 
            // txt_KayitEposta
            // 
            this.txt_KayitEposta.Enabled = false;
            this.txt_KayitEposta.Font = new System.Drawing.Font("Century Schoolbook", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txt_KayitEposta.Location = new System.Drawing.Point(175, 197);
            this.txt_KayitEposta.MaxLength = 50;
            this.txt_KayitEposta.Name = "txt_KayitEposta";
            this.txt_KayitEposta.Size = new System.Drawing.Size(222, 32);
            this.txt_KayitEposta.TabIndex = 51;
            // 
            // TCBasamakHatasi
            // 
            this.TCBasamakHatasi.ContainerControl = this;
            // 
            // linklbl_SifremiUnuttum
            // 
            this.linklbl_SifremiUnuttum.AutoSize = true;
            this.linklbl_SifremiUnuttum.Font = new System.Drawing.Font("Century Schoolbook", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.linklbl_SifremiUnuttum.LinkColor = System.Drawing.Color.White;
            this.linklbl_SifremiUnuttum.Location = new System.Drawing.Point(793, 301);
            this.linklbl_SifremiUnuttum.Name = "linklbl_SifremiUnuttum";
            this.linklbl_SifremiUnuttum.Size = new System.Drawing.Size(147, 21);
            this.linklbl_SifremiUnuttum.TabIndex = 53;
            this.linklbl_SifremiUnuttum.TabStop = true;
            this.linklbl_SifremiUnuttum.Text = "Şifremi Unuttum";
            this.linklbl_SifremiUnuttum.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linklbl_SifremiUnuttum_LinkClicked);
            // 
            // pnl_SifreYenileme
            // 
            this.pnl_SifreYenileme.BackColor = System.Drawing.Color.Tan;
            this.pnl_SifreYenileme.Controls.Add(this.label10);
            this.pnl_SifreYenileme.Controls.Add(this.txt_YeniSifreTekrar);
            this.pnl_SifreYenileme.Controls.Add(this.txt_SifreYenileTC);
            this.pnl_SifreYenileme.Controls.Add(this.btn_SifreYenile);
            this.pnl_SifreYenileme.Controls.Add(this.lbl_TC);
            this.pnl_SifreYenileme.Controls.Add(this.lbl_Sifre);
            this.pnl_SifreYenileme.Controls.Add(this.txt_SifreYenile_YeniSifre);
            this.pnl_SifreYenileme.Controls.Add(this.linklbl_GirisEkraninaDon);
            this.pnl_SifreYenileme.Controls.Add(this.lblSifreYenilemeBaslik);
            this.pnl_SifreYenileme.Location = new System.Drawing.Point(238, 481);
            this.pnl_SifreYenileme.Name = "pnl_SifreYenileme";
            this.pnl_SifreYenileme.Size = new System.Drawing.Size(503, 576);
            this.pnl_SifreYenileme.TabIndex = 54;
            this.pnl_SifreYenileme.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Century Schoolbook", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label10.Location = new System.Drawing.Point(21, 272);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(118, 28);
            this.label10.TabIndex = 33;
            this.label10.Text = "Yeni Şifre";
            // 
            // txt_YeniSifreTekrar
            // 
            this.txt_YeniSifreTekrar.Font = new System.Drawing.Font("Century Schoolbook", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txt_YeniSifreTekrar.ForeColor = System.Drawing.Color.Black;
            this.txt_YeniSifreTekrar.Location = new System.Drawing.Point(163, 268);
            this.txt_YeniSifreTekrar.Margin = new System.Windows.Forms.Padding(4);
            this.txt_YeniSifreTekrar.MaxLength = 15;
            this.txt_YeniSifreTekrar.Name = "txt_YeniSifreTekrar";
            this.txt_YeniSifreTekrar.Size = new System.Drawing.Size(239, 32);
            this.txt_YeniSifreTekrar.TabIndex = 32;
            // 
            // txt_SifreYenileTC
            // 
            this.txt_SifreYenileTC.Font = new System.Drawing.Font("Century Schoolbook", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txt_SifreYenileTC.ForeColor = System.Drawing.Color.Black;
            this.txt_SifreYenileTC.Location = new System.Drawing.Point(163, 130);
            this.txt_SifreYenileTC.Margin = new System.Windows.Forms.Padding(4);
            this.txt_SifreYenileTC.MaxLength = 11;
            this.txt_SifreYenileTC.Name = "txt_SifreYenileTC";
            this.txt_SifreYenileTC.Size = new System.Drawing.Size(239, 32);
            this.txt_SifreYenileTC.TabIndex = 27;
            this.txt_SifreYenileTC.TextChanged += new System.EventHandler(this.txt_SifreYenileTC_TextChanged);
            // 
            // btn_SifreYenile
            // 
            this.btn_SifreYenile.Enabled = false;
            this.btn_SifreYenile.Font = new System.Drawing.Font("Century Schoolbook", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_SifreYenile.ForeColor = System.Drawing.Color.Black;
            this.btn_SifreYenile.Location = new System.Drawing.Point(146, 336);
            this.btn_SifreYenile.Margin = new System.Windows.Forms.Padding(4);
            this.btn_SifreYenile.Name = "btn_SifreYenile";
            this.btn_SifreYenile.Size = new System.Drawing.Size(256, 60);
            this.btn_SifreYenile.TabIndex = 29;
            this.btn_SifreYenile.Text = "Şifre Yenile";
            this.btn_SifreYenile.UseVisualStyleBackColor = true;
            this.btn_SifreYenile.Click += new System.EventHandler(this.btn_SifreYenile_Click);
            // 
            // lbl_TC
            // 
            this.lbl_TC.AutoSize = true;
            this.lbl_TC.Font = new System.Drawing.Font("Century Schoolbook", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_TC.Location = new System.Drawing.Point(95, 134);
            this.lbl_TC.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_TC.Name = "lbl_TC";
            this.lbl_TC.Size = new System.Drawing.Size(44, 28);
            this.lbl_TC.TabIndex = 30;
            this.lbl_TC.Text = "TC";
            // 
            // lbl_Sifre
            // 
            this.lbl_Sifre.AutoSize = true;
            this.lbl_Sifre.Font = new System.Drawing.Font("Century Schoolbook", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_Sifre.Location = new System.Drawing.Point(21, 204);
            this.lbl_Sifre.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_Sifre.Name = "lbl_Sifre";
            this.lbl_Sifre.Size = new System.Drawing.Size(118, 28);
            this.lbl_Sifre.TabIndex = 31;
            this.lbl_Sifre.Text = "Yeni Şifre";
            // 
            // txt_SifreYenile_YeniSifre
            // 
            this.txt_SifreYenile_YeniSifre.Font = new System.Drawing.Font("Century Schoolbook", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txt_SifreYenile_YeniSifre.ForeColor = System.Drawing.Color.Black;
            this.txt_SifreYenile_YeniSifre.Location = new System.Drawing.Point(163, 200);
            this.txt_SifreYenile_YeniSifre.Margin = new System.Windows.Forms.Padding(4);
            this.txt_SifreYenile_YeniSifre.MaxLength = 15;
            this.txt_SifreYenile_YeniSifre.Name = "txt_SifreYenile_YeniSifre";
            this.txt_SifreYenile_YeniSifre.Size = new System.Drawing.Size(239, 32);
            this.txt_SifreYenile_YeniSifre.TabIndex = 28;
            // 
            // linklbl_GirisEkraninaDon
            // 
            this.linklbl_GirisEkraninaDon.AutoSize = true;
            this.linklbl_GirisEkraninaDon.BackColor = System.Drawing.Color.Transparent;
            this.linklbl_GirisEkraninaDon.LinkColor = System.Drawing.Color.White;
            this.linklbl_GirisEkraninaDon.Location = new System.Drawing.Point(160, 529);
            this.linklbl_GirisEkraninaDon.Name = "linklbl_GirisEkraninaDon";
            this.linklbl_GirisEkraninaDon.Size = new System.Drawing.Size(223, 28);
            this.linklbl_GirisEkraninaDon.TabIndex = 1;
            this.linklbl_GirisEkraninaDon.TabStop = true;
            this.linklbl_GirisEkraninaDon.Text = "Giriş Ekranına Dön";
            this.linklbl_GirisEkraninaDon.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linklbl_GirisEkraninaDon_LinkClicked);
            // 
            // lblSifreYenilemeBaslik
            // 
            this.lblSifreYenilemeBaslik.AutoSize = true;
            this.lblSifreYenilemeBaslik.BackColor = System.Drawing.Color.Transparent;
            this.lblSifreYenilemeBaslik.Font = new System.Drawing.Font("Century Schoolbook", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblSifreYenilemeBaslik.Location = new System.Drawing.Point(60, 10);
            this.lblSifreYenilemeBaslik.Name = "lblSifreYenilemeBaslik";
            this.lblSifreYenilemeBaslik.Size = new System.Drawing.Size(446, 43);
            this.lblSifreYenilemeBaslik.TabIndex = 0;
            this.lblSifreYenilemeBaslik.Text = "Şifre Yenileme Ekranı";
            // 
            // Form1
            // 
            this.AcceptButton = this.btn_GirisYap;
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1032, 582);
            this.Controls.Add(this.pnl_SifreYenileme);
            this.Controls.Add(this.linklbl_SifremiUnuttum);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btn_KaydiTamamla);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txt_KayitSifreTekrar);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txt_KayitSoyad);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt_KayitTelefon);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_KayitTC);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_KayitSifre);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_KayitAd);
            this.Controls.Add(this.txtGirisTC);
            this.Controls.Add(this.btn_GirisYap);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.link_PersonelGirisi);
            this.Controls.Add(this.link_PersonelKaydi);
            this.Controls.Add(this.pictur_SifreGor);
            this.Controls.Add(this.txt_GirisSifre);
            this.Controls.Add(this.picture_SifreGizle);
            this.Controls.Add(this.txt_KayitEposta);
            this.Controls.Add(this.label9);
            this.Font = new System.Drawing.Font("Century Schoolbook", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ForeColor = System.Drawing.Color.White;
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Personel Giriş";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_SifreGizle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictur_SifreGor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TChatasi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TCBasamakHatasi)).EndInit();
            this.pnl_SifreYenileme.ResumeLayout(false);
            this.pnl_SifreYenileme.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_GirisYap;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_GirisSifre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtGirisTC;
        private System.Windows.Forms.Button btn_KaydiTamamla;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_KayitSifreTekrar;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_KayitSoyad;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_KayitTelefon;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_KayitTC;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_KayitSifre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_KayitAd;
        private System.Windows.Forms.Timer ResmiKaydir;
        private System.Windows.Forms.LinkLabel link_PersonelGirisi;
        private System.Windows.Forms.LinkLabel link_PersonelKaydi;
        private System.Windows.Forms.PictureBox picture_SifreGizle;
        private System.Windows.Forms.PictureBox pictur_SifreGor;
        private System.Windows.Forms.ErrorProvider TChatasi;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt_KayitEposta;
        private System.Windows.Forms.ErrorProvider TCBasamakHatasi;
        private System.Windows.Forms.Panel pnl_SifreYenileme;
        private System.Windows.Forms.LinkLabel linklbl_GirisEkraninaDon;
        private System.Windows.Forms.Label lblSifreYenilemeBaslik;
        private System.Windows.Forms.LinkLabel linklbl_SifremiUnuttum;
        private System.Windows.Forms.TextBox txt_SifreYenileTC;
        private System.Windows.Forms.Button btn_SifreYenile;
        private System.Windows.Forms.Label lbl_TC;
        private System.Windows.Forms.Label lbl_Sifre;
        private System.Windows.Forms.TextBox txt_SifreYenile_YeniSifre;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txt_YeniSifreTekrar;
    }
}

