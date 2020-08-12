using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace KeepNote.Entities
{
    /*
     * This class will be used to define a User alomg with Notes
     * It should contain four properties
     * 1. UserId - string (must be used as primary key for Mongo Collection)
     * 2. FirstName- string
     * 3. LastName- string
     * 4. Notes - Collection of Note
     **/
    public class User
    {
        [BsonId]
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<Note> Notes { get; set; }
    }
}
