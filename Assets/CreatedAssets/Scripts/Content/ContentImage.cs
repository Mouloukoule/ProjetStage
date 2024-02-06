using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Image Asset", menuName = "Content/Image")]
public class ContentImage : Content
{
    [SerializeField] Image imageToDisplay = null;
}
