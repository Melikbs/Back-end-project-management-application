using DataAccess.Models;
using DataAccess;

namespace Collab_API.Services
{
    public class TeamUsersServices : ITeamUser
    {
        private string connectionString = "Server=Melik-BS;Database=Collab_DB;Trusted_Connection=True;Encrypt=False";
        public List<TeamUsers> GetAllTeamUsers()
        {
            using (var context = new AppDbContext(connectionString))
            {
                return context.teamusers.ToList();
            }

        }
        public TeamUsers? GetTeamUsersById(int id)
        {
            using (var context = new AppDbContext(connectionString))
            {
                return context.teamusers.FirstOrDefault(item => item.Id == id);
            }
        }

        public TeamUsers? AddTeamUsers(AddUpdateTeamUser obj)
        {
            var addTeamUsers = new TeamUsers()
            {
                UserId=obj.UserId,
                TeamId=obj.TeamId
            };
            using (var context = new AppDbContext(connectionString))
            {
                context.teamusers.Add(addTeamUsers);
                context.SaveChanges();
            }

            return addTeamUsers;
        }

       /* public TeamUsers? UpdateTeamUsers(int id, AddUpdateTeamUser obj)
        {
            using (var context = new AppDbContext(connectionString))
            {
                var TeamUserIndex = context.teamusers.FirstOrDefault(item => item.Id == id);
                if (TeamUserIndex != null)
                {
                    TeamUserIndex.UserId = obj.UserId;
                    TeamUserIndex.TeamId = obj.TeamId;

                    
                    context.SaveChanges();
                    return TeamUserIndex;
                }
                else
                {
                    return null;
                }
            }
        }*/

        public bool DeleteTeamUsersById(int id)
        {
            using (var context = new AppDbContext(connectionString))
            {
                var TeamUserIndex = context.teamusers.FirstOrDefault(item => item.Id == id);
                if (TeamUserIndex != null)
                {
                    context.teamusers.Remove(TeamUserIndex);
                    context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }


    }
}
