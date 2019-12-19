using System;
using System.ComponentModel;
using System.Collections.Generic;

namespace LaborBook.Model
{
    [Serializable]
    public class Employee
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Patronymic { get; set; } //name of father

        public string Birthday { get; set; }

        public string Education { get; set; }

        public string EducationDegree { get; set; }

        public string DateReg { get; set; }

        public string FullName
        {
            get { return $"{FirstName} {LastName}"; }
        } //for representing in the combobox

        public BindingList<JobRecords> JobRecords { get; set; }

        public Employee()
        {
            JobRecords = new BindingList<JobRecords>();
        }
    }
}