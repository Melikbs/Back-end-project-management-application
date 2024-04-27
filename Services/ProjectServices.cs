using Collab_API;
using DataAccess;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic.Services
{
    public class ProjectServices : IProject
    {
        private string connectionString = "Server=Melik-BS;Database=Collab_DB;Trusted_Connection=True;Encrypt=False";

        public List<Project> GetAllProjects(bool? estTermine)
        {
            using (var context = new AppDbContext(connectionString))
            {
                return context.projects.ToList();
            }

        }

        public Project? GetProjectsById(int id)
        {
            using (var context = new AppDbContext(connectionString))
            {
                return context.projects.FirstOrDefault(item => item.Id == id);
            }
        }

        public Project? AddProjects(AddUpdateProject obj)
        {
            var addProject = new Project()
            {
                nomprojet = obj.nomprojet,
                description = obj.description,
                DateDeb = DateTime.Now.AddDays(1),
                DateFin = DateTime.Now.AddDays(10),
                EstTermine = obj.EstTermine
            };
            using (var context = new AppDbContext(connectionString))
            {
                context.projects.Add(addProject);
                context.SaveChanges();
            }

            return addProject;
        }

        public Project? UpdateProjects(int id, AddUpdateProject obj)
        {
            using (var context = new AppDbContext(connectionString))
            {
                var projectIndex = context.projects.FirstOrDefault(item => item.Id == id);
                if (projectIndex != null)
                {
                    projectIndex.nomprojet = obj.nomprojet;
                    projectIndex.description = obj.description;
                    projectIndex.DateDeb = DateTime.Now;
                    projectIndex.DateFin = DateTime.Now.AddDays(30);
                    projectIndex.EstTermine = obj.EstTermine;
                    context.SaveChanges();
                    return projectIndex;
                }
                else
                {
                    return null;
                }
            }


        }

        public bool DeleteProjectsById(int id)
        {
            using (var context = new AppDbContext(connectionString))
            {
                var projectIndex = context.projects.FirstOrDefault(item => item.Id == id);
                if (projectIndex != null)
                {
                    context.projects.Remove(projectIndex);
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

