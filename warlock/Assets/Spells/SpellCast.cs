using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class SpellCast : MonoBehaviour
{
    [SerializeField]
    private readonly float cooldown;
    private float timeToCast;
    public readonly Sprite icon;
    public readonly GameObject cursorGameObject;

    [SerializeField]
    protected GameObject spellToCast;



    // Start is called before the first frame update
    void Start()
    {
        timeToCast = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeToCast > 0)
        {
            timeToCast -= Time.deltaTime;
        }
    }

    public abstract void Cursor();

    public GameObject Cast()
    {
        if (timeToCast <= 0)
        {
            GameObject obj = Throw();
            timeToCast = cooldown;
            return obj;
        }
        else
        {
            return null;
        }
    }


    // Instantiate(spellToCast);
    protected abstract GameObject Throw();
}
