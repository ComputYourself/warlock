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
    public bool AddSpell(GameObject prefab)
    {
        //SpellCast obj = (SpellCast)Instantiate(prefab);
        var prefabCast = prefab.GetComponent<SpellCast>();
        SpellCast cast = (SpellCast)this.gameObject.AddComponent(prefab.GetComponent<SpellCast>().GetType());

        if (spells.Count < spells.Capacity)
        {
            gameObject.AddComponent(cast.GetType());
            cast.spellToCast = prefabCast.spellToCast;
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
