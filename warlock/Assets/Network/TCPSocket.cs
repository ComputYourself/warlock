using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;

public class TCPSocket
{
    private Socket socket;

    public Socket Socket {
        get
        {
            return this.socket;
        }
        set
        {
            this.socket = value;
        }
    }


    public TCPSocket(Socket socket)
    {
        this.socket = socket;
    }

    public TCPSocket()
    {
    }

    public bool Connect(string address, int port)
    {
        socket = new Socket(SocketType.Stream, ProtocolType.Tcp);
        IPHostEntry dns = Dns.GetHostEntry(address);
        //socket.Blocking = false;
        socket.Connect(dns.AddressList[0], port);
        return true;

        // gérer les connections ratées et renvoyer false le cas échéant
    }

    private bool Send(byte[] message)
    {
        return true;
    }

    private byte[] Recv()
    {
        return null;
    }

    private bool Close()
    {
        return true;
    }

}
