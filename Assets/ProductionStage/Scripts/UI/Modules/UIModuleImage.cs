using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIModuleImage : UIModule
{
    [SerializeField] RawImage imageToDisplay;

    public override void Init(Content _content)
    {
        base.Init(_content);
        ContentImage _contentImage = (ContentImage)_content;
        imageToDisplay = GetComponentInChildren<RawImage>();
        if (!_contentImage || !imageToDisplay) 
        {
            Debug.Log("no Content image or no raw image to get the texture to");
            return;
        }

        imageToDisplay.texture = _contentImage.ImageToDisplay;
        imageToDisplay.SetNativeSize();
        imageToDisplay.transform.localPosition = Vector3.zero;
        //Debug.Log("image Updated");

        float _ratioPanelToCanvasX = 2000 / imageToDisplay.texture.width;
        float _ratioPanelToCanvasY = 2000 / imageToDisplay.texture.height;

        imageToDisplay.rectTransform.localScale *= _ratioPanelToCanvasX <= _ratioPanelToCanvasY ? _ratioPanelToCanvasX : _ratioPanelToCanvasY;
        imageToDisplay.rectTransform.localScale = new Vector3(imageToDisplay.rectTransform.localScale.x, imageToDisplay.rectTransform.localScale.y, 1);
        //Debug.Log("scale updated");
    }
}
