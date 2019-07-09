using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpellCast_Channel : SpellCast
{

    public GameObject spellInstance;

    override public void Cancel() {
        base.Cancel();
        isCursorActive = false;
        cursor.GetComponent<Projector>().enabled = false;
        if(spellInstance != null) Destroy(spellInstance);
    }
}
