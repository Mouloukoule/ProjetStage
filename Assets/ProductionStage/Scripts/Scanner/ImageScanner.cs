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

            Content _relatedContent = DataBase.Instance.GetRelatedContent(_image);
            if (!_relatedContent) continue;
            ModuleManager.Instance.Execute(_relatedContent);
            return;
        }

    }
}
