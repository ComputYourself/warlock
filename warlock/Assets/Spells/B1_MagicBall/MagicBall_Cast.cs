using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBall_Cast : SpellCast
{
    override protected GameObject Throw()
    {
        Projector proj = cursor.GetComponent<Projector>();
        proj.enabled = false;
        isCursorActive = false;
        return Instantiate(spellToCast, this.transform.position + this.transform.forward * 1.5f, this.transform.rotation);
    }


    public override void Cursor()
    {
        if (!isCursorActive)
        {
            Projector proj = cursor.GetComponent<Projector>();
            proj.enabled = true;
            isCursorActive = true;
            proj.material = this.cursorMaterial;
        }
    }

}
