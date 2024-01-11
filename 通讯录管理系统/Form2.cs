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


namespace 通讯录管理系统
{
    

    public partial class mainForm : Form
    {

        const string filepath = ".\\contacks.txt";
        const int max_count = 2048;
        private bool deleting = false;
        class Student
        {
            public string _name=""; // 姓名
            public string _sex =""; // 性别
            public string _age =""; // 年龄
            public string _people = ""; // 民族 
            public string _cellphone = ""; // 手机号 
            public string _description = ""; // 个人描述
        }
        Student[] students = new Student[max_count];
        Student stu_new = new Student();
        public mainForm()
        {
            InitializeComponent();
            
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        { // 窗体关闭事件
            DialogResult result = MessageBox.Show("确定要关闭程序?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if(result==DialogResult.OK)
            {
                return;
                //System.Environment.Exit(0);
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            comboBox_people.Text = "汉族";
            
            this.Hide();
            loginForm lf = new loginForm();
            lf.ShowDialog();
        }

        

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //stu_new._people = comboBox_people.Text;
        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            textBox_name.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            textBox_age.Text = "";
            comboBox_people.SelectedIndex = 0;
            textBox_phone_no.Text = "";
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            textBox_describe.Text = "";
            label_detail.Text = "";
            
        }
        private void button_save_Click(object sender, EventArgs e)
        {
            string result;
            stu_new._name = textBox_name.Text;
            stu_new._age = textBox_age.Text;
            stu_new._sex = "";
            if (radioButton1.Checked)
            {
                stu_new._sex = radioButton1.Text;
            }
            else if (radioButton2.Checked)
            {
                stu_new._sex = radioButton2.Text;
            }
            
            stu_new._people = comboBox_people.Text;
            
            stu_new._cellphone = textBox_phone_no.Text;
            stu_new._description = textBox_describe.Text;

            

            //检查各项是否有空
            if (stu_new._name=="")
            {
                MessageBox.Show("姓名不得为空!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (stu_new._sex == "")
            {
                MessageBox.Show("性别不得为空!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (stu_new._age == "")
            {
                MessageBox.Show("年龄不得为空!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (stu_new._cellphone == "")
            {
                MessageBox.Show("电话号码不得为空!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //保存到列表和文件中
            //保存到类中
            for(int i=0;i< max_count; i++)
            {
                if(students[i]==null)
                {
                    students[i] = new Student();
                    students[i] = stu_new;
                    

                    listBox1.Items.Add(stu_new._name);
                    label_count.Text = "人数: ";
                    label_count.Text += listBox1.Items.Count.ToString();
                    
                    break;
                }
            }
            //debug
            result = stu_new._name;
            result += " ";
            result += stu_new._sex;
            result += " ";
            result += stu_new._age;
            result += " ";
            result += stu_new._people;
            result += " ";
            result += stu_new._cellphone;
            result += " ";
            result += stu_new._description;
            label_detail.Text = result;
            //保存至文件

            //FileInfo myFile = new FileInfo(@".\contacks.txt", true, Encoding.ASCII); //初始化FileInfo
            //StreamWriter sw = myFile.CreateText();
            StreamWriter sw = new StreamWriter(filepath, true, Encoding.Unicode);//append
            sw.WriteLine(result);
            sw.Close();
        }
        private void textBox_phone_no_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0' && e.KeyChar <= '9') || e.KeyChar == 8)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void textBox_age_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0' && e.KeyChar <= '9') || e.KeyChar == 8)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(deleting)
            {
                return;
            }
            button_clear_Click(null, null);
            if (students[listBox1.SelectedIndex] == null)
            {
                MessageBox.Show("students数据异常!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                
                return;
            }
            textBox_name.Text = students[listBox1.SelectedIndex]._name;
            textBox_age.Text = students[listBox1.SelectedIndex]._age;
            textBox_phone_no.Text = students[listBox1.SelectedIndex]._cellphone;
            if(students[listBox1.SelectedIndex]._sex == "男")
            {
                radioButton1.Checked = true;
            }
            else if (students[listBox1.SelectedIndex]._sex == "女")
            {
                radioButton2.Checked = true;
            }
            comboBox_people.Text = students[listBox1.SelectedIndex]._people;
            textBox_describe.Text = students[listBox1.SelectedIndex]._description;
            label_detail.Text += students[listBox1.SelectedIndex]._name;
            label_detail.Text += " ";
            label_detail.Text += students[listBox1.SelectedIndex]._sex;
            label_detail.Text += " ";
            label_detail.Text += students[listBox1.SelectedIndex]._age;
            label_detail.Text += " ";
            label_detail.Text += students[listBox1.SelectedIndex]._people;
            label_detail.Text += " ";
            label_detail.Text += students[listBox1.SelectedIndex]._cellphone;
            label_detail.Text += " ";
            label_detail.Text += students[listBox1.SelectedIndex]._description;
            
            //comboBox_people.SelectedText= students[listBox1.SelectedIndex]._people;
        }
        private void update_describe()
        {
            textBox_describe.Text = "";
            if(checkBox1.Checked)
            {
                textBox_describe.Text += checkBox1.Text;
                textBox_describe.Text += " ";
            }
            if (checkBox2.Checked)
            {
                textBox_describe.Text += checkBox2.Text;
                textBox_describe.Text += " ";
            }
            if (checkBox3.Checked)
            {
                textBox_describe.Text += checkBox3.Text;
                textBox_describe.Text += " ";
            }
            if (checkBox4.Checked)
            {
                textBox_describe.Text += checkBox4.Text;
                textBox_describe.Text += " ";
            }
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            update_describe();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            update_describe();
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            update_describe();
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            update_describe();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label_detail.Text = stu_new._people;
        }

        private void button_load_Click(object sender, EventArgs e)
        {
            //清空students数据和listbox
            for (int i = 0; i < max_count; i++)
            {
                students[i] = null;
            }
            listBox1.Items.Clear();
            label_count.Text = "人数: ";
            label_count.Text += listBox1.Items.Count.ToString();
            //从文件载入
            if(File.Exists(filepath)==false)
            {
                FileStream fs= File.Create(filepath);

                fs.Close();
                
            }
            StreamReader sr = File.OpenText(filepath);
            string linetemp;
            int count = 0;
            string[] parts=new string[16];
            while ((linetemp = sr.ReadLine()) != null)
            {
                for (int i = 0; i < parts.Length; i++)
                {
                    parts[i] = "";
                }
                parts = linetemp.Split(' ');
                students[count] = new Student();
                
                
                
                
                
                
                for (int i = 0; i < parts.Length; i++)
                {
                    if(i==0)
                    {
                        students[count]._name = parts[0];
                    }
                    else if(i==1)
                    {
                        students[count]._sex = parts[1];
                    }
                    else if(i==2)
                    {
                        students[count]._age = parts[2];
                    }
                    else if(i==3)
                    {
                        students[count]._people = parts[3];
                    }
                    else if(i==4)
                    {
                        students[count]._cellphone = parts[4];
                    }
                    else if(i==5)
                    {
                        students[count]._description = parts[5];
                    }
                    else
                    {
                        students[count]._description += " ";
                        students[count]._description += parts[i];
                    }
                    //if(parts[i]!="")
                    //{
                        
                    //}
                    
                }
                //将students name数据载入listbox
                listBox1.Items.Add(students[count]._name);
                label_count.Text = "人数: ";
                label_count.Text += listBox1.Items.Count.ToString();
                count++;
                if(count>=max_count)
                {
                    break;
                }
            }
            sr.Close();
            
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            if(listBox1.Items.Count==0)
            {
                MessageBox.Show("通讯录数据为空!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //将所选项从list和students中移除
            for(int i= listBox1.SelectedIndex+1;i< listBox1.Items.Count;i++)
            {
                students[i - 1] = students[i];
            }
            students[listBox1.Items.Count - 1] = null;
            deleting = true;
            listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            label_count.Text = "人数: ";
            label_count.Text += listBox1.Items.Count.ToString();
            //同步至文件
            string result;

            StreamWriter sw = new StreamWriter(filepath, false, Encoding.Unicode);//append
            for(int i=0;i< max_count; i++)
            {
                if(students[i]==null)
                {
                    break;
                }
                result = students[i]._name;
                result += " ";
                result += students[i]._sex;
                result += " ";
                result += students[i]._age;
                result += " ";
                result += students[i]._people;
                result += " ";
                result += students[i]._cellphone;
                result += " ";
                result += students[i]._description;
                sw.WriteLine(result);
            }
            
            sw.Close();
            deleting = false;
        }
    }
}
