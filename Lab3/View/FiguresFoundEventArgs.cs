using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View
{
    /// <summary>
    /// Аргументы события для передачи списка фигур
    /// </summary>
    public class FiguresFoundEventArgs : EventArgs
    {
        /// <summary>
        /// Найденные фигуры
        /// </summary>
        public List<FigureBase> Figures { get; }

        //TODO: XML+
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="FiguresFoundEventArgs"/>.
        /// </summary>
        /// <param name="figures">Список найденных фигур
        public FiguresFoundEventArgs(List<FigureBase> figures)
        {
            Figures = figures ?? new List<FigureBase>();
        }
    }
}
