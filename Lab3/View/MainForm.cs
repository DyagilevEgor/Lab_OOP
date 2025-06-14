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
        private BindingList<FigureBase> _figureList = new BindingList<FigureBase>();
        private readonly BindingList<FigureBase> _listForSearch = new BindingList<FigureBase>();
        private readonly XmlSerializer _serializer = new XmlSerializer(typeof(BindingList<FigureBase>));

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
#if DEBUG
    _figureList.Add(RandomFigure.GetRandomFigure());
#endif
        }

        /// <summary>
        /// Удалить выбранные фигуры
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

        private void LoadToolStripMenuItemClick(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = "Файлы (*.di)|*.di|Все файлы (*.*)|*.*"
            };

            if (openFileDialog.ShowDialog() != DialogResult.OK) return;

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

        private void SearchFigureButton_Click(object sender, EventArgs e)
        {
            var searchForm = new SearchFigureForm(_figureList);
            searchForm.SendDataFromFormEvent += AddSearchFigureEvent;
            searchForm.Show();
        }

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
        /// Настраивает отображение колонок таблицы
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
                DefaultCellStyle = { Format = "F2" }
            };
            DataFigureView.Columns.Add(areaColumn);
        }
    }
}