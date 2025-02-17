using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : LoadAutoComponents
{
    [Header("AudioBG")]
    [SerializeField] protected AudioSource sourceBG;
    [SerializeField] protected AudioClip clipBG;
    [Header("AudioPlay")]
    [SerializeField] protected AudioSource sourcePlay;
    [SerializeField] protected AudioClip clipPoint;
    [SerializeField] protected AudioClip clipDie;
    [SerializeField] protected AudioClip clipFly;

    private void Start()
    {
        ObserverManager.Instance.AddObserver(Const.AudioClipPoint,PlayClipPoint);
        ObserverManager.Instance.AddObserver(Const.AudioClipDie, PlayClipDie);
        ObserverManager.Instance.AddObserver(Const.AudioClipFly, PlayClipFly);
    }

    private void OnDestroy()
    {
        if (ObserverManager.Instance == null) return;
        ObserverManager.Instance.RemoveObserver(Const.AudioClipPoint, PlayClipPoint);
        ObserverManager.Instance.RemoveObserver(Const.AudioClipDie, PlayClipDie);
        ObserverManager.Instance.RemoveObserver(Const.AudioClipFly, PlayClipFly);
    }

    #region LoadComponents
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAudioSourceBG();
        this.LoadAudioSourcePlay();
    }

    protected virtual void LoadAudioSourceBG()
    {
        if (this.sourceBG != null) return;
        this.sourceBG = transform.Find("AudioSourceBG").GetComponent<AudioSource>();
    }

    protected virtual void LoadAudioSourcePlay()
    {
        if (this.sourcePlay != null) return;
        this.sourcePlay = transform.Find("AudioSourceClip").GetComponent<AudioSource>();
    }
    #endregion
    public void PlayClipPoint()
    {
        sourcePlay.PlayOneShot(clipPoint);
    }
    public void PlayClipDie()
    {
        sourcePlay.PlayOneShot(clipDie);
    }
    public void PlayClipFly()
    {
        sourcePlay.PlayOneShot(clipFly);
    }
    public void PlayClipBG()
    {
        sourceBG.loop = true;
        sourceBG.clip = clipBG;
        sourceBG.playOnAwake = true;
        sourceBG.Play();
    }

}
