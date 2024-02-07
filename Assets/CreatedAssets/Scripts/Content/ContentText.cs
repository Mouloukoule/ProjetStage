using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Text Asset", menuName = "Content/Text")]
public class ContentText : Content
{
    [SerializeField] string textToDisplay = "";
    [SerializeField] LocalizedText textToDisplayText;

    public string TextToDisplay => textToDisplay;
}

[Serializable]
public struct LocalizedText
{
    [SerializeField] string text;
    [SerializeField] ELanguage language;
}

[Serializable]
public enum ELanguage
{
    English,
    French,
    Spanish,
    German
}
