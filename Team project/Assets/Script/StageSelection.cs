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
    {   // UnlockedStage 키는 GameManager 에서 SetInt 함
        int unlockedStage = PlayerPrefs.GetInt("UnlockedStage", 1);     // 해금된 스테이지 수를 불러온다 (없다면 1을 반환(처음에 1스테이지는 해금되어 있어야 하니까))
        for (int i = 0; i < buttons.Length; i++)    // 버튼 개수 만큼 반복
        {
            buttons[i].interactable = false;    // 일단 버튼을 다 비활성화 시키고
        }
        for (int i = 0; i < unlockedStage; i++)     // 해금된 버튼 까지만 반복
        {
            buttons[i].interactable = true;     // 버튼 상호작용 활성화
        }
    }

    public void OnClickBack()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void LoadStage(int stageNum)
    {
        string stageName = "Stage " + stageNum;     // 씬 이름 바꾸면 바꿔줘야함
        SceneManager.LoadScene(stageName);
    }
}
