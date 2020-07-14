using KeepNote.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KeepNote.DAO
{
    public interface INoteRepository
    {
        Task AddNoteForExistingUser(string userId, Note note);
        Task AddUser(User user);
        Task DeleteNote(string userId, int noteId);
        Task<Note> GetNoteById(string userId, int noteId);
        Task<List<Note>> GetNotesByUser(string userId);
        User GetUser(string userId);
        Task UpdateNote(string userId, int noteId, Note note);
    }
}