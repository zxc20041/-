using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace 通讯录管理系统
{
    public partial class loginForm : Form
    {
        public loginForm()
        {
            InitializeComponent();
        }
        bool hideform = false;
        

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
        
        private string GetMd5(string input)
        {
            // Create a new instance of the MD5CryptoServiceProvider object.
            MD5 md5Hasher = MD5.Create();

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));

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

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string pwd = GetMd5(textBox2.Text);
            
            if (username == "jack" && pwd == "534b44a19bf18d20b71ecc4eb77c572f")
            {
                
                
                foreach(Form main in Application.OpenForms)
                {
                    main.Show();
                }
                hideform = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("用户名或密码错误!","错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       

        private void button2_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        

        private void Formlogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(hideform==false)
            {
                //MessageBox.Show("Formlogin_FormClosing!", "quit", MessageBoxButtons.OK, MessageBoxIcon.Error);
                System.Environment.Exit(0);
            }
            
        }
    }
}
