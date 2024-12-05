using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_0_Dyagilev
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }

        static void CalculateSquareArea()
        {
            Console.Write("Введите длину стороны квадрата: ");
            int a = Convert.ToInt32(Console.ReadLine());

            if (a > 0)
            {
                double area = a * a;
                Console.WriteLine($"Площадь квадрата: {area}");
            }
            else
            {
                Console.WriteLine("Ошибка: введено недопустимое значение для стороны квадрата.");
            }
            Console.ReadLine();
        }
    }
}
