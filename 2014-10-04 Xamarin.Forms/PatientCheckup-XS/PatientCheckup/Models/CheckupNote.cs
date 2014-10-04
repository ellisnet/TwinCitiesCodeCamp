using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Portable.Data.Sqlite;

namespace PatientCheckup.Models {
    public class CheckupNote : EncryptedTableItem {

        private long _patientId = -1;
        private long _userId = -1;
        private string _comment = "";
        private DateTime _timestamp = DateTime.Now;

        [Searchable]
        public long PatientId {
            get { return _patientId; }
            set { _patientId = SetChanged(value); }
        }

        [Searchable]
        public long UserId {
            get { return _userId; }
            set { _userId = SetChanged(value); }
        }

        public string Comment {
            get { return _comment; }
            set { _comment = SetChanged((value ?? "").Trim()); }
        }

        public DateTime Timestamp {
            get { return _timestamp; }
            set { _timestamp = SetChanged(value); }
        }

        public string Description {
            get {
                return _timestamp.ToString() + " - " + _comment;
            }
            set { }
        }
    }
}
