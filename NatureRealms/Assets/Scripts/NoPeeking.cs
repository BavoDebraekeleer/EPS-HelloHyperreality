using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoPeeking : MonoBehaviour
{
    [SerializeField] private float fadeSpeed;
    [SerializeField] private float sphereCheckSize = .15f;
    [SerializeField] private LayerMask collisionLayer;

    private Material _cameraFadeMat;
    private bool _isCameraFadeOut;

    private void Awake()
    {
        _cameraFadeMat = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.CheckSphere(transform.position, sphereCheckSize, collisionLayer, QueryTriggerInteraction.Ignore))
            StartCoroutine(CameraFade(1f));
        else
            StartCoroutine(CameraFade(0f));
    }

    IEnumerator CameraFade(float targetAlpha)
    {
        var fadeValue =
            Mathf.MoveTowards(_cameraFadeMat.GetFloat("_AlphaValue"), targetAlpha, Time.deltaTime * fadeSpeed);
        _cameraFadeMat.SetFloat("_AlphaValue", fadeValue);

        yield return null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0f, 1f, 0f, 0.75f);
        Gizmos.DrawSphere(transform.position, sphereCheckSize);
    }
}
