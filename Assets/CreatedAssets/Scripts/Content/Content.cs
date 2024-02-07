using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Content : ScriptableObject
{
    [SerializeField] protected Texture2D imageToDetect = null;
    [SerializeField] protected EContentType type = EContentType.None;

    public Texture2D ImageToDetect => imageToDetect;
    public EContentType Type => type;
}

[Serializable]
public enum EContentType
{
    None,
    Image,
    Text,
    Video
}
