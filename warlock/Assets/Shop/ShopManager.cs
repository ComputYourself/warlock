using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{

    private PlayerController player;

    [Header("Spells prefabs")]
    [SerializeField]
    GameObject MagicBall_Cast;
    [SerializeField]
    GameObject Meteor_Cast;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void BuyMagicBall()
    {
        player.AddSpell(MagicBall_Cast);
    }
}
