using System.Net.Sockets;
using System.Net;
using System;

class Program
{
    static void Main(string[] args)
    {
        
        Console.WriteLine("TCP Server:");

        
        TcpListener listener = new TcpListener(IPAddress.Any, 7);

        
        listener.Start();
        Console.WriteLine("Waiting for a connection...");

        
        TcpClient socket = listener.AcceptTcpClient();
        Console.WriteLine("Client connected!");

        
        NetworkStream ns = socket.GetStream();

        
        StreamReader reader = new StreamReader(ns);
        StreamWriter writer = new StreamWriter(ns);
        
        bool isRunning = true;
        Random random = new Random();

        while (isRunning)
        {
            try
            {
                
                string message = reader.ReadLine();

                if (message != null)
                {
                    writer.WriteLine("noting was sent");
                }

                else if (message != null && (message.ToLower() == "stop"))
                {
                    Console.WriteLine("Client disconnected or exit command received.");
                    isRunning = false;
                    break;
                }
                else if (message != null && message.ToLower() == "random")
                {
                    writer.WriteLine("input numbers");
                    writer.Flush();
                    string messageTal = reader.ReadLine();
                    string[] tep = new string[messageTal.Length];
                    tep = messageTal.Split(" ");
                    int x = Int32.Parse(tep[0]);
                    int y = Int32.Parse(tep[1]);

                    int n = random.Next(x, y);
                    string retuneTheMessage = n.ToString();
                    writer.WriteLine(retuneTheMessage);
                    writer.Flush();
                    continue;
                }
                else if (message != null && message.ToLower() == "add")
                {
                    writer.WriteLine("input numbers");
                    writer.Flush();
                    string messageTal = reader.ReadLine();
                    string[] tep = new string[messageTal.Length];
                    tep = messageTal.Split(" ");
                    int x = Int32.Parse(tep[0]);
                    int y = Int32.Parse(tep[1]);

                    int n = x + y;
                    string retuneTheMessage = n.ToString();
                    writer.WriteLine(retuneTheMessage);
                    writer.Flush();
                    continue;
                }
                else if (message != null && message.ToLower() == "subtract")
                {
                    writer.WriteLine("input numbers");
                    writer.Flush();
                    string messageTal = reader.ReadLine();
                    string[] tep = new string[messageTal.Length];
                    tep = messageTal.Split(" ");
                    int x = Int32.Parse(tep[0]);
                    int y = Int32.Parse(tep[1]);

                    int n = x - y;
                    string retuneTheMessage = n.ToString();
                    writer.WriteLine(retuneTheMessage);
                    writer.Flush();
                    continue;
                }
                else
                {
                    writer.WriteLine($"i don't understand {message} try random, add or subtract");
                    writer.Flush();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                isRunning = false;
            }
        }


        socket.Close();
        listener.Stop();

        Console.WriteLine("Server stopped.");
    }
}
