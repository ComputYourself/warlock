using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stealth_Cast : SpellCast
{
    public float duration;

    protected override void Cursor()
    {
        Throw();
    }

    protected override GameObject Throw()
    {
        Renderer[] renderers = GetComponentsInChildren<Renderer>();
        foreach(Renderer renderer in renderers)
        {
            renderer.enabled = false;
        }

        Invoke("ReturnVisible", duration);
        return null;
    }

    protected void ReturnVisible()
    {
        Renderer[] renderers = GetComponentsInChildren<Renderer>();
        foreach (Renderer renderer in renderers)
        {
            renderer.enabled = true;
        }
    }
}
