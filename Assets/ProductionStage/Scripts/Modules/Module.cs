using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public abstract class Module : MonoBehaviour
{
    [SerializeField] protected Content currentContentToDisplay;
    [SerializeField] protected EContentType typeToDisplay;
    [SerializeField] protected UIModule UIToDisplay;
    [SerializeField] protected UIModule currentUI;
    [SerializeField] protected bool useDebug = true;
    public EContentType TypeToDisplay => typeToDisplay;
    public Content CurrentContentToDisplay {  get { return currentContentToDisplay; }  set { currentContentToDisplay = value; } }


    void Start()
    {
        Init();
    }

    void Init()
    {
        if (!ModuleManager.Instance) return;
        ModuleManager.Instance.AllModules.Add(this);
    }

    /// <summary>
    /// The Module execute the defined task according to its type
    /// </summary>
    public virtual void Execute(Transform _transform) { }


    protected virtual void InstantiateUI(Transform _parent) 
    {
        if (!UIToDisplay || !currentContentToDisplay) return;
        currentUI = Instantiate(UIToDisplay);
        currentUI.transform.parent = _parent;
        currentUI.transform.localPosition = new Vector3(0, 0, 1);
        currentUI.ModuleRef = this;
        currentUI.SetVisibility(true);
        currentUI.Init(CurrentContentToDisplay);
    }

}
