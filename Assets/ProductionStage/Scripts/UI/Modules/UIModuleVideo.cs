using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class UIModuleVideo : UIModule
{
    [SerializeField] VideoPlayer videoPlayer;
    [SerializeField] PlayButton playButton;
    [SerializeField] StopButton stopButton;

    public override void Init(Content _content)
    {
        base.Init(_content);
        videoPlayer = GetComponent<VideoPlayer>();
        playButton = GetComponentInChildren<PlayButton>();
        stopButton = GetComponentInChildren<StopButton>();
        ContentVideo _contentVideo = (ContentVideo)contentToDisplay;
        if (!videoPlayer || !playButton || !stopButton || !_contentVideo)
        {
            Debug.Log("Missing a key component or content");
            return;
        }
        playButton.Init();
        stopButton.Init();
        if (!playButton.ButtonRef || !stopButton.ButtonRef) return;
        playButton.ButtonRef.onClick.AddListener(SwitchPlay);
        stopButton.ButtonRef.onClick.AddListener(() => 
        { 
            videoPlayer.Stop();
            playButton.Text.text = "Play";
        });

        videoPlayer.clip = _contentVideo.VideoToDisplay;
        if (!videoPlayer.clip)
        {
            Debug.Log("No clip found");
            return; 
        }
        videoPlayer.Play();
        videoPlayer.SetDirectAudioVolume(0, .1f);
    }

    void SwitchPlay()
    {
        if(videoPlayer.isPaused)
        {
            videoPlayer.Play();
            playButton.Text.text = "Pause";
            return;
        }
        videoPlayer.Pause();
        playButton.Text.text = "Play";
    }
}
