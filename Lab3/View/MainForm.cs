using Model;
using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace View
{
    /// <summary>
    /// Главная форма приложения для работы с геометрическими фигурами
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// Основной список всех фигур
        /// </summary>
        private BindingList<FigureBase> _figureList =
            new BindingList<FigureBase>();

        /// <summary>
        /// Список фигур, отфильтрованных в процессе поиска
        /// </summary>
        private readonly BindingList<FigureBase> _listForSearch = 
            new BindingList<FigureBase>();

        /// <summary>
        /// XML-сериализатор для сохранения и загрузки списка фигур
        /// </summary>
        private readonly XmlSerializer _serializer = 
            new XmlSerializer(typeof(BindingList<FigureBase>));

        /// <summary>
        /// Конструктор главной формы
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            DataFigureView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DataFigureView.MultiSelect = true;
            DataFigureView.DataSource = _figureList;

#if !DEBUG
            RandomFigureButton.Visible = false;
#endif
            SetupDataGridColumns();

#if !DEBUG
            RandomFigureButton.Visible = false;
#endif
        }

        /// <summary>
        /// Обработчик кнопки добавления новой фигуры
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
        /// Добавление случайной фигуры
        /// </summary>
        private void RandomFigureButton_Click(object sender, EventArgs e)
        {
#if DEBUG
            _figureList.Add(RandomFigure.GetRandomFigure());
#endif
        }

        /// <summary>
        /// Удаление выбранных фигур из списка
        /// </summary>
        private void DeleteFugureButton_Click(object sender, EventArgs e)
        {
            var source = DataFigureView.DataSource as BindingList<FigureBase>;
            if (source == null || DataFigureView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите строку для удаления.", "Удаление",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int count = DataFigureView.SelectedRows.Count;
            for (int i = 0; i < count; i++)
            {
                int index = DataFigureView.SelectedRows[0].Index;
                if (index >= 0 && index < source.Count)
                {
                    source.RemoveAt(index);
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

            if (openFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            try
            {
                using (var stream = new FileStream(openFileDialog.FileName, FileMode.Open))
                {
                    var loadedList = (BindingList<FigureBase>)_serializer.Deserialize(stream);

                    _figureList.Clear();
                    foreach (var figure in loadedList)
                    {
                        _figureList.Add(figure);
                    }

                    SetupDataGridColumns();
                    MessageBox.Show("Файл успешно загружен.", "Загрузка завершена",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке файла:\n" + ex.Message,
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            if (saveFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            try
            {
                using (var stream = new FileStream(saveFileDialog.FileName, FileMode.Create))
                {
                    _serializer.Serialize(stream, _figureList);

                    MessageBox.Show("Файл успешно сохранён.", "Сохранение завершено",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при сохранении файла:\n" + ex.Message,
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Открытие формы поиска фигур
        /// </summary>
        private void SearchFigureButton_Click(object sender, EventArgs e)
        {
            var searchForm = new SearchFigureForm(_figureList);
            searchForm.SendFigureListEvent += AddSearchFigureListEvent;
            searchForm.Show();
        }

        /// <summary>
        /// Добавление найденной фигуры из формы поиска
        /// </summary>
        public void AddSearchFigureEvent(object sender, FigureEventArgs e)
        {
            _listForSearch.Add(e.SendingFigure);
            DataFigureView.DataSource = _listForSearch;

            DeleteFugureButton.Enabled = false;
            DropFilterButton.Enabled = true;
            SearchFigureButton.Enabled = false;
            AddFigureButton.Enabled = false;
#if DEBUG
            RandomFigureButton.Enabled = false;
#endif
        }

        /// <summary>
        /// Сброс фильтра и возврат ко всему списку фигур
        /// </summary>
        private void DropFilterButton_Click(object sender, EventArgs e)
        {
            _listForSearch.Clear();
            DataFigureView.DataSource = _figureList;

            DeleteFugureButton.Enabled = true;
            SearchFigureButton.Enabled = true;
            AddFigureButton.Enabled = true;
#if DEBUG
            RandomFigureButton.Enabled = true;
#endif
        }

        /// <summary>
        /// Настройка отображения колонок таблицы
        /// </summary>
        private void SetupDataGridColumns()
        {
            DataFigureView.AutoGenerateColumns = false;
            DataFigureView.Columns.Clear();

            var typeColumn = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TypeName",
                HeaderText = "Тип фигуры",
                ReadOnly = true
            };
            DataFigureView.Columns.Add(typeColumn);

            var areaColumn = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Area",
                HeaderText = "Площадь",
                ReadOnly = true,
                DefaultCellStyle = { Format = FormatConstants.AreaFormat }
            };
            DataFigureView.Columns.Add(areaColumn);
        }

        /// <summary>
        /// Добавление найденных фигур из формы поиска
        /// </summary>
        private void AddSearchFigureListEvent(object sender, FiguresFoundEventArgs e)
        {
            _listForSearch.Clear();
            foreach (var figure in e.Figures)
            {
                _listForSearch.Add(figure);
            }

            DataFigureView.DataSource = _listForSearch;

            DeleteFugureButton.Enabled = false;
            DropFilterButton.Enabled = true;
            SearchFigureButton.Enabled = false;
            AddFigureButton.Enabled = false;
#if DEBUG
            RandomFigureButton.Enabled = false;
#endif
        }

    }
}