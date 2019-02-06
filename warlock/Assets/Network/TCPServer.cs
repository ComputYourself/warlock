using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;

public class TCPServer
{ 
    Socket socket;

    
    bool Listen(int port)
    {
        //socket = new Socket(IPAddress.Any.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
        return true;
    }

    TCPSocket Accept()
    {
        return null;
    }

    bool Close()
    {
        socket.Close();
        return true;
    }
}
