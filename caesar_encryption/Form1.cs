using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Лаба_по_шифрованию_цезаря_с_ключом
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Caesar caesar = new Caesar();
        }
        string fileText;
        string filename;

        private static string alpha = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя ";
        private static char[] newAlpha = new char[34];


        public static string encrypt(string Message)
        {
            string res = "";
            foreach (char ch in Message)
            {
                for (int i = 0; i < alpha.Length; i++)
                {
                    if (ch == alpha[i])
                    {
                        res += newAlpha[i];
                        break;
                    }
                    // if (ch == 32) res += ' ';
                }
            }
            return res;
        }

        public static string decrypt(string Message)
        {
            string res = "";
            foreach (char ch in Message)
            {
                for (int i = 0; i < newAlpha.Length; i++)
                {
                    if (ch == newAlpha[i])
                    {
                        res += alpha[i];
                        break;
                    }
                }
            }
            return res;
        }

        public static void createNewAlpha(string keyWord, int key) // создаёт новый алфавит с помощью ключа
        {  
            
            bool findSame = false;
            key--;
            int beg = 0, current = key;
            // добавить ключевое слово в новый алфавит
            for (int i = key; i < keyWord.Length + key; i++)
            {
                for (int j = key; j < keyWord.Length + key; j++)
                {
                    if (keyWord[i - key] == newAlpha[j])
                    {
                        findSame = true;
                        break;
                    }
                }
                if (!findSame)// если повторений нету, то буква добавляется в новый алфавит
                {
                    newAlpha[current] = keyWord[i - key];
                    current++;
                }
                findSame = false;
            }

            // добавить буквы после ключевого слова
            for (int i = 0; i < alpha.Length; i++)
            {
                for (int j = 0; j < newAlpha.Length; j++)
                {
                    if (alpha[i] == newAlpha[j])
                    {
                        findSame = true;
                        break;
                    }
                }
                if (!findSame)
                {
                    newAlpha[current] = alpha[i];
                    current++;
                }
                findSame = false;
                if (current == newAlpha.Length)
                {
                    beg = i;
                    break;
                }
            }

            // добавить буквы после ключевого слова
            current = 0;
            for (int i = beg; i < alpha.Length; i++)
            {
                for (int j = 0; j < newAlpha.Length; j++)
                {
                    if (alpha[i] == newAlpha[j])
                    {
                        findSame = true;
                        break;
                    }
                }
                if (!findSame)
                {
                    newAlpha[current] = alpha[i];
                    current++;
                }
                findSame = false;
            }
        }

        public static string getNewAlpha()
        {
            string strNewAlpha = new string(newAlpha);
            return strNewAlpha;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            if (openFile.ShowDialog() == DialogResult.Cancel) return;
            else
            {
                filename = openFile.FileName;
                // читаем файл в строку
                //fileText = System.IO.File.ReadAllText(filename);
                fileText = System.IO.File.ReadAllText(filename, Encoding.GetEncoding(1251));

                txtForSourceText.Text = fileText;


                MessageBox.Show("Файл открыт", fileText);
            }
        }

       
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        

        private void textBox3_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void btnCode_Click(object sender, EventArgs e)
        {
            textBox3.Text = " ";
            createNewAlpha(textBox2.Text, Convert.ToInt32(txtForKey.Text));
            textBox1.Text = getNewAlpha();
            zakodtext.Text = encrypt(fileText);
             MessageBox.Show(txtForSourceText.Text);
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";

            if (saveFile.ShowDialog() == DialogResult.Cancel) return;
            else
            {
                string filename = saveFile.FileName;
                System.IO.File.WriteAllText(filename, zakodtext.Text, Encoding.GetEncoding(1251)); // потом доделать с сохранением шифрованного файла
                MessageBox.Show("Зашифрованный файл сохранен");
            }

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtForKey_TextChanged(object sender, EventArgs e)
        {

        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtForSourceText_TextChanged(object sender, EventArgs e)
        {

        }

        private void zakodtext_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            zakodtext.Text = " ";
            createNewAlpha(textBox2.Text, Convert.ToInt32(txtForKey.Text));
            textBox1.Text = getNewAlpha();
            textBox3.Text= decrypt(fileText);
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";

            if (saveFile.ShowDialog() == DialogResult.Cancel) return;
            else
            {
                string filename = saveFile.FileName;
                System.IO.File.WriteAllText(filename, textBox3.Text, Encoding.GetEncoding(1251)); // потом доделать с сохранением шифрованного файла
                MessageBox.Show("Зашифрованный файл сохранен");
            }
        }

        private void textBox3_TextChanged_2(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }

    public class Caesar
    {
        private static string alpha = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
        private static char[] newAlpha = new char[32];

        public static string encrypt(string Message)
        {
            string res = "";
            foreach (char ch in Message)
            {
                for (int i = 0; i < alpha.Length; i++)
                {
                    if (ch == alpha[i])
                    {
                        res += newAlpha[i];
                        break;
                    }
                    // if (ch == 32) res += ' ';
                }
            }
            return res;
        }

        public static string decrypt(string Message)
        {
            string res = "";
            foreach (char ch in Message)
            {
                for (int i = 0; i < newAlpha.Length; i++)
                {
                    if (ch == newAlpha[i])
                    {
                        res += alpha[i];
                        break;
                    }
                }
            }
            return res;
        }

        public static void createNewAlpha(string keyWord, int key) // создаёт новый алфавит с помощью ключа
        {
            bool findSame = false;
            key--;
            int beg = 0, current = key;
            // добавить ключевое слово в новый алфавит
            for (int i = key; i < keyWord.Length + key; i++)
            {
                for (int j = key; j < keyWord.Length + key; j++)
                {
                    if (keyWord[i - key] == newAlpha[j])
                    {
                        findSame = true;
                        break;
                    }
                }
                if (!findSame)// если повторений нету, то буква добавляется в новый алфавит
                {
                    newAlpha[current] = keyWord[i - key];
                    current++;
                }
                findSame = false;
            }

            // добавить буквы после ключевого слова
            for (int i = 0; i < alpha.Length; i++)
            {
                for (int j = 0; j < newAlpha.Length; j++)
                {
                    if (alpha[i] == newAlpha[j])
                    {
                        findSame = true;
                        break;
                    }
                }
                if (!findSame)
                {
                    newAlpha[current] = alpha[i];
                    current++;
                }
                findSame = false;
                if (current == newAlpha.Length)
                {
                    beg = i;
                    break;
                }
            }

            // добавить буквы после ключевого слова
            current = 0;
            for (int i = beg; i < alpha.Length; i++)
            {
                for (int j = 0; j < newAlpha.Length; j++)
                {
                    if (alpha[i] == newAlpha[j])
                    {
                        findSame = true;
                        break;
                    }
                }
                if (!findSame)
                {
                    newAlpha[current] = alpha[i];
                    current++;
                }
                findSame = false;
            }
        }

        public static string getNewAlpha()
        {
            string strNewAlpha = new string(newAlpha);
            return strNewAlpha;
        }
    }
}
