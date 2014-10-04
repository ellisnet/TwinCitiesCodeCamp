using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

using PatientCheckUp.ViewModels;
using PatientCheckUp.Models;

namespace PatientCheckUp.Views {
    public partial class AddNotePage {

        private AddNoteViewModel _viewModel;
        private Patient _patient;

        public AddNotePage(Patient patient, NotesViewModel parentViewModel) {
            _patient = patient;
            InitializeComponent();
            _viewModel = new AddNoteViewModel(Navigation, _patient, parentViewModel);
            this.BindingContext = _viewModel;
        }
    }
}
