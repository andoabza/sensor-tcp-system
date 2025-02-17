using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

public class SensorServer
{
    // Define the port and IP address for the server to listen on
    private const int Port = 8888;
    private const string ServerIp = "127.0.0.1"; // Localhost

    // TCP listener to accept incoming client connections
    private TcpListener _listener;

    // Flag to control the server's running state
    private bool _isRunning = true;

    // Method to start the server
    public void Start()
    {
        // Initialize the TCP listener with the specified IP and port
        _listener = new TcpListener(IPAddress.Parse(ServerIp), Port);
        _listener.Start(); // Start listening for incoming connections
        Log("Server started. Waiting for connections...");

        // Main server loop to accept and handle client connections
        while (_isRunning)
        {
            // Accept a new client connection
            try {
            var client = _listener.AcceptTcpClient();
            
            // Handle the client in a separate task to allow multiple clients
            Task.Run(() => HandleClient(client));
            
            }
            catch (Exception)
        {
            // Log any errors that occur during communication
            Log($"Exiting...");
        }
        }
    }

    // Method to handle communication with a connected client
    private void HandleClient(TcpClient client)
    {
        // Generate a unique ID for the client for logging purposes
        string clientId = Guid.NewGuid().ToString();
        Log($"Client connected: {clientId}\n");
        Console.Write("Available commands: \nGET_TEMP - Get temperature reading \nGET_STATUS - Get system status \nGET_PRESSURE - Get pressure reading\n\n");
        Console.Write("ENTER COMMAND -> ");


        try
        {
            // Use the client's network stream to send and receive data
            using (client)
            using (var stream = client.GetStream())
            {
                byte[] buffer = new byte[1024]; // Buffer to store incoming data

                // Loop to handle communication with the client
                while (client.Connected)
                {
                    // Read data from the client
                    int bytesRead = stream.Read(buffer, 0, buffer.Length);
                    if (bytesRead == 0) break; // Exit if the client disconnects

                    // Convert the received bytes to a string
                    string request = Encoding.UTF8.GetString(buffer, 0, bytesRead).Trim();
                    Log($"Received from {clientId}: {request}");

                    // Process the client's request and generate a response
                    string response = ProcessRequest(request);

                    // Send the response back to the client
                    Log($"Sent response to {clientId}:\n");
                    byte[] responseBytes = Encoding.UTF8.GetBytes(response + "\n");
                    stream.Write(responseBytes, 0, responseBytes.Length);
                }
            }
        }
        catch (Exception ex)
        {
            // Log any errors that occur during communication
            Log($"Error with {clientId}: {ex.Message}");
        }

        // Log when the client disconnects
        Log($"Client disconnected: {clientId}");
    }

    // Method to process client requests and generate responses
    private string ProcessRequest(string command)
    {
        // Use a switch statement to handle different commands
        return command.ToUpper() switch
        {
            "GET_TEMP" => $"{new Random().Next(200, 300) / 10.0}°C", // Return a random temperature
            "GET_STATUS" => new Random().Next(2) == 0 ? "ACTIVE" : "INACTIVE", // Return random status
            "GET_PRESSURE" => $"{new Random().Next(900, 1100)} hPa", // Return random pressure
            _ => "ERROR: Unknown command",
        };
    }

    // Method to log messages with a timestamp
    private void Log(string message)
    {
        Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] {message}");
    }

    // Method to stop the server
    public void Stop()
    {
        _isRunning = false; // Set the flag to stop the server loop
        _listener?.Stop(); // Stop the TCP listener
    }
}