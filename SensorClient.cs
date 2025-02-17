using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;

public class SensorClient
{
    private const int Port = 8888;
    private const string ServerIp = "127.0.0.1";

    public void Start()
    {
        try
        {
            using (var client = new TcpClient(ServerIp, Port))
            using (var stream = client.GetStream())
            {
                Console.WriteLine("Connected to server. Enter commands (GET_TEMP, GET_STATUS, GET_PRESSURE)");
                
                while (true)
                {
                    string input = Console.ReadLine();

                    if (string.IsNullOrEmpty(input)) break;

                    byte[] requestBytes = Encoding.UTF8.GetBytes(input + "\n");
                    stream.Write(requestBytes, 0, requestBytes.Length);

                    byte[] buffer = new byte[1024];
                    int bytesRead = stream.Read(buffer, 0, buffer.Length);
                    string response = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    
                    Console.WriteLine($"%%%%%%%%%%%%%%%%%% {input}: {response}");
                    Console.Write("ENTER COMMAND-> ");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}