using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuleVideo : Module
{
    public override void Execute()
    {
        //Casts the content sent by the manager as the type the module handles
        ContentVideo _content = currentContentToDisplay as ContentVideo;
        if (!_content) return;
        //Acts accordingly
        CustomDebug.DebugText($"Video : {_content.name}");
    }
}
