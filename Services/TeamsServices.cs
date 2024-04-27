using DataAccess.Models;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Collab_API;
using System.Linq;
namespace Collab_API.Services
{
    public class TeamsServices : ITeam
    {
        private string connectionString = "Server=Melik-BS;Database=Collab_DB;Trusted_Connection=True;Encrypt=False";

        public List<Team> GetAllTeams()
        {
            using (var context = new AppDbContext(connectionString))
            {
                return context.teams.ToList();
            }

        }
        public Team? GetTeamsById(int id)
        {
            using (var context = new AppDbContext(connectionString))
            {
                return context.teams.FirstOrDefault(item => item.Id == id);
            }
        }

        public Team? AddTeams(AddUpdateTeam obj)
        {
            var addTeams = new Team()
            {
                nomteam = obj.nomteam,
                descriptionteam = obj.descriptionteam,
                
                projectAssigned =obj.projectAssigned
            };
            using (var context = new AppDbContext(connectionString))
            {
                context.teams.Add(addTeams);
                context.SaveChanges();
            }

            return addTeams;
        }

        public Team? UpdateTeams(int id, AddUpdateTeam obj)
        {
            using (var context = new AppDbContext(connectionString))
            {
                var TeamIndex = context.teams.FirstOrDefault(item => item.Id == id);
                if (TeamIndex != null)
                {
                    TeamIndex.nomteam = obj.nomteam;
                    TeamIndex.descriptionteam = obj.descriptionteam;
                    
                    TeamIndex.projectAssigned = obj.projectAssigned;
                    context.SaveChanges();
                    return TeamIndex;
                }
                else
                {
                    return null;
                }
            }
        }

        public bool DeleteTeamsById(int id)
        {
            using (var context = new AppDbContext(connectionString))
            {
                var TeamIndex = context.teams.FirstOrDefault(item => item.Id == id);
                if (TeamIndex != null)
                {
                    context.teams.Remove(TeamIndex);
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
