using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Portable.Data.Sqlite;

namespace PatientCheckUp.Models {
    public class Patient : EncryptedTableItem {

        private string _firstName;
        private string _lastName;
        private char _gender = 'U';
        private Nullable<DateTime> _dob;

        [Searchable]
        public string FirstName {
            get { return _firstName; }
            set { _firstName = SetChanged(value); }
        }

        [Searchable]
        public string LastName {
            get { return _lastName; }
            set { _lastName = SetChanged(value); }
        }

        public char Gender {
            get { return _gender; }
            set { _gender = SetChanged(value); }
        }

        public Nullable<DateTime> Dob {
            get { return _dob; }
            set { _dob = SetChanged(value); }
        }

        public string Description {
            get {
                return String.Format("Name: {0}, {1} ({2}) - DOB: {3}",
                    _lastName, _firstName, _gender, (_dob.HasValue ?
                    _dob.Value.ToString("M/d/yyyy") : ""));
            }
            set { }
        }

    }
}
