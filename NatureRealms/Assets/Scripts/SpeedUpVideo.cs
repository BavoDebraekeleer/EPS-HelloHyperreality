using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class SpeedUpVideo : MonoBehaviour
{
    //[SerializeField] private GameObject videoPlayerObject;
    private VideoPlayer _videoPlayer;
    [SerializeField] private float speed = 0.01f;
    private bool _speedUp;

    private void Awake()
    {
        _videoPlayer = GetComponent<VideoPlayer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        _videoPlayer = GetComponent<VideoPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_speedUp)
        {
            _videoPlayer.playbackSpeed += speed * Time.deltaTime;
        }
    }

    public void StartSpeedUp()
    {
        _speedUp = true;
    }

    public void SetPlaybackSpeed(float newSpeed)
    {
        _videoPlayer.playbackSpeed = newSpeed;
    }
}
