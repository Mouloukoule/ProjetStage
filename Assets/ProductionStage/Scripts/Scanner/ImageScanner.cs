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
        Init();
    }

    void Init()
    {
        trackedImageManager = GetComponent<ARTrackedImageManager>();
        moduleManager = ModuleManager.Instance;
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

    void SendContentToManager(ARTrackedImagesChangedEventArgs _args)
    {
        if (!moduleManager) return;

        foreach (ARTrackedImage _image in _args.added)
        {
            if (!DataBase.Instance) return;

            Content _relatedContent = DataBase.Instance.GetRelatedContent(_image);
            if (!_relatedContent) continue;
            moduleManager.Execute(_relatedContent);
            return;
        }

    }
}
