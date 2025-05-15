using System;
using System.Text.RegularExpressions;

namespace PersonLibrary
{
    //TODO: RSDN
        /// <summary>
        /// Класс, представляющий человека (Person).
        /// Содержит информацию о имени, фамилии, возрасте и поле.
        /// </summary>
        public abstract class PersonBase
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
            protected int _age;

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
                }
            }


            /// <summary>
            /// Возраст 
            /// </summary>
            public abstract int Age { get; set; }

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
            public PersonBase(string name, string surname, int age, Gender gender)
            {
                Name = name;
                Surname = surname;
                Age = age;
                Gender = gender;
            }

            /// <summary>
            /// Конструктор по умолчанию
            /// </summary>
            public PersonBase() : this("John", "Doe", 99, Gender.Male) { }

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

            /// <summary>
            /// Вывод информации о человеке
            /// </summary>
            public virtual string Info => $"{Name} {Surname}, Age: {Age}, Gender: {Gender}";

            /// <summary>
            /// Имя и фамилия
            /// </summary>
            /// <returns>Строка с информацией</returns>
            public string ShortInfoAboutPerson => $"{Name} {Surname}";
        }
}

