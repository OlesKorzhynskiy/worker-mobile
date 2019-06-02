namespace Worker.ViewModels
{
    public class EmployerViewModel : UserViewModel
    {
        private string _company;
        public string Company
        {
            get => _company;
            set
            {
                _company = value;
                OnPropertyChanged();
            }
        }
    }
}