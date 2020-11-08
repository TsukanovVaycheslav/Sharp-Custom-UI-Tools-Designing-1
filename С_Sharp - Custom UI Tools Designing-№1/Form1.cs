using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace С_Sharp___Custom_UI_Tools_Designing__1
{
    public partial class MainForm : System.Windows.Forms.Form
    {
        int count = 0;
        Random rnd;
        char[] spec_shars = new char[] { '№', '%', '?', '*', '(', ')', '_', '~', '@', '#', '$', '%', '^', '&' };

        public MainForm()
        {
            InitializeComponent();
            rnd = new Random();
        }

        private void tsmiExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsmiAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Программу написал: \nЦуканов Вячеслав", "О программе");
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            count++;
            lblCount.Text = count.ToString();
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            count--;
            lblCount.Text = count.ToString();
        }

        private void btnResult_Click(object sender, EventArgs e)
        {
            count = 0;
            lblCount.Text = Convert.ToString(count);
        }

        private void btnRandom_Click(object sender, EventArgs e)
        {
            int n;
            n = rnd.Next(Convert.ToInt32(numericUpDown1.Value), 
                         Convert.ToInt32(numericUpDown2.Value));
            lblRandom.Text = n.ToString();

            if(cbRandom.Checked)
            {
                int i = 0;
                while (tbRandom.Text.IndexOf(n.ToString()) != -1)
                {
                    n = rnd.Next(Convert.ToInt32(numericUpDown1.Value),
                                Convert.ToInt32(numericUpDown2.Value));
                    i++;
                    if (i > 1000) break;
                }
                if (i <= 1000)
                    tbRandom.AppendText(n + "\n");
            }
            else
            {
                tbRandom.AppendText(n + "\n");
            }
        }

        private void btnRandomClear_Click(object sender, EventArgs e)
        {
            tbRandom.Clear();
        }

        private void btnRandomCopy_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText(tbRandom.Text);
            }
            catch
            {
                MessageBox.Show("Поле пустое");
            }
        }

        private void tsmiInsertDate_Click(object sender, EventArgs e)
        {
            rtbNotepad.AppendText(DateTime.Now.ToShortDateString() + "\n");
        }

        private void tsmiInsertTime_Click(object sender, EventArgs e)
        {
            rtbNotepad.AppendText(DateTime.Now.ToShortTimeString() + "\n");
        }

        private void tsmiSave_Click(object sender, EventArgs e)
        {
            try
            {
                rtbNotepad.SaveFile("notepad.rtf");
            }
            catch
            {
                MessageBox.Show("Ошибка при сохранении");
            }
        }

        void loadNotepad()
        {
            try
            {
                rtbNotepad.LoadFile("notepad.rtf");
            }
            catch
            {
                MessageBox.Show("Ошибка при загрузке");
            }
        }
        private void tsmiLoad_Click(object sender, EventArgs e)
        {
            loadNotepad();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            loadNotepad();
            clbPassword.SetItemChecked(1, true);
        }

        private void btnCreatePassword_Click(object sender, EventArgs e)
        {
            
            if (clbPassword.CheckedItems.Count == 0) return;
            string password = "";
            for (int i = 0; i < nudPassLength.Value; i++)
            {
                int n = rnd.Next(0, clbPassword.CheckedItems.Count);
                string s = clbPassword.CheckedItems[n].ToString();
                switch (s)
                {
                    case "Цифры": password += rnd.Next(10).ToString();
                        break;

                    case "Прописные буквы": password += Convert.ToChar(rnd.Next(65, 91));
                        break;

                    case "Строчные буквы": password += Convert.ToChar(rnd.Next(97, 122));
                        break;

                    default: password += spec_shars[rnd.Next(spec_shars.Length)];
                        break;

                }
                tbPassword.Text = password;
                Clipboard.SetText(password);
            }
           
        }
    }
}
