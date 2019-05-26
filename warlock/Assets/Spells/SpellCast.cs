using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class SpellCast : MonoBehaviour
{
    [SerializeField] private float cooldown = 1.0f;
    private float timeToCast;
    public Sprite icon;
    public Material cursorMaterial;
    protected bool isCursorActive;
    public GameObject cursor;

    [SerializeField] public GameObject spellToCast;



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


        // TODO : gérer smartcast
        if(isCursorActive && Input.GetMouseButtonDown(0))
        {
            Cast();
        }
    }
    

    public GameObject Cast()
    {

        // TODO ne pas afficher le curseur si pas le cooldown
        // TODO gérer smartcast sans affichage de portée
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


    /******************************************* Abstracts **************************************/

    /// <summary>
    /// Actually throw the spell instantiating nesserary gameobjects
    /// </summary>
    /// <returns>The GameObject that instantiate the actual spell result</returns>
    protected abstract GameObject Throw();

    /// <summary>
    /// Show useful spell indicator on the cursor of the player
    /// </summary>
    public abstract void Cursor();
}
