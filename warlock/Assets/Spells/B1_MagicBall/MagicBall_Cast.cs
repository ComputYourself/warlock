using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBall_Cast : SpellCast
{
    override protected GameObject Throw()
    {
        return Instantiate(spellToCast, this.transform.position + this.transform.forward * 0.1f, this.transform.rotation);
    }


    public override void Cursor()
    {
        throw new System.NotImplementedException();
    }

}
