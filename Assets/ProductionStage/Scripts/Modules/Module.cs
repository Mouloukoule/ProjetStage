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

    public EContentType TypeToDisplay => typeToDisplay;
    public Content CurrentContentToDisplay {  get { return currentContentToDisplay; }  set { currentContentToDisplay = value; } }
    public UIModule CurrentUI {  get { return currentUI; }  set { currentUI = value; } }


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

    /// <summary>
    /// Instanciates the Corresponding UI, parent it to a Transform, makes it visible and initializes its variables.
    /// </summary>
    /// <param name="_parent"> Tranform to use as a parent for the UI </param>
    protected virtual void InstantiateUI(Transform _transform) 
    {
        if (!UIToDisplay || !currentContentToDisplay) return;
        currentUI = Instantiate(UIToDisplay);
        if (!currentUI) return;
        currentUI.transform.SetParent(_transform);
        currentUI.transform.localPosition = new Vector3(0, 0, 0);
        currentUI.ModuleRef = this;
        currentUI.SetVisibility(true);
        currentUI.Init(CurrentContentToDisplay);
    }

}
