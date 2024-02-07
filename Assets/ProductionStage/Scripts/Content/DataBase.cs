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
        GetAllContentFromFile();
    }

    void GetAllContentFromFile()
    {
        contents = Resources.LoadAll(path, typeof(Content));
        foreach (Object _item in contents) 
        {
            Content _content = (Content)_item;
            if (!_content) continue;
            allContent.Add(_content);
        }
    }

    public Content GetRelatedContent(ARTrackedImage _image)
    {
        foreach (Content _content in allContent) 
        {
            if (_image.referenceImage.name == _content.ImageToDetect.name)
            {
                return _content;
            }
        }
        return null;
    }
}