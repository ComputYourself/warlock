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
    }
}
