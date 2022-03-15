using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] Camera fpsCamera;
    [SerializeField] float zoomedInFOV = 20f;
    [SerializeField] float zoomedOutFOV = 60f;

    bool zoomedInToggle = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if(zoomedInToggle == false)
            {
                zoomedInToggle = true;
                fpsCamera.fieldOfView = zoomedInFOV;
            }
        }
        else if(Input.GetMouseButtonUp(1))
        {
            if(zoomedInToggle == true)
            {
                zoomedInToggle = false;
                fpsCamera.fieldOfView = zoomedOutFOV;
            }
        }
    }

}
