using UnityEngine;

public class Meteor : MonoBehaviour
{
    [SerializeField]
    readonly private ParticleSystem explosion;

    // TODO définir les layers
    private LayerMask mask;

    [SerializeField]
    private float speed, damage, areaOfEffect;

    public float Speed { set => speed = value; }
    public float Damage { set => damage = value; }
    public float AreaOfEffect { set => areaOfEffect = value; }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector3.down * speed, Space.World);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Floor"))
        {
            // Damage every player in the area of effect
            RaycastHit[] hits = Physics.SphereCastAll(transform.position, areaOfEffect, Vector3.up, 0.0f, mask);
            foreach (RaycastHit hit in hits)
            {
                PlayerStats stats;
                if ((stats = hit.transform.GetComponent<PlayerStats>()) != null)
                {
                    stats.Damage(this.damage);
                }
            }

            // Throw in shiny particles and then destroy the gameobject
            //explosion.Play();
            Destroy(this.gameObject);
        }
    }
}
