using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoHandler : MonoBehaviour
{
    [SerializeField] private string _url;
    [SerializeField] private VideoPlayer _videoPlayer;

    private void Start()
    {
        _videoPlayer.url = _url;
        _videoPlayer.Play();
        _videoPlayer.isLooping = true;
    }
}
