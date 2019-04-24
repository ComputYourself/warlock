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
        socket.Connect(dns.AddressList[0], port);

        //socket.Blocking = false;

        return true;

        // gérer les connections ratées et renvoyer false le cas échéant
    }

    public bool Send(byte[] message)
    {
        this.socket.Send(message);

        return true;
    }

    public byte[] Recv()
    {
        byte[] message = new byte[65536];
        this.socket.Receive(message);
        return message;
    }

    private bool Close()
    {
        return true;
    }

}
