using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuleVideo : Module
{

    public override void Execute(Transform _transform)
    {
        //Casts the content sent by the manager as the type the module handles
        ContentVideo _content = currentContentToDisplay as ContentVideo;
        if (!_content) return;
        //Acts accordingly
        //CustomDebug.DebugText(useDebug, $"Video : {_content.name}");
        InstantiateUI(_transform);
    }
}
