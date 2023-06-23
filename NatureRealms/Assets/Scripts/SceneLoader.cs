using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class SceneLoader : Singleton<SceneLoader>
{
    [SerializeField] public UnityEvent onLoadBegin = new UnityEvent();
    [SerializeField] public UnityEvent onLoadEnd = new UnityEvent();

    private bool _isLoading = false;
    
    private void Awake()
    {
        SceneManager.sceneLoaded += SetActiveScene;
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= SetActiveScene;
    }

    public void LoadNewSceneUnloadCurrent(string sceneName)
    {
        if (!_isLoading)
        {
            StartCoroutine(SwitchScene(sceneName));
        }
    }

    public void LoadNewSceneAdditive(string sceneName)
    {
        if (!_isLoading)
        {
            StartCoroutine(LoadScene(sceneName));
        }
    }

    public void UnloadSceneSwitchActive(string sceneName)
    {
        if (!_isLoading)
        {
            onLoadBegin?.Invoke();
            StartCoroutine(UnloadScene(sceneName));
            onLoadEnd?.Invoke();
        }
    }

    private IEnumerator SwitchScene(string sceneName)
    {
        _isLoading = true;

        onLoadBegin?.Invoke();
        yield return StartCoroutine(UnloadCurrent());

        yield return StartCoroutine(LoadNew(sceneName));
        onLoadEnd?.Invoke();
        
        _isLoading = false;
        yield return null;
    }
    
    private IEnumerator LoadScene(string sceneName)
    {
        _isLoading = true;

        onLoadBegin?.Invoke();
        yield return StartCoroutine(LoadNew(sceneName));
        onLoadEnd?.Invoke();
        
        _isLoading = false;
        yield return null;
    }

    private IEnumerator UnloadCurrent()
    {
        // Unload active scene
        AsyncOperation unloadAsyncOperation = SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
        while (!unloadAsyncOperation.isDone)
            yield return null;
    }
    
    private IEnumerator UnloadScene(string sceneName)
    {
        // Unload active scene
        AsyncOperation unloadAsyncOperation = SceneManager.UnloadSceneAsync(sceneName);
        while (!unloadAsyncOperation.isDone)
            yield return null;
    }
    
    private IEnumerator LoadNew(string sceneName)
    {
        AsyncOperation loadAsyncOperation = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        while(!loadAsyncOperation.isDone)
            yield return null;
    }

    private void SetActiveScene(Scene scene, LoadSceneMode mode)
    {
        SceneManager.SetActiveScene(scene);
    }
}
