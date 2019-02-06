using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;

public class TCPTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        TCPSocket socket = new TCPSocket();

        socket.Connect("tec.wf", 23);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
