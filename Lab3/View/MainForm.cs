using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace View
{
    /// <summary>
    /// Главная форма приложения
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// Список всех фигур
        /// </summary>
        private BindingList<FigureBase> _figureList = new BindingList<FigureBase>();

        /// <summary>
        /// Список отфильтрованных фигур (поиск)
        /// </summary>
        private readonly BindingList<FigureBase> _listForSearch = new BindingList<FigureBase>();

        /// <summary>
        /// Сериализатор для сохранения/загрузки
        /// </summary>
        private readonly XmlSerializer _serializer = new XmlSerializer(typeof(BindingList<FigureBase>));

        /// <summary>
        /// Конструктор формы
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            DataFigureView.DataSource = _figureList;
            SetupDataGridColumns();
        }

        /// <summary>
        /// Добавить фигуру вручную
        /// </summary>
        private void AddFigureButton_Click(object sender, EventArgs e)
        {
            var addForm = new AddFigureForm();
            if (addForm.ShowDialog() == DialogResult.OK && addForm.FigureData != null)
            {
                _figureList.Add(addForm.FigureData);
            }
        }

        /// <summary>
        /// Добавить случайную фигуру
        /// </summary>
        private void RandomFigureButton_Click(object sender, EventArgs e)
        {
            _figureList.Add(RandomFigure.GetRandomFigure());
        }

        /// <summary>
        /// Удалить выбранные фигуры
        /// </summary>
        private void DeleteFugureButton_Click(object sender, EventArgs e)
        {
            int count = DataFigureView.SelectedRows.Count;
            for (int i = 0; i < count; i++)
            {
                int index = DataFigureView.SelectedRows[0].Index;
                if (index >= 0 && index < _figureList.Count)
                {
                    _figureList.RemoveAt(index);
                }
            }
        }

        /// <summary>
        /// Загрузка списка фигур из файла
        /// </summary>
        private void LoadToolStripMenuItemClick(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = "Файлы (*.di)|*.di|Все файлы (*.*)|*.*"
            };

            if (openFileDialog.ShowDialog() != DialogResult.OK) return;

            FileStream stream = null;
            try
            {
                stream = new FileStream(openFileDialog.FileName, FileMode.Open);
                var loadedList = (BindingList<FigureBase>)_serializer.Deserialize(stream);

                _figureList.Clear();
                foreach (var figure in loadedList)
                {
                    _figureList.Add(figure);
                }

                MessageBox.Show("Файл успешно загружен.", "Загрузка завершена",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Ошибка при загрузке файла. Возможно, файл поврежден.",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (stream != null)
                {
                    stream.Dispose();
                }
            }
        }

        /// <summary>
        /// Сохранение списка фигур в файл
        /// </summary>
        private void SaveToolStripMenuItemClick(object sender, EventArgs e)
        {
            if (_figureList.Count == 0)
            {
                MessageBox.Show("Нет данных для сохранения.", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var saveFileDialog = new SaveFileDialog
            {
                Filter = "Файлы (*.di)|*.di|Все файлы (*.*)|*.*",
                AddExtension = true,
                DefaultExt = ".di"
            };

            if (saveFileDialog.ShowDialog() != DialogResult.OK) return;

            FileStream stream = null;
            try
            {
                stream = new FileStream(saveFileDialog.FileName, FileMode.Create);
                _serializer.Serialize(stream, _figureList);

                MessageBox.Show("Файл успешно сохранён.", "Сохранение завершено",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                if (stream != null)
                {
                    stream.Dispose();
                }
            }
        }

        /// <summary>
        /// Открытие формы поиска фигур
        /// </summary>
        private void SearchFigureButton_Click(object sender, EventArgs e)
        {
            var searchForm = new SearchFigureForm(_figureList);
            searchForm.SendDataFromFormEvent += AddSearchFigureEvent;
            searchForm.Show();
        }

        /// <summary>
        /// Обработка получения результатов из формы поиска
        /// </summary>
        public void AddSearchFigureEvent(object sender, FigureEventArgs e)
        {
            _listForSearch.Add(e.SendingFigure);
            DataFigureView.DataSource = _listForSearch;

            DeleteFugureButton.Enabled = false;
            DropFilterButton.Enabled = true;
            SearchFigureButton.Enabled = false;
            AddFigureButton.Enabled = false;
            RandomFigureButton.Enabled = false;
        }

        /// <summary>
        /// Сброс фильтрации после поиска
        /// </summary>
        private void DropFilterButton_Click(object sender, EventArgs e)
        {
            _listForSearch.Clear();
            DataFigureView.DataSource = _figureList;

            DeleteFugureButton.Enabled = true;
            SearchFigureButton.Enabled = true;
            AddFigureButton.Enabled = true;
            RandomFigureButton.Enabled = true;
        }

        /// <summary>
        /// Обновляет отображение таблицы фигур
        /// </summary>
        private void SetupDataGridColumns()
        {
            DataFigureView.AutoGenerateColumns = false;
            DataFigureView.Columns.Clear();

            // Колонка: Тип фигуры
            var typeColumn = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TypeName",
                HeaderText = "Тип фигуры",
                ReadOnly = true
            };
            DataFigureView.Columns.Add(typeColumn);

            // Колонка: Площадь
            var areaColumn = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Area",
                HeaderText = "Площадь",
                ReadOnly = true,
                DefaultCellStyle = { Format = "F2" }
            };
            DataFigureView.Columns.Add(areaColumn);
        }
    }
}