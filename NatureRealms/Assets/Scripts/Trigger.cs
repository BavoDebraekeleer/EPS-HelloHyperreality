using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Trigger : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] private LayerMask triggerLayer;    
    [SerializeField] private float sphereCheckSize = .15f;
    //[SerializeField] private String[] commands;
    [SerializeField] private CameraOverlayFade cameraOverlay;
    //[SerializeField] private bool[] fadeOutOnCmds;
    //private int _currentCmd = 0;

    /*private void OnValidate()
    {
        if (gameManager == null)
        {
            gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        }
    }*/

    private void OnTriggerEnter(Collider other)
    {
        gameManager.Trigger(other.gameObject.name);
    }
    
    void Update()
    {
        if (Physics.CheckSphere(transform.position, sphereCheckSize, triggerLayer, QueryTriggerInteraction.Collide))
        {
            /*
            if (!_isCommand1Given)
            {
                if (fadeOutOnCmd1)
                {
                    //cameraOverlay.SetFadeOut();
                    cameraOverlay.FadeOut();
                }

                gameManager.Trigger(command1);
                _isCommand1Given = true;
            }
            else
            {
                if (fadeOutOnCmd2)
                {
                    //cameraOverlay.SetFadeOut();
                    cameraOverlay.FadeOut();
                }

                gameManager.Trigger(command2);
            }*/
            
            /*if (!_isCommandGiven[_currentCmd])
            {
                if (fadeOutOnCmds[_currentCmd])
                {
                    cameraOverlay.FadeOut();
                }

                gameManager.Trigger(commands[_currentCmd]);
                _isCommandGiven[_currentCmd] = true;
            }*/
            
            //cameraOverlay.Blink();
            gameManager.Trigger();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0f, 1f, 0f, 0.75f);
        Gizmos.DrawSphere(transform.position, sphereCheckSize);
    }
}
