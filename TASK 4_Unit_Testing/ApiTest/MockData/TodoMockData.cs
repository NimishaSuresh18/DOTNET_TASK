using Microsoft.VisualStudio.TestPlatform.CrossPlatEngine.Helpers;

public class TodoMockData{
    public static  List<Todo>GetTodos(){
        return new List<Todo>{
            new Todo{
                Id = 1,
                Task_Name= "UnitTesting",
                Team_Name="Dotnet",
                IsCompleted=true
                
            },
            new Todo{
                Id = 2,
                Task_Name= "JWT Authentication",
                Team_Name="Dotnet",
                IsCompleted=true
                
            },
            new Todo{
                Id = 3,
                Task_Name= "Data binding",
                Team_Name="Angular",
                IsCompleted=false
                
            }

        };
              
    }
     public static Todo AddTodo(){
            return new Todo{
               Task_Name= "Selectors",
                Team_Name="Javascript",
                IsCompleted=false 
            };
        }
}