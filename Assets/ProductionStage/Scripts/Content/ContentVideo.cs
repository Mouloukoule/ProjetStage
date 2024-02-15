using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

[CreateAssetMenu(fileName = "Video Asset", menuName = "Content/Video")]
public class ContentVideo : Content
{
    [SerializeField] VideoClip videoToDisplay = null;

    public VideoClip VideoToDisplay => videoToDisplay;
}
