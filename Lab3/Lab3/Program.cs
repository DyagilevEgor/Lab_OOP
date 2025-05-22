using System;
using Model;

namespace ConsoleLoader
{
    /// <summary>
    /// Класс для тестирования библиотеки классов Model
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Точка входа в программу
        /// </summary>
        /// <param name="args">Параметры</param>
        public static void Main(string[] args)
        {
            Console.WriteLine("Калькулятор" +
                " площади фигур!\n" +
                "Нажмите любую кнопку, чтобы начать...");
            Console.ReadKey();

            while (true)
            {
                Console.WriteLine("");
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1 - Вычисление площади круга");
                Console.WriteLine("2 - Вычисление площади прямоугольника");
                Console.WriteLine("3 - Вычисление площади треугольника");
                Console.WriteLine("4 - Выход из программы");
                var consoleKey = Console.ReadLine();
                switch (consoleKey)
                {

                    //TODO: RSDN
                    case "1":
                        {
                            GetVolumeInfo(AddConsoleFigure.
                                GetCircle());
                            break;
                        }
                    case "2":
                        {
                            GetVolumeInfo(AddConsoleFigure.
                                GetRectangle());
                            break;
                        }
                    case "3":
                        {
                            //BUG
                            GetVolumeInfo(AddConsoleFigure.
                                GetTriangle());
                            break;
                        }
                    case "4":
                        {
                            Environment.Exit(0);
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Попробуйте ещё раз.");
                            break;
                        }
                }
            }
        }

        /// <summary>
        /// Вывести информацию в консоль
        /// </summary>
        /// <param name="figure">Экземпляр класса Фигура</param>
        public static void GetVolumeInfo(FigureBase figure)
        {
            Console.WriteLine($"Площадь фигуры равна " +
                $"{figure.Area} см^2.");
        }
    }
}
