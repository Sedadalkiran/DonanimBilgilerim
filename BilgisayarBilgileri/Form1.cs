using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;

namespace BilgisayarBilgileri
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Veri;
            ObjectQuery Sorgu = new ObjectQuery("select * from Win32_OperatingSystem");
            ManagementObjectSearcher Bul = new ManagementObjectSearcher(Sorgu);
            ManagementObjectCollection Elemanlar = Bul.Get();
            foreach (ManagementObject Eleman in Elemanlar)
            {
                foreach (PropertyData Ozellikler in Eleman.Properties)
                {
                    Veri = Ozellikler.Name;
                    listBox1.Items.Add(Veri);

                    try
                        {
                        string Deger = Eleman.Properties[Veri].Value.ToString();
                        listBox2.Items.Add(Deger);
                    }

                    catch  {

                        listBox2.Items.Add("--");
                    }


                }
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToString();
          
        }
    }
}
