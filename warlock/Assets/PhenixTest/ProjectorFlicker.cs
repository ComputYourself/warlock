using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectorFlicker : MonoBehaviour
{
    public Projector proj;
    public float timeToFlicker = 0;

    // Update is called once per frame
    void Update()
    {
        timeToFlicker += Time.deltaTime;
        if(timeToFlicker >= 5)
        {
            timeToFlicker = 0;
            proj.enabled = !(proj.enabled);
        }
    }
}
