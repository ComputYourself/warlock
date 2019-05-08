using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public Image[] spellImages;

    List<SpellCast> spells = new List<SpellCast>(5);

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            spells[0]?.Cast();
        }
    }

    /// <summary>
    /// Add a spell to the first valid place
    /// </summary>
    /// <param name="cast">Cast to add</param>
    /// <returns>True if a cast is add, false otherwise</returns>
    public bool AddSpell(Type type)
    {
        if (spells.Count < spells.Capacity)
        {
            SpellCast cast = (SpellCast)this.gameObject.AddComponent(type);
            spells.Add(cast);

            spellImages[spells.Count - 1].sprite = cast.icon;
            return true;
        }
        else
        {
            return false;
        }
    }
}
