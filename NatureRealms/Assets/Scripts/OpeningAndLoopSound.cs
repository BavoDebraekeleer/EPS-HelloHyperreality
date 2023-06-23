using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]

public class OpeningAndLoopSound : MonoBehaviour
{
    [SerializeField] private AudioClip openingAudioClip;
    [SerializeField] private AudioClip loopAudioClip;
    [SerializeField] private int delay = 1;
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = 5;
        StartCoroutine(PlayOpening());
        StartCoroutine(PlayLoop());
    }

    IEnumerator PlayOpening()
    {
        yield return new WaitForSeconds(delay);
        _audioSource.clip = openingAudioClip;
        _audioSource.Play();
    }

    IEnumerator PlayLoop()
    {
        yield return new WaitForSeconds(openingAudioClip.length);
        _audioSource.clip = loopAudioClip;
        _audioSource.loop = true;
        _audioSource.Play();
    }
}
