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
    public partial class frmOgrenci : Form
    {
        public Veritabani vtIslemleri;
        private MySqlCommand command;
        private MySqlDataAdapter adapter;
        public frmOgrenci()
        {
            InitializeComponent();
            this.vtIslemleri = new Veritabani();
        }

        private void Listele()
        {
            try
            {
                this.command = new MySqlCommand();
                this.vtIslemleri.baglan();
                this.command.Connection = this.vtIslemleri.Baglanti;               
                this.command.CommandText = "select * from ogrenciler";
                this.adapter = new MySqlDataAdapter(this.command);
                DataTable table = new DataTable();
                this.adapter.Fill(table);
                
                if (table.Rows.Count > 0)
                {
                    this.gridOgrenci.DataSource = table;
                    this.gridOgrenci.Columns["ogrenci_no"].HeaderText = "Öğrenci No";
                    this.gridOgrenci.Columns["ad"].HeaderText = "Ad";
                    this.gridOgrenci.Columns["soyad"].HeaderText = "Soyad";
                    this.gridOgrenci.Columns["sinif"].HeaderText = "Sınıf";
                    this.gridOgrenci.Columns["cinsiyet"].HeaderText = "Cinsiyet";
                    this.gridOgrenci.Columns["telefon"].HeaderText = "Telefon";

                }
                else
                {
                    this.gridOgrenci.DataSource = "";
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
                string komut = "INSERT INTO ogrenciler(ogrenci_no,ad,soyad,sinif,cinsiyet,telefon) VALUES(@no,@ad,@soyad,@sinif,@cinsiyet,@telefon)";
                this.command = new MySqlCommand(komut);
                this.vtIslemleri.baglan();
                this.command.Connection = this.vtIslemleri.Baglanti;
                this.command.Parameters.AddWithValue("@no", int.Parse(txtNo.Text.Trim()));
                this.command.Parameters.AddWithValue("@ad", txtAd.Text.Trim());
                this.command.Parameters.AddWithValue("@soyad", txtSoyad.Text.Trim());
                this.command.Parameters.AddWithValue("@sinif",int.Parse(comboSinif.SelectedItem.ToString()));
                this.command.Parameters.AddWithValue("@cinsiyet", comboCinsiyet.SelectedItem.ToString());
                this.command.Parameters.AddWithValue("@telefon", txtTelefon.Text.Trim());
              
                this.command.ExecuteNonQuery();
                this.vtIslemleri.Baglanti.Close();
                DialogResult result = MessageBox.Show("Yeni kayıt eklendi", "İşlem Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (result == DialogResult.OK)
                {
                    this.Listele();
                    this.Temizle();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                MessageBox.Show(ex.Message, "Bir hata oluştu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void btnSil_Click(object sender, EventArgs e)
        {

            try
            {
                string komut = "delete from ogrenciler where ogrenci_no=@ogr_no";
                this.command = new MySqlCommand(komut);
                this.command.Connection = this.vtIslemleri.Baglanti;
                this.vtIslemleri.baglan();                
                this.command.Parameters.AddWithValue("@ogr_no", gridOgrenci.CurrentRow.Cells[0].Value.ToString());
                this.command.ExecuteNonQuery();               
                this.vtIslemleri.Baglanti.Close();
                DialogResult result = MessageBox.Show("Kayıt silindi", "İşlem Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (result == DialogResult.OK)
                {
                    this.Listele();

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
                string komut = "update  ogrenciler set ogrenci_no=@ogrenci_no,ad=@ad,soyad=@soyad,telefon=@telefon,cinsiyet=@cinsiyet,sinif=@sinif where ogrenci_no=@ogrenci_no";
                this.command = new MySqlCommand(komut);
                this.vtIslemleri.baglan();
                this.command.Connection = this.vtIslemleri.Baglanti;
                this.command.Parameters.AddWithValue("@ogrenci_no", int.Parse(gridOgrenci.CurrentRow.Cells["ogrenci_no"].Value.ToString()));
                this.command.Parameters.AddWithValue("@ad", txtAd.Text.Trim());
                this.command.Parameters.AddWithValue("@soyad", txtSoyad.Text.Trim());
                this.command.Parameters.AddWithValue("@telefon", txtTelefon.Text.Trim());
                this.command.Parameters.AddWithValue("@cinsiyet", comboCinsiyet.SelectedItem.ToString());
                this.command.Parameters.AddWithValue("@sinif", int.Parse(comboSinif.SelectedItem.ToString()));                
                
                this.command.ExecuteNonQuery();
                this.vtIslemleri.Baglanti.Close();
                DialogResult result = MessageBox.Show("Kayıt güncellendi", "İşlem Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (result == DialogResult.OK)
                {
                    this.Listele();
                    this.Temizle();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                MessageBox.Show(ex.Message, "Bir hata oluştu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.Listele();

        }


        private void gridOgrenci_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.txtAd.Text = this.gridOgrenci.CurrentRow.Cells["ad"].Value.ToString();
                this.txtSoyad.Text = this.gridOgrenci.CurrentRow.Cells["soyad"].Value.ToString();
                this.txtTelefon.Text = this.gridOgrenci.CurrentRow.Cells["telefon"].Value.ToString();
                this.txtNo.Text = this.gridOgrenci.CurrentRow.Cells["ogrenci_no"].Value.ToString();
                this.comboSinif.SelectedItem = this.gridOgrenci.CurrentRow.Cells["sinif"].Value.ToString();
                this.comboCinsiyet.SelectedItem = this.gridOgrenci.CurrentRow.Cells["cinsiyet"].Value.ToString();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Bir hata oluştu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmOgrenci_Load(object sender, EventArgs e)
        {
            Listele();
        }
        private void Temizle()
        {
            this.txtAd.Clear();
            this.txtSoyad.Clear();
            this.txtNo.Clear();
            this.txtTelefon.Clear();
            this.comboSinif.SelectedIndex = 0;
            this.comboCinsiyet.SelectedIndex =0;
            
           
        }

        private void txtOgrenciAra_TextChanged(object sender, EventArgs e)
        {
            OgrenciArama(txtOgrenciAra.Text);
        }

        private void OgrenciArama(string text)
        {
            try
            {
                string komut = "select * from ogrenciler where ad LIKE '"+text+ "%' OR soyad LIKE '" + text + "%'";
                this.command = new MySqlCommand(komut);
                this.command.Connection = this.vtIslemleri.Baglanti;
                this.vtIslemleri.baglan();
                this.adapter = new MySqlDataAdapter(this.command);
                DataTable table = new DataTable();
                this.adapter.Fill(table);

                if (table.Rows.Count > 0)
                {
                    this.gridOgrenci.DataSource = table;
                    this.gridOgrenci.Columns["ogrenci_no"].HeaderText = "Öğrenci No";
                    this.gridOgrenci.Columns["ad"].HeaderText = "Ad";
                    this.gridOgrenci.Columns["soyad"].HeaderText = "Soyad";
                    this.gridOgrenci.Columns["sinif"].HeaderText = "Sınıf";
                    this.gridOgrenci.Columns["cinsiyet"].HeaderText = "Cinsiyet";
                    this.gridOgrenci.Columns["telefon"].HeaderText = "Telefon";

                }
                else
                {
                    this.gridOgrenci.DataSource = "";
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Bir hata oluştu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
