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
    public partial class FrmMusteriEdit : Form
    {
        public FrmMusteriEdit()
        {
            InitializeComponent();
        }
        PstgreConnection bgl =new PstgreConnection();
        public string mail;
        public string musteri;

        private void FrmMusteriEdit_Load(object sender, EventArgs e)
        {
            NpgsqlCommand cmd1 = new NpgsqlCommand("select * from musteri where musteriid=@p1", bgl.baglanti());
            cmd1.Parameters.AddWithValue("@p1", int.Parse(musteri));
            NpgsqlDataReader dr = cmd1.ExecuteReader();
            while (dr.Read())
            {
                TxtName.Text = dr[1].ToString();
                TxtSurname.Text = dr[2].ToString();
                TxtPhoneEv.Text = dr[3].ToString();
                TxtPhoneCep.Text = dr[4].ToString();
                TxtMail.Text = dr[5].ToString();
                
            }
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            NpgsqlCommand cmd2 = new NpgsqlCommand("update musteri set musteriad=@p2, musterisoyad=@p3, musterievtel=@p4, mustericeptel=@p5, musteriemail=@p6 where musteriid=@p7", bgl.baglanti());
            cmd2.Parameters.AddWithValue("@p2", TxtName.Text);
            cmd2.Parameters.AddWithValue("@p3", TxtSurname.Text);
            cmd2.Parameters.AddWithValue("@p4", TxtPhoneEv.Text);
            cmd2.Parameters.AddWithValue("@p5", TxtPhoneCep.Text);
            cmd2.Parameters.AddWithValue("@p6", TxtMail.Text);
            cmd2.Parameters.AddWithValue("@p7", int.Parse(musteri));
            cmd2.ExecuteNonQuery();
            FrmMusteriDetay fr = new FrmMusteriDetay();
            fr.mail = mail;
            fr.musteri = musteri;
            fr.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            FrmMusteriDetay fr = new FrmMusteriDetay();
            fr.mail = mail;
            fr.musteri = musteri;
            fr.Show();
            this.Hide();
        }
    }
}
