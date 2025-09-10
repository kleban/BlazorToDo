using Microsoft.EntityFrameworkCore;

namespace ToDo.ServerSide.Core
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }


        public DbSet<ToDoItem> ToDoItems => Set<ToDoItem>();
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Guid user1Id = Guid.NewGuid();
            Guid user2Id = Guid.NewGuid();

            modelBuilder.Entity<User>().HasData(
                new List<User>
                {
                    new User { Id = user1Id, Name = "Andriy", Email = "andriy@oa.edu.ua" },
                    new User { Id = user2Id, Name = "Ivan", Email = "ivan@oa.edu.ua" }
                });
            modelBuilder.Entity<ToDoItem>().HasData(
                new List<ToDoItem>
                {
                    new ToDoItem {Text = "Видати лаб. 3 для КН-3", DueDate = new DateTime(2023, 12, 5, 14, 0, 0), UserId = user1Id},
                    new ToDoItem {Text = "Перечитати курсові КН-4", DueDate = new DateTime(2023, 12, 6, 18, 0, 0), UserId = user2Id}
                }
                );
                base.OnModelCreating(modelBuilder);
            }
        }
    }
