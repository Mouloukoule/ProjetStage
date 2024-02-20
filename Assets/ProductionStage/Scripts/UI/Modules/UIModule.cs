using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UIModule : MonoBehaviour
{
    [SerializeField] protected Camera cameraRef;
    [SerializeField] protected Content contentToDisplay;
    [SerializeField] protected Module moduleRef;
    [SerializeField] protected CanvasGroup canvasGroupRef;

    public Module ModuleRef { get { return moduleRef; } set { moduleRef = value; } }
    public CanvasGroup CanvasGroupRef { get { return canvasGroupRef; } set { canvasGroupRef = value; } }

    void Update()
    {
        RotateToFaceCamera();
    }

    public virtual void Init(Content _content)
    {
        cameraRef = Camera.main;
        if (!_content) return;
        contentToDisplay = _content;
        canvasGroupRef = GetComponent<CanvasGroup>();
    }

    public void SetVisibility(bool _value)
    {
        gameObject.SetActive(_value);
    }

    void RotateToFaceCamera()
    {
        if (!cameraRef) return;
        transform.rotation = Quaternion.LookRotation(transform.position - cameraRef.transform.position);
    }
}
