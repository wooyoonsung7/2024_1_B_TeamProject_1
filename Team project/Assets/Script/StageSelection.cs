using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageSelection : MonoBehaviour
{
    //public string[] StageList = new string[30];
    public Button[] buttons;

    /*private void Start()
    {
        AddListener();
    }

    public void AddListener()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            if (buttons[i] == null)
            {
                return;
            }
            int j = i + 1;
            buttons[i].onClick.AddListener(()=>StartStage(j));
            Debug.Log(buttons[i].name);
        }
    }*/

    private void Awake()
    {   // UnlockedStage Ű�� GameManager ���� SetInt ��
        int unlockedStage = PlayerPrefs.GetInt("UnlockedStage", 1);     // �رݵ� �������� ���� �ҷ��´� (���ٸ� 1�� ��ȯ(ó���� 1���������� �رݵǾ� �־�� �ϴϱ�))
        for (int i = 0; i < buttons.Length; i++)    // ��ư ���� ��ŭ �ݺ�
        {
            buttons[i].interactable = false;    // �ϴ� ��ư�� �� ��Ȱ��ȭ ��Ű��
        }
        for (int i = 0; i < unlockedStage; i++)     // �رݵ� ��ư ������ �ݺ�
        {
            buttons[i].interactable = true;     // ��ư ��ȣ�ۿ� Ȱ��ȭ
        }
    }

    public void OnClickBack()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void LoadStage(int stageNum)
    {
        string stageName = "Stage " + stageNum;     // �� �̸� �ٲٸ� �ٲ������
        SceneManager.LoadScene(stageName);
    }
}
