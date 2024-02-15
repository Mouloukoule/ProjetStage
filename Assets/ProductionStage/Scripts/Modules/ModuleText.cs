using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuleText : Module
{
    
    public override void Execute(Transform _transform)
    {
        //Casts the content sent by the manager as the type the module handles
        ContentText _content = currentContentToDisplay as ContentText;
        if (!_content) return;
        //Acts accordingly
        //CustomDebug.DebugText(useDebug, $"text : {_content.TextToDisplay}");
        InstantiateUI(_transform);
    }
}
