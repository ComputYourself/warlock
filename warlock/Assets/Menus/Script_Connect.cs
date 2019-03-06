using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Script_Connect : MonoBehaviour
{
    public InputField port;
    public InputField address;
    public Button thisButton;


    private void Start()
    {
        Check();
    }

    public void Check()
    {
        if(string.IsNullOrEmpty(port.text) || string.IsNullOrEmpty(address.text))
        {
            thisButton.interactable = false;
        }
        else
        {
            thisButton.interactable = true;
        }
    }

    public void Connect()
    {
        TCPSocket socket = new TCPSocket();

        socket.Connect(address.text, int.Parse(port.text));

        // Faire la gestion d'erreurs si connect renvoie false

        Byte[] message = socket.Recv();

        System.Text.Encoding enc = System.Text.Encoding.ASCII;

        Debug.Log(enc.GetString(message));

        socket.Send(enc.GetBytes("bite"));
    }
}
