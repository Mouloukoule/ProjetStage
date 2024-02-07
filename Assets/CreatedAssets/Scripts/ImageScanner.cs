using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ImageScanner : MonoBehaviour
{
    [SerializeField] ModuleManager moduleManager = null;
    [SerializeField] ARTrackedImageManager trackedImageManager = null;

    private void Awake()
    {
        trackedImageManager = GetComponent<ARTrackedImageManager>();
        moduleManager = GetComponent<ModuleManager>();
    }

    void OnEnable()
    {
        if (!moduleManager || !trackedImageManager) return;
        trackedImageManager.trackedImagesChanged += SendImageToManager;

    }

    void OnDisable()
    {
        if (!moduleManager || !trackedImageManager) return;
        trackedImageManager.trackedImagesChanged -= SendImageToManager;
    }

    void SendImageToManager(ARTrackedImagesChangedEventArgs _args)
    {
        foreach (ARTrackedImage _image in _args.added)
        {
            foreach(Content _content in moduleManager.Db.AllContent)
            {
                if (_image.referenceImage.name == _content.ImageToDetect.name)
                {
                    moduleManager.Execute(_content);
                    return;
                }
            }
        }

    }
}
