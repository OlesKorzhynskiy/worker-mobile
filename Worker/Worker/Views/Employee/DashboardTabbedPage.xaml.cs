﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Worker.Views.Employee
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DashboardTabbedPage : TabbedPage
    {
        public DashboardTabbedPage ()
        {
            InitializeComponent();
        }
    }
}