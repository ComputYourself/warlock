using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class SpellCast : MonoBehaviour
{
    [SerializeField]
    private readonly float cooldown;
    private float timeToCast;
    public Sprite icon;
    public Material cursorMaterial;
    protected bool isCursorActive;
    public GameObject cursor;

    [SerializeField]
    public GameObject spellToCast;



    // Start is called before the first frame update
    protected void Start()
    {
        timeToCast = 0;
        cursor = GameObject.Find("CursorFollower");
    }

    protected void OnEnable()
    {
        timeToCast = 0;
        cursor = GameObject.Find("CursorFollower");
    }

    // Update is called once per frame
    protected void Update()
    {
        if (timeToCast > 0)
        {
            timeToCast -= Time.deltaTime;
        }

        if(isCursorActive && Input.GetMouseButtonDown(0))
        {
            Cast();
        }
    }
    
    public GameObject Cast()
    {

        // TODO ne pas afficher le curseur si pas le cooldown
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


    // Abstracts

    // Instantiate(spellToCast);
    protected abstract GameObject Throw();

    public abstract void Cursor();
}
