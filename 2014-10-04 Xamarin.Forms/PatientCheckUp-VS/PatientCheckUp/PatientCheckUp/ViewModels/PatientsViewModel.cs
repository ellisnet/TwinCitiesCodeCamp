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
    public class PatientsViewModel : INotifyPropertyChanged {

        private INavigation _navigation;

        public PatientsViewModel(INavigation navigation) {
            _navigation = navigation;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string name) {
            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        private string _pageTitle = "Patients";
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

        private ObservableCollection<Patient> _patients = new ObservableCollection<Patient>();
        public ObservableCollection<Patient> Patients {
            get { return _patients; }
            set { _patients = (value == null) ? new ObservableCollection<Patient>() : value; }
        }

        public void GetPatientList() {
            var patientTable = new EncryptedTable<Patient>(App.CryptEngine, App.DatabaseConnection);
            var _tempPatients = new ObservableCollection<Patient>();
            foreach (Patient pt in patientTable.GetItems(new TableSearch()).OrderBy(p => p.LastName)) {
                _tempPatients.Add(pt);
            }
            _patients = _tempPatients;
            OnPropertyChanged("Patients");
        }

        public void ShowNotesPage(Patient patient) {
            if (patient != null) {
                _navigation.PushAsync(new NotesPage(patient));
            }
        }

    }
}
