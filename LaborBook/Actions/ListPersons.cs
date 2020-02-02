using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using LaborBook.Model;

namespace LaborBook.Actions
{
    [Serializable]
    class ListPersons
    {
        //private BindingList<Employee> persons = new BindingList<Employee>();

        public BindingList<Employee> Persons { get; set; }

        public ListPersons()
        {
            Persons = new BindingList<Employee>();
        }
    }
}
