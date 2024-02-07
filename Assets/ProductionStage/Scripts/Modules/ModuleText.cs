using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuleText : Module
{
    public override void Execute()
    {
        ContentText _content = currentContentToDisplay as ContentText;
        if (!_content) return;
        Debug.Log($"text : {_content.TextToDisplay}");
    }
}
