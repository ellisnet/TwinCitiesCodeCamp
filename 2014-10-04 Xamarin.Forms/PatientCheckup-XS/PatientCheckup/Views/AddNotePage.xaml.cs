using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

using PatientCheckup.ViewModels;
using PatientCheckup.Models;

namespace PatientCheckup
{	
	public partial class AddNotePage : ContentPage
	{	
		private AddNoteViewModel _viewModel;
		private Patient _patient;

		public AddNotePage (Patient patient, NotesViewModel parentViewModel)
		{
			_patient = patient;
			InitializeComponent ();
			_viewModel = new AddNoteViewModel(Navigation, _patient, parentViewModel);
			this.BindingContext = _viewModel;
		}
	}
}

