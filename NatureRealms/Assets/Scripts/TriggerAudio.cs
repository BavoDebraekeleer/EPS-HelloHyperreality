using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAudio : MonoBehaviour
{
    [SerializeField] private LayerMask triggerLayer;    
    [SerializeField] private float sphereCheckSize = .15f;
    [SerializeField] private AudioSource[] audio;

    private int _audioIndex;
    private bool _playAudioCooldown = true;

    private void OnValidate()
    {
        foreach (var audioSource in audio)
        {
            audioSource.playOnAwake = false;
        }
    }

    private void Start()
    {
        _playAudioCooldown = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (_playAudioCooldown)
        {
            if (Physics.CheckSphere(transform.position, sphereCheckSize, triggerLayer, QueryTriggerInteraction.Collide))
            {
                audio[_audioIndex].Play();
                _audioIndex++;
                if (_audioIndex >= audio.Length)
                {
                    _audioIndex = 0;
                }
                Cooldown(3);
            }
        }
    }
    
    IEnumerator Cooldown(int delay = 1)
    {
        _playAudioCooldown = false;
        yield return new WaitForSeconds(delay);
        _playAudioCooldown = true;
    }
}
