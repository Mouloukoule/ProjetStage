using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class CustomButton : MonoBehaviour
{
    [SerializeField] Button button;

    public Button ButtonRef => button;

    public virtual void Init()
    {
        button = GetComponent<Button>();
    }
}
