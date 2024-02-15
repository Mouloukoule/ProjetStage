using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LanguageSwapButton : MonoBehaviour
{
    [SerializeField] ELanguage language;
    [SerializeField] Button button;

    public ELanguage Language => language;
    public Button ButtonRef => button;

    public void Init()
    {
        button = GetComponent<Button>();
        //Debug.Log("got buttonRef");
    }
}
