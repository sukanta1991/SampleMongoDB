using KeepNote.DAO;
using KeepNote.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace tests.InfraSetup
{

    class NoteDbFixture : IDisposable
    {

        public NotesDbContext noteContext;

        public NoteDbFixture()
        {
            noteContext = new NotesDbContext();
            noteContext.UserNotes.DeleteMany(_=>true);
            noteContext.UserNotes.InsertMany(GetNotes());
        }

        public List<User> GetNotes()
        {
            List<User> users = new List<User>
            {
                new User
                {
                    UserId="mukesh@goel.in",
                    FirstName="Mukesh",
                    LastName="Goel",
                    Notes= new List<Note>
                    {
                        new Note{Id=1, Title="Refactor the code", Content="Some part needs to be removed", CreationDate=DateTime.Now }

                    }
                }
            };
            return users;
        }

        public void Dispose()
        {
            noteContext = null;
        }
    }
}
