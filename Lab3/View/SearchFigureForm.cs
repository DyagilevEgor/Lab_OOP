using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace View
{
    /// <summary>
    /// Класс, описывающий форму для поиска 
    /// </summary>
    public partial class SearchFigureForm : Form
    {
        /// <summary>
        /// Событие для передачи найденных фигур в виде списка
        /// </summary>
        public event EventHandler<FiguresFoundEventArgs> SendFigureListEvent;

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
            var resultList = new List<FigureBase>();

            bool typeFilterEnabled = CheckBoxRectangle.Checked
                                     || CheckBoxTriangle.Checked
                                     || CheckBoxCircle.Checked;
            bool areaFilterEnabled = CheckBoxVolume.Checked;

            if (!typeFilterEnabled && !areaFilterEnabled)
            {
                MessageBox.Show("Вы не ввели критерии для поиска");
                return;
            }

            if (areaFilterEnabled && string.IsNullOrWhiteSpace(TextBoxVolume.Text))
            {
                MessageBox.Show("Введите значение для поиска площади.");
                return;
            }

            foreach (FigureBase figure in _listFigureSearch)
            {
                bool typeMatch = !typeFilterEnabled ||
                                 (figure is Model.Rectangle && CheckBoxRectangle.Checked) ||
                                 (figure is Triangle && CheckBoxTriangle.Checked) ||
                                 (figure is Circle && CheckBoxCircle.Checked);

                bool areaMatch = !areaFilterEnabled ||
                                 figure.Area.ToString(FormatConstants.AreaFormat).Contains(TextBoxVolume.Text.Trim());

                if (typeMatch && areaMatch)
                {
                    resultList.Add(figure);
                }
            }

            if (resultList.Count == 0)
            {
                MessageBox.Show("Таких фигур нет или вы ввели некорректное значение.\nБудьте внимательны",
                                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                SendFigureListEvent?.Invoke(this, new FiguresFoundEventArgs(resultList));
            }

            //Close();

            CheckBoxRectangle.Checked = false;
            CheckBoxTriangle.Checked = false;
            CheckBoxCircle.Checked = false;
            CheckBoxVolume.Checked = false;
        }
    }
}
