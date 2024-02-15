using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StopButton : MonoBehaviour
{
    [SerializeField] Button button;

    public Button ButtonRef => button;

    public void Init()
    {
        button = GetComponent<Button>();
        //Debug.Log("got buttonRef");
    }
}
