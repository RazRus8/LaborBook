using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;
using LaborBook.Model;
using LaborBook.Actions;

namespace LaborBook
{
    // BackLog
    // TO DO LIST()

    [Serializable]
    public partial class MainForm : Form
    {
        // Main collection 
        private BindingList<Employee> persons = new BindingList<Employee>();

        // Путь к расположению файла, указанный в диалоговом окне при сохраниении/открытии
        string path;

        public MainForm()
        {
            InitializeComponent();          
        }

        /// <summary>
        /// Это событие используется для отключения возможности изменять размер полей в List View
        /// </summary>
        private void listView_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.Cancel = true;
            e.NewWidth = employeeListView.Columns[e.ColumnIndex].Width;
        }

        private void btnAddEmp_Click(object sender, EventArgs e)
        {
            Employee newEmployee = new Employee();
            EmployeeForm newPersonForm = new EmployeeForm(newEmployee);
            newPersonForm.Text = "Create new Empoloyee";
            newPersonForm.ShowDialog();

            // Если была нажата кнопка ОК, то объект работника добавляется в коллекцию работников
            // If 
            if (newPersonForm.Flag) 
            {
                newEmployee.Id = persons.Count + 1;
                persons.Add(newEmployee);
                comboBox1.DataSource = persons;
                
                //TO DO...
                comboBox1.DisplayMember = "FullName";

                comboBox1.SelectedIndex = persons.Count - 1;
            }

            //if (newPersonForm.ShowDialog() != DialogResult.OK)
            //{
            //    newEmployee.Id = persons.Count + 1;
            //    persons.Add(newEmployee);
            //    comboBox1.DataSource = persons;

            //    //TO DO...
            //    comboBox1.DisplayMember = "FullName";

            //    comboBox1.SelectedIndex = persons.Count - 1;
            //}
        }

        private void btnAddRec_Click(object sender, EventArgs e)
        {
            // Если есть хотя бы один работник в коллекции
            if (comboBox1.SelectedIndex > -1)
            {
                JobRecords newJobRecord = new JobRecords();
                JobForm newJobForm = new JobForm(newJobRecord);
                newJobForm.Text = "Create new Record";
                newJobForm.ShowDialog();

                // Если была нажата кнопка ОК, то объект записей добавляется в коллекцию записей выбранного работника
                if (newJobForm.Flag)
                {
                    newJobRecord.RecordNumber = persons[comboBox1.SelectedIndex].JobRecords.Count + 1;
                    persons[comboBox1.SelectedIndex].JobRecords.Add(newJobRecord);
                    comboBox2.DataSource = persons[comboBox1.SelectedIndex].JobRecords;

                    //TO DO...
                    comboBox2.DisplayMember = "DisplayInfo";

                    comboBox2.SelectedIndex = persons[comboBox1.SelectedIndex].JobRecords.Count - 1;

                    // Если у работника только одна запись, то происходит вызов события обновления виртуального списка
                    if (persons[comboBox1.SelectedIndex].JobRecords.Count == 1)
                    {
                        employeeListView.VirtualListSize = persons[comboBox1.SelectedIndex].JobRecords.Count;
                        employeeListView.Invalidate();
                    }
                }

                //if (newJobForm.ShowDialog() != DialogResult.OK)
                //{
                //    newJobRecord.RecordNumber = persons[comboBox1.SelectedIndex].JobRecords.Count + 1;
                //    persons[comboBox1.SelectedIndex].JobRecords.Add(newJobRecord);
                //    comboBox2.DataSource = persons[comboBox1.SelectedIndex].JobRecords;

                //    //TO DO...
                //    comboBox2.DisplayMember = "DisplayInfo";

                //    comboBox2.SelectedIndex = persons[comboBox1.SelectedIndex].JobRecords.Count - 1;

                //    // Если у работника только одна запись, то происходит вызов события обновления виртуального списка
                //    if (persons[comboBox1.SelectedIndex].JobRecords.Count == 1)
                //    {
                //        employeeListView.VirtualListSize = persons[comboBox1.SelectedIndex].JobRecords.Count;
                //        employeeListView.Invalidate();
                //    }
                //}
            }

            // Если нет ни одного работника в коллекции
            else
            {
                MessageBox.Show("Add at least one Employee", "Error");
            }
        }

        private void comboBox1_DataSourceChanged(object sender, EventArgs e)
        {
            comboBox1.DataSource = persons;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (persons.Count > 0)
            {
                if (persons[comboBox1.SelectedIndex].JobRecords.Count == 0)
                {
                    comboBox2.SelectedIndex = -1;
                    comboBox2.DataSource = null;

                    // указывает, должны ли изменяться размеры combobox, чтобы избежать частичного отображения элементов
                    comboBox2.IntegralHeight = false;
                }
                else
                {
                    comboBox2.IntegralHeight = true;
                    comboBox2.DataSource = persons[comboBox1.SelectedIndex].JobRecords;
                    comboBox2.DisplayMember = "DisplayInfo";
                }

                // По умолчанию устанавливается нулевое значение для размера виртуального листа
                employeeListView.VirtualListSize = 0;
                employeeListView.Invalidate();

                // Если у работника присутствует хотя бы одна запись, в вирутальный лист заносится выбранная
                if (persons[comboBox1.SelectedIndex].JobRecords.Count > 0)
                {
                    employeeListView.VirtualListSize = 1;
                    employeeListView.Invalidate();
                }
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (persons[comboBox1.SelectedIndex].JobRecords.Count == 0)
            {
                employeeListView.VirtualListSize = 0;
                employeeListView.Invalidate();
            }
            else
            {
                employeeListView.VirtualListSize = 1;
                employeeListView.Invalidate();
            }
        }

        /// <summary>
        /// Это событие срабатывает при вызове employeeListView.Invalidate() и заполняет employeeListView значениями из VirtualList
        /// </summary>
        private void employeeListView_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            if (e.ItemIndex >= 0 && e.ItemIndex < persons[comboBox1.SelectedIndex].JobRecords.Count)
            {
                e.Item = new ListViewItem(persons[comboBox1.SelectedIndex].JobRecords[comboBox2.SelectedIndex].RecordNumber.ToString());
                e.Item.SubItems.Add(persons[comboBox1.SelectedIndex].JobRecords[comboBox2.SelectedIndex].Date);
                e.Item.SubItems.Add(persons[comboBox1.SelectedIndex].JobRecords[comboBox2.SelectedIndex].Description);
                e.Item.SubItems.Add(persons[comboBox1.SelectedIndex].JobRecords[comboBox2.SelectedIndex].Position);
                e.Item.SubItems.Add(persons[comboBox1.SelectedIndex].JobRecords[comboBox2.SelectedIndex].ConfirmDoc);
            }
        }

        private void toolStripOpen_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Open an XML file";
            openFileDialog1.Filter = "XML Documents|*.xml";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    path = openFileDialog1.FileName;

                    using (FileStream fStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.None))
                    {
                        XmlSerializer xmlSerializer = new XmlSerializer(typeof(BindingList<Employee>));
                        BindingList<Employee> employees = (BindingList<Employee>)xmlSerializer.Deserialize(fStream);

                        persons.Clear();
                        BindList.AddRange(employees, persons);

                        comboBox1.DataSource = persons;
                        comboBox1.DisplayMember = "FullName";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void toolStripSaveAs_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Title = "Save an XML file";
            saveFileDialog1.FileName = "Untitled";
            saveFileDialog1.Filter = "XML Documents|*.xml";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    path = saveFileDialog1.FileName;

                    using (FileStream fStream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None))
                    {
                        XmlSerializer xmlSerializer = new XmlSerializer(typeof(BindingList<Employee>));
                        xmlSerializer.Serialize(fStream, persons);
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void toolStripSave_Click(object sender, EventArgs e)
        {
            if (path != null)
            {
                using (FileStream fStream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(BindingList<Employee>));
                    xmlSerializer.Serialize(fStream, persons);
                }
            }
            else
            {
                toolStripSaveAs_Click(sender, e);
            }

        }

        private void toolStripExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEditEmp_Click(object sender, EventArgs e)
        {
            // Если есть хотя бы один работник в коллекции
            if (comboBox1.SelectedIndex > -1)
            {
                // Указывает на то, что данные о работнике будут изменяться, вызывается другой конструктор
                bool flag = true;
                Employee existingEmployee = persons[comboBox1.SelectedIndex];
                EmployeeForm newPersonForm = new EmployeeForm(existingEmployee, flag);
                newPersonForm.Text = "Edit existing Empoloyee";
                newPersonForm.ShowDialog();

                // Если была нажата кнопка OK
                if (newPersonForm.Flag)
                {
                    //TO DO...
                    persons.Add(existingEmployee);
                    persons.Remove(existingEmployee);

                    comboBox1.DataSource = persons;

                    //TO DO...
                    comboBox1.DisplayMember = "FullName";

                    comboBox1.SelectedIndex = persons.Count - 1;
                }

                // Если была нажата кнопка удаления работника
                if (newPersonForm.DelCurrentEmployee)
                {
                    // Удаление всех записей работника
                    persons[comboBox1.SelectedIndex].JobRecords.Clear();

                    // Удаление самого работника
                    persons.Remove(existingEmployee);

                    // Вызов события изменения в combobox
                    comboBox1_SelectedIndexChanged(sender, e);
                }
            }
            
            // Если нет ни одного работника в коллекции
            else
            {
                MessageBox.Show("Add at least one Employee", "Error");
            }
        }

        private void btnEditRec_Click(object sender, EventArgs e)
        {
            // Если есть хотя бы один работник
            if (comboBox1.SelectedIndex > -1 && comboBox2.SelectedIndex > -1)
            {
                // Указывает на то, что данные о работнике будут изменяться, вызывается другой конструктор
                bool flag = true;
                JobRecords existingRecord = persons[comboBox1.SelectedIndex].JobRecords[comboBox2.SelectedIndex];
                JobForm newJobForm = new JobForm(existingRecord, flag);
                newJobForm.Text = "Edit existing Record";
                newJobForm.ShowDialog();

                // Если была нажата кнопка OK
                if (newJobForm.Flag)
                {
                    //TO DO...
                    persons[comboBox1.SelectedIndex].JobRecords.Add(existingRecord);
                    persons[comboBox1.SelectedIndex].JobRecords.Remove(existingRecord);

                    comboBox2.DataSource = persons[comboBox1.SelectedIndex].JobRecords;

                    //TO DO...
                    comboBox2.DisplayMember = "DisplayInfo";

                    comboBox2.SelectedIndex = persons[comboBox1.SelectedIndex].JobRecords.Count - 1;

                    employeeListView.VirtualListSize = 1;
                    employeeListView.Invalidate();
                }

                // Если была нажата кнопка удаления записи
                if (newJobForm.DelCurrentRecord)
                {
                    persons[comboBox1.SelectedIndex].JobRecords.Remove(existingRecord);

                    if (persons[comboBox1.SelectedIndex].JobRecords.Count == 0)
                    {
                        employeeListView.VirtualListSize = 0;
                        employeeListView.Invalidate();
                    }
                    else
                    {
                        employeeListView.VirtualListSize = 1;
                        employeeListView.Invalidate();
                    }
                }
            }
            else
            {
                MessageBox.Show("Add at least one Employee and Record", "Error");
            }
        }

        private void toolStripCreateNew_Click(object sender, EventArgs e)
        {
            btnAddEmp_Click(sender, e);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            var result = MessageBox.Show("Save changes?", "Labor book", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            switch (result)
            {
                case DialogResult.Yes:
                    toolStripSave_Click(sender, e);
                    break;
                case DialogResult.Cancel:
                    e.Cancel = true;
                    break;
                default:
                    break;
            }
        }
    }
}