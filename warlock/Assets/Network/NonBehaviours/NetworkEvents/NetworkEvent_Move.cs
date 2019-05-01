using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkEvent_Move : NetworkEvent
{
    int sender;
    float xCoordinate, zCoordinate;

    public override byte[] Serialize()
    {
        throw new System.NotImplementedException();
    }

    public override bool Deserialize(byte[] data)
    {

        // store data in variables ?

        throw new System.NotImplementedException();
    }

}
