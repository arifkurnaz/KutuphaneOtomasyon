
namespace KutuphaneOtomasyon
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnKitaplar = new System.Windows.Forms.Button();
            this.btnOgrenciler = new System.Windows.Forms.Button();
            this.btnOduncKitaplar = new System.Windows.Forms.Button();
            this.btnKitapTurleri = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnKitaplar
            // 
            this.btnKitaplar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKitaplar.Image = global::KutuphaneOtomasyon.Properties.Resources.kitaplar;
            this.btnKitaplar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnKitaplar.Location = new System.Drawing.Point(42, 41);
            this.btnKitaplar.Name = "btnKitaplar";
            this.btnKitaplar.Size = new System.Drawing.Size(175, 89);
            this.btnKitaplar.TabIndex = 0;
            this.btnKitaplar.Text = "Kitap İşlemleri";
            this.btnKitaplar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnKitaplar.UseVisualStyleBackColor = true;
            this.btnKitaplar.Click += new System.EventHandler(this.btnKitaplar_Click);
            // 
            // btnOgrenciler
            // 
            this.btnOgrenciler.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOgrenciler.Image = global::KutuphaneOtomasyon.Properties.Resources.ogrenciler;
            this.btnOgrenciler.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnOgrenciler.Location = new System.Drawing.Point(217, 41);
            this.btnOgrenciler.Name = "btnOgrenciler";
            this.btnOgrenciler.Size = new System.Drawing.Size(175, 89);
            this.btnOgrenciler.TabIndex = 1;
            this.btnOgrenciler.Text = "Öğrenci İşlemleri";
            this.btnOgrenciler.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnOgrenciler.UseVisualStyleBackColor = true;
            this.btnOgrenciler.Click += new System.EventHandler(this.btnOgrenciler_Click);
            // 
            // btnOduncKitaplar
            // 
            this.btnOduncKitaplar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOduncKitaplar.Image = global::KutuphaneOtomasyon.Properties.Resources.emanetlistesi;
            this.btnOduncKitaplar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnOduncKitaplar.Location = new System.Drawing.Point(217, 130);
            this.btnOduncKitaplar.Name = "btnOduncKitaplar";
            this.btnOduncKitaplar.Size = new System.Drawing.Size(175, 89);
            this.btnOduncKitaplar.TabIndex = 2;
            this.btnOduncKitaplar.Text = "Ödünç Kitap İşlemleri";
            this.btnOduncKitaplar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnOduncKitaplar.UseVisualStyleBackColor = true;
            this.btnOduncKitaplar.Click += new System.EventHandler(this.btnOduncKitaplar_Click);
            // 
            // btnKitapTurleri
            // 
            this.btnKitapTurleri.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKitapTurleri.Image = global::KutuphaneOtomasyon.Properties.Resources.kitap_turleri;
            this.btnKitapTurleri.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnKitapTurleri.Location = new System.Drawing.Point(42, 130);
            this.btnKitapTurleri.Name = "btnKitapTurleri";
            this.btnKitapTurleri.Size = new System.Drawing.Size(175, 89);
            this.btnKitapTurleri.TabIndex = 3;
            this.btnKitapTurleri.Text = "Kitap Türleri";
            this.btnKitapTurleri.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnKitapTurleri.UseVisualStyleBackColor = true;
            this.btnKitapTurleri.Click += new System.EventHandler(this.btnKitapTurleri_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(434, 261);
            this.Controls.Add(this.btnKitapTurleri);
            this.Controls.Add(this.btnOduncKitaplar);
            this.Controls.Add(this.btnOgrenciler);
            this.Controls.Add(this.btnKitaplar);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(450, 300);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(450, 300);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kütüphane Projesi";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnKitaplar;
        private System.Windows.Forms.Button btnOgrenciler;
        private System.Windows.Forms.Button btnOduncKitaplar;
        private System.Windows.Forms.Button btnKitapTurleri;
    }
}

