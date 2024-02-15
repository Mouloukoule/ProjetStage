using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ModuleManager : Singleton<ModuleManager>
{
    [SerializeField] List<Module> allModules = new List<Module>();

    public List<Module> AllModules => allModules;

    /// <summary>
    /// Sends content to corresponding Module and calls its Execute function, 
    /// </summary>
    /// <param name="_content"> Content to check and send to the module</param>
    public void Execute(Content _content, Transform _transform)
    {
        //Checks each module for type to display corresponding to the content type
        foreach (Module _module in allModules) 
        {
            if (!_module) continue;
            if (_module.TypeToDisplay == _content.Type)
            {
                //if it finds one, sets its content to display to the content 
                _module.CurrentContentToDisplay = _content;
                //and asks for it to execute its task
                _module.Execute(_transform);
                return;
            }
        }
    }
}
