using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pr16_3_isomatov_h
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                double[] numbers = textBox1.Text.Split(new[] {';' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(s => double.Parse(s.Trim()))
                    .ToArray();

                A(numbers);
                B(numbers);

            }
            catch (FormatException)
            {
                MessageBox.Show("Ошибка ввода. Пожалуйста введите числа, разделенные двоеточием");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex}");
            }
        }
        private void A(double[] numbers)
        {
            var lq = numbers.GroupBy(n =>n)
                .Select(g => new { Number = g.Key, ch = g.Count() })
                .OrderBy(item => item.Number);

            dataGridView1.Rows.Clear();
            foreach (var item in lq)
            {
                dataGridView1.Rows.Add(item.Number,item.ch);
            }
        }
        private void B(double[] numbers)
        {
            var lq = numbers.GroupBy(n => n)
                .ToDictionary(g => g.Key, g => g.Count());

            double[] mass = numbers.Select(n => n * lq[n]).ToArray();
            dataGridView2.Rows.Clear();

            for (int i = 0; i<numbers.Length;i++)
            {
                dataGridView2.Rows.Add(i,numbers[i],mass[i]);
            }
        }

    }
}
