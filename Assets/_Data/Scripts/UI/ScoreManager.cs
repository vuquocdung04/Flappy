using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.U2D;

public class ScoreManager : LoadAutoComponents
{
    [SerializeField] protected TMP_Text textScore;
    [SerializeField] protected TMP_Text textScorePopUp;
    [SerializeField] protected TMP_Text hightScorePopUp;
    int score;
    int hightScore;

    private void Start()
    {
        hightScore = PlayerPrefs.GetInt(Const.HightScore, 0);
        //ObserverManager.Instance.AddListenerScore(OnUpdateScore);
        //ObserverManager.Instance.AddListenerPopUp(OnUpdateHightScorePopUp);
        ObserverManager.Instance.AddObserver(Const.ScorePlay, OnUpdateScore);
        ObserverManager.Instance.AddObserver(Const.HightScore, OnUpdateHightScorePopUp);
        ObserverManager.Instance.AddObserver(Const.ScorePopUp, OnUpdateScorePopUp);
    }

    private void OnDestroy()
    {
        //ObserverManager.Instance.RemoveListenerScore(OnUpdateScore);
        //ObserverManager.Instance.RemoveListenerPopUp(OnUpdateHightScorePopUp);

        if (ObserverManager.Instance == null) return;

        ObserverManager.Instance.RemoveObserver(Const.ScorePlay, OnUpdateScore);
        ObserverManager.Instance.RemoveObserver(Const.HightScore, OnUpdateHightScorePopUp);
        ObserverManager.Instance.RemoveObserver(Const.ScorePopUp, OnUpdateScorePopUp);
    }

    #region LoadComponent
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTextScore();
        this.LoadTextScorePopUp();
        this.LoadHighScorePopUp();
    }

    protected virtual void LoadTextScore()
    {
        if (this.textScore != null) return;
        this.textScore = transform.Find("GameObject").Find("ScoreText").GetComponent<TMP_Text>();
    }

    protected virtual void LoadTextScorePopUp()
    {
        if (this.textScorePopUp != null) return;
        this.textScorePopUp = GameObject.Find("ScorePopUp").GetComponent<TMP_Text>();
    }
    protected virtual void LoadHighScorePopUp()
    {
        if (this.hightScorePopUp != null) return;
        this.hightScorePopUp = GameObject.Find("HighScorePopUp").GetComponent<TMP_Text>();
    }
    #endregion
    public void OnUpdateScore()
    {
        score++;
        PlayerPrefs.SetInt(Const.Score,score);
        this.textScore.text = "Score: " + score.ToString();


        if(score > hightScore)
        {
            hightScore= score;
            PlayerPrefs.SetInt(Const.HightScore,hightScore);
        }

        //TODO: pipe speed up
        //if (score % 10 == 0 && score > 0)
        //{
        //    ObserverManager.Instance.Notify(Const.UpSpeedByScore);
        //    ObserverManager.Instance.Notify(Const.UpDistanceByScore);
        //}
    }
    public void OnUpdateScorePopUp()
    {
        this.textScorePopUp.text = "Score: " + score.ToString();
    }

    public void OnUpdateHightScorePopUp()
    {
        this.hightScorePopUp.text = "Best: " + PlayerPrefs.GetInt(Const.HightScore,hightScore);
    }
}
