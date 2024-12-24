using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeStar : MonoBehaviour
{
   
    public CameraShake cameraShake;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            
            StartCoroutine(cameraShake.Shake(0.15f, 0.4f));
        }
    }
}
