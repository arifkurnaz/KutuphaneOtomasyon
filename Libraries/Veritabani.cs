using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KutuphaneOtomasyon.Libraries
{
    public class Veritabani
    {
        private string baglantiCumlesi = ConfigurationManager.ConnectionStrings["veriTabaniBaglantisi"].ConnectionString;
        private MySqlConnection baglanti;

        public MySqlConnection Baglanti { get => baglanti; set => baglanti = value; }

        public void baglan() 
        {
            try
            {
                if (this.baglanti==null)
                {
                    this.Baglanti = new MySqlConnection(this.baglantiCumlesi);
                    MySqlConnection.ClearPool(this.Baglanti);
                    this.baglanti.Open();
                }
                else if(this.baglanti.State != ConnectionState.Open){
                    this.baglanti.Open();
                }
            }
            catch (MySqlException e)
            {

                MessageBox.Show(e.Message, "Bir hata oluştu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
                
                
        }
        
    }
}
