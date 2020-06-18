using Catalog.BLL.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Catalog.DAL.Entities;
using Catalog.BLL.DTO;
using Catalog.DAL.Repositories.Interfaces;
using AutoMapper;
using Catalog.DAL.UnitOfWork;
using OSBB.Security;
using OSBB.Security.Identity;

namespace Catalog.BLL.Services.Impl
{
    public class TaskService
        : ITaskService
    {
        private readonly IUnitOfWork _database;
        private int pageSize = 10;

        public TaskService( 
            IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
            {
                throw new ArgumentNullException(
                    nameof(unitOfWork));
            }
            _database = unitOfWork;
        }

        /// <exception cref="MethodAccessException"></exception>
        public IEnumerable<TaskDTO> GetTasks(int pageNumber)
        {
            var user = SecurityContext.GetUser();
            //var userType = user.GetType();
            var catalogID = user.CatalogID;
            var streetsEntities = 
                _database
                    .Tasks
                    .Find(z => z.TaskID == catalogID, pageNumber, pageSize);
            var mapper = 
                new MapperConfiguration(
                    cfg => cfg.CreateMap<Task, TaskDTO>()
                    ).CreateMapper();
            var streetsDto = 
                mapper
                    .Map<IEnumerable<Task>, List<TaskDTO>>(
                        streetsEntities);
            return streetsDto;
        }

        public void AddStreet(TaskDTO street)
        {
            //var user = SecurityContext.GetUser();
            //var userType = user.GetType();

            //if (userType != typeof(CEO)
            //    || userType != typeof(ProjectManager))
            //{
            //    throw new MethodAccessException();
            //}
            if (street == null)
            {
                throw new ArgumentNullException(nameof(street));
            }

            validate(street);

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TaskDTO, Task>()).CreateMapper();
            var streetEntity = mapper.Map<TaskDTO, Task>(street);
            _database.Tasks.Create(streetEntity);
        }

        private void validate(TaskDTO street)
        {
            if (string.IsNullOrEmpty(street.Name))
            {
                throw new ArgumentException("Name повинне містити значення!");
            }
        }
    }
}
