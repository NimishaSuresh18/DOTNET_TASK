namespace Api.Services{
public interface ITodoService{
    Task<List<Todo>> GetAllAsync();
    Task SaveAsync (Todo lists);
}
}
