using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LaborBook.Model;

namespace LaborBook
{
    public partial class EmployeeForm : Form
    {
        Employee employee;
        

        public EmployeeForm()
        {
            InitializeComponent();
            btnPersDel.Enabled = false;
        }

        // Конструктор для создания нового работника
        public EmployeeForm(Employee newEmployee)
        {
            InitializeComponent();

            // Отключение кнопки удаления сотрудника
            btnPersDel.Enabled = false;

            this.employee = newEmployee;
            this.FirstName = newEmployee.FirstName;
            this.LastName = newEmployee.LastName;
        }

        // Конструктор для отображения существующего работника
        public EmployeeForm(Employee existingEmployee, bool flag)
        {
            InitializeComponent();

            // Заполняет поля формы работника для последующего редактирования, если истина
            if (flag)
            {
                this.employee = existingEmployee;
                this.FirstName = existingEmployee.FirstName;
                this.LastName = existingEmployee.LastName;
                this.Flag = false;
            }  
        }

        #region <!--Properties-->
        public bool Flag { get; private set; }
        public bool DelCurrentEmployee { get; private set; }

        public string FirstName
        {
            get { return tbxFirstName.Text; }
            set { tbxFirstName.Text = value; }
        }

        public string LastName
        {
            get { return tbxLastName.Text; }
            set { tbxLastName.Text = value; }
        }

        public string Patronymic
        {
            get { return tbxPatronymic.Text; }
            set { tbxPatronymic.Text = value; }
        }

        public string Birthday
        {
            get { return tbxBirthday.Text; }
            set { tbxBirthday.Text = value; }
        }

        public string Education
        {
            get { return tbxEdu.Text; }
            set { tbxEdu.Text = value; }
        }

        public string EducationDegree
        {
            get { return tbxEduDegree.Text; }
            set { tbxEduDegree.Text = value; }
        }

        public string DateRegistrarion
        {
            get { return tbxDateReg.Text; }
            set { tbxDateReg.Text = value; }
        }
        #endregion

        private void btnPersOk_Click(object sender, EventArgs e)
        {
            if (FirstName != "" && LastName != "")
            {
                employee.FirstName = this.FirstName;
                employee.LastName = this.LastName;
                this.Flag = true; //указывает на необходимость создания/изменения формы
                this.Close();
            }
        }

        private void btnPersDel_Click(object sender, EventArgs e)
        {
            DelCurrentEmployee = true;
            this.Close();
        }
    }
}
