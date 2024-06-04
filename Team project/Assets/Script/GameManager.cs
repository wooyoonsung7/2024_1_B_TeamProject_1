using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Transform[] point = new Transform[5];                          // 이동포인트배열

    [SerializeField] Text text;
    public float coin = 20;                                               //초기 지원자금
    public float coinRate = 2.5f;                               //코인 증가비율
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        //코인을 사용한 만큼 수치가 줄어든다.
        StartCoroutine(co_timer());
    }
    void Update()
    {
        Debug.Log(coin);
        //만약에 준비시간이 끝나고 나면 이라는 조건추가  +  줄어들고나서의 코인 수치값을 넣기
        //StartCoroutine(co_timer(20, 3));
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


   


