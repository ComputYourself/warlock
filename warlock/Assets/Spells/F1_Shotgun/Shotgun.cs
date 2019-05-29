using UnityEngine;

public class Shotgun : MonoBehaviour
{
    // TODO définir les layers
    private LayerMask mask;

    public float damage, areaOfEffect;

    public float Damage { set => damage = value; }
    public float AreaOfEffect { set => areaOfEffect = value; }
    public float Range { set => areaOfEffect = value; }


    private ParticleSystem particles;

    private void Start()
    {
        particles = GetComponentInChildren<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!particles.IsAlive()) Destroy(this.gameObject);
    }
}
