using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellCast : MonoBehaviour
{
    float cooldown;
    Image icon;
    GameObject cursorImage;
    GameObject spellToCast;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    GameObject Cast()
    {
        GameObject obj = Instantiate(spellToCast);
        return obj;
    }
}
