using DataAccess.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BusinessLogic.Services
{
    public interface IProject
    {
        public List<Project> GetAllProjects(bool? estTermine);
        Project? GetProjectsById(int id);
        Project AddProjects(AddUpdateProject obj);
        Project? UpdateProjects(int id, AddUpdateProject obj);
        bool DeleteProjectsById(int id);
    }
}
