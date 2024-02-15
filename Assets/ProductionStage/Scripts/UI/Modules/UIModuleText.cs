using System.Linq;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using System;

public class UIModuleText : UIModule
{
    public event Action<ELanguage> OnLanguageChanged = null;

    
    [SerializeField] TextMeshProUGUI textToDisplay;
    [SerializeField] Color textColor = Color.black;
    [SerializeField] Font font;
    [SerializeField] int textSize;
    [SerializeField] ScrollView scrollView;
    [SerializeField] ELanguage currentLanguage = ELanguage.English;
    [SerializeField] List<LanguageSwapButton> allButtons;

    public List<LanguageSwapButton> AllButtons => allButtons;
    
    public override void Init(Content _content)
    {
        base.Init(_content);
        ChangeText(currentLanguage);
        GetAllButtons();
        SubscribeToButtons();
        
    }

    void SubscribeToButtons()
    {
        foreach(LanguageSwapButton _button in allButtons) 
        {
            if (!_button) continue;
            _button.Init();
            if (!_button.ButtonRef) continue;
            _button.ButtonRef.onClick.AddListener(() => { SetLanguage(_button.Language); }  );
            //Debug.Log($"successfully subscribed to button : {_button.name}");
        }
    }

    void GetAllButtons()
    {
        allButtons = GetComponentsInChildren<LanguageSwapButton>().ToList();
        //Debug.Log("got all buttons");
    }

    public void SetLanguage(ELanguage _language)
    {
        currentLanguage = _language;
        //Debug.Log($"language switched to {currentLanguage}");
        GetNewText(currentLanguage);
    }

    public void GetNewText(ELanguage _language)
    {
        foreach (LanguageSwapButton _button in allButtons)
        {
            if (_language == _button.Language)
            {
                //Debug.Log("Got new text");
                ChangeText(_language);
            }
        }
    }

    public void ChangeText(ELanguage _language)
    {
        if (!moduleRef || !contentToDisplay) return;
        ContentText _content = contentToDisplay as ContentText;
        foreach (LocalizedText _text in _content.AllTexts)
        {
            if(_language == _text.Language)
            {
                textToDisplay.text = _text.Text;
                //Debug.Log("text changed to" + _text.Text);
                return;
            }
        }
    }
}
