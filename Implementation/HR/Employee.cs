using Practice.HR.Events;
using Practice.Organization;
using System;

namespace Practice.HR
{
    /// <summary>
    ///     Скрытая реализация представления о сотруднике.
    /// </summary>
    internal class Employee : AbstractPerson, IEmployee
    {
        Department department;

        // Та же проблема, что и в AbstractPerson с IName
        public IDepartment Department
        {
            get { return department; }
            set
            {
                ValueChangeEventArgs<IDepartment> args = new ValueChangeEventArgs<IDepartment>(Department);
                DepartmentChange?.Invoke(this, args);
                department = new Department(value);
            }
        }

        public event EventHandler<ValueChangeEventArgs<IDepartment>> DepartmentChange;

    }
}
