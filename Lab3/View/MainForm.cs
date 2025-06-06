using System;
using System.Collections.Generic;
using Model;
using System.Windows.Forms;

namespace View
{
    /// <summary>
    /// Главная форма приложения
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// Инициализирует новый экземпляр формы
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            //TODO: duplication
            comboBoxFigure.Items.AddRange(new[] { "Треугольник", 
                "Прямоугольник", "Круг" });
            comboBoxFigure.SelectedIndexChanged += 
                ComboBoxFigure_SelectedIndexChanged;
            buttonCalculate.Click += ButtonCalculate_Click;
        }

        /// <summary>
        /// Обработка выбора фигуры в выпадающем списке
        /// </summary>
        private void ComboBoxFigure_SelectedIndexChanged(object sender, EventArgs e)
        {
            flowLayoutPanelInputs.Visible = false;
            flowLayoutPanelInputs.Controls.Clear();

            int count = 0;
            string figure = comboBoxFigure.SelectedItem.ToString();

            //TODO: RSDN
            //TODO: duplication
            //TODO: rewrite
            switch (figure)
            {
                case "Треугольник": count = 3; break;
                case "Прямоугольник": count = 2; break;
                case "Круг": count = 1; break;
            }

            for (int i = 0; i < count; i++)
            {//TODO: RSDN
                var label = new Label 
                { Text = (count == 1) ? "Радиус:"
                    : $"Сторона {i + 1}:", AutoSize = true };
                var textBox = new TextBox { Width = 100 };
                textBox.TextChanged += TextBox_TextChanged; 
                flowLayoutPanelInputs.Controls.AddRange(new Control[]
                { label, textBox });
            }

            labelResult.Text = string.Empty;
            flowLayoutPanelInputs.Visible = true;
        }

        // <summary>
        /// Проверка значения при изменении текста в поле ввода
        /// </summary>
        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            if (sender is TextBox textBox)
            {
                if (!double.TryParse(textBox.Text.Replace('.', ','),
                    out double value))
                {
                    textBox.BackColor = System.Drawing.Color.MistyRose;
                    errorProvider.SetError(textBox, "Введите числовое" +
                        " значение.");
                }
                else if (value <= 0)
                {
                    textBox.BackColor = System.Drawing.Color.MistyRose;
                    errorProvider.SetError(textBox, "Значение должно" +
                        " быть положительным.");
                }
                else
                {
                    textBox.BackColor = System.Drawing.SystemColors.Window;
                    errorProvider.SetError(textBox, "");
                }
            }
        }

        /// <summary>
        /// Обработка нажатия кнопки "Рассчитать"
        /// </summary>
        private void ButtonCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                string figure = comboBoxFigure.SelectedItem?.ToString();
                if (string.IsNullOrEmpty(figure))
                    throw new InvalidOperationException("Выберите фигуру.");

                List<double> values = new List<double>();
                bool hasInvalid = false;

                foreach (Control control in flowLayoutPanelInputs.Controls)
                {
                    if (control is TextBox textBox)
                    {
                        if (string.IsNullOrWhiteSpace(textBox.Text) ||
                            !double.TryParse(textBox.Text.Replace('.',
                            ','), out double value) ||
                            value <= 0)
                        {
                            textBox.BackColor = 
                                System.Drawing.Color.MistyRose;
                            hasInvalid = true;
                        }
                        else
                        {
                            textBox.BackColor = 
                                System.Drawing.SystemColors.Window; 
                            values.Add(value);
                        }
                    }
                }

                if (hasInvalid)
                    throw new ArgumentException("Пожалуйста, введите" +
                        " положительные числа во все поля.");

                FigureBase shape = null;
                switch (figure)
                {
                    //TODO: duplication
                    case "Треугольник":
                        shape = new Triangle(values[0], values[1], values[2]);
                        break;
                    case "Прямоугольник":
                        shape = new Model.Rectangle(values[0], values[1]);
                        break;
                    case "Круг":
                        shape = new Circle(values[0]);
                        break;
                }

                labelResult.Text = $"Площадь: {shape.Area:F2}";
            }
            catch (Exception ex)
            {
                labelResult.Text = $"Ошибка: {ex.Message}";
            }
        }
    }
}