
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BtnPopUpGamePause : LoadAutoComponents
{
    [SerializeField] protected Transform image;
    [SerializeField] protected Button buttonHome;
    [SerializeField] protected Button buttonReplay;
    [SerializeField] protected Button buttonContinue;
    [SerializeField] protected Button buttonAudioClip;
    [SerializeField] protected Button buttonAudioSource;

    private void Start()
    {
        buttonHome.onClick.AddListener(OnGoHome);
        buttonReplay.onClick.AddListener(OnPlayAgain);
        buttonContinue.onClick.AddListener(OnPlayContinue);
        buttonAudioClip.onClick.AddListener(OnPlayAudioClip);
        buttonAudioSource.onClick.AddListener(OnPlayAudioSource);
    }
    #region LoadComponents
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadImage();
        this.LoadBtnHome();
        this.LoadBtnReplay();
        this.LoadBtnContinue();
        this.LoadBtnAudioClip();
        this.LoadBtnAudioSource();
    }

    protected virtual void LoadImage()
    {
        if (this.image != null) return;
        this.image = transform.Find("Image");
    }
    protected virtual void LoadBtnHome()
    {
        if (this.buttonHome != null) return;
        this.buttonHome = transform.Find("Image").Find("BtnHome").GetComponent<Button>();
    }
    protected virtual void LoadBtnReplay()
    {
        if (this.buttonReplay != null) return;
        this.buttonReplay = transform.Find("Image").Find("BtnReplay").GetComponent<Button>();
    }
    protected virtual void LoadBtnContinue()
    {
        if (this.buttonContinue != null) return;
        this.buttonContinue = transform.Find("Image").Find("BtnContinue").GetComponent<Button>();
    }
    protected virtual void LoadBtnAudioClip()
    {
        if (this.buttonAudioClip != null) return;
        this.buttonAudioClip = transform.Find("Image").Find("BtnSoundAudioClip").GetComponent<Button>();
    }
    protected virtual void LoadBtnAudioSource()
    {
        if (this.buttonAudioSource != null) return;
        this.buttonAudioSource = transform.Find("Image").Find("BtnSoundBG").GetComponent<Button>();
    }
    #endregion

    public void OnGoHome()
    {
        Debug.LogError("GoHome");
    }
    public void OnPlayAgain()
    {
        SceneManager.LoadScene("SampleScene");
        SceneTimeScale.ContinueGame();
    }
    public void OnPlayContinue()
    {
        UIManager.Instance.UICenter.BtnPopUpGamePause.gameObject.SetActive(false);
        SceneTimeScale.ContinueGame();
    }
    public void OnPlayAudioClip()
    {
        Debug.LogError("PlayAudioClip");
    }
    public void OnPlayAudioSource()
    {
        Debug.LogError("PlayAudioSource");
    }
}
