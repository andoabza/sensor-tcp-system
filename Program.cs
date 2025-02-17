class Program
{
    static void Main(string[] args)
    {
        var server = new SensorServer();
        var serverThread = new Thread(server.Start);
    
        serverThread.Start();

        new SensorClient().Start();

        Console.WriteLine("Press ENTER to stop server...");
        Console.ReadLine();
        server.Stop();
    }
}