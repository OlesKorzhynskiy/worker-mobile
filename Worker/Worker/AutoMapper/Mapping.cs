using AutoMapper;
using Worker.Models;
using Worker.ViewModels;

namespace Worker.AutoMapper
{
    public static class Mapping
    {
        public static void Initialize()
        {
            Mapper.Initialize(config =>
            {
                config.CreateMap<EmployeeModel, UserModel>();
                config.CreateMap<UserModel, EmployeeModel>();

                config.CreateMap<EmployerModel, UserModel>();
                config.CreateMap<UserModel, EmployerModel>();

                config.CreateMap<EmployeeJobModel, EmployerJobModel>();
                config.CreateMap<EmployerJobModel, EmployeeJobModel>();

                config.CreateMap<EmployeeJobModel, EmployeeJobViewModel>();
                config.CreateMap<EmployeeJobViewModel, EmployeeJobModel>();

                config.CreateMap<EmployeeModel, EmployeeViewModel>();
                config.CreateMap<EmployeeViewModel, EmployeeModel>();

                config.CreateMap<EmployerJobModel, EmployerJobViewModel>();
                config.CreateMap<EmployerJobViewModel, EmployerJobModel>();

                config.CreateMap<EmployerModel, EmployerViewModel>();
                config.CreateMap<EmployerViewModel, EmployerModel>();

                config.CreateMap<EmployeeModel, SettingsViewModel>();
                config.CreateMap<SettingsViewModel, EmployeeModel>();

                config.CreateMap<EmployerModel, SettingsViewModel>();
                config.CreateMap<SettingsViewModel, EmployerModel>();

                config.CreateMap<JobTypeModel, JobTypeViewModel>();
                config.CreateMap<JobTypeViewModel, JobTypeModel>();

                config.CreateMap<JobUserModel, JobUserViewModel>();
                config.CreateMap<JobUserViewModel, JobUserModel>();

                config.CreateMap<ReviewModel, ReviewViewModel>();
                config.CreateMap<ReviewViewModel, ReviewModel>();

                config.CreateMap<UserModel, UserViewModel>();
                config.CreateMap<UserViewModel, UserModel>();
            });
        }
    }
}