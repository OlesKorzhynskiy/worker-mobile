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
                config.CreateMap<EmployeeModel, EmployeeViewModel>();
                config.CreateMap<EmployeeViewModel, EmployeeModel>();

                config.CreateMap<EmployerModel, EmployerViewModel>();
                config.CreateMap<EmployerViewModel, EmployerModel>();

                config.CreateMap<JobModel, JobViewModel>();
                config.CreateMap<JobViewModel, JobModel>();

                config.CreateMap<JobTypeModel, JobTypeViewModel>();
                config.CreateMap<JobTypeViewModel, JobTypeModel>();

                config.CreateMap<ReviewModel, ReviewViewModel>();
                config.CreateMap<ReviewViewModel, ReviewModel>();

                config.CreateMap<UserModel, UserViewModel>();
                config.CreateMap<UserViewModel, UserModel>();
            });
        }
    }
}