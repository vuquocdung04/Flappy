using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : LoadAutoComponents
{
    [SerializeField] protected TMP_Text textScore;
    int score;
    private void Start()
    {
        ObserverManager.Instance.AddListener(OnUpdateScore);
    }

    private void OnDestroy()
    {
        ObserverManager.Instance.RemoveListener(OnUpdateScore);
    }

    #region LoadComponent
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTextScore();
    }

    protected virtual void LoadTextScore()
    {
        if (this.textScore != null) return;
        this.textScore = transform.Find("GameObject").Find("ScoreText").GetComponent<TMP_Text>();
    }
    #endregion
    public void OnUpdateScore()
    {
        score++;
        this.textScore.text = "Score: " + score.ToString();
    }
}
