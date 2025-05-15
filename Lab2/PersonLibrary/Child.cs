using System;

namespace PersonLibrary
{
    /// <summary>
    /// Ребенок
    /// </summary>
    public class Child : Person
    {
        /// <summary>
        /// Наименьший возраст 
        /// </summary>
        public const int MinChildAge = 0;

        /// <summary>
        /// Максимальный возраст 
        /// </summary>
        public const int MaxChildAge = 17;

        /// <summary>
        /// Проверка возраста ребенка
        /// </summary>
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
                if (!(value > MinChildAge) && !(value <= MaxChildAge))
                {
                    throw new ArgumentOutOfRangeException(
                        $"Sorry, the age must be between" +
                        $" {MinChildAge} and {MaxChildAge} years.");
                }
                _age = value;
            }
        }

        /// <summary>
        /// Мать
        /// </summary>
        public Adult ParentOne { get; set; }

        /// <summary>
        /// Отец
        /// </summary>
        public Adult ParentTwo { get; set; }

        /// <summary>
        /// Название детского сада или школы
        /// </summary>
        public string School { get; set; }


        /// <summary>
        /// Информация о ребёнке
        /// </summary>
        /// <returns>Информация о ребенке</returns>
        public override string Info
        {
            get
            {
                var personInfo = base.Info;
                if (ParentOne != null)
                {
                    personInfo += $"\nParent one:" +
                        $" {ParentOne.Name} {ParentOne.Surname} ";
                }
                if (ParentTwo != null)
                {
                    personInfo += $"\nParent two:" +
                        $" {ParentTwo.Name} {ParentTwo.Surname} ";
                }
                if (ParentOne == null && ParentTwo == null)
                {
                    personInfo += "\nOrphan";
                }
                if (School != null)
                {
                    personInfo += $"\nSchool: {School}";
                }
                return personInfo;
            }
        }

        /// <summary>
        /// Смотреть мультики
        /// </summary>
        /// <returns>ребенок смотрит мульт</returns>
        public string WatchCartoons()
        {
            return $"{ShortInfoAboutPerson} is watching cartoons";
        }
    }
}
