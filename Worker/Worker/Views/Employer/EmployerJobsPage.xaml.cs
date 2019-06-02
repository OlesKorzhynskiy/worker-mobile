﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Worker.Services;
using Worker.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Worker.Views.Employer
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EmployerJobsPage : ContentPage
	{
		public EmployerJobsPage ()
		{
			InitializeComponent ();

            BindingContext = Mapper.Map<ObservableCollection<EmployerJobViewModel>>(EmployerJobsService.GetActive());
        }

        protected override void OnAppearing()
        {
            BindingContext = Mapper.Map<ObservableCollection<EmployerJobViewModel>>(EmployerJobsService.GetActive());
        }
    }
}