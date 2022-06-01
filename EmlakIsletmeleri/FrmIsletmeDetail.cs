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
    public partial class FrmIsletmeDetail : Form
    {
        public string IsletmeMail;
        public int id;
        PstgreConnection bgl =new PstgreConnection();
        public FrmIsletmeDetail()
        {
            InitializeComponent();
        }
        FrmMusteriEkle fr5 = new FrmMusteriEkle();
        FrmMulkEkle fr8 = new FrmMulkEkle();
        FrmMulkAra fr9 = new FrmMulkAra();
        FrmIsletmeEdit fr10 = new FrmIsletmeEdit();
        FrmMusteriDetay fr11 = new FrmMusteriDetay();
        
        private void BtnKayit_Click(object sender, EventArgs e)
        {
            fr5.mail = IsletmeMail;
            fr5.Show();
            this.Hide();
        }

        private void FrmIsletmeDetail_Load(object sender, EventArgs e)
        {
            NpgsqlCommand cmd = new NpgsqlCommand("select * from emlak where isletmemail=@p1",bgl.baglanti());
            cmd.Parameters.AddWithValue("@p1", IsletmeMail);
            NpgsqlDataReader dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                fr9.id = int.Parse(dr[0].ToString());
                id = int.Parse(dr[0].ToString());
                fr8.isletme = dr[0].ToString();
                fr5.isletmeid = dr[0].ToString();
                LblIsletme.Text=dr[1].ToString();
                LblYetkili.Text=dr[2].ToString();
                LblAdres.Text=dr[3].ToString();
                LblTelefon.Text=dr[4].ToString();
                LblFax.Text=dr[5].ToString();
                LblMail.Text=dr[6].ToString();
                
            }
            bgl.baglanti().Close();

            //CmbMusteri.Items.Clear();
            //NpgsqlCommand cmd1 = new NpgsqlCommand("select musteriad,musterisoyad from musteri", bgl.baglanti()); 
            //NpgsqlDataReader dr1 = cmd1.ExecuteReader();
            //while( dr1.Read())
            //{
            //    CmbMusteri.Items.Add(dr1[0] + " " + dr1[1]);
            //    bgl.baglanti().Close();
            //}

            NpgsqlCommand cmd1 = new NpgsqlCommand("select musteriid, musteriad || ' ' || musterisoyad as musteriler from musteri where musteriisletmeid=1 or musteriisletmeid=@p2 order by musteriisletmeid", bgl.baglanti());
            cmd1.Parameters.AddWithValue("@p2", id);
            NpgsqlDataAdapter da1 = new NpgsqlDataAdapter(cmd1);
            DataTable dt1 = new DataTable();
            
            da1.Fill(dt1);
            
            CmbMusteri.DisplayMember = "musteriler";
            CmbMusteri.ValueMember = "musteriid";
            CmbMusteri.DataSource = dt1;

            //CmbMusteri1.Items.Clear();
            //NpgsqlCommand cmd2 = new NpgsqlCommand("select musteriad,musterisoyad from musteri", bgl.baglanti());
            //NpgsqlDataReader dr2 = cmd2.ExecuteReader();
            //while (dr2.Read())
            //{
            //    CmbMusteri1.Items.Add(dr2[0] + " " + dr2[1]);
            //    bgl.baglanti().Close();
            //}

            NpgsqlCommand cmd2 = new NpgsqlCommand("select musteriid, musteriad || ' ' || musterisoyad as musteriler from musteri where musteriisletmeid=1 or musteriisletmeid=@p3 order by musteriisletmeid", bgl.baglanti());
            cmd2.Parameters.AddWithValue("@p3", id);
            NpgsqlDataAdapter da2 = new NpgsqlDataAdapter(cmd2);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            CmbMusteri1.DisplayMember = "musteriler";
            CmbMusteri1.ValueMember = "musteriid";
            CmbMusteri1.DataSource = dt2;

            //CmbMusteri2.Items.Clear();
            //NpgsqlCommand cmd3 = new NpgsqlCommand("select musteriad, musterisoyad from musteri", bgl.baglanti());
            //NpgsqlDataReader dr3 = cmd3.ExecuteReader();
            //while (dr3.Read())
            //{
            //    CmbMusteri2.Items.Add(dr3[0] + " " + dr3[1]);
            //    bgl.baglanti().Close();
            //}

            //CmbMusteri2.Items.Clear();
            NpgsqlCommand cmd3 = new NpgsqlCommand("select musteriid, musteriad || ' ' || musterisoyad as musteriler from musteri where musteriisletmeid=1 or musteriisletmeid=@p5 order by musteriisletmeid", bgl.baglanti());
            cmd3.Parameters.AddWithValue("@p5", id);
            NpgsqlDataAdapter da3 = new NpgsqlDataAdapter(cmd3);
            DataTable dt3= new DataTable();
            da3.Fill(dt3);
            CmbMusteri2.DisplayMember = "musteriler";
            CmbMusteri2.ValueMember = "musteriid";
            CmbMusteri2.DataSource = dt3;
            
            //bgl.baglanti().Close();



        }

        private void CmbMusteri2_SelectedIndexChanged(object sender, EventArgs e)
        {
            label1.Text = CmbMusteri2.SelectedValue.ToString();
            
        }

        private void BtnMulkEkle_Click(object sender, EventArgs e)
        {
            if(label2.Text=="1")
            {
                MessageBox.Show("Lütfen müşteri seçiniz");
            }
            else
            {
                
                fr8.musteri = label2.Text;
                fr8.mail = IsletmeMail;
                fr8.Show();
                this.Hide();
            }
        }

        private void CmbMusteri_SelectedIndexChanged(object sender, EventArgs e)
        {
            label2.Text = CmbMusteri.SelectedValue.ToString();
        }

        private void CmbMusteri1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label3.Text = CmbMusteri1.SelectedValue.ToString();
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            if (label3.Text == "1")
            {
                MessageBox.Show("Lütfen müşteri seçiniz");
            }
            else
            {

                fr9.musteri = label3.Text;
                fr9.mail = IsletmeMail;
                fr9.Show();
                this.Hide();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fr10.mail = IsletmeMail;
            fr10.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (label1.Text == "1")
            {
                MessageBox.Show("Lütfen müşteri seçiniz");
            }
            else
            {

                fr11.musteri = label1.Text;
                fr11.mail = IsletmeMail;
                fr11.Show();
                this.Hide();
            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Form1 frmm=new Form1();
            frmm.Show();
            this.Hide();
        }
    }
}
