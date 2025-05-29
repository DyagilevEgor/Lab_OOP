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

            comboBoxFigure.Items.AddRange(new[] { "Треугольник", "Прямоугольник", "Круг" });
            comboBoxFigure.SelectedIndexChanged += ComboBoxFigure_SelectedIndexChanged;
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

            switch (figure)
            {
                case "Треугольник": count = 3; break;
                case "Прямоугольник": count = 2; break;
                case "Круг": count = 1; break;
            }

            for (int i = 0; i < count; i++)
            {
                var label = new Label { Text = (count == 1) ? "Радиус:" : $"Сторона {i + 1}:", AutoSize = true };
                var textBox = new TextBox { Width = 100 };
                flowLayoutPanelInputs.Controls.AddRange(new Control[] {label, textBox});
            }

            labelResult.Text = string.Empty;
            flowLayoutPanelInputs.Visible = true;
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
                foreach (Control control in flowLayoutPanelInputs.Controls)
                {
                    if (control is TextBox textBox)
                    {
                        if (string.IsNullOrWhiteSpace(textBox.Text))
                            throw new ArgumentException("Пожалуйста, заполните все поля.");
                        values.Add(double.Parse(textBox.Text.Replace('.', ',')));
                    }
                }

                FigureBase shape = null;
                switch (figure)
                {
                    case "Треугольник":
                        var triangle = new Triangle(values[0], values[1], values[2]);
                        shape = triangle;
                        break;
                    case "Прямоугольник":
                        var rectangle = new Model.Rectangle(values[0], values[1]);
                        shape = rectangle;
                        break;
                    case "Круг":
                        var circle = new Circle(values[0]);
                        shape = circle;
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