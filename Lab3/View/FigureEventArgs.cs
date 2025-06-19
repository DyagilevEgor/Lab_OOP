using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View
{
    /// <summary>
    /// Класс аргумента для передачи данныых
    /// </summary>
    public class FigureEventArgs : EventArgs
    {
        /// <summary>
        /// Фигура для передачи
        /// </summary>
        public FigureBase SendingFigure { get; }

        /// <summary>
        /// Конструктор для передачи фигуры
        /// </summary>
        /// <param name="sendingFigure">Транспорт</param>
        public FigureEventArgs(FigureBase sendingFigure)
        {
            //TODO: null?
            if (sendingFigure == null)
                throw new ArgumentNullException(nameof(sendingFigure), "Фигура не может быть null.");

            SendingFigure = sendingFigure;
        }

    }
}
