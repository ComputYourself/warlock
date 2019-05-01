using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkEvent_Spellcast : NetworkEvent
{
    int sender;
    // La description du sort lancé, avec tous les bonus possibles
    float targetXCoordinate, targetZCoordinate;

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
