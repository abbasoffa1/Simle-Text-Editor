using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Test
{
    public partial class Form1 : Form
    {
        private string SelectedFile;
        public Form1()
        {
            InitializeComponent();
            Test1();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void Test1()
        {

            string path = @"C:\Users\pc\Desktop\test";
            //Directory.CreateDirectory(@"C:\Users\pc\Desktop\test");
            //Directory.Delete(path, true);
            //File.Create(path + @"\text.txt");
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            openFile.ShowDialog();
            this.SelectedFile = openFile.FileName;
            ReadFile();
        }
        private void ReadFile()
        {
            string type = this.SelectedFile.Split('.')[1];
            if (type == "txt")
            {
                lblFileName.Text = openFile.FileName;
                using (StreamReader sr=new StreamReader(this.SelectedFile))
                {
                    string line = sr.ReadToEnd();
                    rtbTest.Text = line;
                }
            }
            else
            {
                MessageBox.Show("Ancag txt file sece bilersiniz.");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.SelectedFile != null)
            {
                using (StreamWriter sw = new StreamWriter(this.SelectedFile))
                {
                    sw.WriteLine(rtbTest.Text);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (this.SelectedFile != null)
            {
                this.SelectedFile = null;
                lblFileName.Text = "";
                rtbTest.Text = "";
            }
        }
    }
}
