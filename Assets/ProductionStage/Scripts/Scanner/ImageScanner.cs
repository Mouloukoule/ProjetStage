using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ImageScanner : MonoBehaviour
{
    [SerializeField] ARTrackedImageManager trackedImageManager = null;

    private void Awake()
    {
        Init();
    }

    void Init()
    {
        trackedImageManager = GetComponent<ARTrackedImageManager>();
    }

    void OnEnable()
    {
        if (!trackedImageManager) return;
        //Event called when the camera detects a change of image, subscribe what function we want to handle the rest
        trackedImageManager.trackedImagesChanged += SendContentToManager;

    }

    void OnDisable()
    {
        if (!trackedImageManager) return;
        trackedImageManager.trackedImagesChanged -= SendContentToManager;
    }

    /// <summary>
    /// Gets content from image from DataBase and sends it to the Module Manager
    /// </summary>
    /// <param name="_args"></param>
    void SendContentToManager(ARTrackedImagesChangedEventArgs _args)
    {
        if (!ModuleManager.Instance) return;

        foreach (ARTrackedImage _image in _args.added)
        {
            if (!DataBase.Instance) return;
            //Asks DataBase if there is Content associated with this image
            Content _relatedContent = DataBase.Instance.GetRelatedContent(_image);
            if (!_relatedContent) continue;
            //if there is, sends it to the Module Manager
            ModuleManager.Instance.Execute(_relatedContent);
            return;
        }

    }
}
