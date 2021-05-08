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
            string responseString;
            try
            {
                if (!HttpListener.IsSupported)
                {
                    Console.WriteLine("Your machine dosent support HttpLIstener class.");
                    return;
                }
                // create listener.
                HttpListener listener = new HttpListener();
                // the url and port we are listening to.
                listener.Prefixes.Add("http://localhost:8080/");
                listener.Start();
                Console.WriteLine("Listening...");

                // get context - a blocking line that waiting for http request to arrive.
                HttpListenerContext context = listener.GetContext();        // Blocking 
                HttpListenerRequest request = context.Request;
                // prepare response object
                HttpListenerResponse response = context.Response;
                // prepare response
                responseString = "<HTML><BODY> Hello From C#!</BODY></HTML>";
                byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);

                // get the output respinse stream and write the response.
                response.ContentLength64 = buffer.Length;
                System.IO.Stream output = response.OutputStream;
                output.Write(buffer, 0, buffer.Length);

                output.Close();     // close output stream
                listener.Stop();    // stip listening to http requests
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        
            Console.ReadLine();
        
        }


    }
    
}
