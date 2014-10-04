using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Portable.Data.Sqlite;

namespace PatientCheckUp.Models {
    public class AppUser : EncryptedTableItem {

        private string _username;
        private string _password;

        [Searchable]
        public string Username {
            get { return _username; }
            set { _username = SetChanged(value); }
        }

        public string Password {
            get { return _password; }
            set { _password = SetChanged(value); }
        }

    }
}
