using KeepNote.Entities;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
            var filter = Builders<User>.Filter.Where(x => x.UserId == userId);
            var addNote = Builders<User>.Update.Push<Note>(x => x.Notes, note);
            return _dbContext.UserNotes.FindOneAndUpdateAsync(filter, addNote);
        }

        public Task AddUser(User user)
        {
            return _dbContext.UserNotes.InsertOneAsync(user);
        }

        public Task DeleteNote(string userId, int noteId)
        {
            //var filter = Builders<User>.Filter.Where(x => x.UserId == userId);
            //var delNote = Builders<User>.Update.Pull<Note>(x => x.Notes, Query.Eq);
            //return _dbContext.UserNotes.FindOneAndDeleteAsync(filter);
            throw new System.NotImplementedException();
        }

        public Task<Note> GetNoteById(string userId, int noteId)
        {
            return _dbContext.UserNotes.Find(x => x.UserId == userId)
                .Project(y => y.Notes.FirstOrDefault(z=> z.Id == noteId)).FirstAsync();
        }

        public Task<List<Note>> GetNotesByUser(string userId)
        {   
            return  _dbContext.UserNotes.Find(x => x.UserId == userId)
                .Project(y => y.Notes).FirstAsync();
        }

        public User GetUser(string userId)
        {
            return _dbContext.UserNotes.Find(x => x.UserId == userId).FirstOrDefault();
        }

        public Task UpdateNote(string userId, int noteId, Note note)
        {
            throw new System.NotImplementedException();
        }
    }
}
