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
    {
        int unlockedStage = PlayerPrefs.GetInt("UnlockedStage", 1);
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
        }
        for (int i = 0; i < unlockedStage; i++)
        {
            buttons[i].interactable = true;
        }
    }

    public void OnClickBack()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void LoadStage(int stageNum)
    {
        string stageName = "Stage " + stageNum;
        SceneManager.LoadScene(stageName);
    }
}
