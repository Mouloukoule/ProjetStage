using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataBase : MonoBehaviour
{
    [SerializeField] static List<Content> allContent = new List<Content>();
    public static List<Content> AllContent => allContent;
}
