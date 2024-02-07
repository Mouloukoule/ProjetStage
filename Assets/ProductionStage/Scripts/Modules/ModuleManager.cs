using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ModuleManager : Singleton<ModuleManager>
{
    [SerializeField] List<Module> allModules = new List<Module>();

    public List<Module> AllModules => allModules;

    void Start()
    {

    }

    /// <summary>
    /// Sends content to corresponding Module and calls its Execute function, 
    /// </summary>
    /// <param name="_content"> Content to check and send to the module</param>
    public void Execute(Content _content)
    {
        foreach (Module _module in allModules) 
        {
            if (!_module) continue;
            if (_module.TypeToDisplay == _content.Type)
            {
                _module.CurrentContentToDisplay = _content;
                _module.Execute();
                return;
            }
        }
    }
}
