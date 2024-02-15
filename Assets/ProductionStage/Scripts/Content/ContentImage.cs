using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Image Asset", menuName = "Content/Image")]
public class ContentImage : Content
{
    [SerializeField] Texture2D imageToDisplay = null;

    public Texture2D ImageToDisplay => imageToDisplay;
}
