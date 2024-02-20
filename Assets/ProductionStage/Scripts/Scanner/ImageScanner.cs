using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ImageScanner : Singleton<ImageScanner>
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
        if (!ModuleManager.Instance || !DataBase.Instance) return;
        

        foreach (ARTrackedImage _image in _args.added)
        {
            //Asks DataBase if there is Content associated with this image
            Content _relatedContent = DataBase.Instance.GetRelatedContent(_image);
            if (!_relatedContent) continue;

            //if there is, sends it to the Module Manager
            ModuleManager.Instance.Execute(_relatedContent, _image.transform);
        }

        foreach (ARTrackedImage _image in _args.updated)
        {
            //_image.gameObject.SetActive(_image.trackingState == TrackingState.Tracking);
            //Content _relatedContent = DataBase.Instance.GetRelatedContent(_image);
            //if (!_relatedContent) continue;

            //bool _isImageTracked = _image.trackingState == TrackingState.Tracking;
            //Debug.Log($"{_image.name} is tracked: {_isImageTracked}");
            //ModuleManager.Instance.UpdateUIVisibility(_relatedContent, _isImageTracked);

            if (_image.trackingState == TrackingState.Tracking || _image.trackingState == TrackingState.Limited)
            {
                if (!_image) continue;
                UIModule _uimodule = _image.transform.GetComponentInChildren<UIModule>();
                Debug.Log("Image Valid");
                if(!_uimodule) continue;
                Debug.Log("ui module Valid");
                _uimodule.gameObject.SetActive(true);

                //_image.gameObject.SetActive(true);
                Debug.Log("Tracked");
            }
            else
            {
                if (!_image) continue;
                UIModule _uimodule = _image.transform.GetComponentInChildren<UIModule>();
                Debug.Log(" Not tracked Image Valid");
                if (!_uimodule) continue;
                Debug.Log("Not tracked ui module Valid");
                _uimodule.gameObject.SetActive(false);

                //_image.gameObject.SetActive(false);
                //Debug.Log("Not Tracked ");
            }
        }

        foreach (ARTrackedImage _image in _args.removed)
        {
            Debug.Log("Removed called");
        }
    }
}
