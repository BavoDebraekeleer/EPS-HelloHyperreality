using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadScene : MonoBehaviour
{
    [SerializeField] private string sceneToLoad = string.Empty;
    
    public void LoadGame()
    {
        SceneLoader.Instance.LoadNewSceneUnloadCurrent(sceneToLoad);
    }
}
