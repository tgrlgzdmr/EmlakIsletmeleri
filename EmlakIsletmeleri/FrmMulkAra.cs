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
    public partial class FrmMulkAra : Form
    {
        PstgreConnection bgl=new PstgreConnection();
        public string musteri;
        public string mail;
        public int id;
        public FrmMulkAra()
        {
            InitializeComponent();
        }

        private void FrmMulkAra_Load(object sender, EventArgs e)
        {

            NpgsqlCommand cmd2 = new NpgsqlCommand("select musteriad,musterisoyad from musteri where musteriid=@p1", bgl.baglanti());
            cmd2.Parameters.AddWithValue("@p1", int.Parse(musteri));
            NpgsqlDataReader dr2 = cmd2.ExecuteReader();
            while (dr2.Read())
            {
                LblMusteri.Text = dr2[0] + " " + dr2[1] + " müşterisi için arama yap";

            }


            NpgsqlCommand cmd1 = new NpgsqlCommand("select distinct mulkid, emlakturu from mulk where mulkisletmeid=1 or mulkisletmeid=@p11 ", bgl.baglanti());
            cmd1.Parameters.AddWithValue("@p11", id);
            NpgsqlDataAdapter da1 = new NpgsqlDataAdapter(cmd1);
            DataTable dt1 = new DataTable();

            da1.Fill(dt1);

            CmbTur.DisplayMember = "emlakturu";
            CmbTur.ValueMember = "mulkid";
            CmbTur.DataSource = dt1;

            NpgsqlCommand cmd18 = new NpgsqlCommand("select distinct mulkid,boyutmkare from mulk where mulkisletmeid=1 or mulkisletmeid=@p12 ", bgl.baglanti());
            cmd18.Parameters.AddWithValue("@p12", id);
            NpgsqlDataAdapter da9 = new NpgsqlDataAdapter(cmd18);
            DataTable dt9 = new DataTable();
            da9.Fill(dt9);

            CmbBoyut.DisplayMember = "boyutmkare";
            CmbBoyut.ValueMember = "mulkid";
            CmbBoyut.DataSource = dt9;

            NpgsqlCommand cmd17 = new NpgsqlCommand("select distinct mulkid,odasayisi from mulk where mulkisletmeid=1 or mulkisletmeid=@p13", bgl.baglanti());
            cmd17.Parameters.AddWithValue("@p13", id);
            NpgsqlDataAdapter da8 = new NpgsqlDataAdapter(cmd17);
            DataTable dt8 = new DataTable();
            da8.Fill(dt8);

            CmbOda.DisplayMember = "odasayisi";
            CmbOda.ValueMember = "mulkid";
            CmbOda.DataSource = dt8;

            NpgsqlCommand cmd16 = new NpgsqlCommand("select distinct mulkid,isinmaturu from mulk where mulkisletmeid=1 or mulkisletmeid=@p14 ", bgl.baglanti());
            cmd16.Parameters.AddWithValue("@p14", id);
            NpgsqlDataAdapter da7 = new NpgsqlDataAdapter(cmd16);
            DataTable dt7 = new DataTable();
            da7.Fill(dt7);

            CmbIsınma.DisplayMember = "isinmaturu";
            CmbIsınma.ValueMember = "mulkid";
            CmbIsınma.DataSource = dt7;

            NpgsqlCommand cmd15 = new NpgsqlCommand("select distinct mulkid,mulksehir from mulk where mulkisletmeid=1 or mulkisletmeid=@p15 ", bgl.baglanti());
            cmd15.Parameters.AddWithValue("@p15", id);
            NpgsqlDataAdapter da6 = new NpgsqlDataAdapter(cmd15);
            DataTable dt6 = new DataTable();
            da6.Fill(dt6);

            CmbSehir.DisplayMember = "mulksehir";
            CmbSehir.ValueMember = "mulkid";
            CmbSehir.DataSource = dt6;

            NpgsqlCommand cmd14 = new NpgsqlCommand("select distinct mulkid,mulkilce from mulk where mulkisletmeid=1 or mulkisletmeid=@p16 ", bgl.baglanti());
            cmd14.Parameters.AddWithValue("@p16", id);
            NpgsqlDataAdapter da5 = new NpgsqlDataAdapter(cmd14);
            DataTable dt5 = new DataTable();
            da5.Fill(dt5);

            CmbIlce.DisplayMember = "mulkilce";
            CmbIlce.ValueMember = "mulkid";
            CmbIlce.DataSource = dt5;

            NpgsqlCommand cmd13 = new NpgsqlCommand("select distinct mulkid,mulkmahalle from mulk where mulkisletmeid=1 or mulkisletmeid=@p17", bgl.baglanti());
            cmd13.Parameters.AddWithValue("@p17", id);
            NpgsqlDataAdapter da4 = new NpgsqlDataAdapter(cmd13);
            DataTable dt4 = new DataTable();
            da4.Fill(dt4);

            CmbMahalle.DisplayMember = "mulkmahalle";
            CmbMahalle.ValueMember = "mulkid";
            CmbMahalle.DataSource = dt4;

            NpgsqlCommand cmd12 = new NpgsqlCommand("select distinct mulkid,kat from mulk where mulkisletmeid=1 or mulkisletmeid=@p18 ", bgl.baglanti());
            cmd12.Parameters.AddWithValue("@p18", id);
            NpgsqlDataAdapter da3 = new NpgsqlDataAdapter(cmd12);
            DataTable dt3 = new DataTable();
            da3.Fill(dt3);

            CmbKat.DisplayMember = "kat";
            CmbKat.ValueMember = "mulkid";
            CmbKat.DataSource = dt3;

            NpgsqlCommand cmd11 = new NpgsqlCommand("select distinct mulkid,mulkfiyat from mulk where mulkisletmeid=1 or mulkisletmeid=@p19", bgl.baglanti());
            cmd11.Parameters.AddWithValue("@p19", id);
            NpgsqlDataAdapter da2 = new NpgsqlDataAdapter(cmd11);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);

            CmbFiyat.DisplayMember = "mulkfiyat";
            CmbFiyat.ValueMember = "mulkid";
            CmbFiyat.DataSource = dt2;


            
        }

        private void CmbTur_SelectedIndexChanged(object sender, EventArgs e)
        {
            label12.Text = CmbTur.SelectedValue.ToString();
        }

        private void CmbBoyut_SelectedIndexChanged(object sender, EventArgs e)
        {
            label13.Text= CmbBoyut.SelectedValue.ToString();
        }

        private void CmbOda_SelectedIndexChanged(object sender, EventArgs e)
        {
            label14.Text = CmbOda.SelectedValue.ToString();
        }

        private void CmbKat_SelectedIndexChanged(object sender, EventArgs e)
        {
            label15.Text = CmbKat.SelectedValue.ToString();
        }

        private void CmbIsınma_SelectedIndexChanged(object sender, EventArgs e)
        {
            label16.Text = CmbIsınma.SelectedValue.ToString();
        }

        private void CmbKira_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void CmbSehir_SelectedIndexChanged(object sender, EventArgs e)
        {
            label18.Text = CmbSehir.SelectedValue.ToString();
        }

        private void CmbIlce_SelectedIndexChanged(object sender, EventArgs e)
        {
            label19.Text = CmbIlce.SelectedValue.ToString();
        }

        private void CmbMahalle_SelectedIndexChanged(object sender, EventArgs e)
        {
            label20.Text = CmbMahalle.SelectedValue.ToString();
        }

        private void CmbFiyat_SelectedIndexChanged(object sender, EventArgs e)
        {
            label21.Text = CmbFiyat.SelectedValue.ToString();
        }

        //koşullar
        string tur;
        string boyut;
        string oda;
        string kat;
        string isinma;
        string sehir;
        string ilce;
        string mahalle;
        string fiyat;
        string wher;
        string andd;

        private void BtnMulkKaydet_Click(object sender, EventArgs e)
        {
            if (label12.Text == "1" && label13.Text == "1" && label14.Text == "1" && label15.Text == "1" && label16.Text=="1" && label18.Text=="1" && label19.Text=="1" && label20.Text=="1" && label21.Text=="1")
            {
                wher = " where ";
                andd = " ";
            }
            else
            {
                wher = " where ";
                andd = " and ";
            }
            if(label12.Text =="1")
            {
                tur = " ";
                

            }
            else
            {
                NpgsqlCommand cmd1 = new NpgsqlCommand("select emlakturu from mulk where mulkid=@p2",bgl.baglanti());
                cmd1.Parameters.AddWithValue("@p2", int.Parse(label12.Text));
                NpgsqlDataReader dr3 = cmd1.ExecuteReader();
                while(dr3.Read())
                {
                    if (label13.Text == "1" && label14.Text == "1" && label15.Text == "1" && label16.Text == "1" && label18.Text == "1" && label19.Text == "1" && label20.Text == "1" && label21.Text == "1")
                    { 
                        tur = " emlakturu='" + dr3[0] + "' "; 
                    }
                    else { 
                        tur = " emlakturu='" + dr3[0] + "' and "; 
                    }
                }
                
            }
            if(label13.Text =="1")
            {
                boyut = " ";
            }
            else
            {
                NpgsqlCommand cmd3 = new NpgsqlCommand("select boyutmkare from mulk where mulkid=@p3", bgl.baglanti());
                cmd3.Parameters.AddWithValue("@p3", int.Parse(label13.Text));
                NpgsqlDataReader dr4 = cmd3.ExecuteReader();
                while (dr4.Read())
                {
                    if (label14.Text == "1" && label15.Text == "1" && label16.Text == "1" && label18.Text == "1" && label19.Text == "1" && label20.Text == "1" && label21.Text == "1")
                    { 
                        boyut = "boyutmkare=" + dr4[0] + "  "; 
                    }
                    else 
                    {
                        boyut = "boyutmkare=" + dr4[0] + " and ";
                    }
                }
            }
            if(label14.Text =="1")
            {
                oda = " ";
            }
            else
            {
                NpgsqlCommand cmd4 = new NpgsqlCommand("select odasayisi from mulk where mulkid=@p4", bgl.baglanti());
                cmd4.Parameters.AddWithValue("@p4", int.Parse(label14.Text));
                NpgsqlDataReader dr5 = cmd4.ExecuteReader();
                while (dr5.Read())
                {
                    if (label15.Text == "1" && label16.Text == "1" && label18.Text == "1" && label19.Text == "1" && label20.Text == "1" && label21.Text == "1")
                    { 
                        oda = "odasayisi='" + dr5[0] + "'  ";
                    }
                    else
                    {
                        oda = "odasayisi='" + dr5[0] + "' and ";
                    }
                }
            }
            if(label15.Text =="1")
            {
                kat = " ";

            }
            else
            {
                NpgsqlCommand cmd5 = new NpgsqlCommand("select kat from mulk where mulkid=@p5", bgl.baglanti());
                cmd5.Parameters.AddWithValue("@p5", int.Parse(label15.Text));
                NpgsqlDataReader dr6 = cmd5.ExecuteReader();
                while (dr6.Read())
                {
                    if (label16.Text == "1" && label18.Text == "1" && label19.Text == "1" && label20.Text == "1" && label21.Text == "1")
                    { 
                        kat = "kat=" + dr6[0] + "  "; 
                    }
                    else
                    {
                        kat = "kat=" + dr6[0] + " and ";
                    }
                }
            }
            if(label16.Text =="1")
            {
                isinma = " ";
            }
            else
            {
                NpgsqlCommand cmd6 = new NpgsqlCommand("select isinmaturu from mulk where mulkid=@p6", bgl.baglanti());
                cmd6.Parameters.AddWithValue("@p6", int.Parse(label16.Text));
                NpgsqlDataReader dr7 = cmd6.ExecuteReader();
                while (dr7.Read())
                {
                    if (label18.Text == "1" && label19.Text == "1" && label20.Text == "1" && label21.Text == "1")
                    { 
                        isinma = "isinmaturu='" + dr7[0] + "'  "; 
                    }
                    else
                    {
                        isinma = "isinmaturu='" + dr7[0] + "' and ";
                    }
                }
            }
            if(label18.Text =="1")
            {
                sehir = " ";
            }
            else
            {
                NpgsqlCommand cmd7 = new NpgsqlCommand("select mulksehir from mulk where mulkid=@p7", bgl.baglanti());
                cmd7.Parameters.AddWithValue("@p7", int.Parse(label18.Text));
                NpgsqlDataReader dr8 = cmd7.ExecuteReader();
                while (dr8.Read())
                {
                    if (label19.Text == "1" && label20.Text == "1" && label21.Text == "1")
                    { 
                        sehir = "mulksehir='" + dr8[0] + "'  "; 
                    }
                    else
                    {
                        sehir = "mulksehir='" + dr8[0] + "' and ";
                    }
                }
            }
            if(label19.Text =="1")
            {
                ilce = " ";
            }
            else
            {
                NpgsqlCommand cmd8 = new NpgsqlCommand("select mulkilce from mulk where mulkid=@p8", bgl.baglanti());
                cmd8.Parameters.AddWithValue("@p8", int.Parse(label19.Text));
                NpgsqlDataReader dr9 = cmd8.ExecuteReader();
                while (dr9.Read())
                {
                    if (label20.Text == "1" && label21.Text == "1")
                    {
                        ilce = "mulkilce='" + dr9[0] + "'  ";
                    }
                    else
                    {
                        ilce = "mulkilce='" + dr9[0] + "' and ";
                    }
                }
            }
            if(label20.Text =="1")
            {
                mahalle = " ";
            }
            else
            {
                NpgsqlCommand cmd9 = new NpgsqlCommand("select mulkmahalle from mulk where mulkid=@p9", bgl.baglanti());
                cmd9.Parameters.AddWithValue("@p9", int.Parse(label20.Text));
                NpgsqlDataReader dr10 = cmd9.ExecuteReader();
                while (dr10.Read())
                {
                    if (label21.Text == "1")
                    {
                        mahalle = "mulkmahalle='" + dr10[0] + "'  ";
                    }
                    else
                    {
                        mahalle = "mulkmahalle='" + dr10[0] + "' and ";
                    }
                }
            }
            if(label21.Text =="1")
            {
                fiyat = " ";
            }
            else
            {
                NpgsqlCommand cmd10 = new NpgsqlCommand("select mulkfiyat from mulk where mulkid=@p10", bgl.baglanti());
                cmd10.Parameters.AddWithValue("@p10", int.Parse(label21.Text));
                NpgsqlDataReader dr11 = cmd10.ExecuteReader();
                while (dr11.Read())
                {
                    fiyat = "mulkfiyat=" + dr11[0] ;
                }
            }
            richTextBox1.Text = wher + tur + boyut + oda + kat + isinma + sehir + ilce + mahalle + fiyat + andd + "mulkid!=1 and mulkisletmeid=" + id.ToString();
            NpgsqlCommand cmd19 = new NpgsqlCommand("select emlakturu, kat, boyutmkare,odasayisi,isinmaturu,mulksehir,mulkilce,mulkmahalle,mulkfiyat from mulk " + richTextBox1.Text, bgl.baglanti());
            //NpgsqlCommand cmd19 = new NpgsqlCommand("select * from mulk where ", bgl.baglanti());
            DataTable dt11 = new DataTable();
            NpgsqlDataAdapter da11 = new NpgsqlDataAdapter(cmd19);
            da11.Fill(dt11);
            dataGridView1.DataSource = dt11;
        }

        private void BtnMulkara_Click(object sender, EventArgs e)
        {
            if (label12.Text == "1" && label13.Text == "1" && label14.Text == "1" && label15.Text == "1" && label16.Text == "1" && label18.Text == "1" && label19.Text == "1" && label20.Text == "1" && label21.Text == "1")
            {
                wher = " where ";
                andd = " ";
            }
            else
            {
                wher = " where ";
                andd = " and ";
            }
            if (label12.Text == "1")
            {
                tur = " ";


            }
            else
            {
                NpgsqlCommand cmd1 = new NpgsqlCommand("select emlakturu from mulk where mulkid=@p2", bgl.baglanti());
                cmd1.Parameters.AddWithValue("@p2", int.Parse(label12.Text));
                NpgsqlDataReader dr3 = cmd1.ExecuteReader();
                while (dr3.Read())
                {
                    if (label13.Text == "1" && label14.Text == "1" && label15.Text == "1" && label16.Text == "1" && label18.Text == "1" && label19.Text == "1" && label20.Text == "1" && label21.Text == "1")
                    {
                        tur = " emlakturu='" + dr3[0] + "' ";
                    }
                    else
                    {
                        tur = " emlakturu='" + dr3[0] + "' or ";
                    }
                }

            }
            if (label13.Text == "1")
            {
                boyut = " ";
            }
            else
            {
                NpgsqlCommand cmd3 = new NpgsqlCommand("select boyutmkare from mulk where mulkid=@p3", bgl.baglanti());
                cmd3.Parameters.AddWithValue("@p3", int.Parse(label13.Text));
                NpgsqlDataReader dr4 = cmd3.ExecuteReader();
                while (dr4.Read())
                {
                    if (label14.Text == "1" && label15.Text == "1" && label16.Text == "1" && label18.Text == "1" && label19.Text == "1" && label20.Text == "1" && label21.Text == "1")
                    {
                        boyut = "boyutmkare=" + dr4[0] + "  ";
                    }
                    else
                    {
                        boyut = "boyutmkare=" + dr4[0] + " or ";
                    }
                }
            }
            if (label14.Text == "1")
            {
                oda = " ";
            }
            else
            {
                NpgsqlCommand cmd4 = new NpgsqlCommand("select odasayisi from mulk where mulkid=@p4", bgl.baglanti());
                cmd4.Parameters.AddWithValue("@p4", int.Parse(label14.Text));
                NpgsqlDataReader dr5 = cmd4.ExecuteReader();
                while (dr5.Read())
                {
                    if (label15.Text == "1" && label16.Text == "1" && label18.Text == "1" && label19.Text == "1" && label20.Text == "1" && label21.Text == "1")
                    {
                        oda = "odasayisi='" + dr5[0] + "'  ";
                    }
                    else
                    {
                        oda = "odasayisi='" + dr5[0] + "' or ";
                    }
                }
            }
            if (label15.Text == "1")
            {
                kat = " ";

            }
            else
            {
                NpgsqlCommand cmd5 = new NpgsqlCommand("select kat from mulk where mulkid=@p5", bgl.baglanti());
                cmd5.Parameters.AddWithValue("@p5", int.Parse(label15.Text));
                NpgsqlDataReader dr6 = cmd5.ExecuteReader();
                while (dr6.Read())
                {
                    if (label16.Text == "1" && label18.Text == "1" && label19.Text == "1" && label20.Text == "1" && label21.Text == "1")
                    {
                        kat = "kat=" + dr6[0] + "  ";
                    }
                    else
                    {
                        kat = "kat=" + dr6[0] + " or ";
                    }
                }
            }
            if (label16.Text == "1")
            {
                isinma = " ";
            }
            else
            {
                NpgsqlCommand cmd6 = new NpgsqlCommand("select isinmaturu from mulk where mulkid=@p6", bgl.baglanti());
                cmd6.Parameters.AddWithValue("@p6", int.Parse(label16.Text));
                NpgsqlDataReader dr7 = cmd6.ExecuteReader();
                while (dr7.Read())
                {
                    if (label18.Text == "1" && label19.Text == "1" && label20.Text == "1" && label21.Text == "1")
                    {
                        isinma = "isinmaturu='" + dr7[0] + "'  ";
                    }
                    else
                    {
                        isinma = "isinmaturu='" + dr7[0] + "' or ";
                    }
                }
            }
            if (label18.Text == "1")
            {
                sehir = " ";
            }
            else
            {
                NpgsqlCommand cmd7 = new NpgsqlCommand("select mulksehir from mulk where mulkid=@p7", bgl.baglanti());
                cmd7.Parameters.AddWithValue("@p7", int.Parse(label18.Text));
                NpgsqlDataReader dr8 = cmd7.ExecuteReader();
                while (dr8.Read())
                {
                    if (label19.Text == "1" && label20.Text == "1" && label21.Text == "1")
                    {
                        sehir = "mulksehir='" + dr8[0] + "'  ";
                    }
                    else
                    {
                        sehir = "mulksehir='" + dr8[0] + "' or ";
                    }
                }
            }
            if (label19.Text == "1")
            {
                ilce = " ";
            }
            else
            {
                NpgsqlCommand cmd8 = new NpgsqlCommand("select mulkilce from mulk where mulkid=@p8", bgl.baglanti());
                cmd8.Parameters.AddWithValue("@p8", int.Parse(label19.Text));
                NpgsqlDataReader dr9 = cmd8.ExecuteReader();
                while (dr9.Read())
                {
                    if (label20.Text == "1" && label21.Text == "1")
                    {
                        ilce = "mulkilce='" + dr9[0] + "'  ";
                    }
                    else
                    {
                        ilce = "mulkilce='" + dr9[0] + "' or ";
                    }
                }
            }
            if (label20.Text == "1")
            {
                mahalle = " ";
            }
            else
            {
                NpgsqlCommand cmd9 = new NpgsqlCommand("select mulkmahalle from mulk where mulkid=@p9", bgl.baglanti());
                cmd9.Parameters.AddWithValue("@p9", int.Parse(label20.Text));
                NpgsqlDataReader dr10 = cmd9.ExecuteReader();
                while (dr10.Read())
                {
                    if (label21.Text == "1")
                    {
                        mahalle = "mulkmahalle='" + dr10[0] + "'  ";
                    }
                    else
                    {
                        mahalle = "mulkmahalle='" + dr10[0] + "' or ";
                    }
                }
            }
            if (label21.Text == "1")
            {
                fiyat = " ";
            }
            else
            {
                NpgsqlCommand cmd10 = new NpgsqlCommand("select mulkfiyat from mulk where mulkid=@p10", bgl.baglanti());
                cmd10.Parameters.AddWithValue("@p10", int.Parse(label21.Text));
                NpgsqlDataReader dr11 = cmd10.ExecuteReader();
                while (dr11.Read())
                {
                    fiyat = "mulkfiyat=" + dr11[0];
                }
            }
            richTextBox2.Text = wher + tur + boyut + oda + kat + isinma + sehir + ilce + mahalle + fiyat + andd + " mulkid!=1 and mulkisletmeid="+ id.ToString();
            NpgsqlCommand cmd19 = new NpgsqlCommand("select emlakturu, kat, boyutmkare,odasayisi,isinmaturu,mulksehir,mulkilce,mulkmahalle,mulkfiyat from mulk " + richTextBox2.Text, bgl.baglanti());

            //NpgsqlCommand cmd19 = new NpgsqlCommand("select * from mulk where ", bgl.baglanti());
            DataTable dt11 = new DataTable();
            NpgsqlDataAdapter da11 = new NpgsqlDataAdapter(cmd19);
            da11.Fill(dt11);
            dataGridView1.DataSource = dt11;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            FrmIsletmeDetail frm3=new FrmIsletmeDetail();
            frm3.IsletmeMail = mail;
            frm3.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            printDocument1.Print();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                SolidBrush firca = new SolidBrush(Color.Black);
                Font font = new Font("Arial", 12);
                int i = 0;
                int y = 60;
                while(i<=dataGridView1.Rows.Count -2)
                {
                    font = new Font("Arial", 12);
                    e.Graphics.DrawString(dataGridView1.Rows[i].Cells[0].Value.ToString(), font,firca,60,y);
                    e.Graphics.DrawString(dataGridView1.Rows[i].Cells[1].Value.ToString(), font, firca, 100, y);
                    e.Graphics.DrawString(dataGridView1.Rows[i].Cells[2].Value.ToString(), font, firca, 220, y);
                    e.Graphics.DrawString(dataGridView1.Rows[i].Cells[3].Value.ToString(), font, firca, 300, y);
                    e.Graphics.DrawString(dataGridView1.Rows[i].Cells[4].Value.ToString(), font, firca, 380, y);
                    e.Graphics.DrawString(dataGridView1.Rows[i].Cells[5].Value.ToString(), font, firca, 460, y);
                    e.Graphics.DrawString(dataGridView1.Rows[i].Cells[6].Value.ToString(), font, firca, 640, y);
                    e.Graphics.DrawString(dataGridView1.Rows[i].Cells[7].Value.ToString(), font, firca, 620, y);
                    e.Graphics.DrawString(dataGridView1.Rows[i].Cells[8].Value.ToString(), font, firca, 700, y);
                    y = y + 40;
                    i= i + 1;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
