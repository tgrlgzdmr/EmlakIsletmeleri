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
    public partial class FrmMusteriEkle : Form
    {
        public string isletmeid;
        public string mail;
        PstgreConnection bgl = new PstgreConnection();
        public FrmMusteriEkle()
        {
            InitializeComponent();
        }

        private void FrmMusteriEkle_Load(object sender, EventArgs e)
        {

        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            NpgsqlCommand cmd = new NpgsqlCommand("insert into musteri (musteriad, musterisoyad, musterievtel, mustericeptel, musteriemail, musteriisletmeid) values (@p1,@p2,@p3,@p4,@p5,@p6)", bgl.baglanti());
            cmd.Parameters.AddWithValue("@p1", TxtName.Text);
            cmd.Parameters.AddWithValue("@p2", TxtSurname.Text);
            cmd.Parameters.AddWithValue("@p3", TxtPhoneEv.Text);
            cmd.Parameters.AddWithValue("@p4", TxtPhoneCep.Text);
            cmd.Parameters.AddWithValue("@p5", TxtMail.Text);
            cmd.Parameters.AddWithValue("@p6", int.Parse(isletmeid));
            cmd.ExecuteNonQuery();
            bgl.baglanti().Close();
            FrmIsletmeDetail fr7 = new FrmIsletmeDetail();
            fr7.IsletmeMail = mail;
            fr7.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            FrmIsletmeDetail fr7 = new FrmIsletmeDetail();
            fr7.IsletmeMail = mail;
            fr7.Show();
            this.Hide();
        }
    }
}
