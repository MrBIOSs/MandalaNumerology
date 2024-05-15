using MandalaNumerology.Modal;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace MandalaNumerology
{
    public partial class Form1 : Form
    {
        private СalculationMandala _calculationMandala = new СalculationMandala();
        private List<TextBox> textBoxMandala = new List<TextBox>();

        [DllImport("user32.dll")]
        static extern bool HideCaret(IntPtr hWnd);

        public Form1()
        {
            InitializeComponent();

            InitialWindowSize();

            InitialListMandala();

            comboBox1.Text = comboBox1.Items[0].ToString();
        }

        private void InitialListMandala()
        {
            textBoxMandala.Add(tBArcaneYear1);
            textBoxMandala.Add(tBArcaneYear2);
            textBoxMandala.Add(tBArcaneYear3);
            textBoxMandala.Add(tBArcaneYear4);
            textBoxMandala.Add(tBArcaneYear5);
            textBoxMandala.Add(tBArcaneYear6);
            textBoxMandala.Add(tBDayBirth);
            textBoxMandala.Add(tBMonthBirth);
            textBoxMandala.Add(tBYearBirth);
            textBoxMandala.Add(tBPlatform1);
            textBoxMandala.Add(tBTutorial1);
            textBoxMandala.Add(tBExamination1);
            textBoxMandala.Add(tBSum1);
            textBoxMandala.Add(tBSum2);
            textBoxMandala.Add(tBSum3);
            textBoxMandala.Add(tBGuideStar1);
            textBoxMandala.Add(tBSum4);
            textBoxMandala.Add(tBCube1);
            textBoxMandala.Add(tBCube2);
            textBoxMandala.Add(tBSmallCircle1);
            textBoxMandala.Add(tBSmallCircle2);
            textBoxMandala.Add(tBSmallCircle3);
            textBoxMandala.Add(tBSmallCircle4);
            textBoxMandala.Add(tBExamination2);
            textBoxMandala.Add(tBTutorial2);
            textBoxMandala.Add(tBPlatform2);
            textBoxMandala.Add(tBCircle1);
            textBoxMandala.Add(tBGuideStar2);
            textBoxMandala.Add(tBCircle2);
        }

        private void InitialWindowSize()
        {
            Width = 782;
            Height = 648;

            pictureBox1.Width = 598;
            pictureBox1.Height = 648;
        }

        private void TextInputValidation(TextBox textBox)
        {
            if (textBox.Text.Length == 0)
            {
                textBox.BackColor = Color.FromArgb(255, 192, 192);
            }
            else
            {
                textBox.BackColor = Color.White;
            }
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;

            TextInputValidation(textBox);
        }

        private void textBox_MouseDown(object sender, MouseEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            HideCaret(textBox.Handle);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                label4.Enabled = false;
                tBMonth.Enabled = false;
                tBMonth.Text = "";
                tBMonth.BackColor = Color.White;
            }
            else
            {
                label4.Enabled = true;
                tBMonth.Enabled = true;
                tBMonth.BackColor = Color.FromArgb(255, 192, 192);
            }
        }

        private void tBYear_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0') && (e.KeyChar <= '9') || e.KeyChar == (char)Keys.Back)
            {
                return;
            }
            e.Handled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string year = tBYear.Text;
            string month = tBMonth.Text;
            int dayBirth = dateBirth.Value.Day;
            int monthBirth = dateBirth.Value.Month;
            string yearBirth = dateBirth.Value.Year.ToString();

            if (tBYear.Text.Length == 4)
            {
                if (comboBox1.SelectedIndex == 0)
                {
                    _calculationMandala.YearForecast(year, dayBirth, monthBirth, yearBirth);
                    ShowForecast(_calculationMandala);
                }

                if (comboBox1.SelectedIndex == 1 && tBMonth.Text.Length > 0 && int.Parse(tBMonth.Text) <= 12)
                {
                    _calculationMandala.MonthForecast(year, month, dayBirth, monthBirth, yearBirth);
                    ShowForecast(_calculationMandala);
                }
            }
        }

        private void ShowForecast(СalculationMandala mandala)
        {
            for (int i = 0; i < textBoxMandala.Count; i++)
            {
                textBoxMandala[i].Text = Convert.ToString(mandala.Arcanes[i]);
            }
        }
    }
}
