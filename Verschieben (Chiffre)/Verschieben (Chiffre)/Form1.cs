using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace Verschieben__Chiffre_
{
    public partial class Form1 : Form
    {
        string abc = "abcdefghijklmnopqrstuvwxyz\"äöüABCDEFGHIJKLMNOPQRSTUVWXYZÄÖÜ1234567890.,-?!";
        ArrayList list = new ArrayList();
        string finalstat = "";
        int counterVerschlüssen = 73;
        int counterEnschlüssen = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < abc.Length; i++)
            {
                list.Add(abc[i]);


            }
          
            if (numericUpDown1.Value > 0)
            {
                
              for (int n =0; n<textBox1.Text.Length; n++)
                {
                    for (int j = 0; j < list.Count; j++)
                    {
                        if (textBox1.Text[n].Equals (list[j]))
                        {
                            int k = j - Convert.ToInt32( numericUpDown1.Value);
                            if (k < 0)
                            {
                                k = counterVerschlüssen - (k*-1)+1;
                            }
                            finalstat += Convert.ToString(list[k]);
                            counterVerschlüssen = 73;
                            break;
                        }
                    }
                }
                textBox3.Text =Convert.ToString( numericUpDown1.Value);
                textBox2.Text = finalstat;
                finalstat = "";

            }
            if (Convert.ToInt32(numericUpDown1.Value) < 0)
            {

                for (int n = 0; n < textBox1.Text.Length; n++)
                {
                    for (int j = 0; j < list.Count; j++)
                    {
                        
                        if (textBox1.Text[n].Equals(list[j]))
                        {
                        
                            int k = j + Convert.ToInt32(numericUpDown1.Value);
                            finalstat += Convert.ToString(list[k]);
                            break;
                        }
                    }
                }
                textBox2.Text = finalstat;
                finalstat = "";
            }
            if (numericUpDown1.Value == 0)
            {
                MessageBox.Show("bitte whählen sie Verschiebung zahl");
            }
            
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            //numric value eingenschaften
            numericUpDown1.Minimum = -6;
            numericUpDown1.Maximum = 6;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {

            string hash;
            using (MD5 md5Hash = MD5.Create())
            {
                 hash = GetMd5Hash(md5Hash, textBox1.Text);


            }
            textBox2.Text = hash;
        }
        static string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }




        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < abc.Length; i++)
            {
                list.Add(abc[i]);

            }
            if (numericUpDown1.Value > 0)
            {

                for (int n = 0; n < textBox2.Text.Length; n++)
                {
                    for (int j = 0; j < list.Count; j++)
                    {
                        if (textBox2.Text[n].Equals(list[j]))
                        {
                            
                            int k = j + Convert.ToInt32(numericUpDown1.Value);
                            
                            if (k > 73)
                            {
                                k = counterEnschlüssen + k;
                            }
                            finalstat += Convert.ToString(list[k]);
                            counterEnschlüssen = 0;
                            break;
                        }
                    }
                }
                textBox3.Text = finalstat;
                finalstat = "";
                counterEnschlüssen = 0;

            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
