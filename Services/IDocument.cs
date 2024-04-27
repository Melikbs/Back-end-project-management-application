using DataAccess.Models;

namespace Collab_API.Services
{
    public interface IDocument
    {
        public List<Document> GetAllDocuments();
        Document? GetDocumentsById(int id);
        Document AddDocuments(AddUpdateDocument obj);
        Document? UpdateDocuments(int id, AddUpdateDocument obj);
        bool DeleteDocumentsById(int id);
    }
}
