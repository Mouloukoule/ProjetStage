using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UIModule : MonoBehaviour
{
    [SerializeField] protected Camera cameraRef;
    [SerializeField] protected Content contentToDisplay;
    [SerializeField] protected Module moduleRef;

    public Module ModuleRef { get { return moduleRef; } set { moduleRef = value; } }

    void Update()
    {
        RotateToFaceCamera();
    }

    public virtual void Init(Content _content)
    {
        cameraRef = Camera.main;
        if (!_content) return;
        contentToDisplay = _content;
    }

    public void SetVisibility(bool _value)
    {
        gameObject.SetActive(_value);
    }

    void RotateToFaceCamera()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - Camera.main.transform.position);
    }
}
