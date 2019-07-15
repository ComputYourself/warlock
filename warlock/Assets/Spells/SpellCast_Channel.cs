using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpellCast_Channel : SpellCast
{

    public GameObject spellInstance;
    public bool isSpellChanneling;

    override protected void Start() {
        base.Start();
        isSpellChanneling = false;
    }

    override public void Cancel() {
        base.Cancel();
        if(spellInstance != null) Destroy(spellInstance);
    }
}
