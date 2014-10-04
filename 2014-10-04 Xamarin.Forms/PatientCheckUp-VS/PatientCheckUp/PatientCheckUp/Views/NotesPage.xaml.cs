using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

using PatientCheckUp.ViewModels;
using PatientCheckUp.Models;

namespace PatientCheckUp.Views {
    public partial class NotesPage {

        private NotesViewModel _viewModel;
        private Patient _patient;

        public NotesPage(Patient patient) {
            _patient = patient;
            InitializeComponent();
            _viewModel = new NotesViewModel(Navigation, _patient);
            this.BindingContext = _viewModel;
            _viewModel.GetNoteList();
        }

        private void OnNoteSelected(object sender, ItemTappedEventArgs args) {
            _viewModel.ShowNotePage(args.Item as CheckupNote);
            uiNoteList.SelectedItem = null;
        }
    }
}
