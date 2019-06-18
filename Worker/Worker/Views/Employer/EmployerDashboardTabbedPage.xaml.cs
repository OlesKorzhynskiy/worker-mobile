using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Worker.Views.Employer
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EmployerDashboardTabbedPage : TabbedPage
    {
        public EmployerDashboardTabbedPage ()
        {
            InitializeComponent();
        }
    }
}