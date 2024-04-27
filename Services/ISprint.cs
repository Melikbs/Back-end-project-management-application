using DataAccess.Models;
using static DataAccess.Models.Sprint;
using static DataAccess.Models.SprintStatus;

namespace Collab_API.Services
{
    public interface ISprint
    {
        public List<Sprint> GetAllSprint(sprintstatus? status);
        Sprint? GetSprintById(int id);
        Sprint AddSprint(AddUpdateSprint obj);
        Sprint? UpdateSprint(int id, AddUpdateSprint obj);
        bool DeleteSprintById(int id);
    }
}
