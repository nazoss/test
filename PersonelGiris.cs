using Personel_Giris.entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Personel_Giris
{
    public partial class PersonelGiris : Form
    {
        public PersonelGiris()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            Form1 form2 = new Form1();
            form2.Show();  // form2 göster diyoruz
            this.Hide();   // bu yani form1 gizle diyoruz
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "  ";
            textBox2.Text = "  ";
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            textBox3.Text = "  ";
            textBox4.Text = "  ";
            textBox5.Text = "  ";
            
        }

       
        Db_baglan baglandım = new Db_baglan();
        private void Oluştur_Click(object sender, EventArgs e)
        {
            var nesnem = new Personel();
            nesnem.ad = textBox1.Text;
            nesnem.soyad = textBox2.Text;
            nesnem.tc_no = textBox3.Text;
            nesnem.mezun_durumu = comboBox1.Text;
            nesnem.görevli_depart = comboBox2.Text;
            nesnem.k_adi = textBox4.Text;
            nesnem.sifre = textBox5.Text; 
            if (radioButton1.Checked)
            {
                nesnem.cinsiyet = "Kadın";
            }
            if (radioButton2.Checked)
            {
                nesnem.cinsiyet = "Erkek";
            }



            baglandım.bilgilerpersonel.Add(nesnem);
            baglandım.SaveChanges();


            MessageBox.Show("Oluşturuldu...");

            var kayıt = db.bilgilerpersonel.ToList();
            dataGridView1.DataSource = kayıt;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
     
        Db_baglan db = new Db_baglan();
        private void PersonelGiris_Load(object sender, EventArgs e)
        {
            var kayıt = db.bilgilerpersonel.ToList();
            dataGridView1.DataSource = kayıt;
            temizle();
            tazele();

           

        }
        int id_gir;
        private void button3_Click(object sender, EventArgs e)
        {
            int id_gir = Convert.ToInt32(textBox6.Text);
            var silinecek = db.bilgilerögrenci.Find(id_gir);

            if (silinecek != null) // Eğer silinecek kayıt varsa
            {
                db.bilgilerögrenci.Remove(silinecek);
                db.SaveChanges();
                temizle();
                MessageBox.Show("Silme İşlemi Başşşşarılı");
            }
            else // Eğer silinecek kayıt bulunamazsa
            {
                MessageBox.Show("Silinecek olan id bulunamadı!");
            }
        }
    
        void temizle()
        {
            var tum_veriler = db.bilgilerögrenci.ToList();
            dataGridView1.DataSource = tum_veriler;
        }
        
        private void button5_Click(object sender, EventArgs e)
        {
            var veriler = db.bilgilerpersonel.ToList();
            foreach( var item in veriler ) 
            {
             db.bilgilerpersonel.Remove(item);
            }
            db.SaveChanges();
            tazele();
        }
        void tazele()
        {
            var tum_veriler = db.bilgilerpersonel.ToList();
            dataGridView1 .DataSource = tum_veriler;
        }



        //int gncl_id;
        //private void button4_Click(object sender, EventArgs e)
        //{
        //    gncl_id = Convert.ToInt32(textBox7.Text);   
        //    var vericek =db.bilgilerpersonel.Find(gncl_id);
        //  textBox1.Text = vericek.ad;
        //  textBox2.Text = vericek.soyad;
        //  textBox3.Text = vericek.tc_no;
        //  textBox4.Text = vericek.mezun_durumu;
        //  textBox5.Text = vericek.görevli_depart;
        //  textBox6.Text = vericek.k_adi;
        //  textBox7.Text = vericek.sifre;
        //    if (radioButton1.Checked)
        //    {
        //       vericek.cinsiyet = "Kadın";
        //    }
        //    if (radioButton2.Checked)
        //    {
        //      vericek.cinsiyet = "Erkek";
        //    }


        //}
    }
}
