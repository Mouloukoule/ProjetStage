using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Text Asset", menuName = "Content/Text")]
public class ContentText : Content
{
    [SerializeField] string textToDisplay = "";
    [SerializeField] List<LocalizedText> allTexts;

    public string TextToDisplay => textToDisplay;
    public List<LocalizedText> AllTexts => allTexts;
}

[Serializable]
public struct LocalizedText
{
    [SerializeField] string text;
    [SerializeField] ELanguage language;

    public string Text => text;
    public ELanguage Language => language;
}

[Serializable]
public enum ELanguage
{
    None,
    English,
    French,
    Spanish,
    German
}
