using DataAccess.Models;

namespace Collab_API.Services
{
    public interface ITask
    {
        public List<DataAccess.Models.Task> GetAllTasks();
        DataAccess.Models.Task? GetTasksById(int id);
        DataAccess.Models.Task AddTasks(AddUpdateTask obj);
        
        bool DeleteTasksById(int id);
    }
}

