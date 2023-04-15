using KutuphaneOtomasyon.Libraries;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KutuphaneOtomasyon.Forms
{
    public partial class formKitap : Form
    {
        public Veritabani vtIslemleri;
        private MySqlCommand command;
        private MySqlDataAdapter adapter;
        public formKitap()
        {
            InitializeComponent();
            this.vtIslemleri = new Veritabani();
        }

        private void formKitap_Load(object sender, EventArgs e)
        {
            KitapTurYukle();
            KitapListele();
        }

        private void KitapTurYukle()
        {
            try
            {
                string komut = "select * from kitap_turleri";
               
                this.vtIslemleri.baglan();
                this.adapter = new MySqlDataAdapter(komut,this.vtIslemleri.Baglanti);
                DataTable table = new DataTable();
                this.adapter.Fill(table);

                if (table.Rows.Count > 0)
                {
                    comboKitapTur.DataSource = table;
                    comboKitapTur.ValueMember = "tur_id";
                    comboKitapTur.DisplayMember = "tur_adi";

                }
                else
                {
                    comboKitapTur.DataSource = null;
                    MessageBox.Show("Veri tabanında kayıtlı kitap türü bulunamadı", "Bir hata oluştu", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Bir hata oluştu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void KitapListele()
        {
            try
            {
                this.command = new MySqlCommand();
                this.vtIslemleri.baglan();
                this.command.Connection = this.vtIslemleri.Baglanti;
                this.command.CommandText = "select kitaplar.kitap_id,kitap_turleri.tur_adi,kitaplar.kitap_adi,kitaplar.yazar,kitaplar.yayinevi,kitaplar.sayfasayisi from kitaplar,kitap_turleri where kitaplar.tur_id=kitap_turleri.tur_id";
                this.adapter = new MySqlDataAdapter(this.command);
                DataTable table = new DataTable();
                this.adapter.Fill(table);

                if (table.Rows.Count > 0)
                {
                    this.gridKitap.DataSource = table;
                    this.gridKitap.Columns["kitap_id"].HeaderText = "ID";
                    this.gridKitap.Columns["kitap_id"].Width = 30;
                    
                    this.gridKitap.Columns["kitap_adi"].HeaderText = "Kitap Adı";
                    
                    this.gridKitap.Columns["tur_adi"].HeaderText = "Kitap Türü";
                  
                    this.gridKitap.Columns["yazar"].HeaderText = "Yazar";
                    
                    this.gridKitap.Columns["yayinevi"].HeaderText = "Yayınevi";
                    
                    this.gridKitap.Columns["sayfasayisi"].HeaderText = "Sayfa Sayısı";
                    this.gridKitap.Columns["sayfasayisi"].Width = 40;
                    
                    

                }
                else
                {
                    this.gridKitap.DataSource = "";
                }




            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Bir hata oluştu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                string komut = "INSERT INTO kitaplar(tur_id, kitap_adi, yazar, yayinevi, sayfasayisi) VALUES(@tur_id,@kitap_adi,@yazar,@yayinevi,@sayfasayisi)";
                this.command = new MySqlCommand(komut);
                this.vtIslemleri.baglan();
                this.command.Connection = this.vtIslemleri.Baglanti;
                this.command.Parameters.AddWithValue("@tur_id", int.Parse(comboKitapTur.SelectedValue.ToString()));
                this.command.Parameters.AddWithValue("@kitap_adi", txtKitapAdi.Text.Trim());
                this.command.Parameters.AddWithValue("@yazar", txtYazar.Text.Trim());
                this.command.Parameters.AddWithValue("@yayinevi", txtYayinEvi.Text.Trim());
                this.command.Parameters.AddWithValue("@sayfasayisi", int.Parse(txtSayfaSayisi.Text));
               

                this.command.ExecuteNonQuery();
                this.vtIslemleri.Baglanti.Close();
                DialogResult result = MessageBox.Show("Yeni kayıt eklendi", "İşlem Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (result == DialogResult.OK)
                {
                    this.KitapListele();
                    this.Temizle();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                MessageBox.Show(ex.Message, "Bir hata oluştu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void Temizle()
        {
            txtKitapAdi.Clear();
            txtSayfaSayisi.Clear();
            txtYayinEvi.Clear();
            txtYazar.Clear();
            comboKitapTur.SelectedIndex = 0;
        }

        private void btnSil_Click(object sender, EventArgs e)
        {

            try
            {
                string komut = "delete from kitaplar where kitap_id=@kitap_id";
                this.command = new MySqlCommand(komut);
                this.command.Connection = this.vtIslemleri.Baglanti;
                this.vtIslemleri.baglan();
                this.command.Parameters.AddWithValue("@kitap_id", gridKitap.CurrentRow.Cells["kitap_id"].Value.ToString());
                this.command.ExecuteNonQuery();
                this.vtIslemleri.Baglanti.Close();
                DialogResult result = MessageBox.Show("Kayıt silindi", "İşlem Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (result == DialogResult.OK)
                {
                    this.KitapListele();

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Bir hata oluştu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                string komut = "update  kitaplar set tur_id=@tur_id,kitap_adi=@kitap_adi,yazar=@yazar,yayinevi=@yayinevi,sayfasayisi=@sayfasayisi where kitap_id=@kitap_id";
                this.command = new MySqlCommand(komut);
                this.vtIslemleri.baglan();
                this.command.Connection = this.vtIslemleri.Baglanti;
                this.command.Parameters.AddWithValue("@kitap_id", int.Parse(gridKitap.CurrentRow.Cells["kitap_id"].Value.ToString()));
                this.command.Parameters.AddWithValue("@tur_id", int.Parse(comboKitapTur.SelectedValue.ToString()));
                this.command.Parameters.AddWithValue("@yazar", txtYazar.Text.Trim());
                this.command.Parameters.AddWithValue("@kitap_adi", txtKitapAdi.Text.Trim());
                this.command.Parameters.AddWithValue("@yayinevi", txtYayinEvi.Text.Trim());
                this.command.Parameters.AddWithValue("@sayfasayisi", int.Parse(txtSayfaSayisi.Text));
               

                this.command.ExecuteNonQuery();
                this.vtIslemleri.Baglanti.Close();
                DialogResult result = MessageBox.Show("Kayıt güncellendi", "İşlem Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (result == DialogResult.OK)
                {
                    this.KitapListele();
                    this.Temizle();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                MessageBox.Show(ex.Message, "Bir hata oluştu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

          

        }

        private void txtOgrenciAra_TextChanged(object sender, EventArgs e)
        {
            KitapArama(txtKitapAra.Text);
        }

        private void KitapArama(string text)
        {
            try
            {
                this.command = new MySqlCommand();
                this.vtIslemleri.baglan();
                this.command.Connection = this.vtIslemleri.Baglanti;
                this.command.CommandText = "select kitaplar.kitap_id,kitap_turleri.tur_adi,kitaplar.kitap_adi,kitaplar.yazar,kitaplar.yayinevi,kitaplar.sayfasayisi from kitaplar,kitap_turleri where kitaplar.tur_id=kitap_turleri.tur_id and kitaplar.kitap_adi LIKE '"+text+"%'";
                this.adapter = new MySqlDataAdapter(this.command);
                DataTable table = new DataTable();
                this.adapter.Fill(table);

                if (table.Rows.Count > 0)
                {
                    this.gridKitap.DataSource = table;
                    this.gridKitap.Columns["kitap_id"].HeaderText = "ID";
                    this.gridKitap.Columns["kitap_id"].Width = 30;
                    this.gridKitap.Columns["kitap_adi"].HeaderText = "Kitap Adı";
                    this.gridKitap.Columns["tur_adi"].HeaderText = "Kitap Türü";
                    this.gridKitap.Columns["yazar"].HeaderText = "Yazar";
                    this.gridKitap.Columns["yayinevi"].HeaderText = "Yayınevi";
                    this.gridKitap.Columns["sayfasayisi"].HeaderText = "Sayfa Sayısı";
                    this.gridKitap.Columns["sayfasayisi"].Width = 40;


                }
                else
                {
                    this.gridKitap.DataSource = "";
                }




            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Bir hata oluştu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gridKitap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtKitapAdi.Text = gridKitap.CurrentRow.Cells["kitap_adi"].Value.ToString();
            txtYazar.Text = gridKitap.CurrentRow.Cells["yazar"].Value.ToString();
            txtYayinEvi.Text = gridKitap.CurrentRow.Cells["yayinevi"].Value.ToString();
            txtSayfaSayisi.Text = gridKitap.CurrentRow.Cells["sayfasayisi"].Value.ToString();
           
        }
    }
}
