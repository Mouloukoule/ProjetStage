using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuleImage : Module
{
    public override void Execute(Transform _transform)
    {
        //Casts the content sent by the manager as the type the module handles
        ContentImage _content = currentContentToDisplay as ContentImage;
        if(!_content) return;
        //Acts accordingly
        InstantiateUI(_transform);
    }
}
