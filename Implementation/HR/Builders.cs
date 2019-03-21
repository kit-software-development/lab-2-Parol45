using Practice.Common;
using Practice.HR.Events;
using Practice.Organization;
using System;

namespace Practice.HR
{
    /// <summary>
    ///     Класс-фабрика, позволяющий получать экземпляры типов,
    ///     инкапсулированных на уровне библиотеки.
    /// </summary>
    public static class Builders
    {
        /// <summary>
        ///     Возвращает экземпляр "Строителя" клиентов.
        /// </summary>
        /// <returns>
        ///     Экземпляр типа IClientBuilder.
        /// </returns>
        public static IClientBuilder ClientBuilder()
        {
            return new IClientBuilderImplementation();
        }
        private class IClientBuilderImplementation : IClientBuilder
        {
            private IClient client = new Client();
            public IClientBuilder Name(IName name)
            {
                client.Name = new Name(name);
                client.NameChange += onNameChange;
                return this;
            }
            public IClientBuilder Name(string name, string surname, string patronymic)
            {
                client.Name = new Name(name, surname, patronymic);
                client.NameChange += onNameChange;
                return this;
            }
            public IClientBuilder Discount(float discount)
            {
                client.Discount = discount;
                return this;
            }
            private void onNameChange(object sender, ValueChangeEventArgs<IName> args)
            {
                Console.WriteLine("Old client's name: {0} has been changed!", args.OldValue.FullName);
            }
            public IClient Build()
            {
                return client;
            }
        }
        /// <summary>
        ///     Возвращает экземпляр "Строителя" сотудников.
        /// </summary>
        /// <returns>
        ///     Возвращает экземпляр типа IEmployeeBuilder.
        /// </returns>
        public static IEmployeeBuilder EmployeeBuilder()
        {
            return new IEmployeeBuilderImplementation();
        }
        private class IEmployeeBuilderImplementation : IEmployeeBuilder
        {
            private IEmployee employee = new Employee();
            public IEmployeeBuilder Name(IName name)
            {
                employee.Name = new Name(name);
                employee.NameChange += onNameChange;
                return this;
            }
            public IEmployeeBuilder Name(string name, string surname, string patronymic)
            {
                employee.Name = new Name(name, surname, patronymic);
                employee.NameChange += onNameChange;
                return this;
            }
            public IEmployeeBuilder Department(IDepartment department)
            {
                employee.Department = new Department(department);
                return this;
            }
            public IEmployeeBuilder Department(string department)
            {
                employee.Department = new Department(department);
                employee.DepartmentChange += onDepartmentChange;
                return this;
            }
            private void onNameChange(object sender, ValueChangeEventArgs<IName> args)
            {
                Console.WriteLine("Old employee's name: {0} has been changed!", args.OldValue.FullName);
            }
            private void onDepartmentChange(object sender, ValueChangeEventArgs<IDepartment> args)
            {
                Console.WriteLine("Old employee's department: {0} has been changed!", args.OldValue.Name);
            }
            public IEmployee Build()
            {
                return employee;
            }
        }
    }
}
