using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace View
{
    /// <summary>
    /// Класс, описывающий форму для поиска 
    /// </summary>
    public partial class SearchFigureForm : Form
    {
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
            if (CheckBoxRectangle.Checked == false &&
                CheckBoxTriangle.Checked == false &&
                CheckBoxCircle.Checked == false &&
                CheckBoxVolume.Checked == false)
            {
                MessageBox.Show("Вы не ввели критерии для поиска!");
                return;
            }

            foreach (FigureBase figures in _listFigureSearch)
            {
                switch (figures)
                {
                    case Model.Rectangle _ when CheckBoxRectangle.Checked:
                    case Triangle _ when CheckBoxTriangle.Checked:
                    case Circle _ when CheckBoxCircle.Checked:
                        {
                            count++;
                            SendDataFromFormEvent?.Invoke(this,
                                new FigureEventArgs(figures));
                            break;
                        }
                }

                if (CheckBoxVolume.Checked && figures.Area.ToString().
                    StartsWith(TextBoxVolume.Text))
                {
                    count++;
                    SendDataFromFormEvent?.Invoke(this,
                        new FigureEventArgs(figures));
                }
            }
            if (count == 0)
            {
                MessageBox.Show("Таких фигур нет или вы ввели нечисловое значение.\n" +
                    "Будьте внимательны!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
            Close();
            CheckBoxRectangle.Checked = false;
            CheckBoxTriangle.Checked = false;
            CheckBoxCircle.Checked = false;
            CheckBoxVolume.Checked = false;
        }
    }
}
