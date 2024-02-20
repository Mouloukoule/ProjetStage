using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StopButton : CustomButton
{
    [SerializeField] Image image;

    public Image ImageRef => image;

    public override void Init()
    {
        base.Init();
        image = GetComponent<Image>();
    }
}
