using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

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
        ObserverManager.Instance.AddListenerScore(OnUpdateScore);
        ObserverManager.Instance.AddListenerScore(OnUpdateScorePopUp);
    }

    private void OnDestroy()
    {
        ObserverManager.Instance.RemoveListenerScore(OnUpdateScore);
        ObserverManager.Instance.RemoveListenerScore(OnUpdateScorePopUp);
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
            OnUpdateHightScorePopUp();
        }
        
    }
    public void OnUpdateScorePopUp()
    {
        score++;
        this.textScorePopUp.text = "Score: " + score++.ToString();
    }

    public void OnUpdateHightScorePopUp()
    {
        this.hightScorePopUp.text = "Best: " + hightScore.ToString();
    }
}
