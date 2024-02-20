using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class UIModuleVideo : UIModule
{
    [SerializeField] VideoPlayer videoPlayer;
    [SerializeField] RenderTexture texture;
    [SerializeField] PlayButton playButton;
    [SerializeField] StopButton stopButton;
    [SerializeField] Sprite playImage;
    [SerializeField] Sprite pauseImage;
    [SerializeField, Range(1,10)] int volume = 1;

    public override void Init(Content _content)
    {
        base.Init(_content);
        videoPlayer = GetComponent<VideoPlayer>();
        playButton = GetComponentInChildren<PlayButton>();
        stopButton = GetComponentInChildren<StopButton>();
        ContentVideo _contentVideo = (ContentVideo)contentToDisplay;
        texture = videoPlayer.targetTexture;
        if (!videoPlayer || !playButton || !stopButton || !_contentVideo || !texture) return;
        playButton.Init();
        stopButton.Init();

        if (!playButton.ButtonRef || !stopButton.ButtonRef) return;
        playButton.ButtonRef.onClick.AddListener(SwitchPlay);
        stopButton.ButtonRef.onClick.AddListener(() => 
        { 
            videoPlayer.Stop();
            ChangeButtonAppearance(playButton.ImageRef, playImage);
            texture.Release();
        });

        videoPlayer.clip = _contentVideo.VideoToDisplay;
        if (!videoPlayer.clip) return;
        videoPlayer.Play();
        videoPlayer.SetDirectAudioVolume(0, .1f);
    }

    /// <summary>
    /// Switches between play and pause and changes button appearance
    /// </summary>
    void SwitchPlay()
    {
        if(!videoPlayer.isPlaying)
        {
            videoPlayer.Play();
            ChangeButtonAppearance(playButton.ImageRef, pauseImage);
            return;
        }
        videoPlayer.Pause();
        ChangeButtonAppearance(playButton.ImageRef, playImage);
    }

    /// <summary>
    /// Changes the Image's Sprite to display
    /// </summary>
    /// <param name="_support"> Target Image </param>
    /// <param name="_imageToDisplay"> Sprite to display </param>
    void ChangeButtonAppearance(Image _support, Sprite _imageToDisplay)
    {
        if (!_support || !_imageToDisplay) return;
        _support.sprite = _imageToDisplay;
    }

    void OnDisable()
    {
        texture.Release();
    }
}
