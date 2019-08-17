using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] Transform playerToFollow;
    Vector3 distance;

    // Start is called before the first frame update
    void Start()
    {
        distance = transform.position - playerToFollow.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.position = playerToFollow.position + distance;
    }
}
