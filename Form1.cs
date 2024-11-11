using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Personel_Giris.entity;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace Personel_Giris
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

      
        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Yönlendiriliyorsunuzz...");

            YeniKullanici form2 = new YeniKullanici();
            form2.Show();  // form2 göster diyoruz
            this.Hide();   // bu yani form1 gizle
                           // 

           

        }
        Db_baglan baglandım = new Db_baglan();
        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == "** Ögrenci")
            {
                string username = textBox1.Text;
                string sifre=textBox2.Text;

                var sorgu = (from i in baglandım.bilgilerögrenci where username == i.k_adi && sifre == i.sifree select i).FirstOrDefault();
                if (sorgu != null)
                {
                    MessageBox.Show("Giriş Başarılı");

                    giris form2 = new giris();
                    form2.Show();  // form2 göster diyoruz
                    this.Hide();   // bu yani form1 gizle diyoruz
                }
                else
                {
                    MessageBox.Show("Sistemde Kayıtlı değilsiniz!!!");
                }
            }



            if (comboBox1.SelectedItem == "** Ögretmen")
            {
                string username = textBox1.Text;
                string sifre = textBox2.Text;

                var sorgu = (from i in baglandım.bilgilerögretmen where username == i.k_adi && sifre == i.sifre select i).FirstOrDefault();
                if (sorgu != null)
                {
                    MessageBox.Show("Giriş Başarılı");

                    giris form2 = new giris();
                    form2.Show();  // form2 göster diyoruz
                    this.Hide();   // bu yani form1 gizle diyoruz
                }
                else
                {
                    MessageBox.Show("Sistemde Kayıtlı değilsiniz!!!");
                }
            }

            if (comboBox1.SelectedItem == "** Personel Giriş")
            {
                string username = textBox1.Text;
                string sifre = textBox2.Text;

                var sorgu = (from i in baglandım.bilgilerpersonel where username == i.k_adi && sifre == i.sifre select i).FirstOrDefault();
                if (sorgu != null)
                {
                    MessageBox.Show("Giriş Başarılı");

                    giris form2 = new giris();
                    form2.Show();  // form2 göster diyoruz
                    this.Hide();   // bu yani form1 gizle diyoruz
                }
                else
                {
                    MessageBox.Show("Sistemde Kayıtlı değilsiniz!!!");
                }
            }




        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection baglanti= new SqlConnection("");
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
