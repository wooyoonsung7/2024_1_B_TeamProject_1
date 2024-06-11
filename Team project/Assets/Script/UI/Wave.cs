using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Wave : MonoBehaviour
{
    public static Wave Instance;
    [SerializeField] float waveInterval = 5f; // 추가된 부분: 변수명 변경 및 주석 추가
    [SerializeField] Text waveText; // 추가된 부분: 변수명 변경 및 주석 추가
    [SerializeField] Text monsterText; // 추가된 부분: 변수명 변경 및 주석 추가

    public GameObject[] monster1 = new GameObject[1]; // 생성할 몬스터지정
    public float[] spawnTime1 = new float[1]; // 이전 몬스터생성 후, 다음 몬스토생성까지의 시간

    public GameObject[] monster2 = new GameObject[1]; // 생성할 몬스터지정
    public float[] spawnTime2 = new float[1]; // 이전 몬스터생성 후, 다음 몬스토생성까지의 시간

    public GameObject[] monster3 = new GameObject[1]; // 생성할 몬스터지정
    public float[] spawnTime3 = new float[1]; // 이전 몬스터생성 후, 다음 몬스토생성까지의 시간

    float timer = 0; // 추가된 부분: 변수명 변경 및 주석 추가
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
        timer += Time.deltaTime; 
        OnWave();
    }

    void OnWave() 
    {
        if (isEndWave)
        {
            if (timer >= spawnTime1[i]) 
            {
                M_text();
                Instantiate(monster1[i], transform.position, Quaternion.identity);
                timer = 0; // 변수명 변경 및 주석 추가
                if (i < monster1.Length - 1) i++;
                else { i = 0; isEndWave = false; end = false; }
            }
        }
        else if (!end)
        {
            if (timer > 0.7f) //  변수명 변경 및 주석 추가
            {
                monsterText.text = string.Format("몬스터수 : " + monster2.Length + " / " + monster2.Length); //  변수명 변경 및 주석 추가
                W_text(2);
            }
            if (timer >= waveInterval) // 변수명 변경 및 주석 추가
            {
                isEndWave1 = true;
                end = true;
            }
        }

        if (isEndWave1)
        {
            if (timer >= spawnTime2[i]) //  변수명 변경 및 주석 추가
            {
                M_text();
                Instantiate(monster2[i], transform.position, Quaternion.identity);
                timer = 0; //  변수명 변경 및 주석 추가
                if (i < monster2.Length - 1) i++;
                else { i = 0; isEndWave1 = false; end2 = false; }
            }
        }
        else if (!end2)
        {
            if (timer > 0.7f) //  변수명 변경 및 주석 추가
            {
                monsterText.text = string.Format("몬스터수 : " + monster3.Length + " / " + monster3.Length); //  변수명 변경 및 주석 추가
                W_text(3);
            }
            if (timer >= waveInterval) //  변수명 변경 및 주석 추가
            {
                isEndWave2 = true;
                end2 = true;
            }
        }

        if (isEndWave2)
        {
            if (timer >= spawnTime3[i]) //  변수명 변경 및 주석 추가
            {
                M_text();
                Instantiate(monster3[i], transform.position, Quaternion.identity);
                timer = 0; // 변수명 변경 및 주석 추가
                if (i < monster3.Length - 1) i++;
                else timer = -100; // : 변수명 변경 및 주석 추가
            }
        }
    }

    void W_text(int wave)
    {
        if (wave == 1) waveText.text = string.Format(wave + " / 3"); //  변수명 변경 및 주석 추가

        if (wave == 2) waveText.text = string.Format(wave + " / 3"); //  변수명 변경 및 주석 추가

        if (wave == 3) waveText.text = string.Format(wave + " / 3"); //  변수명 변경 및 주석 추가
    }

    void M_text()
    {
        if (isEndWave)
        {
            monsterText.text = string.Format("몬스터수 : " + (monster1.Length - i - 1) + " / " + monster1.Length);
        }

        if (isEndWave1)
        {
            monsterText.text = string.Format("몬스터수 : " + (monster2.Length - i - 1) + " / " + monster2.Length);
        }

        if (isEndWave2)
        {
            monsterText.text = string.Format("몬스터수 : " + (monster3.Length - i - 1) + " / " + monster3.Length);
        }
    }


}
