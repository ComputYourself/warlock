using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser_Cast : SpellCast
{

    // Laser Lucian ou Vel'Koz ???

    protected override GameObject Throw()
    {
        throw new System.NotImplementedException();
    }


    public override void Cursor()
    {
        Projector proj = cursor.GetComponent<Projector>();
        if (!isCursorActive)
        {
            proj.enabled = true;
            isCursorActive = true;
        }
        proj.material = this.cursorMaterial;
    }


}
