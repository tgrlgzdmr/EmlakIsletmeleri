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
    public partial class FrmMusteriDetay : Form
    {
        public FrmMusteriDetay()
        {
            InitializeComponent();
        }
        PstgreConnection bgl = new PstgreConnection();
        public string musteri;
        public string mail;
        public string secim = " ";
        private void FrmMusteriDetay_Load(object sender, EventArgs e)
        {
            NpgsqlCommand cmd = new NpgsqlCommand("select * from musteri where musteriid=@p1", bgl.baglanti());
            cmd.Parameters.AddWithValue("@p1", int.Parse(musteri));
            NpgsqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Lblmusteri.Text = dr[1] + " " + dr[2];
                LblEvTelefon.Text = dr[3].ToString();
                LblTelefon.Text = dr[4].ToString();
                LblMail.Text = dr[5].ToString();
            }


            NpgsqlCommand cmd1 = new NpgsqlCommand("select mulkid, emlakturu,boyutmkare,kat, isinmaturu,mulksehir, mulkilce,mulkmahalle, mulkfiyat,odasayisi from mulk where mulksahipid=@p2", bgl.baglanti());
            cmd1.Parameters.AddWithValue("@p2", int.Parse(musteri));
            DataTable dt = new DataTable();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd1);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmMusteriEdit frm = new FrmMusteriEdit();
            frm.mail = mail;
            frm.musteri = musteri;
            frm.Show();
            this.Hide();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int chosen = dataGridView1.SelectedCells[0].RowIndex;
            label1.Text = dataGridView1.Rows[chosen].Cells[0].Value.ToString();
            secim = dataGridView1.Rows[chosen].Cells[0].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (secim == " ")
            {
                MessageBox.Show("Lütfen Mülk Seçiniz");
            }
            else
            {
                FrmMulkEdit frm1 = new FrmMulkEdit();
                frm1.mail = mail;
                frm1.musteri = musteri;
                frm1.mulk = secim;
                frm1.Show();
                this.Hide();
            }

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            FrmIsletmeDetail frm1 = new FrmIsletmeDetail();
            frm1.IsletmeMail = mail;
            
            frm1.Show();
            this.Hide();
        }
    }
}
