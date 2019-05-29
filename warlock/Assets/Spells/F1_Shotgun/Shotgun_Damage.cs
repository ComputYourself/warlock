using UnityEngine;

public class Shotgun_Damage : MonoBehaviour
{
    float damage;

    private void Start()
    {
        damage = GetComponentInParent<Shotgun>().damage;
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerStats stats = other.gameObject.GetComponent<PlayerStats>();
        if (stats != null)
        {
            stats.Damage(damage);
        }
    }
}
