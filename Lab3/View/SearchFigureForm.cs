using Model;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace View
{
    /// <summary>
    /// Класс, описывающий форму для поиска 
    /// </summary>
    public partial class SearchFigureForm : Form
    {
        //TODO: optimize
        /// <summary>
        /// Ивент для передачи данных 
        /// </summary>
        public event EventHandler<FigureEventArgs> SendDataFromFormEvent;

        /// <summary>
        /// Лист фильтрованных фигур
        /// </summary>
        private readonly BindingList<FigureBase> _listFigureSearch;

        /// <summary>
        /// Событие при инициализации формы
        /// </summary>
        public SearchFigureForm(BindingList<FigureBase> figures)
        {
            InitializeComponent();
            _listFigureSearch = figures;
            MaximizeBox = false;
            TextBoxVolume.Enabled = false;
            CheckBoxVolume.CheckedChanged += CheckBoxVolumeCheckedChanged;
        }

        /// <summary>
        /// Обработка чисел на форме
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NumericTextboxKeyPress(object sender,
            KeyPressEventArgs e)
        {
            if (double.TryParse(((TextBox)sender).Text + e.KeyChar, out _)
                || e.KeyChar == (char)Keys.Back) return;
        }

        /// <summary>
        /// Обработчик изменения свойства Check объекта VolumeCheckBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckBoxVolumeCheckedChanged(object sender, EventArgs e)
        {
            TextBoxVolume.Enabled = CheckBoxVolume.Checked;
        }

        /// <summary>
        /// Кнопка Поиск
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonShowFigure_Click(object sender, EventArgs e)
        {
            int count = 0;

            bool typeFilterEnabled = CheckBoxRectangle.Checked
                                     || CheckBoxTriangle.Checked
                                     || CheckBoxCircle.Checked;

            bool areaFilterEnabled = CheckBoxVolume.Checked;

            if (!typeFilterEnabled && !areaFilterEnabled)
            {
                MessageBox.Show("Вы не ввели критерии для поиска");
                return;
            }

            double searchedArea = 0;

            if (areaFilterEnabled)
            {
                if (!double.TryParse(TextBoxVolume.Text.Replace('.', ','), out searchedArea))
                {
                    MessageBox.Show("Введите корректное числовое значение площади.");
                    return;
                }
            }

            foreach (FigureBase figure in _listFigureSearch)
            {
                bool typeMatch = !typeFilterEnabled ||
                                 (figure is Model.Rectangle && CheckBoxRectangle.Checked) ||
                                 (figure is Triangle && CheckBoxTriangle.Checked) ||
                                 (figure is Circle && CheckBoxCircle.Checked);

                bool areaMatch = !areaFilterEnabled ||
                                 Math.Abs(Math.Round(figure.Area, 2) - Math.Round(searchedArea, 2)) < 0.001;

                if (typeMatch && areaMatch)
                {
                    count++;
                    SendDataFromFormEvent?.Invoke(this, new FigureEventArgs(figure));
                }
            }

            if (count == 0)
            {
                MessageBox.Show("Таких фигур нет или вы ввели некорректное значение.\nБудьте внимательны",
                                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Close();

            CheckBoxRectangle.Checked = false;
            CheckBoxTriangle.Checked = false;
            CheckBoxCircle.Checked = false;
            CheckBoxVolume.Checked = false;
        }
    }
}
