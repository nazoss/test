using Personel_Giris.entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Personel_Giris
{
    public partial class Ögrencigiris : Form
    {
        public Ögrencigiris()
        {
            InitializeComponent();
        }


        Db_baglan db = new Db_baglan();
        private void Ögrencigiris_Load(object sender, EventArgs e)
        {
            var kayıt = db.bilgilerögrenci.ToList();
            dataGridView1.DataSource = kayıt;
            temizle();
            tazele();
          

        }
    

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form2 = new Form1();
            form2.Show();  // form2 göster diyoruz
            this.Hide();   // bu yani form1 gizle diyoruz
        }
        Db_baglan baglandım = new Db_baglan();
        private void Oluştur_Click(object sender, EventArgs e)
        {


            var nesnem = new Ögrenci();
            nesnem.ad = textBox1.Text;
            nesnem.soyad = textBox2.Text;
            nesnem.ögretim_düzeyi = comboBox2.Text;
            nesnem.Sınıfınız = comboBox1.Text;
            nesnem.Dogum_tarihiniz = DateTime.Now;
            if(radioButton1.Checked)
            {
                nesnem.cinsiyet = "Kadın";
            }
            if (radioButton2.Checked)
            {
                nesnem.cinsiyet = "Erkek";
            }

            nesnem.k_adi=textBox4.Text;
            nesnem.sifree=textBox5.Text;   

            baglandım.bilgilerögrenci.Add(nesnem);
            baglandım.SaveChanges();


            MessageBox.Show("Oluşturuldu...");


            var kayıt = db.bilgilerögrenci.ToList();
            dataGridView1.DataSource = kayıt;

        }



        private void button2_Click(object sender, EventArgs e)
        {


            textBox1.Text = "  ";
            textBox2.Text = "  ";
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            textBox4.Text = "  ";
            textBox5.Text = "  ";

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
            var veriler = db.bilgilerögrenci.ToList();
            foreach (var item in veriler)
            {
                db.bilgilerögrenci.Remove(item);
            }
            db.SaveChanges();
            tazele();
        }
        void tazele()
        {
            var tum_veriler = db.bilgilerögrenci.ToList();
            dataGridView1.DataSource = tum_veriler;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}
