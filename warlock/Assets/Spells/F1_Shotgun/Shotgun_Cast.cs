using UnityEngine;

public class Shotgun_Cast : SpellCast
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
        return Instantiate(spellToCast, this.transform.position + this.transform.forward * 1.5f, this.transform.rotation);
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
