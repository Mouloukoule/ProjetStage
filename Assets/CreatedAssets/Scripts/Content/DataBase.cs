using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataBase : MonoBehaviour
{
    [SerializeField] List<Content> allContent = new List<Content>();
    public List<Content> AllContent => allContent;
}
