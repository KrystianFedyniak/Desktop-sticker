using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Desktop_Sticker
{

    public partial class Form1 : Form
    {



        public Form1()
        {
            InitializeComponent();
        }




        private void Button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //
        // Перетаскивание формы за Panel
        //
        private void Panel2_MouseDown(object sender, MouseEventArgs e)
        {
            panel2.Capture = false;
            //  base.Capture = false;
            Message m = Message.Create(base.Handle, 0xA1, new IntPtr(2), IntPtr.Zero);
            base.WndProc(ref m);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ToolTip Newstiker = new ToolTip();
            Newstiker.SetToolTip(button1, "Добавить стикер");

            ToolTip Bold = new ToolTip();
            Bold.SetToolTip(checkBox1, "Жирный шрифт");

            ToolTip Italic = new ToolTip();
            Italic.SetToolTip(checkBox2, "Курсив");

            ToolTip Underline = new ToolTip();
            Underline.SetToolTip(checkBox3, "Подчеркнутый текст");

            ToolTip t = new ToolTip();
            t.SetToolTip(checkBox4, "Зачеркнутый текст");

            ToolTip Top = new ToolTip();
            Top.SetToolTip(button6, "Закрепить поверх всех окон");

            checkBox1.FlatAppearance.MouseOverBackColor = panel2.BackColor;
            checkBox2.FlatAppearance.MouseOverBackColor = panel2.BackColor;
            checkBox3.FlatAppearance.MouseOverBackColor = panel2.BackColor;
            checkBox4.FlatAppearance.MouseOverBackColor = panel2.BackColor;
            button6.FlatAppearance.MouseOverBackColor = panel2.BackColor;


        }

        //
        // Перетаскивание формы за Label
        //

        private void Label1_MouseDown(object sender, MouseEventArgs e)
        {
            label1.Capture = false;
            //  base.Capture = false;
            Message m = Message.Create(base.Handle, 0xA1, new IntPtr(2), IntPtr.Zero);
            base.WndProc(ref m);
        }

        //
        // Новый лист
        //
        void NewForm()
        {
            Form1 form = new Form1();
            form.ShowDialog();
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            new System.Threading.Thread(NewForm).Start();
        }


        //
        // Скрытие/Раскрытие Panel кнопка Меню
        //

        private void Button8_Click(object sender, EventArgs e)
        {
            if (panel2.Size.Height == 30)
            {
                panel2.Size = new Size(306, 313);


            }
            else
            {
                panel2.Size = new Size(306, 30);
                button8.BackColor = Color.Transparent;
            }
        }



        private void Button9_Click(object sender, EventArgs e)
        {

            //////////Black theme///////

            panel2.BackColor = Color.FromArgb(65, 63, 63);
            button6.ForeColor = Color.White;
            button1.ForeColor = Color.White;
            button13.ForeColor = Color.White;
            button3.ForeColor = Color.White;
            button4.ForeColor = Color.White;

            button14.ForeColor = Color.White;

            button8.ForeColor = Color.White;
            label1.ForeColor = Color.White;

            checkBox1.ForeColor = Color.White;

            checkBox2.ForeColor = Color.White;

            checkBox3.ForeColor = Color.White;

            checkBox4.ForeColor = Color.White;

            button2.BackColor = Color.FromArgb(64, 64, 64); button2.ForeColor = Color.White;


            richTextBox1.BackColor = Color.DimGray;
            richTextBox1.ForeColor = Color.Black;

            button7.ForeColor = Color.White;


            panel9.BackColor = Color.DimGray;
            panel4.BackColor = Color.DimGray;
            panel7.BackColor = Color.DimGray;
            panel5.BackColor = Color.DimGray;

            this.BackColor = Color.DimGray;

            panel2.Size = new Size(304, 30);
        }

        private void Button10_Click(object sender, EventArgs e)
        {
            //////////Light theme///////

            panel2.BackColor = Color.FromArgb(224, 224, 224);

            button6.ForeColor = Color.Black;
            button1.ForeColor = Color.Black;
            button13.ForeColor = Color.Black;
            button3.ForeColor = Color.Black;
            button14.ForeColor = Color.Black;
            button4.ForeColor = Color.Black;

            button8.ForeColor = Color.Black;
            label1.ForeColor = Color.Black;

            checkBox1.ForeColor = Color.Black;

            checkBox2.ForeColor = Color.Black;

            checkBox3.ForeColor = Color.Black;

            checkBox4.ForeColor = Color.Black;

            button2.BackColor = Color.FromArgb(224, 224, 224); button2.ForeColor = Color.Black;


            panel9.BackColor = Color.Black;
            panel4.BackColor = Color.Black;
            panel7.BackColor = Color.Black;
            panel5.BackColor = Color.Black;

            richTextBox1.BackColor = Color.White;
            richTextBox1.ForeColor = Color.Black;

            button7.ForeColor = Color.Black;

            this.BackColor = Color.White;

            panel2.Size = new Size(308, 30);
        }





        private void Button14_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("Вы действительно хотите закрыть Desktop Stickers", "Выход", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

            if (d == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        //
        // Открытие формы О программе
        //

        private void Button13_Click(object sender, EventArgs e)
        {
            AboutBox1 about = new AboutBox1();
            about.ShowDialog();
            panel2.Size = new Size(304, 30);
        }

        private void RichTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont != null)
            {
                checkBox1.Checked = richTextBox1.SelectionFont.Bold;
                checkBox2.Checked = richTextBox1.SelectionFont.Italic;
                checkBox3.Checked = richTextBox1.SelectionFont.Underline;
                checkBox4.Checked = richTextBox1.SelectionFont.Strikeout;
            }
        }

        private void CheckBox1_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont == null)
            {
                checkBox1.BackColor = Color.Transparent;
                return;

            }

            FontStyle style = richTextBox1.SelectionFont.Style;

            if (richTextBox1.SelectionFont.Bold)
            {
                style &= ~FontStyle.Bold;
                checkBox1.BackColor = Color.Transparent;

            }
            else
            {
                style |= FontStyle.Bold;
                checkBox1.BackColor = Color.DarkGray;

            }
            richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, style);
        }

        private void CheckBox2_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont == null)
            {
                checkBox2.BackColor = Color.Transparent;
                return;
            }
            FontStyle style = richTextBox1.SelectionFont.Style;

            if (richTextBox1.SelectionFont.Italic)
            {
                style &= ~FontStyle.Italic;
                checkBox2.BackColor = Color.Transparent;
            }
            else
            {
                style |= FontStyle.Italic;
                checkBox2.BackColor = Color.DarkGray;
            }
            richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, style);
        }

        private void CheckBox3_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont == null)
            {
                checkBox3.BackColor = Color.Transparent;
                return;
            }

            FontStyle style = richTextBox1.SelectionFont.Style;

            if (richTextBox1.SelectionFont.Underline)
            {
                style &= ~FontStyle.Underline;
                checkBox3.BackColor = Color.Transparent;
            }
            else
            {
                style |= FontStyle.Underline;
                checkBox3.BackColor = Color.DarkGray;
            }
            richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, style);
        }

        private void CheckBox4_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont == null)
            {
                checkBox4.BackColor = Color.Transparent;
                return;
            }

            FontStyle style = richTextBox1.SelectionFont.Style;

            if (richTextBox1.SelectionFont.Strikeout)
            {
                style &= ~FontStyle.Strikeout;
                checkBox4.BackColor = Color.Transparent;
            }
            else
            {
                style |= FontStyle.Strikeout;
                checkBox4.BackColor = Color.DarkGray;
            }
            richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, style);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Process.Start(@"C:\Windows\System32\calc.exe");
        }

        //
        // кнопка закрепления Поверх всех окон 
        //
        private void button6_Click(object sender, EventArgs e)
        {
            if (TopMost == false)
            {
                TopMost = true;
                button6.BackColor = Color.DarkRed;
            }
            else
            {
                TopMost = false;
                button6.BackColor = Color.Transparent;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Текстовый документ (*.txt)|*.txt|Все файлы (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                StreamWriter streamWriter = new StreamWriter(saveFileDialog.FileName);
                streamWriter.WriteLine(richTextBox1.Text);
                streamWriter.Close();
                panel2.Size = new Size(306, 30);


            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Текстовый документ (*.txt)|*.txt|Все файлы (*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filename = openFileDialog.FileName;
                string text = File.ReadAllText(filename);
                richTextBox1.Text = text;
                panel2.Size = new Size(306, 30);

            }
        }
    }
}
