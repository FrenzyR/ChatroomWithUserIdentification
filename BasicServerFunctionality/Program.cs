using System;
using System.Net;
using System.Net.Sockets;
using ChatroomWithUserIdentification;

namespace BasicServerFunctionality
{
    internal abstract class Program
    {
        
        public static void Main(string[] args)
        {
            SignUpAndSignIn attempt = new SignUpAndSignIn();
            IPEndPoint ipEndPoint = new IPEndPoint (IPAddress.Any, 31416);
            
            Socket socket = new Socket (AddressFamily.InterNetwork, SocketType.Stream,
                ProtocolType.Tcp);
            
            socket.Bind (ipEndPoint);
            
            socket.Listen (10);
            
            Socket socketClient = socket.Accept();
            
            IPEndPoint ipEndPointClient = (IPEndPoint) socketClient.RemoteEndPoint;
            Console.WriteLine ("Client connected:{0} at port {1}", ipEndPointClient.Address,
                ipEndPointClient.Port);
            socketClient.Close (); 
            socket.Close ();
            


        }
    }
}