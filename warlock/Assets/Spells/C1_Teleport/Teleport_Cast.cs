using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport_Cast : SpellCast
{

    override protected GameObject Throw()
    {


        Projector proj = cursor.GetComponent<Projector>();
        proj.enabled = false;
        isCursorActive = false;

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            this.transform.LookAt(new Vector3(hit.point.x, this.transform.position.y, hit.point.z));
        }
        float height = this.transform.position.y;
        this.transform.position = new Vector3(hit.point.x, height, hit.point.z);
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
