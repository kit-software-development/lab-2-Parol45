using Practice.Common;
using Practice.HR.Events;
using System;

namespace Practice.HR
{
    /// <summary>
    ///     Абстрактная база для описания конкретных реализаций типа "Человек".
    ///     Используется для дальнейшего наследования.
    /// </summary>
    internal abstract class AbstractPerson : IPerson
    {

        // От AbstractPerson зависит и Client, но у него нет отдела как такового, 
        // поэтому я удалил отсюда Department: всё равно он есть в IEmployee.

        private Name name;

        // По идее Name реализует IName, но почему тогда нельзя конкретизировать
        // для реализуемого свойства?
        public IName Name
        {
            get
            {
                return name;
            }

            set
            {
                ValueChangeEventArgs<IName> args = new ValueChangeEventArgs<IName>(name);
                NameChange?.Invoke(this, args);
                name = new Name(value);
            }
        }

        public event EventHandler<ValueChangeEventArgs<IName>> NameChange;

    }
}
