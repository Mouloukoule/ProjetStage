using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuleImage : Module
{
    public override void Execute()
    {
        ContentImage _content = currentContentToDisplay as ContentImage;
        Debug.Log($"Image : {_content.ImageToDisplay.name}");
    }
}
