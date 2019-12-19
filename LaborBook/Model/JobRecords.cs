using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaborBook.Model
{
    [Serializable]
    public class JobRecords
    {
        // Automatically change when adding a new one
        public int RecordNumber { get; set; } 

        public string Date { get; set; }

        // Recruitment, dismissal, moving to
        public string Description { get; set; } 

        public string Position { get; set; }

        public string ConfirmDoc { get; set; }

        public string DisplayInfo
        {
            get { return $"{RecordNumber} - {Position}"; }
        }
    }
}