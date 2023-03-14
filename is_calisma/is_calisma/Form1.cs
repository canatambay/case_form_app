using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace is_calisma
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        // İŞLEVSELLİK-1 KODU
        private void BtnCalculate_Click(object sender, EventArgs e)
        {
            double num1, num2, num3, sum;

            if (double.TryParse(txtnum1.Text, out num1) && double.TryParse(txtnum2.Text, out num2) && double.TryParse(txtnum3.Text, out num3)) // girilen değerin sayı olup olmadığı kontrol ediliyor..
            {
                sum = (num1 + num2) * num3;  // 1. ve 2. texbox'a girilen değer toplanır 3. texbox'a girilen değer ile çarpılır.
                txtResult.Text = sum.ToString();
                txtResult.Show();
            }
            else
            {
                MessageBox.Show("LÜTFEN RAKAM GİRİNİZ..");
            }
        }

        // İŞLEVSELLİK-2 KODU
        private void Btnzigzag_Click(object sender, EventArgs e)
        {
            for (int i = 1; i <= 200; i++) // 200'e kadar sayı getir 200 dahil
            {
                if (i % 3 == 0 && i % 5 == 0) // 3 ve 5 in katı olduğunu kontrol ediyor
                {
                    if (i <= 100)
                    {
                        sayilar.Items.Add("zigzag");
                    }
                    else
                    {
                        sayilar.Items.Add("zagzig");
                    }
                }
                else if (i % 3 == 0)
                {
                    sayilar.Items.Add("zig");
                }
                else if (i % 5 == 0)
                {
                    sayilar.Items.Add("zag");
                }
                else
                {
                    sayilar.Items.Add(i);
                }
            }
        }


        // İŞLEVSELLİK-4 KODU
        private void Datacatch_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog(); // dosyayı seçip açabilmemiz için nesne oluşturuldu. Bu nesnede dosya ismi  ve yolu döndürüldü.
            DialogResult sonuc = openFileDialog1.ShowDialog(); // ShowDialog ile kullanıcıya göstereceğin veri sonuc nesnesine aktarılır. ShowDialog() metodunun döndürdüğü DialogResult nesnesi kullanılır. Bu nesne, seçilen dosya yolunu içerir.
            if (sonuc == DialogResult.OK)
            {
                string dosya = openFileDialog1.FileName;
                Console.WriteLine(dosya);
                try
                {
                    string text = File.ReadAllText(dosya);
                    int boyut = text.Length;


                    text = Regex.Replace(text, @"\s+", " "); // Regex (Regular Expression - Düzenli İfade)  metindeki tüm boşluk karakterlerini bulur. Tek bir boşluğa dönüştürür.
                    text = text.Trim();
                    txtfile.Text = text;
                    txtfile.Show();

                    string[] text_liste = text.Split();

                    List<double> number_list = text_liste.Select(x => double.Parse(x)).ToList(); //double listesi oluşturmak için kullanıldı..

                    number_list.Sort();
                    number_list.Reverse();

                    Console.WriteLine(number_list);

                    for (int i = 0; i < number_list.Count; i++)
                    {
                        lstboxsonuc.Items.Add(number_list[i]);
                    }

                }
                catch (IOException)
                {
                    Console.WriteLine("Dosya okunurken hata olustu!");
                }
            }
        }

        private void BtnCalculate_MouseHover(object sender, EventArgs e)
        {
            btnCalculate.BackColor = Color.Bisque;
        }

        private void BtnCalculate_MouseMove(object sender, MouseEventArgs e)
        {
            btnCalculate.BackColor = Color.Transparent;
        }
        // İŞLEVSELLİK-5 KODU

        public static int GetNthFibonacci(int n)
        {
            if ((n == 0) || (n == 1))
            {
                return n;
            }
            else
                return GetNthFibonacci(n - 1) + GetNthFibonacci(n - 2);
        }

        private void Btnfibo_Click(object sender, EventArgs e)
        {
            int sayi = int.Parse(txtfib.Text);
            string fibsayilar = "0";
            if (sayi <= 0)
            {
                MessageBox.Show("EN AZ 1 GİREBİLİRSİNİZ !");
            }
            else if (sayi == 1)
            {
                fibsayilar = "0";
            }
            else
            {
                fibsayilar = GetNthFibonacci(sayi - 1).ToString();
            }

            txtfib2.Text = fibsayilar;
        }

        // İŞLEVSELLİK-3 KODU
        private void Btntablo_Click(object sender, EventArgs e)
        {

            var n = int.Parse(txtcarpim.Text);
            if (n <= 15)
            {

                try
                {
                    dataGridView1.DataSource = null; // DataGridView'in kaynak verisini sıfırlıyoruz
                    dataGridView1.Rows.Clear(); // DataGridView'in tüm satırlarını siliyoruz
                    dataGridView1.ColumnCount = n + 1;
                    dataGridView1.Rows.Add();

                    for (int i = 0; i <= n; i++)
                    {
                        dataGridView1.Rows[0].Cells[i].Value = i;
                    }

                    for (int i = 1; i <= n; i++)
                    {
                        dataGridView1.Rows.Add();
                        dataGridView1.Rows[i].Cells[0].Value = i;

                        for (int j = 1; j <= n; j++)
                        {
                            dataGridView1.Rows[i].Cells[j].Value = i * j;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("NEGATİF DEĞER YAZILAMAZ");
                }
            }
            else
            {
                MessageBox.Show("EN FAZLA 15'E KADAR SAYI GİREBİLİRSİNİZ !");
            }

            /*  datagriedwievda istemezseniz richtexbox kodu da mevcuttur..
          var n = 9;
          for (int i = 0; i <= n; i++)
          {
              richTextBox1.AppendText(i + "\t");
              for (int j = 1; j <= n; j++)
              {
                  if (i > 0)
                  {
                      this.richTextBox1.AppendText(string.Format("{0," + ((n * n).ToString().Length + 1).ToString() + "}", i * j) + "\t"); // çarpımların richtexbox'a eklenmesi 
                  }
                  else
                  {
                      this.richTextBox1.AppendText(string.Format("{0," + ((n * n).ToString().Length + 1).ToString() + "}", j) + "\t");
                  }
              }
              this.richTextBox1.AppendText(Environment.NewLine);
              richTextBox1.AppendText("\n");  
          } 
          */
        }
    }
}
