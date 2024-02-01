class testClass : IDisposable
{
    public void Dispose()
    {
        // Dispose objects here
 	// clean resources
 	Console.WriteLine("Dispose Method!!!!");
    }
}

//call class
class Program
{
    static void Main(string[] args)
    {
        // Use using statement with class that implements Dispose.
 	using (testClass objClass = new testClass())
 	{
     		Console.WriteLine("Using Statment to execute the Dispose Method !!!!!!");
	}
	 Console.WriteLine("After Dispose method cleans up!!!!!!");
    }
}

