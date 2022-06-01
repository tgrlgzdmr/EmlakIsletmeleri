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
    public partial class IsletmeKayitForm : Form
    {
        
        public IsletmeKayitForm()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        PstgreConnection bgl = new PstgreConnection();
        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            
            NpgsqlCommand cmd = new NpgsqlCommand("insert into emlak (isletmead, Yetkili, Adres, Telefon, Fax, IsletmeMail, IsletmeSifre) values (:p1,:p2,:p3,:p4,:p5,:p6,:p7)", bgl.baglanti());
            cmd.Parameters.AddWithValue("p1", TxtName.Text);
            cmd.Parameters.AddWithValue("p2", TxtAuthorizer.Text);
            cmd.Parameters.AddWithValue("p3", TxtAdress.Text);
            cmd.Parameters.AddWithValue("p4", TxtPhone.Text);
            cmd.Parameters.AddWithValue("p5", TxtFax.Text);
            cmd.Parameters.AddWithValue("p6", TxtMail.Text);
            cmd.Parameters.AddWithValue("p7", TxtPassword.Text);
            cmd.ExecuteNonQuery();
            bgl.baglanti().Close();
            Form1 fr = new Form1();
            fr.Show();
            this.Hide();


        }

        private void IsletmeKayitForm_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form1 fr = new Form1();
            fr.Show();
            this.Hide();
        }
    }
}
