using UnityEngine;

public class Meteor_Cast : SpellCast
{
    override protected GameObject Throw()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, LayerMask.GetMask("Floor")))
        {
            Projector proj = cursor.GetComponent<Projector>();
            proj.enabled = false;
            isCursorActive = false;
            return Instantiate(spellToCast, new Vector3(hit.point.x, 10, hit.point.z), this.transform.rotation);
        }
        return null;
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
    }
}
