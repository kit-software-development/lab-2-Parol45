namespace Practice.Organization
{
    /// <summary>
    ///     Скрытая реализация представления об отделе предприятия.
    /// </summary>
    internal struct Department : IDepartment
    {
        public string Name { get; }

        public Department(string name)
        {
            Name = name;
        }
        public Department(IDepartment department)
        {
            Name = department.Name;
        }
    }
}
