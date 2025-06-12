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
using System.Xml.Serialization;

namespace View
{
    public partial class MainForm: Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
		/// Cписок фигур
		/// </summary>
		private BindingList<FigureBase> _figureList =
            new BindingList<FigureBase>();

        /// <summary>
        /// Лист фильтрованных фигур
        /// </summary>
        private readonly BindingList<FigureBase> _listForSearch =
            new BindingList<FigureBase>();

        /// <summary>
        /// Для файлов
        /// </summary>
        private readonly XmlSerializer _serializer =
            new XmlSerializer(typeof(BindingList<FigureBase>));

        /// <summary>
        /// Событие при загрузке формы
        /// </summary>
        private void MainForm_Load(object sender, EventArgs e)
        {
            DataGridFigureTools.CreateTable(_figureList, DataFigureView);
        }
    }
}
