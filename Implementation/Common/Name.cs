namespace Practice.Common
{
    /// <summary>
    ///     Скрытая реализация представления об имени человека.
    /// </summary>
    internal struct Name : IName
    {
        /// <summary>
        ///     Полное имя.
        /// </summary>
        public string FullName { get; }

        /// <summary>
        ///     Имя + инициалы.
        /// </summary>
        public string ShortName { get; }

        /// <summary>
        ///     Имя.
        /// </summary>
        public string FirstName { get; }

        /// <summary>
        ///     Фамилия.
        /// </summary>
        public string Surname { get; }

        /// <summary>
        ///     Отчество.
        /// </summary>
        public string Patronymic { get; }

        public Name(string name, string surname, string patronymic)
        {
            FullName = name + ' ' + surname + ' ' + patronymic;
            ShortName = name + ' ' + surname[0] + ". " + patronymic[0] + '.';
            FirstName = name;
            Surname = surname;
            Patronymic = patronymic;
        }
        public Name(IName name)
        {
            FullName = name.FullName;
            ShortName = name.ShortName;
            int temp = FullName.IndexOf(' ');
            FirstName = FullName.Substring(0, temp);
            Surname = FullName.Substring(temp + 1, FullName.IndexOf(' ', temp + 1) - temp);
            temp = FullName.IndexOf(' ', temp + 1);
            Patronymic = FullName.Substring(temp + 1);
        }
    }
}
