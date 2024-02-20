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

    /// <summary>
    /// Gets all LanguageSwapButtons in children
    /// </summary>
    void GetAllButtons()
    {
        allButtons = GetComponentsInChildren<LanguageSwapButton>().ToList();
        //Debug.Log("got all buttons");
    }

    /// <summary>
    /// Subscribes the SetLanguage function to each  button, using the button's language as parameter
    /// </summary>
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

    /// <summary>
    /// Changes current language to target language
    /// </summary>
    /// <param name="_language"> target language </param>
    public void SetLanguage(ELanguage _language)
    {
        currentLanguage = _language;
        //Debug.Log($"language switched to {currentLanguage}");
        GetNewText(currentLanguage);
    }

    /// <summary>
    /// Checks if the language exists in the buttons and changes text accordingly
    /// </summary>
    /// <param name="_language"></param>
    public void GetNewText(ELanguage _language)
    {
        foreach (LanguageSwapButton _button in allButtons)
        {
            if (_language == _button.Language)
            {
                ChangeText(_language);
            }
        }
    }

    /// <summary>
    /// Gets the text with the same language in the ContentText and uses it to display
    /// </summary>
    /// <param name="_language"></param>
    public void ChangeText(ELanguage _language)
    {
        if (!moduleRef || !contentToDisplay) return;
        ContentText _content = contentToDisplay as ContentText;
        foreach (LocalizedText _text in _content.AllTexts)
        {
            if(_language == _text.Language)
            {
                textToDisplay.text = _text.Text;
                return;
            }
        }
    }
}
