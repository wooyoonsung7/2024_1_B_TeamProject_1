using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Wave : MonoBehaviour
{
    public static Wave Instance;

    [SerializeField] float W_inteval = 5f;
    [SerializeField] Text w_text;
    [SerializeField] Text m_text;

    public GameObject[] monster1 = new GameObject[1];             //생성할 몬스터지정
    public float[] spawnTime1 = new float[1];                     //이전 몬스터생성 후, 다음 몬스토생성까지의 시간

    public GameObject[] monster2 = new GameObject[1];             //생성할 몬스터지정
    public float[] spawnTime2 = new float[1];                     //이전 몬스터생성 후, 다음 몬스토생성까지의 시간

    public GameObject[] monster3 = new GameObject[1];             //생성할 몬스터지정
    public float[] spawnTime3 = new float[1];                     //이전 몬스터생성 후, 다음 몬스토생성까지의 시간
    float Timer = 0;
    int i = 0;
    bool isEndWave = true;
    bool isEndWave1 = false;
    bool isEndWave2 = false;

    bool end = true;
    bool end2 = true;

    private void Awake()
    {
        Instance = this;
    }
    void Update()
    {
        Timer += Time.deltaTime;
        OnWave();
    }

    void OnWave()                                                                  //웨이브시스템 
    {
        if (isEndWave)
        {

            if (Timer >= spawnTime1[i])
            {
                M_text();
                Instantiate(monster1[i], transform.position, Quaternion.identity);
                Timer = 0;
                if (i < monster1.Length - 1) i++;
                else
                { i = 0; isEndWave = false; end = false; }
            }
        }
        else if (!end)
        {
            if (Timer > 0.7f)
            {
                m_text.text = string.Format("몬스터수 : " + monster2.Length + " / " + monster2.Length);
                W_text(2);
            }
            if (Timer >= W_inteval)
            {
                isEndWave1 = true;
                end = true;
            }
        }

        if (isEndWave1)
        {
            if (Timer >= spawnTime2[i])
            {
                M_text();
                Instantiate(monster2[i], transform.position, Quaternion.identity);
                Timer = 0;
                if (i < monster2.Length - 1) i++;
                else
                { i = 0; isEndWave1 = false; end2 = false; }
            }
        }
        else if (!end2)
        {
            if (Timer > 0.7f)
            {
                m_text.text = string.Format("몬스터수 : " + monster3.Length + " / " + monster3.Length);
                W_text(3);
            }
            if (Timer >= W_inteval)
            {
                isEndWave2 = true;
                end2 = true;
            }
        }

        if (isEndWave2)
        {
            if (Timer >= spawnTime3[i])
            {
                M_text();
                Instantiate(monster3[i], transform.position, Quaternion.identity);
                Timer = 0;
                if (i < monster3.Length - 1) i++;
                else
                    Timer = -100;
            }
        }
    }
    void W_text(int wave)
    {
        if (wave == 1) w_text.text = string.Format(wave + " / 3");

        if (wave == 2) w_text.text = string.Format(wave + " / 3");

        if (wave == 3) w_text.text = string.Format(wave + " / 3");
    }
    void M_text()
    {
        if (isEndWave)
        {
            m_text.text = string.Format("몬스터수 : " + (monster1.Length - i - 1) + " / " + monster1.Length);
        }

        if (isEndWave1)
        {
            m_text.text = string.Format("몬스터수 : " + (monster2.Length - i - 1) + " / " + monster2.Length);
        }

        if (isEndWave2)
        {
            m_text.text = string.Format("몬스터수 : " + (monster3.Length - i - 1) + " / " + monster3.Length);
        }
    }
    public void End()
    {

        Debug.Log("된다2");

        if (UIManager.Instance.INGameUI[2] != null)
        {
            UIManager.Instance.ClearStage();
        }
        if (SceneManager.GetActiveScene().name == "3StageSceneGrid")
        {
            SceneManager.LoadScene("ClearScene");
        }

    }
}
