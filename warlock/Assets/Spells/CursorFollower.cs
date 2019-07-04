using UnityEngine;

/// <summary>
/// CursorFollower is used to make an empty GameObject with a Projector object that helps displaying spell indicators follow the cursor when active
/// </summary>

public class CursorFollower : MonoBehaviour
{
    RaycastHit hit;
    [SerializeField] private LayerMask mask;
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
                    this.transform.position = new Vector3(hit.point.x, 10, hit.point.z);
                }
                break;
        }

    }
}

public enum CursorMode
{
    followMouse, pointTo
}

