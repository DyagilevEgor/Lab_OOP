using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Model;

namespace View
{
    /// <summary>
    /// Форма добавления фигуры.
    /// </summary>
    public partial class AddFigureForm : Form
    {
        /// <summary>
        /// Поле для хранения созданной фигуры
        /// </summary>
        private FigureBase _figure;

        /// <summary>
        /// Свойство для получения данных фигуры
        /// </summary>
        public FigureBase FigureData => _figure;

        /// <summary>
        /// Словарь с параметрами и фабрикой создания фигуры
        /// </summary>
        private readonly Dictionary<string,
            (int paramCount, Func<List<double>, FigureBase> create)> _figureMap;

        /// <summary>
        /// Конструктор формы
        /// </summary>
        public AddFigureForm()
        {
            InitializeComponent();

            comboBoxFigure.SelectedIndexChanged += ComboBoxFigure_SelectedIndexChanged;
            buttonCalculate.Click += ButtonCalculate_Click;
            buttonAdd.Click += ButtonAdd_Click;

            buttonAdd.Enabled = false;

            _figureMap = new Dictionary<string, (int, Func<List<double>, FigureBase>)>
            {
                ["Треугольник"] = (3, values => new Triangle(values[0], values[1], values[2])),
                ["Прямоугольник"] = (2, values => new Model.Rectangle(values[0], values[1])),
                ["Круг"] = (1, values => new Circle(values[0]))
            };

            comboBoxFigure.Items.AddRange(_figureMap.Keys.ToArray());
        }

        /// <summary>
        /// Обработка выбора фигуры
        /// </summary>
        private void ComboBoxFigure_SelectedIndexChanged(object sender, EventArgs e)
        {
            flowLayoutPanelInputs.Visible = false;
            flowLayoutPanelInputs.Controls.Clear();
            buttonAdd.Enabled = false;
            labelResult.Text = string.Empty;

            if (comboBoxFigure.SelectedItem is string figureName &&
                _figureMap.TryGetValue(figureName, out var config))
            {
                for (int i = 0; i < config.paramCount; i++)
                {
                    var label = new Label
                    {
                        Text = config.paramCount == 1 ? "Радиус:" : $"Сторона {i + 1}:",
                        AutoSize = true
                    };
                    var textBox = new TextBox { Width = 100 };
                    textBox.TextChanged += TextBox_TextChanged;
                    flowLayoutPanelInputs.Controls.Add(label);
                    flowLayoutPanelInputs.Controls.Add(textBox);
                }

                flowLayoutPanelInputs.Visible = true;
            }
        }

        /// <summary>
        /// Проверка введённого значения
        /// </summary>
        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            if (sender is TextBox textBox)
            {
                if (!double.TryParse(textBox.Text.Replace('.', ','), out double value) || value <= 0)
                {
                    textBox.BackColor = System.Drawing.Color.MistyRose;
                    errorProvider.SetError(textBox, "Введите положительное число.");
                }
                else
                {
                    textBox.BackColor = System.Drawing.SystemColors.Window;
                    errorProvider.SetError(textBox, "");
                }

                buttonAdd.Enabled = false;
                labelResult.Text = string.Empty;
            }
        }

        /// <summary>
        /// Обработка кнопки "Рассчитать"
        /// </summary>
        private void ButtonCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                string figureName = comboBoxFigure.SelectedItem?.ToString();
                if (string.IsNullOrEmpty(figureName))
                {
                    throw new InvalidOperationException("Выберите фигуру.");
                }

                if (!_figureMap.TryGetValue(figureName, out var config))
                {
                    throw new InvalidOperationException("Неизвестная фигура.");
                }

                var values = new List<double>();
                bool hasInvalid = false;

                foreach (Control control in flowLayoutPanelInputs.Controls)
                {
                    if (control is TextBox textBox)
                    {
                        if (string.IsNullOrWhiteSpace(textBox.Text) ||
                            !double.TryParse(textBox.Text.Replace('.', ','), out double value) ||
                            value <= 0)
                        {
                            textBox.BackColor = System.Drawing.Color.MistyRose;
                            hasInvalid = true;
                        }
                        else
                        {
                            values.Add(value);
                        }
                    }
                }

                if (hasInvalid)
                {
                    throw new ArgumentException("Введите корректные положительные числа.");
                }

                _figure = config.create(values);
                labelResult.Text = $"Площадь: {_figure.Area:F2}";
                buttonAdd.Enabled = true;
            }
            catch (Exception ex)
            {
                labelResult.Text = $"Ошибка: {ex.Message}";
                buttonAdd.Enabled = false;
                _figure = null;
            }
        }

        /// <summary>
        /// Обработка кнопки "Добавить"
        /// </summary>
        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            if (_figure != null)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}