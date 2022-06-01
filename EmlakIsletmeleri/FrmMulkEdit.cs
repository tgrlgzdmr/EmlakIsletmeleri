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
    public partial class FrmMulkEdit : Form
    {
        public FrmMulkEdit()
        {
            InitializeComponent();
        }

        PstgreConnection bgl=new PstgreConnection();
        public string mail;
        public string musteri;
        public string mulk;
        private void FrmMulkEdit_Load(object sender, EventArgs e)
        {
            NpgsqlCommand cmd = new NpgsqlCommand("select musteriad, musterisoyad from musteri where musteriid=@p1",bgl.baglanti());
            cmd.Parameters.AddWithValue("@p1", int.Parse(musteri));
            NpgsqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                LblMusteri.Text = dr[0] + " " + dr[1] +" müşterisi için mülk düzenleme";
                
            }

            NpgsqlCommand cmd1 = new NpgsqlCommand("select emlakturu, boyutmkare, odasayisi, kat, isinmaturu, mulksehir, mulkilce, mulkmahalle, mulkfiyat from mulk where mulkid=@p2",bgl.baglanti());
            cmd1.Parameters.AddWithValue("@p2", int.Parse(mulk));
            NpgsqlDataReader dr2 = cmd1.ExecuteReader();
            while(dr2.Read())
            {
                TxtTur.Text = dr2[0].ToString();
                TxtBoyut.Text = dr2[1].ToString();
                TxtOda.Text=dr2[2].ToString();
                TxtKat.Text=dr2[3].ToString();
                TxtIsinma.Text=dr2[4].ToString();
                TxtSehir.Text=dr2[5].ToString();
                TxtIlce.Text=dr2[6].ToString();
                TxtMahalle.Text=dr2[7].ToString();
                TxtFiyat.Text=dr2[8].ToString();
            }
        }

        private void BtnMulkKaydet_Click(object sender, EventArgs e)
        {
            NpgsqlCommand cmd2 = new NpgsqlCommand("update mulk set emlakturu=@p3, boyutmkare=@p4, odasayisi=@p5, kat=@p6, isinmaturu=@p7, mulksehir=@p8, mulkilce=@p9, mulkmahalle=@p10, mulkfiyat=@p11 where mulkid=@p12",bgl.baglanti());
            cmd2.Parameters.AddWithValue("@p3", TxtTur.Text);
            cmd2.Parameters.AddWithValue("@p4", int.Parse(TxtBoyut.Text));
            cmd2.Parameters.AddWithValue("@p5", TxtOda.Text);
            cmd2.Parameters.AddWithValue("@p6", int.Parse(TxtKat.Text));
            cmd2.Parameters.AddWithValue("@p7", TxtIsinma.Text);
            cmd2.Parameters.AddWithValue("@p8", TxtSehir.Text);
            cmd2.Parameters.AddWithValue("@p9", TxtIlce.Text);
            cmd2.Parameters.AddWithValue("@p10", TxtMahalle.Text);
            cmd2.Parameters.AddWithValue("@p11", int.Parse(TxtFiyat.Text));
            cmd2.Parameters.AddWithValue("@p12", int.Parse(mulk));
            cmd2.ExecuteNonQuery();
            FrmMusteriDetay frm5=new FrmMusteriDetay();
            frm5.mail = mail;
            frm5.musteri = musteri;
            frm5.Show();
            this.Hide();


        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            FrmMusteriDetay frm5 = new FrmMusteriDetay();
            frm5.mail = mail;
            frm5.musteri = musteri;
            frm5.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
