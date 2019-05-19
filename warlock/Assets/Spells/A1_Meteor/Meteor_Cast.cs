using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor_Cast : SpellCast
{
    override protected GameObject Throw()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            Projector proj = cursor.GetComponent<Projector>();
            proj.enabled = false;
            isCursorActive = false;
            return Instantiate(spellToCast, new Vector3(hit.point.x, 10, hit.point.z), this.transform.rotation);
        }

        return null;
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
