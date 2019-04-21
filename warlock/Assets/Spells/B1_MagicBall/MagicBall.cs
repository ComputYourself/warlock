using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider)),
    RequireComponent(typeof(ParticleSystem))]
public class MagicBall : Spell
{
    [SerializeField]
    readonly private ParticleSystem explosion;

    private float speed, damage, areaOfEffect;

    // TODO définir les layers
    private LayerMask mask;


    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(this.transform.forward);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Damage every player in the area of effect
        RaycastHit[] hits = Physics.SphereCastAll(collision.contacts[0].point, areaOfEffect, Vector3.up, 0.0f, mask);
        foreach(RaycastHit hit in hits)
        {
            PlayerController controller;
            if ((controller = hit.transform.GetComponent<PlayerController>()) != null)
            {
                controller.Damage(this.damage);
            }
        }

        // Throw in shiny particles and then destroy the gameobject
        explosion.Play();
        Destroy(this.gameObject);
    }


}
