using Collab_API.Services;
using DataAccess;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = DataAccess.Models.Task;

namespace BusinessLogic.Services
{
    public class TaskServices : ITask
    {
        private string connectionString = "Server=Melik-BS;Database=Collab_DB;Trusted_Connection=True;Encrypt=False";

        public List<Task> GetAllTasks()
        {
            using (var context = new AppDbContext(connectionString))
            {
                return context.tasks.ToList();
            }

        }


        public Task AddTasks(AddUpdateTask obj)
        {
            var addtask = new Task()
            {
                
                AssignedTo = obj.AssignedTo,
                AssignedFrom = obj.AssignedFrom
            };

            using (var context = new AppDbContext(connectionString))
            {
                
                context.tasks.Add(addtask);
                context.SaveChanges();
            };

            return addtask;
        }

        public bool DeleteTasksById(int id)
        {
            using (var context = new AppDbContext(connectionString))
            {
                var taskIndex = context.tasks.FirstOrDefault(item => item.Id == id);
                if (taskIndex != null)
                {
                    context.tasks.Remove(taskIndex);
                    context.SaveChanges();
                    return true;
                }
                return false;
            }

            
        }
        public Task? GetTasksById(int id)
        {
            using (var context = new AppDbContext(connectionString))
            {
                return context.tasks.FirstOrDefault(item => item.Id == id);
            }
        }
    }
} 

