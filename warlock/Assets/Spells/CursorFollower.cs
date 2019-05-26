using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// CursorFollower is used to make an empty GameObject with a Projector object that helps displaying spell indicators follow the cursor
/// </summary>

public class CursorFollower : MonoBehaviour
{
    RaycastHit hit;
    [SerializeField] private LayerMask mask;

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, mask))
        {
            this.transform.position = new Vector3(hit.point.x, 10, hit.point.z);
        }
    }
}
