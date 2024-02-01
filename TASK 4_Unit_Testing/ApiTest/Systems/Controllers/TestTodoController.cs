
using Moq;
using Api.Services;
using FluentAssertions;
using System.Reflection.Metadata;
using Microsoft.AspNetCore.Mvc;
public class TestTodoController{
    [Fact]
     public async Task GetAllAsync_ShouldReturn200Status(){
       //arrange 
       var todoService = new Mock<ITodoService>();
       todoService.Setup(get=>get.GetAllAsync()).ReturnsAsync(TodoMockData.GetTodos());
       var control = new TodoController(todoService.Object);

       //act
       var result = await control.GetAllAsync();

       //assert
       Assert.NotNull(result);
       result.GetType().Should().Be(typeof(OkObjectResult));
       (result as OkObjectResult).StatusCode.Should().Be(200);
    }

    [Fact]
    public async Task SaveAsync_ShouldCallTodoSaveAsyncOnce()
    {
      //arrange
      var todoService = new Mock<ITodoService>();
      var newtodo = TodoMockData.AddTodo();
      var save = new TodoController(todoService.Object);

      //act
      var result = await save.SaveAsync(newtodo);

      //assert
      todoService.Verify(post=>post.SaveAsync(newtodo),Times.Exactly(1));
      
    }



     
    
}