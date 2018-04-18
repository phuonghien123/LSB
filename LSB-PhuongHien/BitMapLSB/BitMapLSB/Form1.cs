using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BitMapLSB
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.ShowDialog();
            op.Filter = "txt file|*.txt";
            textBox1.Text = op.FileName;
            pictureBox1.Image = Image.FromFile(op.FileName);
        }

        private void button2_Click(object sender, EventArgs e)
        {
          

                try
            {   
                
                Bitmap pm = new Bitmap(textBox1.Text);
                int pmx = pm.Width;
                int pmy = pm.Height;
                int pmSetx = 0, pmSety = 0;
                string num = Convert.ToString((textBox2.Text.Length * 8),2);
                if(num.Length < 16)
                {
                    for(int i = 16 - num.Length; i > 0; i--)
                    {
                        num = '0' + num;
                    }
                }
                for (int j = 0; j < num.Length; j++)
                {
                    Color cl = pm.GetPixel(pmSetx, pmSety);
                    string cl2 = Convert.ToString(cl.R, 2);
                    cl2 = cl2.Remove(cl2.Length - 2, 1) + num[j];
                    double x = 0;
                    for (int z = cl2.Length - 1; z >= 0; z--)
                    {
                        if (cl2[z] == '1')
                            x += Math.Pow(2.0, cl2.Length - 1 - z);
                    }
                    Color newcl = Color.FromArgb(Convert.ToByte(x), cl.G, cl.B);
                    pm.SetPixel(pmSetx, pmSety, newcl);
                    pmSety++;
                    if (pmSety == pmy)
                    {
                        pmSetx++;
                        pmSety = 0;
                    }
                }
                String s2 = textBox2.Text;
                byte[] s2Byte = Encoding.Unicode.GetBytes(s2);
                String s = "";
                for (int i = 0; i < s2Byte.Count(); i+=2)
                {
                    s = Convert.ToString(s2Byte[i], 2);
                    if (s.Length < 8)
                    {
                        for (int k = 8 - s.Length; k > 0; k--)
                        {
                            s = '0' + s;
                        }
                    }
                    for (int j = 0; j < s.Length; j++)
                    {
                        Color cl = pm.GetPixel(pmSetx, pmSety);
                        string cl2 = Convert.ToString(cl.R, 2);
                        cl2 = cl2.Remove(cl2.Length - 2, 1) + s[j];
                        double x = 0;
                        for(int z = cl2.Length -1; z >= 0; z--)
                        {
                            if(cl2[z] == '1')
                                x += Math.Pow(2.0,cl2.Length - 1 - z);
                        }
                        Color newcl = Color.FromArgb(Convert.ToByte(x), cl.G, cl.B);
                        pm.SetPixel(pmSetx, pmSety, newcl);
                        pmSety++;
                        if (pmSety == pmy)
                        {
                            pmSetx++;
                            pmSety = 0;
                        }
                    }
                }
                SaveFileDialog saveFile = new SaveFileDialog();
                 saveFile.Filter = "Image Files (*.png, *.jpg) | *.png; *.jpg";
                 saveFile.InitialDirectory = @"C:\User\metech\Desktop";
                if (saveFile.ShowDialog() == DialogResult.OK)
            {
                 textBox1.Text = saveFile.FileName.ToString();
                pictureBox1.ImageLocation = textBox1.Text;
                pm.Save(textBox1.Text);
                
            };
               
            }
            catch (Exception){
                MessageBox.Show("Mời bạn chọn ảnh!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                
                Bitmap pm = new Bitmap(textBox3.Text);
                int pmx = pm.Width;
                int pmy = pm.Height;
                string num = "", kq = "";
                for (int i = 0; i < 16; i++)
                {
                    Color cl = pm.GetPixel(0, i);
                    string clstr = Convert.ToString(cl.R, 2);
                    num += clstr.Substring(clstr.Length - 1, 1);
                }

                double x = 0;
                for (int z = num.Length - 1; z >= 0; z--)
                {
                    if (num[z] == '1')
                        x += Math.Pow(2.0, num.Length - 1 - z);
                }
                int count = 0;
                bool stop = false;
                for (int j = 0; j < pmx - 1; j++)
                {
                    if (stop == true) break;
                    for (int i = 0; i < pmy - 1; i++)
                    {
                        Color cl = pm.GetPixel(j, i);
                        string clstr = Convert.ToString(cl.R, 2);
                        kq += clstr.Substring(clstr.Length - 1, 1);
                        count++;
                        if (count >= Convert.ToInt32(x) + 16)
                        {
                            stop = true;
                            break;
                        }
                    }
                }
                string output = "";
                for (int i = 16; i < kq.Length - 1; i = i + 8)
                {
                    string temp = kq.Substring(i, 8);
                    double xtemp = 0;
                    for (int z = temp.Length - 1; z >= 0; z--)
                    {
                        if (temp[z] == '1')
                            xtemp += Math.Pow(2.0, temp.Length - 1 - z);
                    }
                    output += (char)xtemp;
                }
                lab.Text = output;
            }
            catch (Exception)
            {
                MessageBox.Show("Ảnh không có thông điệp");
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void tachTin_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
                op.ShowDialog();
                op.Filter = "txt file|*.txt";
                textBox3.Text = op.FileName;
                pictureBox2.Image = Image.FromFile(op.FileName);

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }
    }
}
