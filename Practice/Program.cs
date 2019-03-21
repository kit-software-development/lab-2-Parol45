using Practice.Common;
using Practice.HR;
using Practice.Organization;
using System;

namespace Practice
{
    /// <summary>
    ///     Цели работы:
    ///     1. на практике познакомиться с механизмом наследования;
    ///     2. научиться использовать полиморфизм;
    ///     3. научиться разделять контексты;
    ///     4. научиться использовать инкапсуляцию на уровне библиотеки;
    ///     5. научиться использовать абстрактные типы данных.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            IClient client = Builders.ClientBuilder()
                .Name("Иванов", "Иван", "Иванович") 
                .Discount(.1f)
                .Build();

            IEmployee employee = Builders.EmployeeBuilder()
                .Name("Сидоров", "Григорий", "Петрович")
                .Department("Бухгалтерия")
                .Build();

            client.Name = new Name("Даб", "Даб", "Я");
            Console.WriteLine();
            employee.Name = new Name("Даб", "Даб", "Я");
            employee.Department = new Department("Твич");

            /*
             * Оно собралось!
             */

            /*
             * Всё работает как часы, за исключением свойства Name в AbstractPerson с типом интерфейса IName,
             *  из-за которого каждый раз вызывается два конструктора Name. Не знаю, как исправить.
             */
            Console.ReadKey();
        }
    }
}
