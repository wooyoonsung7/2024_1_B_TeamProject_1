using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinSystem : MonoBehaviour
{
    public static CoinSystem Instance;

    [SerializeField] Text text;
    public float coin = 20;                                      //초기 지원자금
    public float coinRate = 3f;                                  //코인 증가비율

    Coroutine co_Coin;

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
       co_Coin = StartCoroutine(co_timer());
    }
    private void Update()
    {

    }

    IEnumerator co_timer()
    {
        while (true)
        {
            coin += coinRate;
            text.text = string.Format("{0:#,#}", Mathf.Round(coin));

            yield return new WaitForSeconds(1f);

        }
    }

    public  void EndCoin()
    {
        StartCoroutine (Stop_timer());
    }
    IEnumerator Stop_timer()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        StopCoroutine(co_Coin);
    }
}

