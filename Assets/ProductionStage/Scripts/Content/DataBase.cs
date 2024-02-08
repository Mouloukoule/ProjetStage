using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class DataBase : Singleton<DataBase>
{
    [SerializeField] List<Content> allContent = new List<Content>();
    [SerializeField] string path = "";
    Object[] contents = new Object[0];

    void Start()
    {
        GetAllContentFromFolder(path);
    }

    /// <summary>
    /// 
    /// Gets all content from folder located at specified path
    /// </summary>
    /// <param name="_path"> Path of the folder to get content from, starting at Resources </param>
    void GetAllContentFromFolder(string _path)
    {
        //Retrieve all Content from folder
        contents = Resources.LoadAll(_path, typeof(Content));

        //Checks if it is the right type and adds it to the list
        foreach (Object _item in contents) 
        {
            Content _content = (Content)_item;
            if (!_content) continue;
            allContent.Add(_content);
        }
    }

    /// <summary>
    /// Returns content associated with incoming image, returns null if no content has been found
    /// </summary>
    /// <param name="_image"> Image to get content from </param>
    /// <returns></returns>
    public Content GetRelatedContent(ARTrackedImage _image)
    {
        foreach (Content _content in allContent) 
        {
            //Compares names to get a match. Beware : strings !
            if (_image.referenceImage.name == _content.ImageToDetect.name)
            {
                return _content;
            }
        }
        return null;
    }
}