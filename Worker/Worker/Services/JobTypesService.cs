using System.Collections.Generic;
using Worker.Models;

namespace Worker.Services
{
    public static class JobTypesService
    {
        public static List<JobTypeModel> JobTypes { get; set; }

        static JobTypesService()
        {
            JobTypes = new List<JobTypeModel>()
            {
                new JobTypeModel() {Id = 0, Name = "Вантажні роботи"},
                new JobTypeModel() {Id = 1, Name = "Діти"},
                new JobTypeModel() {Id = 2, Name = "Прибирання"},
                new JobTypeModel() {Id = 3, Name = "Тварини"}
            };
        }

        public static List<JobTypeModel> GetAll()
        {
            return JobTypes;
        }
    }
}