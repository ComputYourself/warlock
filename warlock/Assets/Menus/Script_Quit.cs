using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Quit : MonoBehaviour
{

    public void Quit()
    {
        if (Application.isEditor)
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
        else
        {
            Application.Quit();
        }
    }
}
