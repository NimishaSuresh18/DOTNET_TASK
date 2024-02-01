using FluentAssertions;
using Microsoft.EntityFrameworkCore;

public class TestTodoService : IDisposable
{
    private readonly AppDbContext _contexts;

    public TestTodoService()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
        .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
        _contexts = new AppDbContext(options);
        _contexts.Database.EnsureCreated();

    }
    [Fact]
    public async Task GetTaskAsync_ReturnTodoCollection()
    {
    //arrange
    _contexts.Todos.AddRange(TodoMockData.GetTodos());
    _contexts.SaveChanges();
     var service = new TodoService(_contexts);

    //act
    var result = await service.GetAllAsync();

    //asserts
    result.Should().HaveCount(TodoMockData.GetTodos().Count);
    }
    

    [Fact]
    public async Task SaveAsync_AddNewTodo()
    {
    //arrange
    _contexts.Todos.AddRange(TodoMockData.GetTodos());
    _contexts.SaveChanges();
    var newtodo = TodoMockData.AddTodo();
    var service = new TodoService(_contexts);

    //act
    await service.SaveAsync(newtodo);

    //asserts
    int counts = TodoMockData.GetTodos().Count+1;
    _contexts.Todos.Count().Should().Be(counts);


    }

    public void Dispose()
    {
        _contexts.Database.EnsureDeleted();
        _contexts.Dispose();
        
    }
}