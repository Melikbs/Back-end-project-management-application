using DataAccess.Models;

namespace Collab_API.Services
{
    public interface ITeam
    {
        public List<Team> GetAllTeams();
        Team? GetTeamsById(int id);
        Team AddTeams(AddUpdateTeam obj);
        Team? UpdateTeams(int id, AddUpdateTeam obj);
        bool DeleteTeamsById(int id);
    }
}
