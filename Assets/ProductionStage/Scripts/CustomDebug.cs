using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomDebug : MonoBehaviour
{
    public static void DebugText(bool _value, string _text)
    {
        if (!_value) return;
        Debug.Log(_text);
    }
}
