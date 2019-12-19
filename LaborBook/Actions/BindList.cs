using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using LaborBook.Model;

namespace LaborBook.Actions
{
    class BindList
    {
        // Метод, позволяющий добавить несколько объектов в коллекцию
        public static void AddRange(BindingList<Employee> source, BindingList<Employee> outcome)
        {
            if (source.Count > 0)
            {
                foreach (Employee epm in source)
                {
                    outcome.Add(epm);
                }
            }
        }
    }
}
