using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ModuleManager : MonoBehaviour
{
    [SerializeField] List<Module> allModules = new List<Module>();
    [SerializeField] DataBase db = null;

    public DataBase Db => db;
    public List<Module> AllModules => allModules;

    void Start()
    {
        db = GetComponent<DataBase>();
    }


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
