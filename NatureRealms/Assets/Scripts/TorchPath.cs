using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchPath : MonoBehaviour
{
    //public GameObject torchStand;
    //public GameObject torchFlame;
    //public FlamePath otherScript;
    
    [SerializeField] private Transform[] pathPoints;
    [SerializeField] private float speed = 1.0f;
    [SerializeField] private int delay = 3;
    [SerializeField] private bool autoStart;
    private int _waypointIndex;
    private bool _shouldUpdate;

    private void Awake()
    {
        transform.position = pathPoints[_waypointIndex].transform.position;
        if(autoStart)
            StartCoroutine(WaitAndUpdate());
    }

    IEnumerator WaitAndUpdate()
    {
        yield return new WaitForSeconds(delay);
        _shouldUpdate = true;
    }
    
    /*void Update()
    {
        if (_shouldUpdate)
        {
            if(_waypointIndex <= pathPoints.Length - 1)
            {
                transform.position = Vector3.MoveTowards(transform.position, pathPoints[_waypointIndex].transform.position, speed * Time.deltaTime);
                if (transform.position == pathPoints[_waypointIndex].transform.position)
                {
                    _waypointIndex += 1;
                }
                if (_waypointIndex == pathPoints.Length - 1)
                {
                    torchStand.transform.localScale = new Vector3(0, 0, 0);
                    torchFlame.transform.localScale *= 3f;
                    //otherScript.shouldUpdate = true;
                }
            }
        }
    }*/

    private void Update()
    {
        if (_shouldUpdate)
        {
            if (_waypointIndex <= pathPoints.Length - 1)
            {
                if (transform.position == pathPoints[_waypointIndex].transform.position)
                    _waypointIndex += 1;
            
                transform.position = Vector3.MoveTowards(transform.position, pathPoints[_waypointIndex].transform.position, speed * Time.deltaTime);
            }
        }
    }

    public void StartUpdate()
    {
        StartCoroutine(WaitAndUpdate());
    }
}
