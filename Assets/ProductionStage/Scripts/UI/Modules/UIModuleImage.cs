using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIModuleImage : UIModule
{
    [SerializeField] RawImage imageToDisplay;
    [SerializeField] GameObject panel;

    public override void Init(Content _content)
    {
        base.Init(_content);
        ContentImage _contentImage = (ContentImage)_content;
        imageToDisplay = GetComponentInChildren<RawImage>();
        if (!_contentImage || !imageToDisplay) return;

        //Change Raw Image's texture to content texture
        imageToDisplay.texture = _contentImage.ImageToDisplay;
        //sets Raw Image size to native texture size
        imageToDisplay.SetNativeSize();
        imageToDisplay.transform.localPosition = Vector3.zero;


        if (!panel) return;
        float _ratioPanelToCanvasX = 2000 / imageToDisplay.rectTransform.sizeDelta.x;
        float _ratioPanelToCanvasY = 2000 / imageToDisplay.rectTransform.sizeDelta.y;

        float _scaleRatio =  _ratioPanelToCanvasX <= _ratioPanelToCanvasY ? _ratioPanelToCanvasX : _ratioPanelToCanvasY;

        panel.transform.localScale = new Vector3(panel.transform.localScale.x * _scaleRatio, panel.transform.localScale.y * _scaleRatio, 1);
    }
}
