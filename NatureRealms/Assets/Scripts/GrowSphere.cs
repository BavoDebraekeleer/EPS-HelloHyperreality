using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowSphere : MonoBehaviour
{
    [SerializeField] private float growthSpeed = .1f;
    [SerializeField] private float growthAcceleration = .5f;
    [SerializeField] private float growthAccelerationMultiplier = 2;
    private bool _isGrowing;
    
    public void OnSelect() {
        _isGrowing = true;
    }

    void Update() {
        if (_isGrowing) {
            transform.localScale += new Vector3(growthSpeed, growthSpeed, growthSpeed) * Time.deltaTime;
            growthSpeed += growthAcceleration * Time.deltaTime;
            growthAcceleration += growthAcceleration * growthAccelerationMultiplier * Time.deltaTime;
        }
    }
    
}
