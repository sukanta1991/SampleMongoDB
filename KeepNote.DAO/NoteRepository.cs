using KeepNote.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KeepNote.DAO
{
    /*
     * This class implements INoteRepository interface to define CRUD operations on User and Notes.
     * It should make the use of NotesDbContext to connect with Database but should not create 
     * the instance of NotesDbContext. Use dependency Injection.
     */
    public class NoteRepository : INoteRepository
    {
        readonly NotesDbContext _dbContext;
        public NoteRepository(NotesDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task AddNoteForExistingUser(string userId, Note note)
        {
            throw new System.NotImplementedException();
        }

        public Task AddUser(User user)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteNote(string userId, int noteId)
        {
            throw new System.NotImplementedException();
        }

        public Task<Note> GetNoteById(string userId, int noteId)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<Note>> GetNotesByUser(string userId)
        {
            throw new System.NotImplementedException();
        }

        public User GetUser(string userId)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateNote(string userId, int noteId, Note note)
        {
            throw new System.NotImplementedException();
        }
    }
}
