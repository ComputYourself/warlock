using UnityEngine;
using UnityEngine.Networking;

public class PlayerSetup : NetworkBehaviour
{

    [SerializeField] Behaviour[] componentsToDisable;
    [SerializeField] GameObject[] gameobjectsToDisable;
    Camera sceneCamera;

    // Start is called before the first frame update
    void Start()
    {
        if (!isLocalPlayer)
        {
            for (int i = 0; i < componentsToDisable.Length; i++)
            {
                componentsToDisable[i].enabled = false;
            }
            for (int i = 0; i < gameobjectsToDisable.Length; i++)
            {
                gameobjectsToDisable[i].SetActive(false);
            }
        }
        else
        {
            sceneCamera = Camera.main;
            sceneCamera.gameObject.SetActive(false);
        }
    }

    private void OnDisable()
    {
        if (sceneCamera != null)
        {
            sceneCamera.gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
