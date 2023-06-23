using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FollowTransform : MonoBehaviour
{
    [SerializeField] [Tooltip("Give the GameObject Transform of the main Camera (CenterEye).")]
    private Transform mainCamera;

    [SerializeField] private float cameraNearClipPlaneOffset = 0.01f;

    private Vector3 cameraNearClipPlanePlusOffset;

    // Update is called once per frame
    private void OnValidate()
    {
        //cameraNearClipPlanePlusOffset = mainCamera.transform.position - this.GameObject().transform.position;
        cameraNearClipPlanePlusOffset = new Vector3(0.0f, 0.0f, 0.11f);
        
        /*var cameraNearClipPlane = mainCamera.GetComponent<Camera>().nearClipPlane;
        cameraNearClipPlanePlusOffset = new Vector3(0.0f, 0.0f, cameraNearClipPlane + cameraNearClipPlaneOffset);
        */
        
    }
    

    void Update()
    {
        this.GameObject().transform.position = mainCamera.transform.position + cameraNearClipPlanePlusOffset;
        this.GameObject().transform.rotation = mainCamera.transform.rotation;
    }
}
