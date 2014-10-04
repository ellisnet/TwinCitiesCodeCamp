using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Portable.Data.Sqlite;

using PatientCheckUp.Models;
using PatientCheckUp.Views;

namespace PatientCheckUp.ViewModels {
    public class AddNoteViewModel : INotifyPropertyChanged {

        private Patient _patient;
        private INavigation _navigation;
        private NotesViewModel _parentViewModel;

        public AddNoteViewModel(INavigation navigation, Patient patient, NotesViewModel parentViewModel) {
            _navigation = navigation;
            _patient = patient;
            _parentViewModel = parentViewModel;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string name) {
            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        private string _pageTitle = "Add Checkup Note";
        public string PageTitle {
            get { return _pageTitle; }
            set {
                value = (value ?? "").Trim();
                if (value != _pageTitle) {
                    _pageTitle = value;
                    OnPropertyChanged("PageTitle");
                }
            }
        }

        private DateTime _timestamp = DateTime.Now;
        public DateTime Timestamp {
            get { return _timestamp; }
            set { 
                _timestamp = value;
                OnPropertyChanged("Timestamp");
            }
        }

        private string _comment = "";
        public string Comment {
            get { return _comment; }
            set {
                value = (value ?? "").Trim();
                if (value != _comment) {
                    _comment = value;
                    OnPropertyChanged("Comment");
                }
            }
        }

        private Command addNoteCommand;
        public Command AddNoteCommand {
            get {
                return addNoteCommand ?? (addNoteCommand = new Command(DoAddNoteCommand));
            }
        }

        private void DoAddNoteCommand() {
            var newNote = new CheckupNote {
                PatientId = _patient.Id,
                UserId = App.User.Id,
                Timestamp = DateTime.Now,
                Comment = _comment
            };
            var notesTable = new EncryptedTable<CheckupNote>(App.CryptEngine, App.DatabaseConnection);
            notesTable.AddItem(newNote, true);
            _parentViewModel.GetNoteList();
            _navigation.PopAsync();
        }
    }
}
