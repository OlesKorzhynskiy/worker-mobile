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
	public partial class ReviewsPage : ContentPage
	{
		public ReviewsPage ()
		{
			InitializeComponent ();
		}

        public int ReviewsListViewHeight
        {
            get
            {
                var elements = (ObservableCollection<ReviewViewModel>)BindingContext;
                return elements?.Count * 170 ?? 0;
            }
        }

        private void ListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                ((ListView)sender).SelectedItem = null;
            }
        }
    }
}