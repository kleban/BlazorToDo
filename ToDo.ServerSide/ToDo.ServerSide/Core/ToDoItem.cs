using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDo.ServerSide.Core
{
    public class ToDoItem
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Text { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public bool IsComplete { get; set; }
        public DateTime DueDate { get; set; }
        public User? User { get; set; }
        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }

    }
}
