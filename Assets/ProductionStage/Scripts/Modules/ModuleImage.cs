using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuleImage : Module
{
    public override void Execute()
    {
        //Casts the content sent by the manager as the type the module handles
        ContentImage _content = currentContentToDisplay as ContentImage;
        if(!_content) return;
        //Acts accordingly
        CustomDebug.DebugText($"Image : {_content.ImageToDisplay.name}");
    }
}
