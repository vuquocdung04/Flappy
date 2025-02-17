using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIAudioSceneHome : LoadAutoComponents
{
    [SerializeField] protected Button btnAudioBG;
    [SerializeField] protected Button btnAudioClip;
    int audioBG = 0;
    int audioClip = 0;

    private void Start()
    {
        this.btnAudioBG.onClick.AddListener(OnAudioBG);
        this.btnAudioClip.onClick.AddListener(OnAudioClip);
    }
    #region LoadComponent
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBtnAudioBG();
        this.LoadBtnAudioClip();
    }

    protected virtual void LoadBtnAudioBG()
    {
        if (this.btnAudioBG != null) return;
        this.btnAudioBG = transform.Find("BtnAudioBG").GetComponent<Button>();
    }

    protected virtual void LoadBtnAudioClip()
    {
        if (this.btnAudioClip != null) return;
        this.btnAudioClip = transform.Find("BtnAudioClip").GetComponent<Button>();
    }
    #endregion

    public void OnAudioBG()
    {
        if (audioBG == 0)
        {
            audioBG = 1;
            btnAudioBG.image.color = Color.red;
        }
        else
        {
            audioBG = 0;
            btnAudioBG.image.color = new Color32(35,255,0,255);
        }
    } 
    public void OnAudioClip()
    {
        if (audioClip == 0)
        {
            audioClip = 1;
            btnAudioClip.image.color = Color.red;
        }
        else
        {
            audioClip = 0;
            btnAudioClip.image.color = new Color32(35, 255, 0, 255);
        }
    }

}
