using System.Collections;
using TMPro;
using UnityEngine;

public class CountDownManager : LoadAutoComponents
{
    [SerializeField] protected int countDownStartNumber = 3;
    [SerializeField] protected int countDownCount;
    [SerializeField] protected TMP_Text countDownText;
    [SerializeField] protected Transform parent;

    Coroutine coroutine;

    protected override void Awake()
    {
        SceneTimeScale.PauseGame();
        base.Awake();

    }
    private void Start()
    {
        StartCountDown();
        ObserverManager.Instance.AddObserver(Const.CountDown, StartCountDown);
        ObserverManager.Instance.AddObserver(Const.ListenerCount,ResetCount);
    }

    private void OnDestroy()
    {
        if (ObserverManager.Instance == null) return;
        ObserverManager.Instance.RemoveObserver(Const.CountDown, StartCountDown);
        ObserverManager.Instance.RemoveObserver(Const.ListenerCount, ResetCount);
    }
    private void OnDisable()
    {
        StopCoroutine(coroutine);
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCountDownText();
        this.LoadTransformParent();
    }

    protected virtual void LoadCountDownText()
    {
        if (this.countDownText != null) return;
        this.countDownText = transform.Find("Mes").GetComponentInChildren<TMP_Text>();
    }
    protected virtual void LoadTransformParent()
    {
        if (this.parent != null) return;
        this.parent = transform.Find("Mes");
    }

    public void StartCountDown()
    {
        countDownCount = countDownStartNumber;
        this.parent.gameObject.SetActive(true);
        coroutine = StartCoroutine(CountDownCo());
    }

    protected IEnumerator CountDownCo()
    {
        countDownText.text = countDownCount.ToString();
        yield return new WaitForSecondsRealtime(1f);
        countDownCount--;
        if (countDownCount >= 0)
        {
            coroutine = StartCoroutine(CountDownCo());
            //GameManager.isPauseGame = false;
            SceneTimeScale.PauseGame();
        }
        else
        {
            this.parent.gameObject.SetActive(false);
            GameManager.isPauseGame = true;
            SceneTimeScale.ContinueGame();
        }
    }

    protected void ResetCount()
    {
        this.parent.gameObject.SetActive(false);
        if (coroutine == null) return;
        StopCoroutine(coroutine);
    }
}
