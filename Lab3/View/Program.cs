using System;
using System.Windows.Forms;

namespace View
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа в приложение
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new AddFigureForm());
        }
    }
}
