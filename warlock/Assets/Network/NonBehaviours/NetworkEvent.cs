using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NetworkEvent
{
    // Constructors

    // Creators
    public static T Create<T>(byte[] data)
        where T : NetworkEvent, new()
    {
        T ne = new T();
        if (!ne.Deserialize(data))
            return null;

        return ne;
    }

    public static T Create<T>()
        where T : NetworkEvent, new()
    {
        T ne = new T();
        return ne;
    }

    public virtual byte[] Serialize()
    {
        return new byte[0];
    }

    public virtual bool Deserialize(byte[] data)
    {
        return data.Length == 0;
    }
}

//Exemple
public class NetworkEvent_ExempleVide : NetworkEvent
{
    
}


