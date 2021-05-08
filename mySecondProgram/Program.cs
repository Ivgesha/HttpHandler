using System;
using System.Threading;
using System.Net;
using System.Net.Sockets;

namespace mySecondProgram
{
    class Program
    {
        const int port = 8080;
        static void Main(string[] args) {

            try
            {
                if (!HttpListener.IsSupported)
                {
                    Console.WriteLine("Wow dude chill");
                    return;
                }
                // create listener
                HttpListener listener = new HttpListener();
                listener.Prefixes.Add("http://localhost:8080/");
                listener.Start();
                Console.WriteLine("Listening...");

                HttpListenerContext context = listener.GetContext();        // Blocking line
                HttpListenerRequest request = context.Request;


                Console.WriteLine("passed blocking line ");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        
            Console.ReadLine();
        
        }


    }
    
}
