using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class SpellCast : MonoBehaviour
{
    [SerializeField] private float cooldown = 1.0f;
    protected Camera cam;
    private float timeToCast;
    public Sprite icon;
    public Material cursorMaterial;
    public bool isCursorActive;
    public GameObject cursor;

    [SerializeField] public GameObject spellToCast;



    // Start is called before the first frame update
    virtual protected void Start()
    {
        Init();
    }

    protected void OnEnable()
    {
        Init();
    }

    virtual protected void Init()
    {
        cam = transform.parent.GetComponentInChildren<Camera>();
        timeToCast = 0;
        cursor = GameObject.Find("CursorFollower");
    }

    // Update is called once per frame
    virtual protected void Update()
    {
        if (timeToCast > 0)
        {
            timeToCast -= Time.deltaTime;
        }

        // TODO : gérer smartcasts
        // TODO gérer smartcast sans affichage de portée
        if(isCursorActive && Input.GetMouseButtonDown(0))
        {
            GameObject obj = Throw();
            timeToCast = cooldown;
            //return obj;
        }
    }

    /*
     * appui sur le bouton : affichage du curseur
     * selon le type de cast, relacher le bouton ou click ou autre : lance le sort
     * 
     * 
     * 
     * */
    

    public void Cast()
    {
        // TODO gérer si le spell se lance pas
        if (timeToCast <= 0)
        {
            Cursor();
        }
        else
        {
            return ;
        }
    }

    public virtual void Cancel() {
        isCursorActive = false;
        cursor.GetComponent<Projector>().enabled = false;
    }


    /******************************************* Abstracts **************************************/

    /// <summary>
    /// Actually throw the spell instantiating nesserary gameobjects
    /// </summary>
    /// <returns>The GameObject that instantiate the actual spell result</returns>
    protected abstract GameObject Throw();

    /// <summary>
    /// Show useful spell indicator on the cursor of the player
    /// Should be personnalised for each spell
    /// </summary>
    protected abstract void Cursor();
}
