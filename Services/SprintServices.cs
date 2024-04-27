using DataAccess.Models;
using DataAccess;
using static DataAccess.Models.Sprint;
using static DataAccess.Models.SprintStatus;

namespace Collab_API.Services
{
    public class SprintServices : ISprint
    {
        private string connectionString = "Server=Melik-BS;Database=Collab_DB;Trusted_Connection=True;Encrypt=False";


            public List<Sprint> GetAllSprint(sprintstatus? status)
        
            {
                using (var context = new AppDbContext(connectionString))
                {
                    return context.sprints.ToList();
                }

            }
        
            public Sprint? GetSprintById(int id)
        {
            using (var context = new AppDbContext(connectionString))
            {
                return context.sprints.FirstOrDefault(item => item.Id == id);
            }
        }

        public Sprint? AddSprint(AddUpdateSprint obj)
        {
            var addSprint = new Sprint()
            {
                namesprint = obj.namesprint,
                startDate = DateTime.Now,
                endDate = DateTime.Now.AddDays(30),
                status =sprintstatus.Planning

            };
            using (var context = new AppDbContext(connectionString))
            {
                context.sprints.Add(addSprint);
                context.SaveChanges();
            }

            return addSprint;
        }

        public Sprint? UpdateSprint(int id, AddUpdateSprint obj)
        {
            using (var context = new AppDbContext(connectionString))
            {
                var sprintIndex = context.sprints.FirstOrDefault(item => item.Id == id);
                if (sprintIndex != null)
                {
                    sprintIndex.namesprint = obj.namesprint;

                    sprintIndex.startDate = DateTime.Now;
                    sprintIndex.endDate = DateTime.Now.AddDays(60);
                    sprintIndex.status = sprintstatus.InProgress;

                    context.SaveChanges();
                    return sprintIndex;
                }
                else
                {
                    return null;
                }
            }


        }

        public bool DeleteSprintById(int id)
        {
            using (var context = new AppDbContext(connectionString))
            {
                var sprintIndex = context.sprints.FirstOrDefault(item => item.Id == id);
                if (sprintIndex != null)
                {
                    context.sprints.Remove(sprintIndex);
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
