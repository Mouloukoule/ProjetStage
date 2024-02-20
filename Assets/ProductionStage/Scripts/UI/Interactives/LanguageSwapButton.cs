using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LanguageSwapButton : CustomButton
{
    [SerializeField] ELanguage language;

    public ELanguage Language => language;
}
