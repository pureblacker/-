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

namespace WordFrequent
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void upfile_Click(object sender, EventArgs e)
        {
            /*打开文件夹*/
            FolderBrowserDialog folderDialog = new FolderBrowserDialog();
            if (folderDialog.ShowDialog() == DialogResult.OK)
            { 
                textBox1.Text = folderDialog.SelectedPath;
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            /*设置保存路径*/
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = false;//是否同时选中多个文件
            fileDialog.Title = "请选择文件路径";
            fileDialog.Filter = "所有文件(*.*)|*.*";//获取文件路径，所有文件类型
            //fileDialog.Filter = "文本文件 (*.txt)|*.txt";//过滤你想设置的文本文件类型（这是txt型）
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string file = fileDialog.FileName;
                //MessageBox.Show("已选择文件:" + file, "选择文件提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox2.Text = file;
            }
        }

       


        private void button3_Click(object sender, EventArgs e)
        {
            /*统计一元字频*/
            string path;
            path = textBox1.Text; // 文件夹目录。
            DirectoryInfo dir = new DirectoryInfo(path);
            FileInfo[] files = dir.GetFiles(); // 获取所有文件信息
            Dictionary<char, int> word_dict = new Dictionary<char, int>();//字典用于保存结果及查找词
            foreach (FileInfo items in files)//循环每个文件
            {
                StreamReader file = new StreamReader(items.FullName,true);//读取文件内容，false 不保留原来内容
                string line;
                while ((line = file.ReadLine()) != null)//按行读取，循环每一行
                {
                    line= line.Replace(" ", "");//去除空格
                    foreach (char i in line) 
                    {
                        if (word_dict.ContainsKey(i))//word_dict.Keys.Contains()
                            word_dict[i] += 1;//在字典出现过的词加一
                        else
                            word_dict[i] = 1;//未出现过的让其键等于一
                    }
                }
                file.Close();
            }
            //排序，value.Value 按值排序，desending降序
            var result = from value in word_dict orderby value.Value descending select value;
            //写入文件
            FileStream fs = new FileStream(textBox2.Text, FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);
            foreach (KeyValuePair<char, int> kvp in result)
            {
                //开始写入
                sw.WriteLine("key=" + kvp.Key + ",value=" + kvp.Value);
            }
            //清空缓冲区
            sw.Flush();
            //关闭流
            sw.Close();
            fs.Close();
            MessageBox.Show("done!");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            /*统计二元字频*/
            string path=textBox1.Text; // 文件夹目录。
            DirectoryInfo dir = new DirectoryInfo(path);
            FileInfo[] files = dir.GetFiles(); // 获取所有文件信息
            Dictionary<string, int> word_dict = new Dictionary<string, int>();//字典用于保存结果
            string line;
            string p="";
            foreach (FileInfo item in files)
            {
                StreamReader file = new StreamReader(item.FullName, true);//false 不保留原来内容
                while ((line = file.ReadLine()) != null)
                {
                    line = line.Replace(" ", "");
                    foreach(char word in line)
                    {
                        p += word;
                        if (p.Length == 2)
                        {
                            if (word_dict.ContainsKey(p))
                                word_dict[p] += 1;
                            else
                                word_dict[p] = 1;
                            p = p.Substring(1);//Substring(Int32)  子字符串在指定的字符位置开始并一直到该字符串的末尾。
                                               //Substring(Int32, Int32)   子字符串从指定的字符位置开始且具有指定的长度。
                                               //参数一：起始位置(从0开始);   参数二：指定长度
                        }
                    }  
                }
                file.Close();
            }
            //排序
            var result = from value in word_dict orderby value.Value descending select value;
            //写入文件
            FileStream fs = new FileStream(textBox2.Text, FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);
            foreach (KeyValuePair<string, int> kvp in result)
            {
                //开始写入
                sw.WriteLine("key=" + kvp.Key + ",value=" + kvp.Value);
            }
            //清空缓冲区
            sw.Flush();
            //关闭流
            sw.Close();
            fs.Close();
            MessageBox.Show("done!");

        }

        private void button5_Click(object sender, EventArgs e)
        {
            string path = textBox1.Text; // 文件夹目录。
            DirectoryInfo dir = new DirectoryInfo(path);
            FileInfo[] files = dir.GetFiles(); // 获取所有文件信息
            Dictionary<string, int> word_dict = new Dictionary<string, int>();//字典用于保存结果
            string line;
            string p = "";
            foreach (FileInfo item in files)
            {
                StreamReader file = new StreamReader(item.FullName, true);//false 不保留原来内容
                while ((line = file.ReadLine()) != null)
                {
                    line = line.Replace(" ", "");
                    foreach (char word in line)
                    {
                        p += word;
                        if (p.Length == 3)
                        {
                            if (word_dict.ContainsKey(p))
                                word_dict[p] += 1;
                            else
                                word_dict[p] = 1;
                            p = p.Substring(1);
                        }
                    }
                }
                file.Close();
            }
            //排序
            var result = from value in word_dict orderby value.Value descending select value;
            //写入文件
            FileStream fs = new FileStream(textBox2.Text, FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);
            foreach (KeyValuePair<string, int> kvp in result)
            {
                //开始写入
                sw.WriteLine("key=" + kvp.Key + ",value=" + kvp.Value);
            }
            //清空缓冲区
            sw.Flush();
            //关闭流
            sw.Close();
            fs.Close();
            MessageBox.Show("done!");
        }
    }
}
