using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonInput : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    private void OnValidate()
    {
        if (gameManager == null)
        {
            gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.One))
        {
            // Button A is pressed.
            gameManager.Trigger();
        }
        
        if (OVRInput.GetDown(OVRInput.Button.Two))
        {
            // Reload scene
            /*var currentSceneBuildIndex = SceneManager.GetActiveScene().buildIndex;
            StartCoroutine(ChangeScene(currentSceneBuildIndex));*/
            
            // Load next scene
            var currentSceneBuildIndex = SceneManager.GetActiveScene().buildIndex;
            StartCoroutine(ChangeScene(currentSceneBuildIndex + 1));
        }

    }
    
    IEnumerator ChangeScene(int sceneBuildIndex)
    {
        SceneManager.LoadScene(sceneBuildIndex);
        yield return null;
    }
}
