using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Portable.Data.Sqlite;

using PatientCheckup.Models;

namespace PatientCheckup.ViewModels {
    public class NotesViewModel : INotifyPropertyChanged {

        private Patient _patient;
        private INavigation _navigation;

        public NotesViewModel(INavigation navigation, Patient patient) {
            _navigation = navigation;
            _patient = patient;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string name) {
            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        private string _pageTitle = "Patient Notes";
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

        private ObservableCollection<CheckupNote> _notes = new ObservableCollection<CheckupNote>();
        public ObservableCollection<CheckupNote> Notes {
            get { return _notes; }
            set { _notes = (value == null) ? new ObservableCollection<CheckupNote>() : value; }
        }

        public void GetNoteList() {
            var notesTable = new EncryptedTable<CheckupNote>(App.CryptEngine, App.DatabaseConnection);
            var _tempNotes = new ObservableCollection<CheckupNote>();
            var notesSearch = new TableSearch();
            notesSearch.MatchItems.Add(new TableSearchItem("PatientId", _patient.Id.ToString()));
            foreach (CheckupNote note in notesTable.GetItems(notesSearch).OrderByDescending(n => n.Timestamp)) {
                _tempNotes.Add(note);
            }
            _notes = _tempNotes;
            OnPropertyChanged("Notes");
        }

        public void ShowNotePage(CheckupNote note) {
            if (note != null) {
                //_navigation.PushAsync(new PatientPage(patient));
            }
        }

        private Command addNoteCommand;
        public Command AddNoteCommand {
            get {
                return addNoteCommand ?? (addNoteCommand = new Command(DoAddNoteCommand));
            }
        }

        private void DoAddNoteCommand() {
            _navigation.PushAsync(new AddNotePage(_patient, this));
        }
    }
}
