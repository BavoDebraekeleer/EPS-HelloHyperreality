using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] [Tooltip("Object transform to manipulate on user movement.")]
    private Transform playerOrigin;

    [SerializeField] [Tooltip("GameObject with all the OVR locations in the scene.")]
    private GameObject OVRLocations;
    
    [SerializeField] [Tooltip("GameObject with all the locations in the scene.")]
    private GameObject locations;

    [SerializeField] [Tooltip("Which location on which to load the next scene.")]
    private int loadNextScene;

    [SerializeField] [Tooltip("Skybox materials to change too.")]
    private Material[] skyboxes;

    [SerializeField] [Tooltip("At which locations there should be changed to the next skybox.")]
    private int[] skyboxLocationIndexes;

    //[SerializeField] [Tooltip("Should be on Umbrella prefab in OVR Left Controller.")]
    //private UmbrellaEffectsController umbrellaEffectsController;
    
    [SerializeField] private AudioSource umbrellaAudioSource;
    //[SerializeField] private OVRControllerHelper leftOVRControllerHelper;
    //[SerializeField] private MeshRenderer umbrellaFabricMeshRenderer;
    //[SerializeField] private Material umbrellaMaterialWetOn;
    //[SerializeField] private Material umbrellaMaterialDryOn;
    //[SerializeField] private Material umbrellaMaterialWetOff;
    //SerializeField] private Material umbrellaMaterialDryOff;

    [SerializeField] [Tooltip("Which location should the rain effect be turned on.")]
    private int umbrellaEffectsOnLocation;
    
    [SerializeField] private CameraOverlayFade cameraOverlay;

    //private GameObject _OVR;
    private int _currentLocation;
    private int _currentSkybox;
    //private string _currentScene;

    private void OnValidate()
    {
        //_currentScene = SceneManager.GetActiveScene().name;

        if (playerOrigin == null)
        {
            playerOrigin = GameObject.Find("OVRCameraRig").transform;
        }

        if (OVRLocations == null)
        {
            OVRLocations = GameObject.Find("OVRLocations");
        }
        
        if (locations == null)
        {
            locations = GameObject.Find("Locations");
        }
    }

    private void Start()
    {
        //OVRLocations.gameObject.SetActive(false);

        foreach (Transform child in locations.transform.GetComponentInChildren<Transform>())
        {
            child.gameObject.SetActive(false);
        }
        locations.gameObject.transform.GetChild(0).gameObject.SetActive(true);
        
        //umbrellaEffectsController.SetRainEffect(false);

        cameraOverlay.FadeIn(1);
    }

    public void Trigger(string triggerName)
    {
        switch (triggerName)
        {
            case "Load Forest":
                StartCoroutine(ChangeScene("Scenes/Forest"));
                break;
            case "Load Cave":
                StartCoroutine(ChangeScene("Scenes/Cave"));
                break;
            case "Load Beach":
                StartCoroutine(ChangeScene("Scenes/Beach"));
                break;
        }
    }
    
    public void Trigger()
    {
        if (_currentLocation + 1 == loadNextScene)
        {
            cameraOverlay.FadeOut();
            _currentLocation = 0;
            var currentSceneBuildIndex = SceneManager.GetActiveScene().buildIndex;
            StartCoroutine(ChangeScene(currentSceneBuildIndex + 1, 0.5f));
        }
        
        cameraOverlay.Blink();
        NextLocation();

        if (skyboxes != null)
        {
            // Change Skybox to updated _currentLocation
            if (_currentLocation == skyboxLocationIndexes[_currentSkybox])
            {
                RenderSettings.skybox = skyboxes[_currentSkybox];
                _currentSkybox += 1;
            } 
        }
        
        // Change Umbrella effects
        //StartUmbrellaRainEffect();
        if (umbrellaEffectsOnLocation != 0)
        {
            if (_currentLocation == umbrellaEffectsOnLocation)
            {
                //StartUmbrellaRainEffect(0.3f);
                //leftOVRControllerHelper.SwapQuest2Controllers();
                SetUmbrellaVolume(0.1f);
            }
            else if (_currentLocation == umbrellaEffectsOnLocation + 1)
            {
                //StartUmbrellaRainEffect(0.6f);
                SetUmbrellaVolume(0.5f);
            }
        }

        /*switch (_currentScene)
        {
            case "Forest":
                
                break;
            case "Cave":
                if (_currentLocation < locations.Length)
                {
                    NextLocation();
                }
                else
                {
                    StartCoroutine(ChangeScene("Scenes/Beach"));
                }
                break;
            case "Beach":
                if (_currentLocation < locations.Length)
                {
                    NextLocation();
                }
                else
                {
                    // Ending
                }
                break;
        }*/
    }

    private void NextLocation()
    {
        locations.transform.GetChild(_currentLocation).gameObject.SetActive(false);
        _currentLocation += 1;
        locations.transform.GetChild(_currentLocation).gameObject.SetActive(true);
        
        // Update user location
        //_OVR.gameObject.transform.position = OVRLocations.transform.GetChild(_currentLocation).position;
        playerOrigin.position = OVRLocations.transform.GetChild(_currentLocation).position;
    }
    IEnumerator ChangeScene(string newScene, float delay = 0.0f)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(newScene);
        yield return null;
    }
    
    IEnumerator ChangeScene(int sceneBuildIndex, float delay = 0.0f)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneBuildIndex);
        yield return null;
    }

    private void LoadNextScene(float delay = 0.0f)
    {
        var currentSceneBuildIndex = SceneManager.GetActiveScene().buildIndex;
        StartCoroutine(ChangeScene(currentSceneBuildIndex + 1, delay));
    }
    
    private void StartUmbrellaRainEffect(float volume = 1.0f)
    {
        //umbrellaFabricMeshRenderer.materials[0] = umbrellaMaterialWetOn;
        //umbrellaFabricMeshRenderer.materials[1] = umbrellaMaterialDryOn;
        //umbrellaFabricMeshRenderer.material = umbrellaMaterialDryOn;
        umbrellaAudioSource.mute = false;
        umbrellaAudioSource.volume = volume;
        umbrellaAudioSource.Play();
    }
    
    private void SetUmbrellaVolume(float volume = 1.0f)
    {
        umbrellaAudioSource.mute = false;
        umbrellaAudioSource.volume = volume;
        umbrellaAudioSource.Play();
    }

    public void ChangeSceneDelayed(float delay = 0.0f)
    {
        LoadNextScene(delay);
    }
}
