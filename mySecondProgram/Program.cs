using System;
using System.Threading;
using System.Net;
using System.Net.Sockets;

namespace mySecondProgram
{
    class Program
    {
        static string url;
        static void Main(string[] args)
        {
            string responseString;
            url = "http://localhost:8080/";
            

            while (true)
            {
                try
                {
                    if (!HttpListener.IsSupported)
                    {
                        Console.WriteLine("Your machine dosent support HttpLIstener class.");
                        return;     // exiting the loop. 
                    }
                    // create listener.
                    HttpListener listener = new HttpListener();
                    // the url and port we are listening to.
                    listener.Prefixes.Add(url);
                    listener.Start();
                    Console.WriteLine("Listening...");

                    // get context - a blocking line that waiting for http request to arrive.
                    HttpListenerContext context = listener.GetContext();        // Blocking 
                    HttpListenerRequest request = context.Request;
                    Console.WriteLine("Got requests, preparing response.");
                    // prepare response object
                    HttpListenerResponse response = context.Response;
                    // prepare response
                    responseString = "<HTML><BODY> Hello From C#!</BODY></HTML>";
                    byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);

                    // get the output respinse stream and write the response.
                    response.ContentLength64 = buffer.Length;
                    response.StatusCode = 200;
                    System.IO.Stream output = response.OutputStream;
                    output.Write(buffer, 0, buffer.Length);

                    output.Close();     // close output stream
                    listener.Stop();    // stip listening to http requests
                }
                catch (Exception e)
                {
                    Console.WriteLine("Fail: " + e.Message);

                }
            }
        }
    }
}
