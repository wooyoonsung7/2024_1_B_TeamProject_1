using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Wave : MonoBehaviour
{
    public static Wave Instance;
    [SerializeField] float waveInterval = 5f; // �߰��� �κ�: ������ ���� �� �ּ� �߰�
    [SerializeField] Text waveText; // �߰��� �κ�: ������ ���� �� �ּ� �߰�
    [SerializeField] Text monsterText; // �߰��� �κ�: ������ ���� �� �ּ� �߰�

    public GameObject[] monster1 = new GameObject[1]; // ������ ��������
    public float[] spawnTime1 = new float[1]; // ���� ���ͻ��� ��, ���� ������������� �ð�

    public GameObject[] monster2 = new GameObject[1]; // ������ ��������
    public float[] spawnTime2 = new float[1]; // ���� ���ͻ��� ��, ���� ������������� �ð�

    public GameObject[] monster3 = new GameObject[1]; // ������ ��������
    public float[] spawnTime3 = new float[1]; // ���� ���ͻ��� ��, ���� ������������� �ð�

    float timer = 0; // �߰��� �κ�: ������ ���� �� �ּ� �߰�
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
                timer = 0; // ������ ���� �� �ּ� �߰�
                if (i < monster1.Length - 1) i++;
                else { i = 0; isEndWave = false; end = false; }
            }
        }
        else if (!end)
        {
            if (timer > 0.7f) //  ������ ���� �� �ּ� �߰�
            {
                monsterText.text = string.Format("���ͼ� : " + monster2.Length + " / " + monster2.Length); //  ������ ���� �� �ּ� �߰�
                W_text(2);
            }
            if (timer >= waveInterval) // ������ ���� �� �ּ� �߰�
            {
                isEndWave1 = true;
                end = true;
            }
        }

        if (isEndWave1)
        {
            if (timer >= spawnTime2[i]) //  ������ ���� �� �ּ� �߰�
            {
                M_text();
                Instantiate(monster2[i], transform.position, Quaternion.identity);
                timer = 0; //  ������ ���� �� �ּ� �߰�
                if (i < monster2.Length - 1) i++;
                else { i = 0; isEndWave1 = false; end2 = false; }
            }
        }
        else if (!end2)
        {
            if (timer > 0.7f) //  ������ ���� �� �ּ� �߰�
            {
                monsterText.text = string.Format("���ͼ� : " + monster3.Length + " / " + monster3.Length); //  ������ ���� �� �ּ� �߰�
                W_text(3);
            }
            if (timer >= waveInterval) //  ������ ���� �� �ּ� �߰�
            {
                isEndWave2 = true;
                end2 = true;
            }
        }

        if (isEndWave2)
        {
            if (timer >= spawnTime3[i]) //  ������ ���� �� �ּ� �߰�
            {
                M_text();
                Instantiate(monster3[i], transform.position, Quaternion.identity);
                timer = 0; // ������ ���� �� �ּ� �߰�
                if (i < monster3.Length - 1) i++;
                else timer = -100; // : ������ ���� �� �ּ� �߰�
            }
        }
    }

    void W_text(int wave)
    {
        if (wave == 1) waveText.text = string.Format(wave + " / 3"); //  ������ ���� �� �ּ� �߰�

        if (wave == 2) waveText.text = string.Format(wave + " / 3"); //  ������ ���� �� �ּ� �߰�

        if (wave == 3) waveText.text = string.Format(wave + " / 3"); //  ������ ���� �� �ּ� �߰�
    }

    void M_text()
    {
        if (isEndWave)
        {
            monsterText.text = string.Format("���ͼ� : " + (monster1.Length - i - 1) + " / " + monster1.Length);
        }

        if (isEndWave1)
        {
            monsterText.text = string.Format("���ͼ� : " + (monster2.Length - i - 1) + " / " + monster2.Length);
        }

        if (isEndWave2)
        {
            monsterText.text = string.Format("���ͼ� : " + (monster3.Length - i - 1) + " / " + monster3.Length);
        }
    }


}
