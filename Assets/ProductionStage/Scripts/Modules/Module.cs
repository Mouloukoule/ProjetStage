using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public abstract class Module : MonoBehaviour
{
    Action<Content> OnContentUpdate;

    [SerializeField] protected Content currentContentToDisplay;
    [SerializeField] protected EContentType typeToDisplay;
    [SerializeField] protected UIModule UIToDisplay;
    [SerializeField] protected ModuleManager moduleManager = null;

    public EContentType TypeToDisplay => typeToDisplay;
    public Content CurrentContentToDisplay {  get { return currentContentToDisplay; }  set { currentContentToDisplay = value; } }


    void Start()
    {
        Init();
    }

    void Init()
    {
        moduleManager = ModuleManager.Instance;
        if (!moduleManager) return;
        moduleManager.AllModules.Add(this);
    }

    public virtual void Execute() { }

    protected virtual void InstantiateUI() { }

    //public virtual void ManageScan(ARTrackedImagesChangedEventArgs _args) { }

    //Content GetRelatedContent(ARTrackedImage _image)
    //{
    //    return null;
    //}
}
