using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class AuroraDirectionalLightAnimation : MonoBehaviour
{
    private DirectionalLight light = new DirectionalLight();
    
    // Start is called before the first frame update
    void OnValidate()
    {
        light = GetComponent<DirectionalLight>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
