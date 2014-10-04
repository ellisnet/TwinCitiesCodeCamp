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
	public partial class PatientsPage : ContentPage
	{	
		private PatientsViewModel _viewModel;

		public PatientsPage ()
		{
			InitializeComponent ();
			_viewModel = new PatientsViewModel(Navigation);
			this.BindingContext = _viewModel;
			_viewModel.GetPatientList();
		}

		private void OnPatientSelected(object sender, ItemTappedEventArgs args) {
			_viewModel.ShowNotesPage(args.Item as Patient);
			uiPatientList.SelectedItem = null;
		}

	}
}

