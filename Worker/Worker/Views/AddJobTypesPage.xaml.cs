using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Worker.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Worker.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddJobTypesPage : ContentPage
    {
        public delegate void AddedJobTypesEventHandler(ObservableCollection<JobTypeViewModel> jobTypes);
        public event AddedJobTypesEventHandler OnAddJobTypes;

        public AddJobTypesPage ()
		{
			InitializeComponent ();
		}

        private void OnSelected(object sender, EventArgs e)
        {
            var jobTypes = (ObservableCollection<JobTypeViewModel>) BindingContext;
            var chosenJobTypes = new ObservableCollection<JobTypeViewModel>(jobTypes.Where(jobType => jobType.IsChecked));
            OnAddJobTypes?.Invoke(chosenJobTypes);
            Navigation.PopModalAsync();
        }

        private void ListView_ClearSelectedItem(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                ((ListView)sender).SelectedItem = null;
            }
        }
    }
}