using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    SpellCast[] spells = new SpellCast[5];
    public float maxLife;
    private float life;

    // Start is called before the first frame update
    void Start()
    {
        life = maxLife;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            spells[0].Cast();
        }
    }

    public void Damage(float damage)
    {
        life -= damage;
        if (life <= 0)
        {
            Destroy(this);
        }
    }
}
