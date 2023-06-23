using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerVR : MonoBehaviour
{
    [SerializeField] private CharacterController controller;
    [SerializeField] private float gravity = -7.5f;
    [SerializeField] private float speed = 2f;
    
    private Vector3 _velocity;
    private Vector3 _move;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        _velocity.y += gravity * Time.deltaTime;
        controller.Move(_velocity);

        _move = Input.GetAxis("Horizontal") * transform.right + Input.GetAxis("Vertical") * transform.forward;
        controller.Move(_move * speed * Time.deltaTime);
    }
}
