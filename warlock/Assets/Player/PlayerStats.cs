using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float maxLife;
    private float life;

    // Start is called before the first frame update
    void Start()
    {
        life = maxLife;
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
