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

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        StartCoroutine(co_timer());
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
    IEnumerator Stop_timer()
    {
        //만약에 게임이 종료되었을 경우 추가
        StopCoroutine(co_timer());
        yield return new WaitForSecondsRealtime(1f);
    }
}

