using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        

        private void Button6_Click(object sender, EventArgs e)
        {
            if (TopMost == false)
            {
                TopMost = true;
                button6.BackColor = panel2.BackColor;
            }
            else
            {
                TopMost = false;
                button6.BackColor = Color.FromArgb(64, 64, 64);
            }
        }

        private void Label1_MouseDown(object sender, MouseEventArgs e)
        {
            label1.Capture = false;
            //  base.Capture = false;
            Message m = Message.Create(base.Handle, 0xA1, new IntPtr(2), IntPtr.Zero);
            base.WndProc(ref m);
        }

        
        void NewForm()
        {
            Form1 form = new Form1();
            form.ShowDialog();
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            new System.Threading.Thread(NewForm).Start();
                    }


        private void Button8_Click(object sender, EventArgs e)
        {
            if (panel2.Size.Height == 30)
            {
                panel2.Size= new Size(304, 260);
                
            }
            else
            {
                panel2.Size = new Size(304, 30);
                button8.BackColor = Color.Transparent;
            }
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            panel2.BackColor = Color.DarkGreen;
            panel2.Size = new Size(304, 30);
        }

        private void Button10_Click(object sender, EventArgs e)
        {
            panel2.BackColor = Color.OrangeRed;
            panel2.Size = new Size(304, 30);
        }

        private void Button11_Click(object sender, EventArgs e)
        {
            panel2.BackColor = Color.Crimson;
            panel2.Size = new Size(304, 30);
        }

        private void Button12_Click(object sender, EventArgs e)
        {
            panel2.BackColor = Color.Indigo;
            panel2.Size = new Size(304, 30);
        }

      

        private void Button14_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("Вы действительно хотите закрыть Desktop Stickers", "Выход", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

            if (d == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

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
                checkBox1.BackColor = Color.FromArgb(64,64,64);
                return;
                
            }

            FontStyle style = richTextBox1.SelectionFont.Style;

            if (richTextBox1.SelectionFont.Bold)
            {
                style &= ~FontStyle.Bold;
                checkBox1.BackColor = Color.FromArgb(64,64,64);

            }
            else
            {
                style |= FontStyle.Bold;
                checkBox1.BackColor = Color.Red;

            }
            richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, style);
        }

        private void CheckBox2_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont == null)
            {
                checkBox2.BackColor = Color.FromArgb(64,64,64);
                return;
            }
            FontStyle style = richTextBox1.SelectionFont.Style;

            if (richTextBox1.SelectionFont.Italic)
            {
                style &= ~FontStyle.Italic;
                checkBox2.BackColor = Color.FromArgb(64,64,64);
            }
            else
            {
                style |= FontStyle.Italic;
                checkBox2.BackColor = Color.Red;
            }
            richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, style);
        }

        private void CheckBox3_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont == null)
            {
                checkBox3.BackColor = Color.FromArgb(64,64,64);
                return;
            }

            FontStyle style = richTextBox1.SelectionFont.Style;

            if (richTextBox1.SelectionFont.Underline)
            {
                style &= ~FontStyle.Underline;
                checkBox3.BackColor = Color.FromArgb(64,64,64);
            }
            else
            {
                style |= FontStyle.Underline;
                checkBox3.BackColor = Color.Red;
            }
            richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, style);
        }

        private void CheckBox4_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont == null)
            {
                checkBox4.BackColor = Color.FromArgb(64,64,64);
                return;
            }

            FontStyle style = richTextBox1.SelectionFont.Style;

            if (richTextBox1.SelectionFont.Strikeout)
            {
                style &= ~FontStyle.Strikeout;
                checkBox4.BackColor = Color.FromArgb(64,64,64);
            }
            else
            {
                style |= FontStyle.Strikeout;
                checkBox4.BackColor = Color.Red;
            }
            richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, style);
        }

     
    }
}
