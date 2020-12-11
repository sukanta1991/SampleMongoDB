using KeepNote.DAO;
using KeepNote.Entities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using tests.InfraSetup;

namespace tests
{
    public class NoteRepositoryTest
    {
        NoteRepository noteRepository;
       
        [OneTimeSetUp]
        public void SetUp()
        {
            NoteDbFixture fixture = new NoteDbFixture();
            noteRepository = new NoteRepository(fixture.noteContext);
        }


        #region model_validation_methods

        [Test, Order(1)]
        public void UserModelIsValid()
        {
            var userType = typeof(User);
            Assert.That(userType, Has.Property("UserId"));
            Assert.That(userType, Has.Property("FirstName"));
            Assert.That(userType, Has.Property("LastName"));
            Assert.That(userType, Has.Property("Notes"));
        }

        [Test, Order(2)]
        public void NoteModelIsValid()
        {
            var noteType = typeof(Note);
            Assert.That(noteType, Has.Property("Id"));
            Assert.That(noteType, Has.Property("Title"));
            Assert.That(noteType, Has.Property("Content"));
            Assert.That(noteType, Has.Property("CreationDate"));
        }
        #endregion

        [Test, Order(3)]
        public async Task CreateUserShouldSuccess()
        {
            User user = new User
            {
                UserId = "sam@gmail.com",
                FirstName = "sam",
                LastName = "dsouza",
                Notes = new List<Note>
                {
                    new Note{ Id=1, Title="Demo", Content="NoSQL Document DB", CreationDate= DateTime.Now }
                }
            };
            await noteRepository.AddUser(user);

            var result = noteRepository.GetUser("sam@gmail.com");
            Assert.IsAssignableFrom<User>(result);
            Assert.AreEqual("sam", result.FirstName);
        }

        [Test, Order(4)]
        public async Task CreateNoteShouldSuccess()
        {
            string userId = "mukesh@goel.in";
            Note note = new Note { Id = 2, Title ="Test", Content="Unit Testing using Nunit", CreationDate= DateTime.Now };
            await noteRepository.AddNoteForExistingUser(userId, note);

            var result = await noteRepository.GetNotesByUser(userId);
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual("Test", result[1].Title);
            Assert.AreEqual(2, result[1].Id);
        }

        [Test,Order(5)]
        public async Task GetNoteByIdShouldSuccess()
        {
            string userId = "mukesh@goel.in";
            int noteId =2;

            var result = await noteRepository.GetNoteById(userId, noteId);
            Assert.IsAssignableFrom<Note>(result);
            Assert.NotNull(result);
            Assert.AreEqual("Test", result.Title);
        }

        [Test, Order(6)]
        public async Task UpdateNoteShouldSuccess()
        {
            string userId = "mukesh@goel.in";
            int noteId = 2;
            Note note = new Note { Id=2, Title="Unit Testing", Content= "Unit Testing using Nunit", CreationDate=DateTime.Now };
            await noteRepository.UpdateNote(userId, noteId,note);

            var result = await noteRepository.GetNoteById(userId, noteId);
            Assert.IsAssignableFrom<Note>(result);
            Assert.NotNull(result);
            Assert.AreEqual("Unit Testing", result.Title);
        }

        [Test, Order(7)]
        public async Task DeleteNoteShouldSuccess()
        {
            string userId = "mukesh@goel.in";
            int noteId = 2;
            await noteRepository.DeleteNote(userId, noteId);

            var result = await noteRepository.GetNoteById(userId, noteId);
            Assert.Null(result);
        }
    }
}
