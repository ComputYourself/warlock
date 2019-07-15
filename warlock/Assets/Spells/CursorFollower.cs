using UnityEngine;

/// <summary>
/// CursorFollower is used to make an empty GameObject with a Projector object that helps displaying spell indicators follow the cursor when active
/// </summary>

// TODO changer en cursorManager pour gérer les différents types de curseurs

public class CursorFollower : MonoBehaviour
{
    RaycastHit hit;
    [SerializeField] private LayerMask mask = 0;
    [SerializeField] private Transform player = null;
    public CursorMode mode;

    private void Start()
    {
        mode = CursorMode.pointTo;

    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        switch (mode)
        {
            case CursorMode.followMouse:

                if (Physics.Raycast(ray, out hit, Mathf.Infinity, mask))
                {
                    this.transform.position = new Vector3(hit.point.x, 10, hit.point.z);
                }
                break;
            case CursorMode.pointTo:
                if (Physics.Raycast(ray, out hit, Mathf.Infinity, mask))
                {
                    this.transform.position = player.position + new Vector3(0, 10, 0);
                    Vector2 temp = new Vector2(hit.point.x - player.position.x, hit.point.z - player.position.z);
                    temp.Normalize();
                    this.transform.LookAt(new Vector3(temp.x, -1.5f, temp.y) + player.position);
                }
                break;
        }
    }

    /// <summary>
    /// Callback to draw gizmos that are pickable and always drawn.
    /// </summary>
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        //Gizmos.DrawSphere((new Vector3(temp.x, -1.5f, temp.y) + player.position), 0.1f);
    }
}

public enum CursorMode
{
    followMouse, pointTo
}


