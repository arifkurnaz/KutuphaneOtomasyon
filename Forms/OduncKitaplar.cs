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
    public partial class formOduncKitap : Form
    {
        public Veritabani vtIslemleri;
        private MySqlCommand command;
        private MySqlDataAdapter adapter;
        public formOduncKitap()
        {
            InitializeComponent();
            this.vtIslemleri = new Veritabani();
        }

        private void formOduncKitap_Load(object sender, EventArgs e)
        {
            Listele();
            KitapYukle();
        }

        private void Listele()
        {
            try
            {
                this.command = new MySqlCommand();
                this.vtIslemleri.baglan();
                this.command.Connection = this.vtIslemleri.Baglanti;
                this.command.CommandText = "select id,ogrenci_no,ad,soyad,kitap_adi,verilis_tarihi,teslim_tarihi,aciklama from kitaplar,odunc_kitaplar,ogrenciler"+
                    " where ogr_no=ogrenci_no and kitaplar.kitap_id=odunc_kitaplar.kitap_id";
                this.adapter = new MySqlDataAdapter(this.command);
                DataTable table = new DataTable();               
                    this.adapter.Fill(table);

                if (table.Rows.Count > 0)
                {
                    this.gridOduncKitaplar.DataSource = table;
                    this.gridOduncKitaplar.Columns["id"].HeaderText = "ID";
                    this.gridOduncKitaplar.Columns["ogrenci_no"].HeaderText = "Öğrenci No";
                    this.gridOduncKitaplar.Columns["ad"].HeaderText = "Ad";
                    this.gridOduncKitaplar.Columns["soyad"].HeaderText = "Soyad";
                    this.gridOduncKitaplar.Columns["kitap_adi"].HeaderText = "Kitap Adı";
                    this.gridOduncKitaplar.Columns["verilis_tarihi"].HeaderText = "Veriliş Tarihi";
                    this.gridOduncKitaplar.Columns["teslim_tarihi"].HeaderText = "Teslim Tarihi";
                    this.gridOduncKitaplar.Columns["aciklama"].HeaderText = "Açıklama";
                    this.gridOduncKitaplar.Columns["aciklama"].Width = 150;
                    this.gridOduncKitaplar.Columns["id"].Width = 30;
                    this.gridOduncKitaplar.Columns["ogrenci_no"].Width = 40;
                    this.gridOduncKitaplar.Columns["ad"].Width = 70;
                    this.gridOduncKitaplar.Columns["soyad"].Width = 70;
                    this.gridOduncKitaplar.Columns["kitap_adi"].Width =100;
                    this.gridOduncKitaplar.Columns["verilis_tarihi"].Width =70;
                    this.gridOduncKitaplar.Columns["teslim_tarihi"].Width =70;  
                }
                else
                {
                    this.gridOduncKitaplar.DataSource = null;
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Bir hata oluştu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void KitapYukle()
        {
            try
            {
                string komut = "select kitap_id,kitap_adi from kitaplar where kitap_id not in (select kitap_id from odunc_kitaplar where teslim_tarihi IS NULL)";

                this.vtIslemleri.baglan();
                this.adapter = new MySqlDataAdapter(komut, this.vtIslemleri.Baglanti);
                DataTable table = new DataTable();
                this.adapter.Fill(table);
                

                if (table.Rows.Count > 0)
                {
                    comboKitap.DataSource = table;
                    comboKitap.ValueMember = "kitap_id";
                    comboKitap.DisplayMember = "kitap_adi";

                }
                else
                {
                    comboKitap.DataSource = null;
                    MessageBox.Show("Veri tabanında kayıtlı kitap türü bulunamadı", "Bir hata oluştu", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Bir hata oluştu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                string komut = "delete from odunc_kitaplar where id=@id";
                this.command = new MySqlCommand(komut);
                this.command.Connection = this.vtIslemleri.Baglanti;
                this.vtIslemleri.baglan();
                this.command.Parameters.AddWithValue("@id", gridOduncKitaplar.CurrentRow.Cells["id"].Value.ToString());
                this.command.ExecuteNonQuery();
                this.vtIslemleri.Baglanti.Close();
                DialogResult result = MessageBox.Show("Kayıt silindi", "İşlem Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (result == DialogResult.OK)
                {
                    this.Listele();
                    this.KitapYukle();

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Bir hata oluştu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnKitapAl_Click(object sender, EventArgs e)
        {
            if (gridOduncKitaplar.CurrentRow.Cells["teslim_tarihi"].Value.ToString() != String.Empty)
            {
                MessageBox.Show("Bu Kitap daha önce teslim alınmıştır", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                string komut = "update  odunc_kitaplar set teslim_tarihi=@teslim_tarihi,aciklama=@aciklama where id=@id";
                this.command = new MySqlCommand(komut);
                this.vtIslemleri.baglan();
                this.command.Connection = this.vtIslemleri.Baglanti;
                this.command.Parameters.AddWithValue("@id", int.Parse(gridOduncKitaplar.CurrentRow.Cells["id"].Value.ToString()));
                this.command.Parameters.AddWithValue("@teslim_tarihi", DateTime.Now.ToString("yyyy/MM/dd"));
                this.command.Parameters.AddWithValue("@aciklama", txtAciklama.Text.Trim()); 
                this.command.ExecuteNonQuery();
                this.vtIslemleri.Baglanti.Close();
                DialogResult result = MessageBox.Show("Kayıt güncellendi", "İşlem Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (result == DialogResult.OK)
                {
                    this.Listele();
                    this.Temizle();
                    this.KitapYukle();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                MessageBox.Show(ex.Message, "Bir hata oluştu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnKitapVer_Click(object sender, EventArgs e)
        {
            
            try
            {
                string komut = "INSERT INTO odunc_kitaplar(ogr_no, kitap_id, verilis_tarihi,aciklama)"+
                    " VALUES(@ogr_no,@kitap_id,@verilis_tarihi,@aciklama)";
                this.command = new MySqlCommand(komut);
                this.vtIslemleri.baglan();
                this.command.Connection = this.vtIslemleri.Baglanti;
                this.command.Parameters.AddWithValue("@ogr_no", int.Parse(txtNo.Text.Trim()));
                this.command.Parameters.AddWithValue("@kitap_id", int.Parse(comboKitap.SelectedValue.ToString()));
                this.command.Parameters.AddWithValue("@verilis_tarihi", DateTime.Now.ToString("yyyy/MM/dd"));
                this.command.Parameters.AddWithValue("@aciklama", txtAciklama.Text.Trim());

                this.command.ExecuteNonQuery();
                this.vtIslemleri.Baglanti.Close();
                DialogResult result = MessageBox.Show("Yeni kayıt eklendi", "İşlem Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (result == DialogResult.OK)
                {
                    this.Listele();
                    this.Temizle();
                    this.KitapYukle();
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
            txtNo.Clear();
            txtAciklama.Clear();
        }

        private void gridOduncKitaplar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtNo.Text = gridOduncKitaplar.CurrentRow.Cells["ogrenci_no"].Value.ToString();
            txtAciklama.Text = gridOduncKitaplar.CurrentRow.Cells["aciklama"].Value.ToString();
        }

        private void txtAramaOgrenci_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.command = new MySqlCommand();
                this.vtIslemleri.baglan();
                this.command.Connection = this.vtIslemleri.Baglanti;
                this.command.CommandText = "select id,ogrenci_no,ad,soyad,kitap_adi,verilis_tarihi,teslim_tarihi,aciklama from kitaplar,odunc_kitaplar,ogrenciler" +
                    " where ogr_no=ogrenci_no and kitaplar.kitap_id=odunc_kitaplar.kitap_id and  kitap_adi LIKE '%"+txtAramaOgrenci.Text.Trim()+"%'";
                this.adapter = new MySqlDataAdapter(this.command);
                DataTable table = new DataTable();
                this.adapter.Fill(table);

                if (table.Rows.Count > 0)
                {
                    this.gridOduncKitaplar.DataSource = table;
                    this.gridOduncKitaplar.Columns["id"].HeaderText = "ID";
                    this.gridOduncKitaplar.Columns["ogrenci_no"].HeaderText = "Öğrenci No";
                    this.gridOduncKitaplar.Columns["ad"].HeaderText = "Ad";
                    this.gridOduncKitaplar.Columns["soyad"].HeaderText = "Soyad";
                    this.gridOduncKitaplar.Columns["kitap_adi"].HeaderText = "Kitap Adı";
                    this.gridOduncKitaplar.Columns["verilis_tarihi"].HeaderText = "Veriliş Tarihi";
                    this.gridOduncKitaplar.Columns["teslim_tarihi"].HeaderText = "Teslim Tarihi";
                    this.gridOduncKitaplar.Columns["aciklama"].HeaderText = "Açıklama";
                    this.gridOduncKitaplar.Columns["aciklama"].Width = 150;
                    this.gridOduncKitaplar.Columns["id"].Width = 30;
                    this.gridOduncKitaplar.Columns["ogrenci_no"].Width = 40;
                    this.gridOduncKitaplar.Columns["ad"].Width = 70;
                    this.gridOduncKitaplar.Columns["soyad"].Width = 70;
                    this.gridOduncKitaplar.Columns["kitap_adi"].Width = 100;
                    this.gridOduncKitaplar.Columns["verilis_tarihi"].Width = 70;
                    this.gridOduncKitaplar.Columns["teslim_tarihi"].Width = 70;
                }
                else
                {
                    this.gridOduncKitaplar.DataSource = "";
                }




            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Bir hata oluştu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
