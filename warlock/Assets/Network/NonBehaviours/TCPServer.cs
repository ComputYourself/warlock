using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;

public class TCPServer
{ 
    Socket socket;

    
    bool Listen(int port)
    {
        IPEndPoint localIPEndpoint = new IPEndPoint(0, port);
        this.socket = new Socket(SocketType.Stream, ProtocolType.Tcp);
        this.socket.Bind(localIPEndpoint);
        this.socket.Listen(255);
        return true;
    }

    TCPSocket Accept()
    {
        TCPSocket client = new TCPSocket(this.socket.Accept());
        return (client);
    }

    bool Close()
    {
        this.socket.Close();
        return true;
    }
}
