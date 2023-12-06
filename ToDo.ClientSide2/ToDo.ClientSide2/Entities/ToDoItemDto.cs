using System.ComponentModel.DataAnnotations;

namespace ToDo.ClientSide2.Entities
{
    public class ToDoItemDto
    {
        public Guid Id { get; set; }

        public string Text { get; set; } 
        public DateTime CreatedOn { get; set; } 
        public bool IsComplete { get; set; }
        public DateTime DueDate { get; set; }
        public string UserId { get; set; }
        public User? User { get; set; }
    }

    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
