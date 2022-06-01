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
    public partial class FrmIsletmeEdit : Form
    {
        PstgreConnection bgl = new PstgreConnection();
        public FrmIsletmeEdit()
        {
            InitializeComponent();
        }
        public string mail;
        
        private void FrmIsletmeEdit_Load(object sender, EventArgs e)
        {
            NpgsqlCommand cmd1 = new NpgsqlCommand("select * from emlak where isletmemail=@p1", bgl.baglanti());
            cmd1.Parameters.AddWithValue("@p1", mail);
            NpgsqlDataReader dr = cmd1.ExecuteReader();
            while(dr.Read())
            {
                TxtName.Text=dr[1].ToString();
                TxtAuthorizer.Text=dr[2].ToString();
                TxtAdress.Text=dr[3].ToString();
                TxtPhone.Text=dr[4].ToString();
                TxtFax.Text=dr[5].ToString();
                TxtMail.Text=dr[6].ToString();
                TxtPassword.Text=dr[7].ToString();
            }

        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            NpgsqlCommand cmd1 = new NpgsqlCommand("update emlak set isletmead=@p2, yetkili=@p3, adres=@p4, telefon=@p5, fax=@p6, isletmemail=@p7,isletmesifre=@p8 where isletmemail=@p9", bgl.baglanti());
            cmd1.Parameters.AddWithValue("@p2", TxtName.Text);
            cmd1.Parameters.AddWithValue("@p3", TxtAuthorizer.Text);
            cmd1.Parameters.AddWithValue("@p4", TxtAdress.Text);
            cmd1.Parameters.AddWithValue("@p5", TxtPhone.Text);
            cmd1.Parameters.AddWithValue("@p6", TxtFax.Text);
            cmd1.Parameters.AddWithValue("@p7", TxtMail.Text);
            cmd1.Parameters.AddWithValue("@p8", TxtPassword.Text);
            cmd1.Parameters.AddWithValue("@p9", mail);
            cmd1.ExecuteNonQuery();
            FrmIsletmeDetail fr21 = new FrmIsletmeDetail();
            fr21.IsletmeMail = TxtMail.Text;
            fr21.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            FrmIsletmeDetail fr21 = new FrmIsletmeDetail();
            fr21.IsletmeMail = TxtMail.Text;
            fr21.Show();
            this.Hide();
        }
    }
}
