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
        if (spells.Count > 0 && Input.GetKeyDown(KeyCode.A))
        {
            spells[0].Cursor();
        }
        if (spells.Count > 1 && Input.GetKeyDown(KeyCode.Z))
        {
            spells[1].Cursor();
        }
        if (spells.Count > 2 && Input.GetKeyDown(KeyCode.E))
        {
            spells[2].Cursor();
        }
        if (spells.Count > 3 && Input.GetKeyDown(KeyCode.R))
        {
            spells[3].Cursor();
        }
        if (spells.Count > 4 && Input.GetKeyDown(KeyCode.T))
        {
            spells[4].Cursor();
        }
    }

    /// <summary>
    /// Add a spell to the first valid place
    /// </summary>
    /// <param name="cast">Cast to add</param>
    /// <returns>True if a cast is added, false otherwise</returns>
    public bool AddSpell(GameObject prefab)
    {
        // TODO utiliser des scriptable objects ? Les sorts sous forme de prefabs ici ne sont qu'un tas de données

        if (spells.Count < spells.Capacity)
        {
            var prefabCast = prefab.GetComponent<SpellCast>();
            SpellCast cast = (SpellCast)this.gameObject.AddComponent(prefab.GetComponent<SpellCast>().GetType());
            cast.spellToCast = prefabCast.spellToCast;
            cast.cursorMaterial = prefabCast.cursorMaterial;
            cast.icon = prefabCast.icon;
            spells.Add(cast);

            if(prefabCast.GetType() == typeof(Stealth_Cast))
            {
                Stealth_Cast stealthcast = (Stealth_Cast)cast;
                stealthcast.duration = prefab.GetComponent<Stealth_Cast>().duration;
            }

            spellImages[spells.Count - 1].sprite = cast.icon;
            return true;
        }
        else
        {
            Debug.Log("You can't buy anymore spells");
            return false;
        }
    }
}
