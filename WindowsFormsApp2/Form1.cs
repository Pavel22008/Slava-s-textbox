using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Title = "Data Save";
            saveFileDialog1.FileName = "MyText.txt";
            saveFileDialog1.Filter = "Text files(*.txt) | *.txt|All files(*.*)| *.*";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    FileStream file = new FileStream(saveFileDialog1.FileName, FileMode.Create);
                    StreamWriter writer = new StreamWriter(file);
                    try
                    {
                        writer.WriteLine(textBox1.Text);
                        MessageBox.Show("Сохранено");
                    }
                    catch (IOException ex)
                    {
                        MessageBox.Show("Ошибка при записи");
                    }
                    writer.Close();
                    file.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при создании файла:{ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Ошибка");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Data Open";
            openFileDialog1.FileName = "MyText.txt";
            openFileDialog1.Filter = "Text files(*.txt) | *.txt|All files(*.*)| *.*";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    FileStream file = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.Read);
                    StreamReader reader = new StreamReader(file);
                    try
                    {
                        while (!reader.EndOfStream)
                        {
                            textBox1.Text += reader.ReadLine() + "\r\n";
                        }
                    }
                    catch (IOException ex)
                    {
                        MessageBox.Show("Ошибка при открытии");
                    }
                    reader.Close();
                    file.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при открытии файла:{ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Ошибка");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Font = fontDialog1.Font;
            }
            else
            {
                MessageBox.Show("Вы вышли из смены шрифта");
            }
        }
    }
}
