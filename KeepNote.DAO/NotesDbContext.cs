﻿using KeepNote.Entities;
using MongoDB.Driver;

namespace KeepNote.DAO
{
    /*
     * This class will act as mediator between our Data operations and Database.
     */

    public class NotesDbContext
    {
        /*
         * Constructor must initialize the connection with AWS DocumentDB through tunneling 
         */
        readonly IMongoDatabase _database;
        public NotesDbContext()
        {
            var connectionString = "";
            var client = new MongoClient(connectionString);
            _database = client.GetDatabase("userDb");
        }

        /*
         * Define a public property to return IMongoCollection of User type.
         */
        public IMongoCollection<User> UserNotes => _database.GetCollection<User>("users");
    }
}
