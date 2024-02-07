using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuleText : Module
{
    public override void Execute()
    {
        ContentText _text = currentContentToDisplay as ContentText;
        Debug.Log($"text : {_text.TextToDisplay}");
    }
}
