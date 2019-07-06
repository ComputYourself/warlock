using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser_Cast : SpellCast
{
    // TODO : prepare the incant effect where moving breaks the spell
    // TOOD : make the laser follow the cursor the way Vel'Koz's ultimate from League of Legend does

    override protected GameObject Throw()
    {
        Projector proj = cursor.GetComponent<Projector>();
        proj.enabled = false;
        isCursorActive = false;
        cursor.GetComponent<CursorFollower>().mode = CursorMode.followMouse;
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            this.transform.LookAt(new Vector3(hit.point.x, this.transform.position.y, hit.point.z));
        }
        return Instantiate(spellToCast, this.transform.position + this.transform.forward * 1.5f, this.transform.rotation);
    }


    protected override void Cursor()
    {
        Projector proj = cursor.GetComponent<Projector>();
        if (!isCursorActive)
        {
            proj.enabled = true;
            isCursorActive = true;
        }
        proj.material = this.cursorMaterial;
        cursor.GetComponent<CursorFollower>().mode = CursorMode.pointTo;
    }
}
