using PersonLibrary;
using System;
using System.Collections.Generic;

namespace Lb1
{
    /// <summary>
    /// Класс, предназначенный для
    /// добавленя персоны через консоль
    /// </summary>
    public static class AddConsolePerson
    {
        /// <summary>
        /// Добавление Person через консоль        
        /// </summary>
        /// <returns>Новая персона</returns>
        public static Person NewPerson()
        {
            Person newPerson = new Person("Im", "Batman", 123, Gender.Male);
            List<Action> actions = new List<Action>()
            {
                new Action(() =>
                {
                    Console.Write("Name: ");
                    newPerson.Name = Console.ReadLine();
                }),
                new Action(() =>
                {
                    Console.Write("Surname: ");
                    newPerson.Surname = Console.ReadLine();
                }),
                new Action(() =>
                {
                    Console.Write("Age: ");
                    string ageString = Console.ReadLine();
                    if(!Int32.TryParse(ageString, out int age))
                    {
                        throw new ArgumentException("The age must be an " +
                            "integer value!");
                    }
                    newPerson.Age = age;
                }),
                new Action(() =>
                {
                    Console.Write("Gender (1 - Male, 2 - Female): ");
                    int gender = Int32.Parse(Console.ReadLine());
                    CheckingGender(gender);
                    newPerson.Gender = (Gender)Enum.Parse(
                        typeof(Gender), Convert.ToString(gender));
                }),
            };
            actions.ForEach(SetValue);
            return newPerson;
        }

        // <summary>
        /// Получение пользовательский ввода
        /// и задание параметра
        /// </summary>
        public static void SetValue(Action action)
        {
            while (true)
            {
                try
                {
                    action.Invoke();
                    return;
                }
                catch (Exception e)
                {
                    Console.WriteLine($"\n{e.Message}\n");
                }
            }
        }

        //TODO: remove +
        /// <summary>
        /// Проверка пола
        /// </summary>
        /// <param name="number">Цифра пола для проверки</param>
        /// <returns>Корректная цифра для определения пола</returns>
        public static int CheckingGender(int number)
        {
            if (number < 1 || number > 2)
            {
                throw new Exception("Please enter 1 or 2 " +
                    $", where 1 - Male, 2 - Female!");
            }
            else
            {
                return number;
            }
        }
    }
}
