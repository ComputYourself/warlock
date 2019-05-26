using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{

    private PlayerController player;

    [Header("Spells prefabs")]
    [SerializeField] GameObject MagicBall_Cast;
    [SerializeField] GameObject Meteor_Cast;
    [SerializeField] GameObject Teleport_Cast;
    [SerializeField] GameObject Stealth_Cast;

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

    public void BuyMeteor()
    {
        player.AddSpell(Meteor_Cast);
    }

    public void BuyTeleport()
    {
        player.AddSpell(Teleport_Cast);
    }

    public void BuyStealth()
    {
        player.AddSpell(Stealth_Cast);
    }
}
