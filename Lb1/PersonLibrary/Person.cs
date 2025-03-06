using System;
using System.Text.RegularExpressions;

namespace PersonLibrary
{
    /// <summary>
    /// Класс, представляющий человека (Person).
    /// Содержит информацию о имени, фамилии, возрасте и поле.
    /// </summary>
    public class Person
    {
        /// <summary>
        /// Имя 
        /// </summary>
        private string _name;

        /// <summary>
        /// Фамилия
        /// </summary>
        private string _surname;

        /// <summary>
        /// Возраст
        /// </summary>
        private int _age;

        /// <summary>
        /// Максимальный возраст человека
        /// </summary>
        public const int AgeMax = 125;

        /// <summary>
        /// Имя 
        /// </summary>
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                CheckingNameAndSurname(value);
                _name = ConvertToRightRegister(value);
            }
        }

        /// <summary>
        /// Фамилия 
        /// </summary>
        public string Surname
        {
            get
            {
                return _surname;
            }
            set
            {
                CheckingNameAndSurname(value);
                _surname = ConvertToRightRegister(value);
                AreSameLaguage();
            }
        }

        /// <summary>
        /// Возраст 
        /// </summary>
        public int Age
        {
            get
            {
                return _age;
            }
            set
            {
                CheckingAge(value);
                _age = value;
            }
        }

        /// <summary>
        /// Пол 
        /// </summary>
        public Gender Gender { get; set; }

        /// <summary>
        /// Констукрутор класса
        /// </summary>
        /// <param name="name">Имя человека</param>
        /// <param name="surname">Фамилия человека</param>
        /// <param name="age">Возраст человека</param>
        /// <param name="gender">Пол человека</param>
        public Person(string name, string surname, int age, Gender gender)
        {
            Name = name;
            Surname = surname;
            Age = age;
            Gender = gender;
        }

        /// <summary>
        /// Проверка имени и фамилии на корректность ввода
        /// </summary>
        /// <param name="value">Имя или фамилия для проверки</param>
        /// <returns>True/False в зависимости от результата
        /// проверки</returns>
        private static bool IsNameAndSurnameCorrect(string value)
        {
            var regex = new Regex("^([A-Za-z]|[А-Яа-я])+(((-| )?([A-Za-z]|" +
                "[А-Яа-я])+))?$");

            return regex.IsMatch(value);
        }

        /// <summary>
        /// Проверка имя и фамилия на одном языке.
        /// </summary>
        private void AreSameLaguage()
        {
            var regex = new Regex("^[A-Za-z\\-]+");

            if ((regex.IsMatch(_name) ^ regex.IsMatch(_surname)))
            {
                throw new Exception(
                    "Name and Surname are not in the same language! ");
            }
        }

            /// <summary>
            /// Проверка имени и фамилии
            /// </summary>
            /// <param name="value">Имя или фамилия для проверки</param>
            /// <returns>Корректная строка</returns>
            public static string CheckingNameAndSurname(string value)
        {
            if (value == string.Empty)
            {
                throw new Exception(
                    "Expression is null or empty! ");
            }
            else if (!IsNameAndSurnameCorrect(value))
            {
                throw new FormatException("Name or surname must contain " +
                    "only Cyrillic or Latin symbols!");
            }
            else
            {
                return value;
            }
        }

        /// <summary>
        /// Приводит имя или фамилию к правильному регистру 
        /// (первая буква заглавная, остальные строчные).
        /// Сохраняет дефисы между словами.
        /// </summary>
        /// <param name="name">Имя или фамилия для обработки.</param>
        /// <returns>Имя или фамилия в правильном регистре.</returns>
        private string ConvertToRightRegister(string name)
        {
            // Регулярное выражение для поиска слов, разделённых пробелами
            // или дефисами
            return Regex.Replace(name.ToLower(), @"\b(\w)",
                m => m.Value.ToUpper());
        }

        //TODO: encapsulation +
        /// <summary>
        /// Проверка для ввода возраста
        /// </summary>
        /// <param name="age">Возраст для проверки</param>
        /// <returns>Корректный возраст</returns>
        private static int CheckingAge(int age)
        {
            if (age < 0 || age > AgeMax)
            {
                throw new Exception("Age must not be " +
                    "a negative and must not exceed " +
                    $"{AgeMax} years!");
            }
            else
            {
                return age;
            }
        }
                
        /// <summary>
        /// Вывод информации о человеке
        /// </summary>
        public string Info
        {
            get
            {
                return $"{Name} {Surname}, Age: {Age}, Gender: {Gender}";
            }
        }
    }
}
