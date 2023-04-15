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
    public partial class formKitapTur : Form
    {
        public Veritabani vtIslemleri;
        private MySqlCommand command;
        private MySqlDataAdapter adapter;

        public formKitapTur()
        {
            InitializeComponent();
            this.vtIslemleri = new Veritabani();
            
        }

        private void formKitapTur_Load(object sender, EventArgs e)
        {
            this.Listele();
        }
        private void Listele()
        {
            try
            {
                string komut = "select * from kitap_turleri";
                this.vtIslemleri.baglan();
                this.command= new MySqlCommand(komut,this.vtIslemleri.Baglanti);               
                           
                this.adapter = new MySqlDataAdapter(this.command);
                DataTable table = new DataTable();
                this.adapter.Fill(table);
                if (table.Rows.Count > 0)
                {
                    gridKitapTur.DataSource = table;
                    gridKitapTur.Columns["tur_id"].HeaderText = "ID";
                    gridKitapTur.Columns["tur_id"].Width = 50;
                    gridKitapTur.Columns["tur_adi"].HeaderText = "Kitap Türü";
                }
                else
                {
                    gridKitapTur.DataSource = "";
                }
               
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message, "Bir hata oluştu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                string komut = "insert into kitap_turleri(tur_adi)values(@tur_adi)";
                this.command = new MySqlCommand(komut);
                this.vtIslemleri.baglan();
                this.command.Connection = this.vtIslemleri.Baglanti;
                this.command.Parameters.AddWithValue("@tur_adi", txtTurAdi.Text.Trim());
                this.command.ExecuteNonQuery();
                this.vtIslemleri.Baglanti.Close();
                DialogResult result = MessageBox.Show("Yeni kayıt eklendi", "İşlem Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (result == DialogResult.OK)
                {
                    this.Listele();
                    Temizle();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Bir hata oluştu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            
        }

        private void Temizle()
        {
            txtTurAdi.Clear();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            
            try
            {
                string komut = "delete from kitap_turleri where tur_id=@id";
                this.command = new MySqlCommand(komut);
                this.command.Connection = this.vtIslemleri.Baglanti;
                this.vtIslemleri.baglan();               
                this.command.Parameters.AddWithValue("@id", gridKitapTur.CurrentRow.Cells[0].Value.ToString());
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
                string komut = "update  kitap_turleri set tur_adi=@tur_adi where tur_id=@id";
                this.command = new MySqlCommand(komut);
                this.vtIslemleri.baglan();
                this.command.Connection = this.vtIslemleri.Baglanti;
                this.command.Parameters.AddWithValue("@tur_adi", txtTurAdi.Text.Trim());
                this.command.Parameters.AddWithValue("@id", gridKitapTur.CurrentRow.Cells[0].Value.ToString());
                this.command.ExecuteNonQuery();
                this.vtIslemleri.Baglanti.Close();
                DialogResult result = MessageBox.Show("Kayıt güncellendi", "İşlem Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (result == DialogResult.OK)
                {
                    this.Listele();
                    Temizle();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Bir hata oluştu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
            this.Listele();

        }

        private void gridKitapTur_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.txtTurAdi.Text = this.gridKitapTur.CurrentRow.Cells["tur_adi"].Value.ToString();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Bir hata oluştu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

    }
}
