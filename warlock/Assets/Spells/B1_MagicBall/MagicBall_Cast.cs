using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MagicBall_Cast : SpellCast
{
    override protected GameObject Throw()
    {
        Projector proj = cursor.GetComponent<Projector>();
        proj.enabled = false;
        isCursorActive = false;

        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            this.transform.LookAt(new Vector3(hit.point.x, this.transform.position.y, hit.point.z));
        }
        GameObject go = Instantiate(spellToCast, this.transform.position + this.transform.forward * 1.5f, this.transform.rotation);
        NetworkServer.Spawn(go);
        return go;
    }


    protected override void Cursor()
    {
        Projector proj;
        if (!isCursorActive)
        {
            proj = cursor.GetComponent<Projector>();
            proj.enabled = true;
            isCursorActive = true;
            proj.material = this.cursorMaterial;
        }
    }

}
