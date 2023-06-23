using System.Collections;
using System.Collections.Generic;
using Oculus.Interaction;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    // Start is called before the first frame update
    
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision Detected");
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        
    }
    
}
