using UnityEngine;

public class Shotgun_Cast : SpellCast
{
    override protected GameObject Throw()
    {
        Projector proj = cursor.GetComponent<Projector>();
        proj.enabled = false;
        isCursorActive = false;
        cursor.GetComponent<CursorFollower>().mode = CursorMode.followMouse;
        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
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
