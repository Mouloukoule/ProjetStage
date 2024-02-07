using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuleVideo : Module
{
    public override void Execute()
    {
        ContentVideo _content = currentContentToDisplay as ContentVideo;
        if (!_content) return;
        Debug.Log($"Video : {_content.name}");
    }
}
