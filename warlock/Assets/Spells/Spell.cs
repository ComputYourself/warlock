using UnityEngine.Networking;

public class Spell : NetworkBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    enum Cast
    {
        Instant,
        Incantation,
        Channeling
    }

    enum Physique
    {
        Falling,
        Projectile,
        Distortion,
        Line,
        Cone,
        Self
    }

}
