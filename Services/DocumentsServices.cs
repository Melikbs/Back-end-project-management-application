using DataAccess.Models;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Collab_API.Services;

namespace BusinessLogic.Services
{
    public class DocumentsServices : IDocument
    {
        private string connectionString = "Server=Melik-BS;Database=Collab_DB;Trusted_Connection=True;Encrypt=False";
        public List<Document> GetAllDocuments()
        {
            using (var context = new AppDbContext(connectionString))
            {
                return context.documents.ToList();
            }

        }

        public Document? GetDocumentsById(int id)
        {
            using (var context = new AppDbContext(connectionString))
            {
                return context.documents.FirstOrDefault(item => item.Id == id);
            }
        }

        public Document? AddDocuments(AddUpdateDocument obj)
        {
            var addDocument = new Document()
            {
                Namedoc = obj.Namedoc,
                description = obj.description,
                datepublished = DateTime.Now
                
            };
            using (var context = new AppDbContext(connectionString))
            {
                context.documents.Add(addDocument);
                context.SaveChanges();
            }

            return addDocument;
        }

        public Document? UpdateDocuments(int id, AddUpdateDocument obj)
        {
            using (var context = new AppDbContext(connectionString))
            {
                var documentIndex = context.documents.FirstOrDefault(item => item.Id == id);
                if (documentIndex != null)
                {
                    documentIndex.Namedoc = obj.Namedoc;
                    documentIndex.description = obj.description;
                    documentIndex.datepublished = DateTime.Now;
                    
                    context.SaveChanges();
                    return documentIndex;
                }
                else
                {
                    return null;
                }
            }


        }

        public bool DeleteDocumentsById(int id)
        {
            using (var context = new AppDbContext(connectionString))
            {
                var documentIndex = context.documents.FirstOrDefault(item => item.Id == id);
                if (documentIndex != null)
                {
                    context.documents.Remove(documentIndex);
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

