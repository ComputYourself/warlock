using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Image[] spellImages;

    List<SpellCast> spells = new List<SpellCast>(5);

    private Vector2 direction = new Vector2 (0, 0);
    public float speed;
    public bool canMove = true;
    private bool isMoving = false;

    public const float MOUVEMENT_OFFSET = 0.1f;

    // Update is called once per frame
    void Update()
    {
        if (spells.Count > 0 && Input.GetKeyDown(KeyCode.A))
        {
            UncastAllSpells();
            spells[0].Cast();
        }
        if (spells.Count > 1 && Input.GetKeyDown(KeyCode.Z))
        {
            UncastAllSpells();
            spells[1].Cast();
        }
        if (spells.Count > 2 && Input.GetKeyDown(KeyCode.E))
        {
            UncastAllSpells();
            spells[2].Cast();
        }
        if (spells.Count > 3 && Input.GetKeyDown(KeyCode.R))
        {
            UncastAllSpells();
            spells[3].Cast();
        }
        if (spells.Count > 4 && Input.GetKeyDown(KeyCode.T))
        {
            UncastAllSpells();
            spells[4].Cast();
        }

        if(Input.GetMouseButtonDown(1))
        {
            UncastAllSpells();
            Move();
        }
    }

    private void UncastAllSpells()
    {
        foreach(SpellCast cast in spells)
        {
            cast.isCursorActive = false;
        }
    }

    private void FixedUpdate()
    {
        // This part is responsible of player movement
        if(canMove && isMoving)
        {
            Vector2 pos = new Vector2(transform.position.x, transform.position.z);
            if (Vector2.Distance(pos, direction) > MOUVEMENT_OFFSET)
            {
                Vector3 finishPoint = new Vector3((direction - pos).x, 0, (direction - pos).y);
                transform.Translate(finishPoint.normalized * speed, Space.World);

                // TODO : try to make this less snappy for animation purposes
                this.transform.LookAt(new Vector3(direction.x, transform.position.y, direction.y));
            }
            else
            {
                isMoving = false;
            }
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

    /// <summary>
    /// Sets the target of the movement and triggers movement
    /// </summary>
    private void Move()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            this.direction = new Vector2(hit.point.x, hit.point.z);
            isMoving = true;
        }
    }
}
