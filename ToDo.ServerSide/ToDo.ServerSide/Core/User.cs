using System.ComponentModel.DataAnnotations;

namespace ToDo.ServerSide.Core
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public virtual ICollection<ToDoItem> Tasks { get; set; }


    }
}
