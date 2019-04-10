using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellCast : MonoBehaviour
{
    float cooldown;
    float timeToCast;
    Image icon;
    GameObject cursorImage;
    GameObject spellToCast;



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


    public GameObject Cast()
    {
        if (timeToCast <= 0)
        {
            GameObject obj = Instantiate(spellToCast);
            timeToCast = cooldown;
            return obj;
        }
        else
        {
            return null;
        }
    }
}
