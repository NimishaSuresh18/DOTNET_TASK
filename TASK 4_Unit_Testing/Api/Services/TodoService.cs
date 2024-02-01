using Api.Services;
using Microsoft.EntityFrameworkCore;

public class TodoService :ITodoService{
    private readonly AppDbContext _context;
    public TodoService(AppDbContext context)
    {
        _context = context;
        
    }
    public async Task<List<Todo>> GetAllAsync(){
        return await _context.Todos.ToListAsync();
    }


    public async Task SaveAsync(Todo lists)
    {
        _context.Todos.Add(lists);
       await _context.SaveChangesAsync();
    }
}