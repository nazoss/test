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
    public partial class ÖgretmenGiris : Form
    {
        public ÖgretmenGiris()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form2 = new Form1();
            form2.Show();  // form2 göster diyoruz
            this.Hide();   // bu yani form1 gizle diyoruz
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "  ";
            textBox2.Text = "  ";
            textBox3.Text = "  ";
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            textBox4.Text = "  ";
            textBox5.Text = "  ";
        }
        Db_baglan baglandım = new Db_baglan();
        private void Oluştur_Click(object sender, EventArgs e)
        {
            var nesnem = new Ögretmen();
            nesnem.ad = textBox1.Text;
            nesnem.soyad = textBox2.Text;
            nesnem.tc_no = comboBox2.Text;
            nesnem.Branşınız = comboBox1.Text;
            nesnem.girdiğiniz_sınıflar = comboBox1.Text;
            nesnem.k_adi = textBox4.Text;
            nesnem.sifre = textBox5.Text; 
            if (radioButton1.Checked)
            {
                nesnem.cinsiyett = "Kadın";
            }
            if (radioButton2.Checked)
            {
                nesnem.cinsiyett = "Erkek";
            }

            baglandım.bilgilerögretmen.Add(nesnem);
            baglandım.SaveChanges();


            MessageBox.Show("Oluşturuldu...");

            var kayıt = db.bilgilerögrenci.ToList();
            dataGridView1.DataSource = kayıt;

        }
        Db_baglan db = new Db_baglan();
        private void ÖgretmenGiris_Load(object sender, EventArgs e)
        {
            var kayıt = db.bilgilerögrenci.ToList();
            dataGridView1.DataSource = kayıt;
            temizle();
            yenile();
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

        void yenile()
        {
            var tumveriler = db.bilgilerögretmen.ToList();
            dataGridView1.DataSource= tumveriler;
        }
        string aranacak_ad;
        private void button4_Click(object sender, EventArgs e)
        {
            aranacak_ad = textBox7.Text;
            var sonuclar = (from i in db.bilgilerögretmen
                            where i.ad == aranacak_ad
                            select i).ToList();
            dataGridView1.DataSource=sonuclar;
        }

        private void button5_Click(object sender, EventArgs e)
        {

            var veriler = db.bilgilerögretmen.ToList();
            foreach (var item in veriler)
            {
                db.bilgilerögretmen.Remove(item);
            }
            db.SaveChanges();
            tazele();

        }
        void tazele()
        {
            var tum_veriler = db.bilgilerögretmen.ToList();
            dataGridView1.DataSource = tum_veriler;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
