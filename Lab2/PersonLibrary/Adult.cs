﻿using System;
using System.Text.RegularExpressions;

namespace PersonLibrary
{
    /// <summary>
    /// Взрослый человек
    /// </summary>
    public class Adult : Person
    {
        /// <summary>
        /// Минимальный возраст
        /// </summary>
        public const int MinAdultAge = 18;

        /// <summary>
        /// Максимальный возраст
        /// </summary>
        public const int MaxAdultAge = 100;

        /// <summary>
        /// Возраст
        /// </summary>
        public override int Age
        {
            get
            {
                return _age;
            }
            set
            {
                if (!(value > MinAdultAge) && !(value <= MaxAdultAge))
                {
                    throw new ArgumentOutOfRangeException(
                        $"Sorry, the age must be between {MinAdultAge} and {MaxAdultAge} years.");
                }
                _age = value;
            }
        }

        /// <summary>
        /// Поле паспортных данных
        /// </summary>
        private string _passport;

        /// <summary>
        ///Максимальное кол-во данных 
        /// </summary>
        public const int MaxLengthPassport = 10;

        /// <summary>
		/// Паспорт
		/// </summary>
        public string Passport
        {
            get => _passport;
            set
            {
                const string pattern = @"\D";
                Regex regex = new Regex(pattern);
                if (value.Length != MaxLengthPassport || regex.IsMatch(value.ToString()))
                {
                    throw new ArgumentException($"Passport must" +
                        $" contain {MaxLengthPassport} digits!");
                }
                _passport = value;
            }
        }

        /// <summary>
        /// Семейное положение
        /// </summary> 
        public MaritalStatus MaritalStatus { get; set; }

        /// <summary>
        /// Супруг
        /// </summary>
        private Adult _partner;

        /// <summary>
        /// Супруг(а)
        /// </summary>
        public Adult Partner
        {
            get
            {
                return _partner;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(
                        $"{nameof(Partner)}", $"{nameof(Partner)} value is" +
                        " null!");
                }
                if (MaritalStatus == MaritalStatus.Married &&
                    value.MaritalStatus == MaritalStatus.Married)
                {
                    _partner = value;
                }
                else
                {
                    throw new ArgumentException(
                        "Something went wrong." +
                        "Please check marital statuses both of partners!");
                }
            }
        }

        /// <summary>
        /// Информация о месте работы
        /// </summary>
        public string Job { get; set; }

        /// <summary>
        /// Получение информации о взрослом человеке
        /// </summary>
        /// <returns></returns>
        public override string Info
        {
            get
            {
                var personInfo = base.Info +
                    $"\nPassport Data: {Passport}" +
                    $"\nMaritial Status: {MaritalStatus}";
                if (MaritalStatus == MaritalStatus.Married)
                {
                    personInfo += $"\nSpouse: {Partner.Name} " +
                        $"{Partner.Surname}";
                }
                personInfo += "\nPlace of work: ";
                if (string.IsNullOrEmpty(Job))
                {
                    personInfo += "Unemployed";
                }
                else
                {
                    personInfo += Job;
                }
                return personInfo;
            }
        }

        /// <summary>
        /// Идти на работу
        /// </summary>
        /// <returns>Взрослый ушел на работу</returns>
        public string GoToWork()
        {
            return $"\n{ShortInfoAboutPerson} is going to work";
        }

    }
}
