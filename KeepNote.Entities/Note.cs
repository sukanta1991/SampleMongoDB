using System;

namespace KeepNote.Entities
{
    /*
     * This class will be used to define a Note
     * It should contain four properties
     * 1. Id - int 
     * 2. Title- string
     * 3. Content- string
     * 4. CreationDate - DateTime
     **/
    public class Note
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
