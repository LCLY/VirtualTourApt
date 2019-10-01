using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onClick : MonoBehaviour
{
    public GameObject sphereChgObj;
    public Transform nextSphere;
    SphereChanger sphereChgScript;

    void Awake()
    {
        sphereChgScript = sphereChgObj.GetComponent<SphereChanger>();
    }

    void OnMouseDown()
    {
        // this object was clicked - do something
        sphereChgScript.ChangeSphere(nextSphere);
    }
}
