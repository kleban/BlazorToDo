using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDo.ServerSide.Core;

namespace ToDo.ServerSide.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   // [EnableCors(origins: "https://localhost:7158", headers: "*", methods: "*")]
    public class TodoController : ControllerBase
    {
        private readonly DataContext _context;

        public TodoController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<ToDoItem>> GetAllAsync()
        {
            return await _context.ToDoItems.Include(x=> x.User).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ToDoItem> GetAsync(Guid id)
        {
            return await _context.ToDoItems.Include(x=> x.User).FirstAsync( x=> x.Id == id);
        }

        [HttpPost]
        public async Task<ToDoItem> CreateAsync(ToDoItem item)
        {
            item.CreatedOn = DateTime.Now;
            var obj = await _context.ToDoItems.AddAsync(item);
            await _context.SaveChangesAsync();
            return await GetAsync(obj.Entity.Id);
        }

        [HttpPut]
        public async Task UpdateAsync(ToDoItem item)
        {
            var dbObj = await _context.ToDoItems.FindAsync(item.Id);

            if (dbObj.IsComplete != item.IsComplete)
                dbObj.IsComplete = item.IsComplete;

            if (dbObj.Text != item.Text)
                dbObj.Text = item.Text;

            if (dbObj.DueDate != item.DueDate)
                dbObj.DueDate = item.DueDate;

            await _context.SaveChangesAsync();
        }

        [HttpDelete("{id}")]
        public async Task DeleteAsync(Guid id)
        {
            _context.ToDoItems.Remove(await _context.ToDoItems.FindAsync(id));
            await _context.SaveChangesAsync();
        }
    }
}
