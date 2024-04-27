using DataAccess.Models;

namespace Collab_API.Services
{
    public interface ITeamUser
    {
        public List<TeamUsers> GetAllTeamUsers();
        TeamUsers? GetTeamUsersById(int id);
        TeamUsers? AddTeamUsers(AddUpdateTeamUser obj);
        //TeamUsers? UpdateTeamUsers(int id, AddUpdateTeamUser obj);
        bool DeleteTeamUsersById(int id);
    }
}
