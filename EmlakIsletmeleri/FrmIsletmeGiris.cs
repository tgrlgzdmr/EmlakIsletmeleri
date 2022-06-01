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
    public partial class FrmIsletmeGiris : Form
    {
        public FrmIsletmeGiris()
        {
            InitializeComponent();
        }
        PstgreConnection bgl = new PstgreConnection();
        private void BtnLogin_Click(object sender, EventArgs e)
        {
            
            NpgsqlCommand cmd = new NpgsqlCommand("select * from emlak where isletmemail=@p1 and isletmesifre=@p2", bgl.baglanti());
            cmd.Parameters.AddWithValue("@p1", TxtMail.Text);
            cmd.Parameters.AddWithValue("p2", TxtPassword.Text);
            NpgsqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                FrmIsletmeDetail fr2 = new FrmIsletmeDetail();
                fr2.IsletmeMail = TxtMail.Text;
                fr2.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Yanlış Email veya Şifre");
            }
        }

        private void FrmIsletmeGiris_Load(object sender, EventArgs e)
        {

        }
    }
}
