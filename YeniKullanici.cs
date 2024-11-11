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
    public partial class YeniKullanici : Form
    {
        public YeniKullanici()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
          Form1 form2 = new Form1();
            form2.Show();  // form2 göster diyoruz
            this.Hide();   // bu yani form1 gizle diyoruz


        }

        private void button1_Click(object sender, EventArgs e)
        {
            ÖgretmenGiris form2 = new ÖgretmenGiris();
            form2.Show();  // form2 göster diyoruz
            this.Hide();   // bu yani form1 gizle diyoruz

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Ögrencigiris form2 = new Ögrencigiris();
            form2.Show();  // form2 göster diyoruz
            this.Hide();   // bu yani form1 gizle diyoruz

        }

        private void button3_Click(object sender, EventArgs e)
        {
            PersonelGiris form2 = new PersonelGiris();
            form2.Show();  // form2 göster diyoruz
            this.Hide();   // bu yani form1 gizle diyoruz

        }
    }
}
