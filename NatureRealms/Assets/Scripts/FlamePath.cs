using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlamePath : MonoBehaviour
{
    [SerializeField]
    private Transform[] pathPointsFlame;
    [SerializeField]
    private float speedFlame = 2f;
    
    private int waypointIndexFlame = 0;

    public bool shouldUpdate = false;
    void Start()
    {
        
    }
    
    void Update()
    {
        if (shouldUpdate)
        {
            
            if(waypointIndexFlame <= pathPointsFlame.Length - 1)
            {
                transform.position = Vector3.MoveTowards(transform.position, pathPointsFlame[waypointIndexFlame].transform.position, speedFlame * Time.deltaTime);
                if (transform.position == pathPointsFlame[waypointIndexFlame].transform.position)
                {
                    waypointIndexFlame += 1;
                }
            }
        }
    }
}
