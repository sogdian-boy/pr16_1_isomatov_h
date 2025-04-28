using System;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace pr16_1_Isomatov_h
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void search_Click(object sender, EventArgs e)
        {
            if (File.Exists("text.txt"))
            {
                string s = word.Text;
                string fileText = File.ReadAllText("text.txt");
                if (s == string.Empty)
                {
                    MessageBox.Show("Пожалуйста введите искомое слово для поиска");
                    return;
                }

                var words = fileText.Split(new[] { ' ', ',', '.', '!', '?', ';', ':', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                // LINQ
                int count = words.Count(w => w.Equals(s, StringComparison.OrdinalIgnoreCase));

                result.Text = $"Найдено {count} повторений слова в предложении";
            }
            else
            {
                result.Text = $"Файл c текстом не существует";

            }
        }
    }
}
