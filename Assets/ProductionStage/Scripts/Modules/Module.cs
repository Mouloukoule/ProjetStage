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
    public virtual void Execute() { }

    protected virtual void InstantiateUI() { }

}
