using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public GameObject[] StartUI = new GameObject[1];

    public GameObject[] INGameUI = new GameObject[3];

    bool isGo = false;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void FixedUpdate()
    {
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "MainScene")
        {
            if (Input.GetKeyDown(KeyCode.Escape)) StartUI[0].SetActive(false);  //시작화면의 옵션나가기
        }
        if (SceneManager.GetActiveScene().name == "1StageSceneGrid" || SceneManager.GetActiveScene().name == "2StageSceneGrid" || SceneManager.GetActiveScene().name == "3StageSceneGrid")
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                INGameUI[1].SetActive(true);  //게임세팅화면 키기 
                Time.timeScale = 0f;
            }
        }

    }

    public void StartGame1()
    {
        isGo = true;
        Time.timeScale = 0f;
        SceneManager.LoadScene("1StageSceneGrid");
    }
    public void StartGame2()
    {
        isGo = true;
        Time.timeScale = 0f;
        SceneManager.LoadScene("2StageSceneGrid");
    }
    public void StartGame3()
    {
        isGo = true;
        Time.timeScale = 0f;
        SceneManager.LoadScene("3StageSceneGrid");
    }
    public void Option()
    {
        StartUI[0].SetActive(true);
    }
    public void ExitGame()
    {
        Application.Quit();
    }

    public void GoToMain()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void GoReady()
    {
        isGo = true;
        Time.timeScale = 0f;
        INGameUI[0].SetActive(true);
    }
    public void EndReady()
    {
        isGo = false;
        Time.timeScale = 1f;
        INGameUI[0].SetActive(false);
    }

    public void GotoSetting()
    {
        INGameUI[1].SetActive(true);
        Time.timeScale = 0f;
    }
    public void EndSetting()
    {
        INGameUI[1].SetActive(false);
        if (isGo == true)
        {
            Time.timeScale = 0f;
        }
        else { Time.timeScale = 1f; }
    }
    public void ClearStage()
    {
        INGameUI[2].SetActive(true);
    }
    public void GameOver()
    {
        INGameUI[3].SetActive(true);
    }
}
