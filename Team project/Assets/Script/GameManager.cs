using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Transform[] point = new Transform[5];                          // �̵�����Ʈ�迭

    [SerializeField] Text text;
    public float coin = 20;                                               //�ʱ� �����ڱ�
    public float coinRate = 2.5f;                               //���� ��������
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
        //������ ����� ��ŭ ��ġ�� �پ���.
        StartCoroutine(co_timer());
    }
    void Update()
    {
        Debug.Log(coin);
        //���࿡ �غ�ð��� ������ ���� �̶�� �����߰�  +  �پ������� ���� ��ġ���� �ֱ�
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
        //���࿡ ������ ����Ǿ��� ��� �߰�
        StopCoroutine(co_timer());
        yield return new WaitForSecondsRealtime(1f);
    }
}


   


