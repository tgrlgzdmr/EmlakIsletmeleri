using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmlakIsletmeleri
{
    public partial class FrmMulkEkle : Form
    {
        public FrmMulkEkle()
        {
            InitializeComponent();
        }
        PstgreConnection bgl = new PstgreConnection();
        public string musteri;
        public string mail;
        public string isletme;
        private void FrmMulkEkle_Load(object sender, EventArgs e)
        {
            NpgsqlCommand cmd1 = new NpgsqlCommand("select musteriad,musterisoyad from musteri where musteriid=@p1", bgl.baglanti());
            cmd1.Parameters.AddWithValue("@p1", int.Parse(musteri));
            NpgsqlDataReader dr1 = cmd1.ExecuteReader();
            while( dr1.Read())
            {
                LblMusteri.Text=dr1[0] + " " + dr1[1] + " müşterisi için yeni mülk ekle";
               
            }
        }

        private void BtnMulkKaydet_Click(object sender, EventArgs e)
        {
            NpgsqlCommand cmd = new NpgsqlCommand("insert into mulk (mulksahipid, emlakturu, boyutmkare, odasayisi, isinmaturu, mulksehir, mulkilce, mulkmahalle, kat, mulkisletmeid, mulkfiyat) values (@p1,@p2,@p3,@p4,@p5,@p7,@p8,@p9,@p10,@p11,@p12)", bgl.baglanti());
            cmd.Parameters.AddWithValue("@p1", int.Parse(musteri));
            cmd.Parameters.AddWithValue("@p2", TxtTur.Text);
            cmd.Parameters.AddWithValue("@p3", int.Parse(TxtBoyut.Text));
            cmd.Parameters.AddWithValue("@p4", TxtOda.Text);
            cmd.Parameters.AddWithValue("@p5", TxtIsınma.Text);
            
            cmd.Parameters.AddWithValue("@p7", TxtSehir.Text);
            cmd.Parameters.AddWithValue("@p8", TxtIlce.Text);
            cmd.Parameters.AddWithValue("@p9", TxtMahalle.Text);
            cmd.Parameters.AddWithValue("@p10", int.Parse(TxtKat.Text));
            cmd.Parameters.AddWithValue("@p11", int.Parse(isletme));
            cmd.Parameters.AddWithValue("@p12", int.Parse(TxtFiyat.Text));
            cmd.ExecuteNonQuery();
            bgl.baglanti().Close();
            FrmIsletmeDetail fr9=new FrmIsletmeDetail();
            fr9.IsletmeMail = mail;
            fr9.Show();
            this.Hide();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            FrmIsletmeDetail fr9 = new FrmIsletmeDetail();
            fr9.IsletmeMail = mail;
            fr9.Show();
            this.Hide();
        }
    }
}
