using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class Module : MonoBehaviour
{
    Action<Content> OnContentUpdate;
    [SerializeField] ARTrackedImageManager trackedImageManager;
    [SerializeField] protected Content currentContentToDisplay;
    [SerializeField] protected EContentType typeToDisplay;
    [SerializeField] protected UIModule UIToDisplay;

    private void Awake()
    {
        trackedImageManager = GetComponent<ARTrackedImageManager>();
    }

    void OnEnable()
    {
        trackedImageManager.trackedImagesChanged += ManageScan;
    }

    void OnDisable()
    {
        trackedImageManager.trackedImagesChanged -= ManageScan;
    }

    void ManageScan(ARTrackedImagesChangedEventArgs _args)
    {
        foreach (ARTrackedImage _trackedImage in _args.added)
        {
            if (currentContentToDisplay) continue;
            currentContentToDisplay = GetRelatedContent(_trackedImage);
        }

        foreach (ARTrackedImage _trackedImage in _args.updated)
        {

        }

        foreach (ARTrackedImage _trackedImage in _args.removed)
        {
            if (!currentContentToDisplay) continue;
            currentContentToDisplay = null;
        }
    }

    public virtual void Execute()
    {

    }

    protected void InstantiateUI()
    {

    }

    Content GetRelatedContent(ARTrackedImage _image)
    {
        if (DataBase.AllContent.Count < 1) return null;
        foreach (Content _content in DataBase.AllContent)
        {
            if (_image.referenceImage.texture == _content.ImageToDetect)
            {
                return _content;
            }
        }
        return null;
    }
}
