using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{

    [SerializeField] private PlayerController player;

#pragma warning disable CS0649,IDE0044 // "Readonly", and "is never assigned to, and will always have its default value" warning
    // I know it looks odd, but here these variables are specific needed to add an empty object that will add a SpellCast to the player, initialisation is made via Unity Editor
    // And I want to get rid of any warning.
    // TLDR : I know what I'm doing here
    [Header("Spells prefabs")]
    [SerializeField] private GameObject Meteor_Cast;
    [SerializeField] private GameObject MagicBall_Cast;
    [SerializeField] private GameObject Teleport_Cast;
    [SerializeField] private GameObject Stealth_Cast;
    [SerializeField] private GameObject Laser_Cast;
    [SerializeField] private GameObject Shotgun_Cast;
#pragma warning restore CS0649,IDE0044

    // Start is called before the first frame update
    void Start()
    {
        player = transform.parent.GetComponentInChildren<PlayerController>();
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

    public void BuyLaser()
    {
        player.AddSpell(Laser_Cast);
    }

    public void BuyShotgun()
    {
        player.AddSpell(Shotgun_Cast);
    }
}
