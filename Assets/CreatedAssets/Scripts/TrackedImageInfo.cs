using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARTrackedImageManager))]
public class TrackedImageInfo : MonoBehaviour
{
    ARTrackedImageManager trackedImageManager = null;

    //prefabs to instantiate when corresponding tracked image is detected
    public GameObject[] arPrefabs;

    //keep dictionary of created prefabs
    readonly Dictionary<string, GameObject> instanciatedPrefabs = new Dictionary<string, GameObject>();

    void Awake()
    {
        //get reference of manager
        trackedImageManager = GetComponent<ARTrackedImageManager>();
    }

    void OnEnable()
    {
        //adds listener for when image is changed (on new image detected, image moved or image exiting view)
        trackedImageManager.trackedImagesChanged += OnTrackedImagesChanged;
    }

    void OnDisable()
    {
        //removes listener
        trackedImageManager.trackedImagesChanged -= OnTrackedImagesChanged;
    }

    //method to call on image changes
    void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        //loops through all new tracked images detected
        foreach (ARTrackedImage _trackedImage in eventArgs.added)
        {
            //get new image name
            string _imageName = _trackedImage.referenceImage.name;

            //loop over prefabs
            foreach (GameObject _prefab in arPrefabs)
            {
                //check if prefab name matches the tracked image name and that prefab does not already exist in the dictionary
                if (string.Compare(_prefab.name, _imageName, StringComparison.OrdinalIgnoreCase) == 0 && !instanciatedPrefabs.ContainsKey(_imageName))
                {
                    //Instanciate the prefab, parented to ARTrackedImage
                    GameObject _newPrefab = Instantiate(_prefab, _trackedImage.transform);
                    //add the prefab to the dictionary
                    instanciatedPrefabs[_imageName] = _newPrefab;
                }
            }
        }

        //for all prefabs already created, set them active if their corresponding image id being tracked
        foreach (ARTrackedImage _trackedImage in eventArgs.updated)
        {
            //instanciatedPrefabs[_trackedImage.referenceImage.name].SetActive(_trackedImage.trackingState == TrackingState.Tracking);
        }

        //if AR subsytems stops looking for tracked image
        foreach (ARTrackedImage _trackedImage in eventArgs.removed)
        {
            //sets prefab to inactive
            instanciatedPrefabs[_trackedImage.referenceImage.name].SetActive(false);
        }
    }

    private void Update()
    {
        ListAllImages();
    }

    void ListAllImages()
    {
        Debug.Log(
            $"There are {trackedImageManager.trackables.count} images being tracked.");

        foreach (var trackedImage in trackedImageManager.trackables)
        {
            Debug.Log($"Image: {trackedImage.referenceImage.name} is at " +
                      $"{trackedImage.transform.position}");
        }
    }
}
