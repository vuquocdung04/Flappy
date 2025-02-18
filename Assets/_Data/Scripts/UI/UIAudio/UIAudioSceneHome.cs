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
        if (PlayerPrefs.GetInt(Const.AudioBG, audioBG) == 0)
        {
            audioBG = 1;
            PlayerPrefs.SetInt(Const.AudioBG,audioBG);
            btnAudioBG.image.color = Color.red;
        }
        else
        {
            audioBG = 0;
            PlayerPrefs.SetInt(Const.AudioBG,audioBG);
            btnAudioBG.image.color = new Color32(35,255,0,255);
        }
    } 
    public void OnAudioClip()
    {
        if (PlayerPrefs.GetInt(Const.AudioClip, audioClip) == 0)
        {
            audioClip = 1;
            PlayerPrefs.SetInt(Const.AudioClip, audioClip);
            btnAudioClip.image.color = Color.red;
        }
        else
        {
            audioClip = 0;
            PlayerPrefs.SetInt(Const.AudioClip, audioClip);
            btnAudioClip.image.color = new Color32(35, 255, 0, 255);
        }
    }

}
