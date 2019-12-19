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
    public partial class JobForm : Form
    {
        JobRecords jobRecord;

        public JobForm()
        {
            InitializeComponent();
        }

        // Конструктор для создания новой записи для работника
        public JobForm(JobRecords newJobRecord)
        {
            InitializeComponent();

            // Отключение кнопки удаления записи сотрудника
            btnJobDel.Enabled = false;

            this.jobRecord = newJobRecord;
            this.Position = jobRecord.Position;
        }

        // Конструктор для отображения существующей записи работника
        public JobForm(JobRecords existingJobRecord, bool flag)
        {
            InitializeComponent();

            // Заполняет поля формы записи работника для последующего редактирования, если истина
            if (flag)
            {
                this.jobRecord = existingJobRecord;
                this.Position = existingJobRecord.Position;
                this.Flag = false;
            }
        }

        #region <!-- Properties -->
        public bool Flag { get; set; }
        public bool DelCurrentRecord { get; private set; }

        public string RecordNumber { get; set; }

        public string Date
        {
            get { return tbxDate.Text; }
            set { tbxDate.Text = value; }
        }

        public string JobNote
        {
            get { return tbxJobNote.Text; }
            set { tbxJobNote.Text = value; }
        }

        public string Position
        {
            get { return tbxPosition.Text; }
            set { tbxPosition.Text = value; }
        }

        public string Document
        {
            get { return tbxDoc.Text; }
            set { tbxDoc.Text = value; }
        }

        #endregion

        private void btnJobOk_Click(object sender, EventArgs e)
        {
            if (Position != "")
            {
                jobRecord.Position = this.Position;
                this.Flag = true;
                this.Close();
            }
        }

        private void btnJobDel_Click(object sender, EventArgs e)
        {
            DelCurrentRecord = true;
            this.Close();
        }
    }
}
